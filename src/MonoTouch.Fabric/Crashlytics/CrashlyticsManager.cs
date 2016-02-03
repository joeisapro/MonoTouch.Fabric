using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Foundation;

namespace MonoTouch.Fabric.Crashlytics
{
    public abstract class CrashlyticsManager: NSObject
    {
        private bool errorReportingEnabled;

        private enum Signal
        {
            SIGBUS = 10,
            SIGSEGV = 11
        }

        [DllImport("libc")]
        private static extern int sigaction(Signal sig, IntPtr act, IntPtr oact);

        public abstract void OnExceptionCaught(Exception ex);

        public virtual bool CatchUnhandledExceptions { get; set; }

        public virtual bool CatchUnobservedTaskExceptions { get; set; }

        public abstract NSObject SharedInstance { get; }

        internal void EnableCrashReporting(Action fabricInitializationCode)
        {
            if (errorReportingEnabled)
            {
                Fabric.Log("[MonoTouch.Fabric.Crashlytics] Crash reporting has already been enabled, ignoring duplicate call.");
                return;
            }

            IntPtr sigbus = Marshal.AllocHGlobal(512);
            IntPtr sigsev = Marshal.AllocHGlobal(512);
            //IntPtr sigabrt = Marshal.AllocHGlobal(512);

            //store handlers
            sigaction(Signal.SIGBUS, IntPtr.Zero, sigbus);
            sigaction(Signal.SIGSEGV, IntPtr.Zero, sigsev);

            fabricInitializationCode();

            //setup crash reporting
            if (CatchUnhandledExceptions)
                AppDomain.CurrentDomain.UnhandledException += (sender, e) => OnExceptionCaught(e.ExceptionObject as Exception);

            if (CatchUnobservedTaskExceptions)
                TaskScheduler.UnobservedTaskException += (sender, e) => OnExceptionCaught(e.Exception);

            //restore handlers
            sigaction(Signal.SIGBUS, sigbus, IntPtr.Zero);
            sigaction(Signal.SIGSEGV, sigsev, IntPtr.Zero);

            Marshal.FreeHGlobal(sigbus);
            Marshal.FreeHGlobal(sigsev);

            errorReportingEnabled = true;
        }
    }
}