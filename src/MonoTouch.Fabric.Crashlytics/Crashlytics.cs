using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace MonoTouch.Fabric.Crashlytics
{
    
    public partial class Crashlytics
    {
        // extern void CLSLog (NSString * format, ...);
        [DllImport("__Internal", EntryPoint = "CLSLog")]
        //[Verify (PlatformInvoke)]
        internal static extern void __CLSLog(IntPtr format, string arg0);

        // extern void CLSLog (NSString * format, ...);
        [DllImport("__Internal", EntryPoint = "CLSLog")]
        //[Verify (PlatformInvoke)]
        internal static extern void __CLSLog_arm64(IntPtr format, IntPtr dummy1, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, string arg0);

        // extern void CLSLogv (NSString * format, va_list ap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
		internal static extern unsafe void CLSLogv(IntPtr format, sbyte* ap);

        // extern void CLSNSLog (NSString * format, ...);
        [DllImport("__Internal", EntryPoint = "CLSNSLog")]
        //[Verify (PlatformInvoke)]
		internal static extern void __CLSNSLog(IntPtr format, string arg0);

        // extern void CLSNSLog (NSString * format, ...);
        [DllImport("__Internal", EntryPoint = "CLSNSLog")]
        //[Verify (PlatformInvoke)]
        internal static extern void __CLSNSLog_arm64(IntPtr format, IntPtr dummy1, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, string arg0);

        // extern void CLSNSLogv (NSString * format, va_list ap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
		internal static extern unsafe void CLSNSLogv(IntPtr format, sbyte* ap);

        public static void CLSLog(string format, params object[] arg)
        {
            using (var nsFormat = new NSString(string.Format(format, arg)))
                if (Runtime.Arch == Arch.DEVICE && IntPtr.Size == 8)
                    __CLSLog_arm64(nsFormat.Handle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "");
                else
                    __CLSLog(nsFormat.Handle, "");
        }

        public static void CLSNSLog(string format, params object[] arg)
        {
            using (var nsFormat = new NSString(string.Format(format, arg)))
                if (Runtime.Arch == Arch.DEVICE && IntPtr.Size == 8)
                    __CLSNSLog_arm64(nsFormat.Handle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "");
                else
                    __CLSNSLog(nsFormat.Handle, "");
        } 
    }
        
}