using Foundation;
using ObjCRuntime;

namespace MonoTouch.Fabric
{
	// @interface Fabric : NSObject
	[BaseType (typeof(NSObject))]
	interface Fabric
	{
		// +(instancetype)with:(NSArray *)kits;
		[Static]
		[Export ("with:")]
		//[Verify (StronglyTypedNSArray)]
		Fabric With (NSObject[] kits);

		// +(instancetype)sharedSDK;
		[Static]
		[Export ("sharedSDK")]
		Fabric SharedSDK ();

		// @property (assign, nonatomic) BOOL debug;
		[Export ("debug")]
		bool Debug { get; set; }

		// -(id)kitForClass:(Class)klass;
		[Export ("kitForClass:")]
		NSObject KitForClass (Class klass);

		// -(NSDictionary *)configurationDictionaryForKit:(id)kitInstance;
		[Export ("configurationDictionaryForKit:")]
		NSDictionary ConfigurationDictionaryForKit (NSObject kitInstance);
	}
}

