using System;
using System.Linq;
using Foundation;
using MonoTouch.Fabric.Crashlytics;
using ObjCRuntime;
using System.Collections.Generic;

namespace MonoTouch.Fabric
{
    public partial class Fabric
    {
        public static void InitializeFramework(NSObject[] kits, bool enableDebugging = true)
        {
            InitializeFramework(kits, null, enableDebugging);
        }

        public CrashlyticsManager CrashlyticsManager { get; private set; }

        public static Fabric With(NSObject[] kits)
        {
            Log("[MonoTouch.Fabric] Initialized using legacy With() method.  Consider using the approach described at https://github.com/joeisapro/MonoTouch.Fabric", true);
            return WithInternal(kits);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static void InitializeFramework(NSObject[] kits, CrashlyticsManager crashlyticsManager, bool enableDebugging = true)
        {
            if (kits == null)
                throw new ArgumentNullException("kits");
            
            SharedSDK().Debug = enableDebugging;

            if (crashlyticsManager != null)
            {
                SharedSDK().CrashlyticsManager = crashlyticsManager;

                //only initialize Crashlytics with device builds since Xamarin.iOS 
                //doesn't generate dSYM files for simulator builds
                if (Runtime.Arch == Arch.DEVICE)
                {
                    Log(GetKitInitializationMessage(kits));
                    crashlyticsManager.EnableCrashReporting(() => Fabric.WithInternal(kits));
                }
                else
                {
                    Log("[MonoTouch.Fabric] Running on simulator: Crashlytics will not be enabled and crash reports will not be submitted", true);
                    var otherKits = RemoveKit(kits, crashlyticsManager.SharedInstance);
                    if (otherKits.Length > 0)
                    {
                        Log(GetKitInitializationMessage(otherKits));
                        Fabric.WithInternal(otherKits);
                    }
                }
            }
            else
            {
                Log(GetKitInitializationMessage(kits));
                Fabric.WithInternal(kits);
            }
        }

        private static NSObject[] RemoveKit(NSObject[] kits, NSObject kit)
        {
            var tmpKits = new List<NSObject>(kits);
            if (tmpKits.Contains(kit))
            {
                tmpKits.Remove(kit);
                return tmpKits.ToArray();
            }

            return kits;
        }

        public static void Log(string message, bool alwaysLog = false)
        {
            if (SharedSDK().Debug || alwaysLog)
                Console.WriteLine(message);
        }

        private static string GetKitInitializationMessage(NSObject[] kits)
        {
            var numkits = kits.Length + 1;
            return string.Format("[MonoTouch.Fabric] {0} kit{1} {2} about to be initialized", 
                numkits, numkits > 1 ? "s" : "", numkits > 1 ? "are" : "is");
        }
    }
}

