# MonoTouch.Fabric

This is a Xamarin.iOS Unified binding project for Fabric 1.2.8, with support for:
* Crashlytics 3.1.0
* DigitsKit 1.9.0
* MoPub 3.8.0
* TwitterKit 1.9.0

Other kits might be added in the future.

## Crashlytics
Before you can start receiving crash reports, distributing beta builds or collecting analytics from your app, you will have to create an empty Xcode project with the same bundle identifier as the one for your Xamarin app.  Then, use the Fabric Mac app to add your app and complete the Crashlytics on-boarding process. 

Your Xamarin project will have to reference
* MonoTouch.Fabric
* MonoTouch.Fabric.Crashlytics

In AppDelegate.cs, add Crashlytics initialization code to FinishedLaunching() and make sure it precedes any other startup code:

```c#
		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			Setup.EnableCrashReporting(() =>
				{
					var crashlytics = Crashlytics.SharedInstance;
					crashlytics.DebugMode = true;
					Crashlytics.StartWithAPIKey("replace_with_your_crashlytics_api_key");

					Fabric.With(new NSObject[]{ crashlytics });

					AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
					{
						Setup.CaptureManagedInfo(e.ExceptionObject);
						Setup.CaptureStackFrames(e.ExceptionObject);
						Setup.ThrowExceptionAsNative(e.ExceptionObject);
					};

					TaskScheduler.UnobservedTaskException += (sender, e) =>
					{
						Setup.CaptureManagedInfo(e.Exception);
						Setup.CaptureStackFrames(e.Exception);
						Setup.ThrowExceptionAsNative(e.Exception);
					};
				}, Path.GetFileNameWithoutExtension(typeof(AppDelegate).Module.Name));

			return true;
		}
```

Now, we'll have to add a post-build script to upload your dSYMs automatically.  Without a valid dSYM, crash reports will not appear on your Crashlytics dashboard.  Please note that Xamarin does not generate dSYMs for simulator builds.  This means you will not be able to receive any crash reports for simulator builds.  Optionally, you can use a define symbol to only initialize Crashlytics for device builds.  Refer to this [post](https://forums.xamarin.com/discussion/comment/132204/#Comment_132204) and the Crashlytics sample app for more information.

By default, filenames and line numbers are not available for release build crash reports.  If app size is not an issue for you, you can package .mdb files with your app by adding "--package-mdb" to the additional mtouch arguments in the project's iOS Build options.  Refer to this [bugzilla bug report](https://bugzilla.xamarin.com/show_bug.cgi?id=3357) for more information.

### Beta distribution
Use the Fabric Mac app to upload your archives.

Refer to [Crashlytics documentation](https://docs.fabric.io/ios/crashlytics/index.html) and the Crashlytics sample app for more information on how to use this kit.

## DigitsKit
Create an empty Xcode project.  Then, use the Fabric Mac app to add your app and complete the Digits on-boarding process. This will generate a consumer key and a consumer key secret which you will need to provide during initialization.

Your Xamarin project will have to reference
* MonoTouch.Fabric
* MonoTouch.Fabric.DigitsKit
* MonoTouch.Fabric.TwitterCore

Before initializing DigitsKit, you will have to make changes to Info.plist.  Add a Dictionary key named 'Fabric'.  Add a String sub-key named 'APIKey' and copy your api key to it.  <b>Failure to do so will result in your app crashing.</b>

In AppDelegate.cs, add Digits initialization code to FinishedLaunching():
```c#
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            var digitsKit = Digits.SharedInstance;
            digitsKit.StartWithConsumerKey("replace_with_your_consumer_key", 
            	"replace_with_your_consumer_secret");

            Fabric.With(new NSObject[]{ digitsKit });

            return true;
        }
```
Refer to [Digits documentation](https://docs.fabric.io/ios/digits/index.html) and the DigitsKit sample app for more information on how to use this kit.

## MoPub
Completely untested.  Use at your own risk.
Refer to [MoPub documentation](https://dev.twitter.com/mopub/ios) for more information on how to use this kit.

## TwitterKit
Create an empty Xcode project.  Then, use the Fabric Mac app to add your app and complete the Twitter on-boarding process. This will generate a consumer key and a consumer key secret which you will need to provide during initialization.

Your Xamarin project will have to reference
* MonoTouch.Fabric
* MonoTouch.Fabric.TwitterCore
* MonoTouch.Fabric.TwitterKit

Before initializing TwitterKit, you will have to make changes to Info.plist.  Add a Dictionary key named 'Fabric'.  Add a String sub-key named 'APIKey' and copy your api key to it.  <b>Failure to do so will result in your app crashing.</b>

In AppDelegate.cs, add Twitter initialization code to FinishedLaunching():
```c#
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            var twitterKit = MonoTouch.Fabric.TwitterKit.Twitter.SharedInstance;
            twitterKit.StartWithConsumerKey("replace_with_your_consumer_key", 
                "replace_with_your_consumer_secret");

            Fabric.With(new NSObject[]{ twitterKit });

            return true;
        }
```
Refer to [Twitter documentation](https://docs.fabric.io/ios/twitter/index.html) and the TwitterKit sample app for more information on how to use this kit.
