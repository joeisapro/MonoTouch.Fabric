using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using MonoTouch.Fabric.TwitterCore;

namespace MonoTouch.Fabric.TwitterKit
{
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTRAPIErrorDomain;
		[Field ("TWTRAPIErrorDomain")]
		NSString TWTRAPIErrorDomain { get; }
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTRErrorDomain;
		[Field ("TWTRErrorDomain")]
		NSString TWTRErrorDomain { get; }
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTRLogInErrorDomain;
		[Field ("TWTRLogInErrorDomain")]
		NSString TWTRLogInErrorDomain { get; }
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTROAuthEchoRequestURLStringKey;
		[Field ("TWTROAuthEchoRequestURLStringKey")]
		NSString TWTROAuthEchoRequestURLStringKey { get; }

		// extern NSString *const TWTROAuthEchoAuthorizationHeaderKey;
		[Field ("TWTROAuthEchoAuthorizationHeaderKey")]
		NSString TWTROAuthEchoAuthorizationHeaderKey { get; }
	}

	// typedef void (^TWTRGuestLogInCompletion)(TWTRGuestSession *NSError *);
	delegate void TWTRGuestLogInCompletion ([NullAllowed]TWTRGuestSession arg0, [NullAllowed]NSError arg1);

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTRTweetsNotLoadedKey;
		[Field ("TWTRTweetsNotLoadedKey")]
		NSString TWTRTweetsNotLoadedKey { get; }
	}

	// typedef void (^TWTRLoadUserCompletion)(TWTRUser *NSError *);
	delegate void TWTRLoadUserCompletion ([NullAllowed]TWTRUser arg0, [NullAllowed]NSError arg1);

	// typedef void (^TWTRLoadTweetCompletion)(TWTRTweet *NSError *);
	delegate void TWTRLoadTweetCompletion ([NullAllowed]TWTRTweet arg0, [NullAllowed]NSError arg1);

	// typedef void (^TWTRLoadTweetsCompletion)(NSArray *NSError *);
	delegate void TWTRLoadTweetsCompletion ([NullAllowed]NSObject[] arg0, [NullAllowed]NSError arg1);

	// typedef void (^TWTRNetworkCompletion)(NSURLResponse *NSData *NSError *);
	delegate void TWTRNetworkCompletion ([NullAllowed]NSUrlResponse arg0, NSData arg1, [NullAllowed]NSError arg2);

	// typedef void (^TWTRJSONRequestCompletion)(NSURLResponse *idNSError *);
	delegate void TWTRJSONRequestCompletion ([NullAllowed]NSUrlResponse arg0, [NullAllowed]NSObject arg1, [NullAllowed]NSError arg2);

	// typedef void (^TWTRTweetActionCompletion)(TWTRTweet *NSError *);
	delegate void TWTRTweetActionCompletion ([NullAllowed]TWTRTweet arg0, [NullAllowed]NSError arg1);

	// @interface TWTRAPIClient : NSObject
	[BaseType (typeof(NSObject))]
	interface TWTRAPIClient
	{
		// -(instancetype)initWithConsumerKey:(NSString *)consumerKey consumerSecret:(NSString *)consumerSecret __attribute__((deprecated("")));
		[Export ("initWithConsumerKey:consumerSecret:")]
		IntPtr Constructor (string consumerKey, string consumerSecret);

		// -(NSURLRequest *)URLRequestWithMethod:(NSString *)method URL:(NSString *)URLString parameters:(NSDictionary *)parameters error:(NSError **)error;
		[Export ("URLRequestWithMethod:URL:parameters:error:")]
		NSUrlRequest URLRequestWithMethod (string method, string URLString, NSDictionary parameters, out NSError error);

		// -(void)sendTwitterRequest:(NSURLRequest *)request completion:(TWTRNetworkCompletion)completion;
		[Export ("sendTwitterRequest:completion:")]
		void SendTwitterRequest (NSUrlRequest request, TWTRNetworkCompletion completion);

		// -(void)loadUserWithID:(NSString *)userID completion:(TWTRLoadUserCompletion)completion;
		[Export ("loadUserWithID:completion:")]
		void LoadUserWithID (string userID, TWTRLoadUserCompletion completion);

		// -(void)loadTweetWithID:(NSString *)tweetID completion:(TWTRLoadTweetCompletion)completion;
		[Export ("loadTweetWithID:completion:")]
		void LoadTweetWithID (string tweetID, TWTRLoadTweetCompletion completion);

		// -(void)loadTweetsWithIDs:(NSArray *)tweetIDStrings completion:(TWTRLoadTweetsCompletion)completion;
		[Export ("loadTweetsWithIDs:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void LoadTweetsWithIDs (NSObject[] tweetIDStrings, TWTRLoadTweetsCompletion completion);
	}

	// @interface TWTRSession : NSObject <TWTRAuthSession>
	[BaseType (typeof(NSObject))]
	interface TWTRSession : ITWTRAuthSession
	{
		// @property (readonly, copy, nonatomic) NSString * userName;
		[Export ("userName")]
		string UserName { get; }

		// -(instancetype)initWithSessionDictionary:(NSDictionary *)sessionDictionary;
		[Export ("initWithSessionDictionary:")]
		IntPtr Constructor (NSDictionary sessionDictionary);
	}

	// typedef void (^TWTRLogInCompletion)(TWTRSession *NSError *);
	delegate void TWTRLogInCompletion ([NullAllowed]TWTRSession arg0, [NullAllowed]NSError arg1);

	// @interface Twitter : NSObject
	[BaseType (typeof(NSObject))]
	interface Twitter
	{
		// +(Twitter *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		Twitter SharedInstance { get; }

		// -(void)startWithConsumerKey:(NSString *)consumerKey consumerSecret:(NSString *)consumerSecret;
		[Export ("startWithConsumerKey:consumerSecret:")]
		void StartWithConsumerKey (string consumerKey, string consumerSecret);

		// @property (readonly, nonatomic, strong) TWTRAPIClient * APIClient;
		[Export ("APIClient", ArgumentSemantic.Strong)]
		TWTRAPIClient APIClient { get; }

		// @property (readonly, copy, nonatomic) NSString * version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * consumerKey;
		[Export ("consumerKey")]
		string ConsumerKey { get; }

		// @property (readonly, copy, nonatomic) NSString * consumerSecret;
		[Export ("consumerSecret")]
		string ConsumerSecret { get; }

		// @property (readonly, nonatomic, strong) TWTRAuthConfig * authConfig;
		[Export ("authConfig", ArgumentSemantic.Strong)]
		TWTRAuthConfig AuthConfig { get; }

		// -(void)logInWithCompletion:(TWTRLogInCompletion)completion;
		[Export ("logInWithCompletion:")]
		void LogInWithCompletion (TWTRLogInCompletion completion);

		// -(void)logInWithViewController:(UIViewController *)viewController completion:(TWTRLogInCompletion)completion;
		[Export ("logInWithViewController:completion:")]
		void LogInWithViewController (UIViewController viewController, TWTRLogInCompletion completion);

		// -(void)logInGuestWithCompletion:(TWTRGuestLogInCompletion)completion;
		[Export ("logInGuestWithCompletion:")]
		void LogInGuestWithCompletion (TWTRGuestLogInCompletion completion);

		// -(void)logInWithExistingAuthToken:(NSString *)authToken authTokenSecret:(NSString *)authTokenSecret completion:(TWTRLogInCompletion)completion;
		[Export ("logInWithExistingAuthToken:authTokenSecret:completion:")]
		void LogInWithExistingAuthToken (string authToken, string authTokenSecret, TWTRLogInCompletion completion);

		// -(TWTRSession *)session;
		[Export ("session")]
		//[Verify (MethodToProperty)]
		TWTRSession Session { get; }

		// -(TWTRGuestSession *)guestSession;
		[Export ("guestSession")]
		//[Verify (MethodToProperty)]
		TWTRGuestSession GuestSession { get; }

		// -(void)logOut;
		[Export ("logOut")]
		void LogOut ();

		// -(void)logOutGuest;
		[Export ("logOutGuest")]
		void LogOutGuest ();
	}

	// typedef void (^TWTRLoadTimelineCompletion)(NSArray *TWTRTimelineCursor *NSError *);
	delegate void TWTRLoadTimelineCompletion ([NullAllowed]NSObject[] arg0, [NullAllowed]NSObject arg1, [NullAllowed]NSError arg2);

	// @protocol TWTRTimelineDataSource <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TWTRTimelineDataSource
	{
		// @required -(void)loadPreviousTweetsBeforePosition:(NSString *)position completion:(TWTRLoadTimelineCompletion)completion;
		//[Abstract]
		[Export ("loadPreviousTweetsBeforePosition:completion:")]
		void Completion (string position, TWTRLoadTimelineCompletion completion);

		// @required @property (readonly, nonatomic) TWTRTimelineType timelineType;
		[Export ("timelineType")]
		TWTRTimelineType TimelineType { get; }
	}

	// @interface TWTRCollectionTimelineDataSource : NSObject <TWTRTimelineDataSource>
	[BaseType (typeof(TWTRTimelineDataSource))]
	interface TWTRCollectionTimelineDataSource : TWTRTimelineDataSource
	{
		// @property (readonly, assign, nonatomic) NSInteger maxTweetsPerRequest;
		[Export ("maxTweetsPerRequest", ArgumentSemantic.Assign)]
		nint MaxTweetsPerRequest { get; }

		// -(instancetype)initWithCollectionID:(NSString *)collectionID APIClient:(TWTRAPIClient *)client __attribute__((nonnull()));
		[Export ("initWithCollectionID:APIClient:")]
		IntPtr Constructor (string collectionID, TWTRAPIClient client);

		// -(instancetype)initWithCollectionID:(NSString *)collectionID APIClient:(TWTRAPIClient *)client maxTweetsPerRequest:(NSUInteger)maxTweetsPerRequest __attribute__((objc_designated_initializer)) __attribute__((nonnull()));
		[Export ("initWithCollectionID:APIClient:maxTweetsPerRequest:")]
		IntPtr Constructor (string collectionID, TWTRAPIClient client, nuint maxTweetsPerRequest);
	}

	// typedef void (^TWTRComposerCompletion)(TWTRComposerResult);
	delegate void TWTRComposerCompletion ([NullAllowed]TWTRComposerResult arg0);

	// @interface TWTRComposer : NSObject
	[BaseType (typeof(NSObject))]
	interface TWTRComposer
	{
		// -(BOOL)setText:(NSString *)text;
		[Export ("setText:")]
		bool SetText (string text);

		// -(BOOL)setImage:(UIImage *)image;
		[Export ("setImage:")]
		bool SetImage (UIImage image);

		// -(BOOL)setURL:(NSURL *)url;
		[Export ("setURL:")]
		bool SetURL (NSUrl url);

		// -(void)showFromViewController:(UIViewController *)fromController completion:(TWTRComposerCompletion)completion;
		[Export ("showFromViewController:completion:")]
		void ShowFromViewController (UIViewController fromController, TWTRComposerCompletion completion);
	}

	// @interface TWTRDeprecated (TWTRComposer)
	[Category]
	[BaseType (typeof(TWTRComposer))]
	interface TWTRComposer_TWTRDeprecated
	{
		// -(void)showWithCompletion:(TWTRComposerCompletion)completion;
		[Export ("showWithCompletion:")]
		void ShowWithCompletion (TWTRComposerCompletion completion);
	}

	// @interface TWTRListTimelineDataSource : NSObject <TWTRTimelineDataSource>
	[BaseType (typeof(TWTRTimelineDataSource))]
	interface TWTRListTimelineDataSource : TWTRTimelineDataSource
	{
		// @property (readonly, copy, nonatomic) NSString * listID;
		[Export ("listID")]
		string ListID { get; }

		// @property (readonly, copy, nonatomic) NSString * listSlug;
		[Export ("listSlug")]
		string ListSlug { get; }

		// @property (readonly, copy, nonatomic) NSString * listOwnerScreenName;
		[Export ("listOwnerScreenName")]
		string ListOwnerScreenName { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxTweetsPerRequest;
		[Export ("maxTweetsPerRequest", ArgumentSemantic.Assign)]
		nuint MaxTweetsPerRequest { get; }

		// @property (readonly, assign, nonatomic) BOOL includeRetweets;
		[Export ("includeRetweets")]
		bool IncludeRetweets { get; }

		// -(instancetype)initWithListID:(NSString *)listID APIClient:(TWTRAPIClient *)client;
		[Export ("initWithListID:APIClient:")]
		IntPtr Constructor (string listID, TWTRAPIClient client);

		// -(instancetype)initWithListSlug:(NSString *)listSlug listOwnerScreenName:(NSString *)listOwnerScreenName APIClient:(TWTRAPIClient *)client;
		[Export ("initWithListSlug:listOwnerScreenName:APIClient:")]
		IntPtr Constructor (string listSlug, string listOwnerScreenName, TWTRAPIClient client);

		// -(instancetype)initWithListID:(NSString *)listID listSlug:(NSString *)listSlug listOwnerScreenName:(NSString *)listOwnerScreenName APIClient:(TWTRAPIClient *)client maxTweetsPerRequest:(NSUInteger)maxTweetsPerRequest includeRetweets:(BOOL)includeRetweets __attribute__((objc_designated_initializer));
		[Export ("initWithListID:listSlug:listOwnerScreenName:APIClient:maxTweetsPerRequest:includeRetweets:")]
		IntPtr Constructor (string listID, string listSlug, string listOwnerScreenName, TWTRAPIClient client, nuint maxTweetsPerRequest, bool includeRetweets);
	}

	// @interface TWTRLogInButton : UIButton
	[BaseType (typeof(UIButton))]
	interface TWTRLogInButton
	{
		// @property (copy, nonatomic) TWTRLogInCompletion logInCompletion;
		[Export ("logInCompletion", ArgumentSemantic.Copy)]
		TWTRLogInCompletion LogInCompletion { get; set; }

		// +(instancetype)buttonWithLogInCompletion:(TWTRLogInCompletion)completion;
		[Static]
		[Export ("buttonWithLogInCompletion:")]
		TWTRLogInButton ButtonWithLogInCompletion (TWTRLogInCompletion completion);
	}

	// @interface TWTROAuthSigning : NSObject <TWTRCoreOAuthSigning>
	[BaseType (typeof(NSObject))]
	interface TWTROAuthSigning : ITWTRCoreOAuthSigning
	{
		// -(instancetype)initWithAuthConfig:(TWTRAuthConfig *)authConfig authSession:(TWTRSession *)authSession __attribute__((objc_designated_initializer));
		[Export ("initWithAuthConfig:authSession:")]
		IntPtr Constructor (TWTRAuthConfig authConfig, TWTRSession authSession);
	}

	// @interface TWTRSearchTimelineDataSource : NSObject <TWTRTimelineDataSource>
	[BaseType (typeof(TWTRTimelineDataSource))]
	interface TWTRSearchTimelineDataSource : TWTRTimelineDataSource
	{
		// @property (readonly, copy, nonatomic) NSString * searchQuery;
		[Export ("searchQuery")]
		string SearchQuery { get; }

		// @property (readonly, copy, nonatomic) NSString * languageCode;
		[Export ("languageCode")]
		string LanguageCode { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxTweetsPerRequest;
		[Export ("maxTweetsPerRequest", ArgumentSemantic.Assign)]
		nuint MaxTweetsPerRequest { get; }

		// -(instancetype)initWithSearchQuery:(NSString *)searchQuery APIClient:(TWTRAPIClient *)client __attribute__((nonnull()));
		[Export ("initWithSearchQuery:APIClient:")]
		IntPtr Constructor (string searchQuery, TWTRAPIClient client);

		// -(instancetype)initWithSearchQuery:(NSString *)searchQuery APIClient:(TWTRAPIClient *)client languageCode:(NSString *)languageCode maxTweetsPerRequest:(NSUInteger)maxTweetsPerRequest __attribute__((objc_designated_initializer)) __attribute__((nonnull(0, 1)));
		[Export ("initWithSearchQuery:APIClient:languageCode:maxTweetsPerRequest:")]
		IntPtr Constructor (string searchQuery, TWTRAPIClient client, string languageCode, nuint maxTweetsPerRequest);
	}

	// typedef void (^TWTRShareEmailCompletion)(NSString *NSError *);
	delegate void TWTRShareEmailCompletion ([NullAllowed]string arg0, [NullAllowed]NSError arg1);

	// @interface TWTRShareEmailViewController : UINavigationController
	[BaseType (typeof(UINavigationController))]
	interface TWTRShareEmailViewController
	{
		// @property (copy, nonatomic) TWTRShareEmailCompletion completion;
		[Export ("completion", ArgumentSemantic.Copy)]
		TWTRShareEmailCompletion Completion { get; set; }

		// -(instancetype)initWithCompletion:(TWTRShareEmailCompletion)completion;
		[Export ("initWithCompletion:")]
		IntPtr Constructor (TWTRShareEmailCompletion completion);
	}

	// @interface TWTRTimelineViewController : UITableViewController
	[BaseType (typeof(UITableViewController))]
	interface TWTRTimelineViewController
	{
		// -(instancetype)initWithDataSource:(id<TWTRTimelineDataSource>)dataSource __attribute__((objc_designated_initializer));
		[Export ("initWithDataSource:")]
		IntPtr Constructor (TWTRTimelineDataSource dataSource);

		// @property (nonatomic, strong) id<TWTRTimelineDataSource> dataSource;
		[Export ("dataSource", ArgumentSemantic.Strong)]
		TWTRTimelineDataSource DataSource { get; set; }

		// @property (assign, nonatomic) BOOL showTweetActions;
		[Export ("showTweetActions")]
		bool ShowTweetActions { get; set; }

		// -(instancetype)initWithStyle:(UITableViewStyle)style __attribute__((unavailable("Use -initWithDataSource: instead")));
		[Export ("initWithStyle:")]
		IntPtr Constructor (UITableViewStyle style);
	}

	// @interface TWTRTweet : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface TWTRTweet : INSCoding
	{
		// @property (readonly, copy, nonatomic) NSString * tweetID;
		[Export ("tweetID")]
		string TweetID { get; }

		// @property (readonly, copy, nonatomic) NSDate * createdAt;
		[Export ("createdAt", ArgumentSemantic.Copy)]
		NSDate CreatedAt { get; }

		// @property (readonly, copy, nonatomic) NSString * text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic, strong) TWTRUser * author;
		[Export ("author", ArgumentSemantic.Strong)]
		TWTRUser Author { get; }

		// @property (readonly, assign, nonatomic) long long favoriteCount;
		[Export ("favoriteCount")]
		long FavoriteCount { get; }

		// @property (readonly, assign, nonatomic) long long retweetCount;
		[Export ("retweetCount")]
		long RetweetCount { get; }

		// @property (readonly, copy, nonatomic) NSString * inReplyToTweetID;
		[Export ("inReplyToTweetID")]
		string InReplyToTweetID { get; }

		// @property (readonly, copy, nonatomic) NSString * inReplyToUserID;
		[Export ("inReplyToUserID")]
		string InReplyToUserID { get; }

		// @property (readonly, copy, nonatomic) NSString * inReplyToScreenName;
		[Export ("inReplyToScreenName")]
		string InReplyToScreenName { get; }

		// @property (readonly, copy, nonatomic) NSURL * permalink;
		[Export ("permalink", ArgumentSemantic.Copy)]
		NSUrl Permalink { get; }

		// @property (readonly, assign, nonatomic) BOOL isFavorited;
		[Export ("isFavorited")]
		bool IsFavorited { get; }

		// @property (readonly, assign, nonatomic) BOOL isRetweeted;
		[Export ("isRetweeted")]
		bool IsRetweeted { get; }

		// @property (readonly, copy, nonatomic) NSString * retweetID;
		[Export ("retweetID")]
		string RetweetID { get; }

		// @property (readonly, nonatomic, strong) TWTRTweet * retweetedTweet;
		[Export ("retweetedTweet", ArgumentSemantic.Strong)]
		TWTRTweet RetweetedTweet { get; }

		// @property (readonly, assign, nonatomic) BOOL isRetweet;
		[Export ("isRetweet")]
		bool IsRetweet { get; }

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)dictionary;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// +(NSArray *)tweetsWithJSONArray:(NSArray *)array;
		[Static]
		[Export ("tweetsWithJSONArray:")]
		//[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
		NSObject[] TweetsWithJSONArray (NSObject[] array);

		// -(TWTRTweet *)tweetWithFavoriteToggled;
		[Export ("tweetWithFavoriteToggled")]
		//[Verify (MethodToProperty)]
		TWTRTweet TweetWithFavoriteToggled { get; }
	}

	// @interface TWTRTweetTableViewCell : UITableViewCell
	[BaseType (typeof(UITableViewCell))]
	interface TWTRTweetTableViewCell
	{
		// @property (readonly, nonatomic, strong) TWTRTweetView * tweetView;
		[Export ("tweetView", ArgumentSemantic.Strong)]
		TWTRTweetView TweetView { get; }

		// -(void)configureWithTweet:(TWTRTweet *)tweet;
		[Export ("configureWithTweet:")]
		void ConfigureWithTweet (TWTRTweet tweet);

		// +(CGFloat)heightForTweet:(TWTRTweet *)tweet width:(CGFloat)width showingActions:(BOOL)actionsAreVisible;
		[Static]
		[Export ("heightForTweet:width:showingActions:")]
		nfloat HeightForTweet (TWTRTweet tweet, nfloat width, bool actionsAreVisible);

		// +(CGFloat)heightForTweet:(TWTRTweet *)tweet width:(CGFloat)width;
		[Static]
		[Export ("heightForTweet:width:")]
		nfloat HeightForTweet (TWTRTweet tweet, nfloat width);

		// -(CGFloat)calculatedHeightForWidth:(CGFloat)width __attribute__((deprecated("Use +heightForTweet:width: instead.")));
		[Export ("calculatedHeightForWidth:")]
		nfloat CalculatedHeightForWidth (nfloat width);
	}

	// @protocol TWTRTweetViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TWTRTweetViewDelegate
	{
		// @optional -(void)tweetView:(TWTRTweetView *)tweetView didSelectTweet:(TWTRTweet *)tweet;
		[Export ("tweetView:didSelectTweet:")]
		void DidSelectTweet (TWTRTweetView tweetView, TWTRTweet tweet);

		// @optional -(void)tweetView:(TWTRTweetView *)tweetView didTapURL:(NSURL *)url;
		[Export ("tweetView:didTapURL:")]
		void DidTapURL (TWTRTweetView tweetView, NSUrl url);

		// @optional -(void)tweetView:(TWTRTweetView *)tweetView willShareTweet:(TWTRTweet *)tweet;
		[Export ("tweetView:willShareTweet:")]
		void WillShareTweet (TWTRTweetView tweetView, TWTRTweet tweet);

		// @optional -(void)tweetView:(TWTRTweetView *)tweetView didShareTweet:(TWTRTweet *)tweet withType:(NSString *)shareType;
		[Export ("tweetView:didShareTweet:withType:")]
		void DidShareTweet (TWTRTweetView tweetView, TWTRTweet tweet, string shareType);

		// @optional -(void)tweetView:(TWTRTweetView *)tweetView cancelledShareTweet:(TWTRTweet *)tweet;
		[Export ("tweetView:cancelledShareTweet:")]
		void CancelledShareTweet (TWTRTweetView tweetView, TWTRTweet tweet);

		// @optional -(void)tweetView:(TWTRTweetView *)tweetView didFavoriteTweet:(TWTRTweet *)tweet;
		[Export ("tweetView:didFavoriteTweet:")]
		void DidFavoriteTweet (TWTRTweetView tweetView, TWTRTweet tweet);

		// @optional -(void)tweetView:(TWTRTweetView *)tweetView didUnfavoriteTweet:(TWTRTweet *)tweet;
		[Export ("tweetView:didUnfavoriteTweet:")]
		void DidUnfavoriteTweet (TWTRTweetView tweetView, TWTRTweet tweet);
	}

	// @interface TWTRTweetView : UIView <UIAppearanceContainer>
	[BaseType (typeof(UIView))]
	interface TWTRTweetView : IUIAppearanceContainer
	{
		// @property (nonatomic, strong) UIColor * backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * primaryTextColor;
		[Export ("primaryTextColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextColor { get; set; }

		// @property (nonatomic, strong) UIColor * linkTextColor;
		[Export ("linkTextColor", ArgumentSemantic.Strong)]
		UIColor LinkTextColor { get; set; }

		// @property (assign, nonatomic) BOOL showBorder;
		[Export ("showBorder")]
		bool ShowBorder { get; set; }

		// @property (assign, nonatomic) BOOL showActionButtons;
		[Export ("showActionButtons")]
		bool ShowActionButtons { get; set; }

		// @property (assign, nonatomic) TWTRTweetViewTheme theme;
		[Export ("theme", ArgumentSemantic.Assign)]
		TWTRTweetViewTheme Theme { get; set; }

		// @property (readonly, assign, nonatomic) TWTRTweetViewStyle style;
		[Export ("style", ArgumentSemantic.Assign)]
		TWTRTweetViewStyle Style { get; }

		[Wrap ("WeakDelegate")]
		TWTRTweetViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWTRTweetViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, weak) UIViewController * presenterViewController;
		[Export ("presenterViewController", ArgumentSemantic.Weak)]
		UIViewController PresenterViewController { get; set; }

		// -(instancetype)initWithTweet:(TWTRTweet *)tweet;
		[Export ("initWithTweet:")]
		IntPtr Constructor ([NullAllowed]TWTRTweet tweet);

		// -(instancetype)initWithTweet:(TWTRTweet *)tweet style:(TWTRTweetViewStyle)style;
		[Export ("initWithTweet:style:")]
		IntPtr Constructor ([NullAllowed]TWTRTweet tweet, TWTRTweetViewStyle style);

		// -(instancetype)initWithFrame:(CGRect)frame __attribute__((unavailable("Use -initWithTweet: instead")));
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// -(CGSize)sizeThatFits:(CGSize)size;
		[Export ("sizeThatFits:")]
		CGSize SizeThatFits (CGSize size);

		// -(void)configureWithTweet:(TWTRTweet *)tweet;
		[Export ("configureWithTweet:")]
		void ConfigureWithTweet (TWTRTweet tweet);
	}

	// @interface TWTRUser : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface TWTRUser : INSCoding, INSCopying
	{
		// @property (readonly, copy, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserID { get; }

		// @property (readonly, copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * screenName;
		[Export ("screenName")]
		string ScreenName { get; }

		// @property (readonly, assign, nonatomic) BOOL isVerified;
		[Export ("isVerified")]
		bool IsVerified { get; }

		// @property (readonly, assign, nonatomic) BOOL isProtected;
		[Export ("isProtected")]
		bool IsProtected { get; }

		// @property (readonly, copy, nonatomic) NSString * profileImageURL;
		[Export ("profileImageURL")]
		string ProfileImageURL { get; }

		// @property (readonly, copy, nonatomic) NSString * profileImageMiniURL;
		[Export ("profileImageMiniURL")]
		string ProfileImageMiniURL { get; }

		// @property (readonly, copy, nonatomic) NSString * profileImageLargeURL;
		[Export ("profileImageLargeURL")]
		string ProfileImageLargeURL { get; }

		// @property (readonly, copy, nonatomic) NSString * formattedScreenName;
		[Export ("formattedScreenName")]
		string FormattedScreenName { get; }

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)dictionary;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// +(NSArray *)usersWithJSONArray:(NSArray *)array;
		[Static]
		[Export ("usersWithJSONArray:")]
		//[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
		NSObject[] UsersWithJSONArray (NSObject[] array);
	}

	// @interface TWTRUserTimelineDataSource : NSObject <TWTRTimelineDataSource>
	[BaseType (typeof(TWTRTimelineDataSource))]
	interface TWTRUserTimelineDataSource : TWTRTimelineDataSource
	{
		// @property (readonly, copy, nonatomic) NSString * screenName;
		[Export ("screenName")]
		string ScreenName { get; }

		// @property (readonly, copy, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserID { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxTweetsPerRequest;
		[Export ("maxTweetsPerRequest", ArgumentSemantic.Assign)]
		nuint MaxTweetsPerRequest { get; }

		// @property (readonly, assign, nonatomic) BOOL includeReplies;
		[Export ("includeReplies")]
		bool IncludeReplies { get; }

		// @property (readonly, assign, nonatomic) BOOL includeRetweets;
		[Export ("includeRetweets")]
		bool IncludeRetweets { get; }

		// -(instancetype)initWithScreenName:(NSString *)screenName APIClient:(TWTRAPIClient *)client __attribute__((nonnull()));
		[Export ("initWithScreenName:APIClient:")]
		IntPtr Constructor (string screenName, TWTRAPIClient client);

		// -(instancetype)initWithScreenName:(NSString *)screenName userID:(NSString *)userID APIClient:(TWTRAPIClient *)client maxTweetsPerRequest:(NSUInteger)maxTweetsPerRequest includeReplies:(BOOL)includeReplies includeRetweets:(BOOL)includeRetweets __attribute__((objc_designated_initializer)) __attribute__((nonnull(2)));
		[Export ("initWithScreenName:userID:APIClient:maxTweetsPerRequest:includeReplies:includeRetweets:")]
		IntPtr Constructor (string screenName, string userID, TWTRAPIClient client, nuint maxTweetsPerRequest, bool includeReplies, bool includeRetweets);
	}
}

