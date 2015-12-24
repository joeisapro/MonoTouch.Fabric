using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace MonoTouch.Fabric.Crashlytics
{
	public class Setup
	{
		private enum Signal
		{
			SIGBUS = 10,
			SIGSEGV
		}

		private static string Library = "";

		[DllImport("libc")]
		private static extern int sigaction(Setup.Signal sig, IntPtr act, IntPtr oact);

		[DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern void void_objc_msgSend(IntPtr receiver, IntPtr selector);

		public static void EnableCrashReporting(Action crashReportingDelegate, string library)
		{
			Library = library;

			IntPtr sigbus = Marshal.AllocHGlobal(512);
			IntPtr sigsev = Marshal.AllocHGlobal(512);

			//store handlers
			Setup.sigaction(Setup.Signal.SIGBUS, IntPtr.Zero, sigbus);
			Setup.sigaction(Setup.Signal.SIGSEGV, IntPtr.Zero, sigsev);

			//setup crash reporting
			crashReportingDelegate();

			//restore handlers
			Setup.sigaction(Setup.Signal.SIGBUS, sigbus, IntPtr.Zero);
			Setup.sigaction(Setup.Signal.SIGSEGV, sigsev, IntPtr.Zero);

			Marshal.FreeHGlobal(sigbus);
			Marshal.FreeHGlobal(sigsev);
		}

		public static void ThrowExceptionAsNative(Exception exception)
		{
			Setup.ConvertToNativeExceptionAndRaise(exception);
		}

		public static void ThrowExceptionAsNative(object exception)
		{
			Setup.ConvertToNativeExceptionAndRaise(exception);
		}

		public static void CaptureManagedInfo(object exception)
		{
			Crashlytics.SharedInstance.SetObjectValue(new NSString(Constants.Version), "monotouch version");

			Exception ex = exception as Exception;

			if (ex != null)
			{
				Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.StackTrace), "unhandled exception stack trace");
				Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.Message), "unhandled exception message");
				Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.GetType().FullName), "unhandled exception");
			}
		}

		public static void CaptureStackFrames(object exception)
		{
			var frames = new List<CLSStackFrame>();
			Exception ex = exception as Exception;

			Action<StackTrace> frameWalker = (st) =>
			{
				for (int i = 0; i < st.FrameCount; i++)
				{
					StackFrame sf = st.GetFrame(i);

					string filename = sf.GetFileName();
					System.Reflection.MethodBase method = sf.GetMethod();

					string methodName = "";
					if (method != null)
					{
						var tokens = method.ToString().Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);

						if (tokens.Count() > 1)
							methodName = tokens.Skip(1).Aggregate((a, b) => a + " " + b);
						else
							methodName = method.ToString();
					}

					frames.Add(new CLSStackFrame()
						{
							FileName = filename ?? (method != null ? method.DeclaringType.Name + ".cs" : "uknown"),
							LineNumber = (uint)sf.GetFileLineNumber(),
							Library = Library,
							Symbol = method != null ? method.DeclaringType.FullName + "." + methodName : "wrapper_managed_to_native"
						});
				}
			};    

			if (ex != null)
			{
				//get traces from excetion dispath info - their are not included in StackTrace on mono
				StackTrace[] traces = null;
				var fi = typeof(Exception).GetField("captured_traces", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
				if (fi != null)
					traces = fi.GetValue(ex) as StackTrace[];

				if (traces != null)
					foreach (var st in traces)
						frameWalker(st);

				frameWalker(new StackTrace(ex, true));

				Crashlytics.SharedInstance.RecordCustomExceptionName(ex.GetType().Name, ex.Message, frames.Cast<NSObject>().ToArray());
			}
		}

		private static void ConvertToNativeExceptionAndRaise(object e)
		{
			string name = "Managed Exception";
			string reason = e.ToString();
			Exception ex = e as Exception;

			if (ex != null)
			{
				string file = "Unknown file";
				string line = "???";

				try
				{
					if (!string.IsNullOrEmpty(reason))
					{
						string buf = reason;
						buf = buf.Replace(ex.Message, "");
						buf = buf.Replace(ex.GetType().FullName, "");
						var pos = buf.IndexOf(" in ");
						var pos2 = buf.IndexOf(".cs", pos);

						file = buf.Substring(pos + 4, pos2 + 3 - (pos + 4));

						file = Path.GetFileName(file);
						int i = pos2 + 4;
						string line2 = "";
						char tmp = reason[i];
						while ("0123456789".Contains(buf[i].ToString()) && i < buf.Length)
							line2 += buf[i++];

						line = line2;
					}
				}
				catch
				{
				}

				name = string.Format("{0}: {1} - {2} line {3}", ex.GetType().FullName, ex.Message, file, line);
			}

			name = name.Replace("%", "%%");
			reason = reason.Replace("%", "%%");

			NSException nsex = new NSException(name, reason, null);
			Selector selector = new Selector("raise");
			void_objc_msgSend(nsex.Handle, selector.Handle);
		}
	}
}

