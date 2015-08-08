using System;
using System.Runtime.InteropServices;

namespace MonoTouch.Crashlytics
{
	static class CFunctions
	{
		// extern void CLSLog (NSString * format, ...);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CLSLog (string format, IntPtr varArgs);

		// extern void CLSLogv (NSString * format, va_list ap);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern unsafe void CLSLogv (string format, sbyte* ap);

		// extern void CLSNSLog (NSString * format, ...);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CLSNSLog (string format, IntPtr varArgs);

		// extern void CLSNSLogv (NSString * format, va_list ap);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern unsafe void CLSNSLogv (string format, sbyte* ap);
	}
}