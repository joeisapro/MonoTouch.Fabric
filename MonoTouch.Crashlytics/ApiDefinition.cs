using System;
using Foundation;
using ObjCRuntime;

namespace MonoTouch.Crashlytics
{
	// @protocol CLSCrashReport <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface CLSCrashReport
	{
		// @required @property (readonly, copy, nonatomic) NSString * identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @required @property (readonly, copy, nonatomic) NSDictionary * customKeys;
		[Export ("customKeys", ArgumentSemantic.Copy)]
		NSDictionary CustomKeys { get; }

		// @required @property (readonly, copy, nonatomic) NSString * bundleVersion;
		[Export ("bundleVersion")]
		string BundleVersion { get; }

		// @required @property (readonly, copy, nonatomic) NSString * bundleShortVersionString;
		[Export ("bundleShortVersionString")]
		string BundleShortVersionString { get; }

		// @required @property (readonly, copy, nonatomic) NSDate * crashedOnDate;
		[Export ("crashedOnDate", ArgumentSemantic.Copy)]
		NSDate CrashedOnDate { get; }

		// @required @property (readonly, copy, nonatomic) NSString * OSVersion;
		[Export ("OSVersion")]
		string OSVersion { get; }

		// @required @property (readonly, copy, nonatomic) NSString * OSBuildVersion;
		[Export ("OSBuildVersion")]
		string OSBuildVersion { get; }
	}

	public interface ICLSCrashReport
	{

	}

	// @interface CLSReport : NSObject <CLSCrashReport>
	[BaseType (typeof(NSObject))]
	interface CLSReport : ICLSCrashReport
	{
		// @property (readonly, copy, nonatomic) NSString * identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * customKeys;
		[Export ("customKeys", ArgumentSemantic.Copy)]
		NSDictionary CustomKeys { get; }

		// @property (readonly, copy, nonatomic) NSString * bundleVersion;
		[Export ("bundleVersion")]
		string BundleVersion { get; }

		// @property (readonly, copy, nonatomic) NSString * bundleShortVersionString;
		[Export ("bundleShortVersionString")]
		string BundleShortVersionString { get; }

		// @property (readonly, copy, nonatomic) NSDate * dateCreated;
		[Export ("dateCreated", ArgumentSemantic.Copy)]
		NSDate DateCreated { get; }

		// @property (readonly, copy, nonatomic) NSString * OSVersion;
		[Export ("OSVersion")]
		string OSVersion { get; }

		// @property (readonly, copy, nonatomic) NSString * OSBuildVersion;
		[Export ("OSBuildVersion")]
		string OSBuildVersion { get; }

		// @property (readonly, assign, nonatomic) BOOL isCrash;
		[Export ("isCrash")]
		bool IsCrash { get; }

		// -(void)setObjectValue:(id)value forKey:(NSString *)key;
		[Export ("setObjectValue:forKey:")]
		void SetObjectValue (NSObject value, string key);

		// @property (copy, nonatomic) NSString * userIdentifier;
		[Export ("userIdentifier")]
		string UserIdentifier { get; set; }

		// @property (copy, nonatomic) NSString * userName;
		[Export ("userName")]
		string UserName { get; set; }

		// @property (copy, nonatomic) NSString * userEmail;
		[Export ("userEmail")]
		string UserEmail { get; set; }
	}

	// @interface CLSStackFrame : NSObject
	[BaseType (typeof(NSObject))]
	interface CLSStackFrame
	{
		// +(instancetype)stackFrame;
		[Static]
		[Export ("stackFrame")]
		CLSStackFrame StackFrame ();

		// +(instancetype)stackFrameWithAddress:(NSUInteger)address;
		[Static]
		[Export ("stackFrameWithAddress:")]
		CLSStackFrame StackFrameWithAddress (nuint address);

		// +(instancetype)stackFrameWithSymbol:(NSString *)symbol;
		[Static]
		[Export ("stackFrameWithSymbol:")]
		CLSStackFrame StackFrameWithSymbol (string symbol);

		// @property (copy, nonatomic) NSString * symbol;
		[Export ("symbol")]
		string Symbol { get; set; }

		// @property (copy, nonatomic) NSString * library;
		[Export ("library")]
		string Library { get; set; }

		// @property (copy, nonatomic) NSString * fileName;
		[Export ("fileName")]
		string FileName { get; set; }

		// @property (assign, nonatomic) uint32_t lineNumber;
		[Export ("lineNumber")]
		uint LineNumber { get; set; }

		// @property (assign, nonatomic) uint64_t offset;
		[Export ("offset")]
		ulong Offset { get; set; }

		// @property (assign, nonatomic) uint64_t address;
		[Export ("address")]
		ulong Address { get; set; }
	}

	// @interface Answers : NSObject
	[BaseType (typeof(NSObject))]
	interface Answers
	{
		// +(void)logSignUpWithMethod:(NSString *)signUpMethodOrNil success:(NSNumber *)signUpSucceededOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logSignUpWithMethod:success:customAttributes:")]
        void LogSignUpWithMethod (string signUpMethodOrNil, NSNumber signUpSucceededOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logLoginWithMethod:(NSString *)loginMethodOrNil success:(NSNumber *)loginSucceededOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logLoginWithMethod:success:customAttributes:")]
		void LogLoginWithMethod (string loginMethodOrNil, NSNumber loginSucceededOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logShareWithMethod:(NSString *)shareMethodOrNil contentName:(NSString *)contentNameOrNil contentType:(NSString *)contentTypeOrNil contentId:(NSString *)contentIdOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logShareWithMethod:contentName:contentType:contentId:customAttributes:")]
        void LogShareWithMethod (string shareMethodOrNil, string contentNameOrNil, string contentTypeOrNil, string contentIdOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logInviteWithMethod:(NSString *)inviteMethodOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logInviteWithMethod:customAttributes:")]
        void LogInviteWithMethod (string inviteMethodOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logPurchaseWithPrice:(NSDecimalNumber *)itemPriceOrNil currency:(NSString *)currencyOrNil success:(NSNumber *)purchaseSucceededOrNil itemName:(NSString *)itemNameOrNil itemType:(NSString *)itemTypeOrNil itemId:(NSString *)itemIdOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logPurchaseWithPrice:currency:success:itemName:itemType:itemId:customAttributes:")]
        void LogPurchaseWithPrice (NSDecimalNumber itemPriceOrNil, string currencyOrNil, NSNumber purchaseSucceededOrNil, string itemNameOrNil, string itemTypeOrNil, string itemIdOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logLevelStart:(NSString *)levelNameOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logLevelStart:customAttributes:")]
        void LogLevelStart (string levelNameOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logLevelEnd:(NSString *)levelNameOrNil score:(NSNumber *)scoreOrNil success:(NSNumber *)levelCompletedSuccesfullyOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logLevelEnd:score:success:customAttributes:")]
        void LogLevelEnd (string levelNameOrNil, NSNumber scoreOrNil, NSNumber levelCompletedSuccesfullyOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logAddToCartWithPrice:(NSDecimalNumber *)itemPriceOrNil currency:(NSString *)currencyOrNil itemName:(NSString *)itemNameOrNil itemType:(NSString *)itemTypeOrNil itemId:(NSString *)itemIdOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logAddToCartWithPrice:currency:itemName:itemType:itemId:customAttributes:")]
        void LogAddToCartWithPrice (NSDecimalNumber itemPriceOrNil, string currencyOrNil, string itemNameOrNil, string itemTypeOrNil, string itemIdOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logStartCheckoutWithPrice:(NSDecimalNumber *)totalPriceOrNil currency:(NSString *)currencyOrNil itemCount:(NSNumber *)itemCountOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logStartCheckoutWithPrice:currency:itemCount:customAttributes:")]
        void LogStartCheckoutWithPrice (NSDecimalNumber totalPriceOrNil, string currencyOrNil, NSNumber itemCountOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logRating:(NSNumber *)ratingOrNil contentName:(NSString *)contentNameOrNil contentType:(NSString *)contentTypeOrNil contentId:(NSString *)contentIdOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logRating:contentName:contentType:contentId:customAttributes:")]
        void LogRating (NSNumber ratingOrNil, string contentNameOrNil, string contentTypeOrNil, string contentIdOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logContentViewWithName:(NSString *)contentNameOrNil contentType:(NSString *)contentTypeOrNil contentId:(NSString *)contentIdOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logContentViewWithName:contentType:contentId:customAttributes:")]
        void LogContentViewWithName (string contentNameOrNil, string contentTypeOrNil, string contentIdOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logSearchWithQuery:(NSString *)queryOrNil customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logSearchWithQuery:customAttributes:")]
        void LogSearchWithQuery (string queryOrNil, [NullAllowed]NSDictionary customAttributesOrNil);

		// +(void)logCustomEventWithName:(NSString *)eventName customAttributes:(NSDictionary *)customAttributesOrNil;
		[Static]
		[Export ("logCustomEventWithName:customAttributes:")]
        void LogCustomEventWithName (string eventName, [NullAllowed]NSDictionary customAttributesOrNil);
	}

	// @interface Crashlytics : NSObject
	[BaseType (typeof(NSObject))]
	interface Crashlytics
	{
		// @property (readonly, copy, nonatomic) NSString * apiKey;
		[Export ("apiKey")]
		string ApiKey { get; }

		// @property (readonly, copy, nonatomic) NSString * version;
		[Export ("version")]
		string Version { get; }

		// @property (assign, nonatomic) BOOL debugMode;
		[Export ("debugMode")]
		bool DebugMode { get; set; }

		[Wrap ("WeakDelegate")]
		CrashlyticsDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<CrashlyticsDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// +(Crashlytics *)startWithAPIKey:(NSString *)apiKey;
		[Static]
		[Export ("startWithAPIKey:")]
		Crashlytics StartWithAPIKey (string apiKey);

		// +(Crashlytics *)startWithAPIKey:(NSString *)apiKey afterDelay:(NSTimeInterval)delay __attribute__((deprecated("Crashlytics no longer needs or uses the delay parameter.  Please use +startWithAPIKey: instead.")));
		[Static]
		[Export ("startWithAPIKey:afterDelay:")]
		Crashlytics StartWithAPIKey (string apiKey, double delay);

		// +(Crashlytics *)startWithAPIKey:(NSString *)apiKey delegate:(id<CrashlyticsDelegate>)delegate;
		[Static]
		[Export ("startWithAPIKey:delegate:")]
		Crashlytics StartWithAPIKey (string apiKey, CrashlyticsDelegate del);

		// +(Crashlytics *)startWithAPIKey:(NSString *)apiKey delegate:(id<CrashlyticsDelegate>)delegate afterDelay:(NSTimeInterval)delay __attribute__((deprecated("Crashlytics no longer needs or uses the delay parameter.  Please use +startWithAPIKey:delegate: instead.")));
		[Static]
		[Export ("startWithAPIKey:delegate:afterDelay:")]
		Crashlytics StartWithAPIKey (string apiKey, CrashlyticsDelegate del, double delay);

		// +(Crashlytics *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		Crashlytics SharedInstance { get; }

		// -(void)crash;
		[Export ("crash")]
		void Crash ();

		// -(void)throwException;
		[Export ("throwException")]
		void ThrowException ();

		// -(void)setUserIdentifier:(NSString *)identifier;
		[Export ("setUserIdentifier:")]
		void SetUserIdentifier (string identifier);

		// -(void)setUserName:(NSString *)name;
		[Export ("setUserName:")]
		void SetUserName (string name);

		// -(void)setUserEmail:(NSString *)email;
		[Export ("setUserEmail:")]
		void SetUserEmail (string email);

		// -(void)setObjectValue:(id)value forKey:(NSString *)key;
		[Export ("setObjectValue:forKey:")]
		void SetObjectValue (NSObject value, string key);

		// -(void)setIntValue:(int)value forKey:(NSString *)key;
		[Export ("setIntValue:forKey:")]
		void SetIntValue (int value, string key);

		// -(void)setBoolValue:(BOOL)value forKey:(NSString *)key;
		[Export ("setBoolValue:forKey:")]
		void SetBoolValue (bool value, string key);

		// -(void)setFloatValue:(float)value forKey:(NSString *)key;
		[Export ("setFloatValue:forKey:")]
		void SetFloatValue (float value, string key);

		// -(void)recordCustomExceptionName:(NSString *)name reason:(NSString *)reason frameArray:(NSArray *)frameArray;
		[Export ("recordCustomExceptionName:reason:frameArray:")]
		//[Verify (StronglyTypedNSArray)]
		void RecordCustomExceptionName (string name, string reason, NSObject[] frameArray);

		// -(void)logEvent:(NSString *)eventName __attribute__((deprecated("Please refer to Answers +logCustomEventWithName:")));
		[Export ("logEvent:")]
		void LogEvent (string eventName);

		// -(void)logEvent:(NSString *)eventName attributes:(NSDictionary *)attributes __attribute__((deprecated("Please refer to Answers +logCustomEventWithName:")));
		[Export ("logEvent:attributes:")]
		void LogEvent (string eventName, NSDictionary attributes);
	}

	// @protocol CrashlyticsDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface CrashlyticsDelegate
	{
		// @optional -(void)crashlyticsDidDetectCrashDuringPreviousExecution:(Crashlytics *)crashlytics __attribute__((deprecated("Please refer to -crashlyticsDidDetectReportForLastExecution:")));
		[Export ("crashlyticsDidDetectCrashDuringPreviousExecution:")]
		void CrashlyticsDidDetectCrashDuringPreviousExecution (Crashlytics crashlytics);

		// @optional -(void)crashlytics:(Crashlytics *)crashlytics didDetectCrashDuringPreviousExecution:(id<CLSCrashReport>)crash __attribute__((deprecated("Please refer to -crashlyticsDidDetectReportForLastExecution:")));
		[Export ("crashlytics:didDetectCrashDuringPreviousExecution:")]
		void Crashlytics (Crashlytics crashlytics, CLSCrashReport crash);

		// @optional -(void)crashlyticsDidDetectReportForLastExecution:(CLSReport *)report completionHandler:(void (^)(BOOL))completionHandler;
		[Export ("crashlyticsDidDetectReportForLastExecution:completionHandler:")]
		void CrashlyticsDidDetectReportForLastExecution (CLSReport report, Action<bool> completionHandler);

		// @optional -(BOOL)crashlyticsCanUseBackgroundSessions:(Crashlytics *)crashlytics;
		[Export ("crashlyticsCanUseBackgroundSessions:")]
		bool CrashlyticsCanUseBackgroundSessions (Crashlytics crashlytics);
	}
}
