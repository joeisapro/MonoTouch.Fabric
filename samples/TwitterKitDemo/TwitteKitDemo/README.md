Before running the sample app, make sure you compile the bindings solution and reference the proper binaries for this sample app:

* MonoTouch.Fabric
* MonoTouch.Fabric.TwitterKit
* MonoTouch.Fabric.TwitterCore

You also need to update info.plist with your own fabric api key, as well as use your own consumerkey/consumersecret in AppDelegate.FinishedLaunching().

You might get an exception at launch, from time to time, saying TwitterKitResources.bundle is missing.  A full clean and rebuild will get rid of it.
