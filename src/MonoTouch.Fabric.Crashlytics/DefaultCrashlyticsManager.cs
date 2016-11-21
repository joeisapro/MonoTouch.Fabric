using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace MonoTouch.Fabric.Crashlytics
{
    public class DefaultCrashlyticsManager: CrashlyticsManager
    {
        [DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        private static extern void void_objc_msgSend(IntPtr receiver, IntPtr selector);

        public DefaultCrashlyticsManager()
        {
            CatchUnhandledExceptions = true;
            CatchUnobservedTaskExceptions = true;
            RethrowException = false;
        }

        public override void OnExceptionCaught(Exception ex)
        {
            CaptureManagedInfo(ex);
            CaptureStackFrames(ex);

            if (RethrowException)
                RaiseNativeException(ex);
        }

        public override NSObject SharedInstance { get { return Crashlytics.SharedInstance; } }
        public bool RethrowException { get; set; }

        protected virtual void CaptureManagedInfo(Exception ex)
        {
            Crashlytics.SharedInstance.SetObjectValue(new NSString(Constants.Version), "monotouch version");
        
            if (ex != null)
            {
				if (!string.IsNullOrWhiteSpace(ex.StackTrace))
                	Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.StackTrace), "unhandled exception stack trace");
				
                Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.Message), "unhandled exception message");
                Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.GetType().FullName), "unhandled exception");
            }
        }

        protected virtual void CaptureStackFrames(Exception ex)
        {
            var frames = new List<CLSStackFrame>();
        
            Action<StackTrace> frameWalker = (st) =>
            {
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
        
                    string filename = sf.GetFileName();
                    MethodBase method = sf.GetMethod();
        
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
                            Symbol = method != null ? method.DeclaringType.FullName + "." + methodName : "wrapper_managed_to_native"
                        });
                }
            };    
        
            if (ex != null)
            {
                //get traces from exception dispath info - they're are not included in StackTrace on mono
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

        protected virtual void RaiseNativeException(Exception ex)
        {
            string name = "Managed Exception";
            string reason = "???";
        
            NSException nsex = new NSException(name, reason, null);
            Selector selector = new Selector("raise");
            void_objc_msgSend(nsex.Handle, selector.Handle);
        }
    }
}