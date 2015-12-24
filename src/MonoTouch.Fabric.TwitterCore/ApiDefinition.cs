using System;
using Foundation;

namespace MonoTouch.Fabric.TwitterCore
{

	// @interface TWTRAuthConfig : NSObject
	[BaseType (typeof(NSObject))]
	interface TWTRAuthConfig
	{
		// @property (readonly, copy, nonatomic) NSString * consumerKey;
		[Export ("consumerKey")]
		string ConsumerKey { get; }

		// @property (readonly, copy, nonatomic) NSString * consumerSecret;
		[Export ("consumerSecret")]
		string ConsumerSecret { get; }

		// -(instancetype)initWithConsumerKey:(NSString *)consumerKey consumerSecret:(NSString *)consumerSecret;
		[Export ("initWithConsumerKey:consumerSecret:")]
		IntPtr Constructor (string consumerKey, string consumerSecret);
	}

	// @protocol TWTRAuthSession <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TWTRAuthSession
	{
		// @required @property (readonly, copy, nonatomic) NSString * authToken;
		[Export ("authToken")]
		string AuthToken { get; }

		// @required @property (readonly, copy, nonatomic) NSString * authTokenSecret;
		[Export ("authTokenSecret")]
		string AuthTokenSecret { get; }

		// @required @property (readonly, copy, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserID { get; }
	}

	// @protocol TWTRCoreOAuthSigning <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TWTRCoreOAuthSigning
	{
		// @required -(NSDictionary *)OAuthEchoHeadersForRequestMethod:(NSString *)method URLString:(NSString *)URLString parameters:(NSDictionary *)parameters error:(NSError **)error __attribute__((nonnull(0, 1)));
		[Abstract]
		[Export ("OAuthEchoHeadersForRequestMethod:URLString:parameters:error:")]
		NSDictionary URLString (string method, string URLString, NSDictionary parameters, out NSError error);

		// @required -(NSDictionary *)OAuthEchoHeadersToVerifyCredentials;
		[Abstract]
		[Export ("OAuthEchoHeadersToVerifyCredentials")]
		//[Verify (MethodToProperty)]
		NSDictionary OAuthEchoHeadersToVerifyCredentials { get; }
	}

	// @interface TWTRGuestSession : NSObject
	[BaseType (typeof(NSObject))]
	interface TWTRGuestSession
	{
		// @property (readonly, copy, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, copy, nonatomic) NSString * guestToken;
		[Export ("guestToken")]
		string GuestToken { get; }

		// -(instancetype)initWithSessionDictionary:(NSDictionary *)sessionDictionary;
		[Export ("initWithSessionDictionary:")]
		IntPtr Constructor (NSDictionary sessionDictionary);
	}

}

