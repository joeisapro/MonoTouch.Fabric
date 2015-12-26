using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using MonoTouch.Fabric.TwitterCore;

namespace MonoTouch.Fabric.DigitsKit
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
    delegate void TWTRGuestLogInCompletion (TWTRGuestSession arg0, NSError arg1);

    // typedef void (^DGTUploadContactsCompletion)(DGTContactsUploadResult *NSError *);
    delegate void DGTUploadContactsCompletion (DGTContactsUploadResult arg0, NSError arg1);

    // typedef void (^DGTLookupContactsCompletion)(NSArray *NSString *NSError *);
    delegate void DGTLookupContactsCompletion (NSObject[] arg0, string arg1, NSError arg2);

    // typedef void (^DGTDeleteAllUploadedContactsCompletion)(NSError *);
    delegate void DGTDeleteAllUploadedContactsCompletion (NSError arg0);

    // @interface DGTContacts : NSObject
    [BaseType (typeof(NSObject))]
    interface DGTContacts
    {
        // +(DGTContactAccessAuthorizationStatus)contactsAccessAuthorizationStatus;
        [Static]
        [Export ("contactsAccessAuthorizationStatus")]
        //[Verify (MethodToProperty)]
        DGTContactAccessAuthorizationStatus ContactsAccessAuthorizationStatus { get; }

        // -(instancetype)initWithUserSession:(DGTSession *)userSession;
        [Export ("initWithUserSession:")]
        IntPtr Constructor (DGTSession userSession);

        // -(void)startContactsUploadWithCompletion:(DGTUploadContactsCompletion)completion;
        [Export ("startContactsUploadWithCompletion:")]
        void StartContactsUploadWithCompletion (DGTUploadContactsCompletion completion);

        // -(void)startContactsUploadWithTitle:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
        [Export ("startContactsUploadWithTitle:completion:")]
        void StartContactsUploadWithTitle (string title, DGTUploadContactsCompletion completion);

        // -(void)startContactsUploadWithPresenterViewController:(UIViewController *)presenterViewController title:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
        [Export ("startContactsUploadWithPresenterViewController:title:completion:")]
        void StartContactsUploadWithPresenterViewController (UIViewController presenterViewController, string title, DGTUploadContactsCompletion completion);

        // -(void)startContactsUploadWithDigitsAppearance:(DGTAppearance *)appearance presenterViewController:(UIViewController *)presenterViewController title:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
        [Export ("startContactsUploadWithDigitsAppearance:presenterViewController:title:completion:")]
        void StartContactsUploadWithDigitsAppearance (DGTAppearance appearance, UIViewController presenterViewController, string title, DGTUploadContactsCompletion completion);

        // -(void)lookupContactMatchesWithCursor:(NSString *)cursor completion:(DGTLookupContactsCompletion)completion;
        [Export ("lookupContactMatchesWithCursor:completion:")]
        void LookupContactMatchesWithCursor (string cursor, DGTLookupContactsCompletion completion);

        // -(void)deleteAllUploadedContactsWithCompletion:(DGTDeleteAllUploadedContactsCompletion)completion;
        [Export ("deleteAllUploadedContactsWithCompletion:")]
        void DeleteAllUploadedContactsWithCompletion (DGTDeleteAllUploadedContactsCompletion completion);
    }

    // @interface DGTContactsUploadResult : NSObject
    [BaseType (typeof(NSObject))]
    interface DGTContactsUploadResult
    {
        // @property (readonly, nonatomic) NSUInteger totalContacts;
        [Export ("totalContacts")]
        nuint TotalContacts { get; }

        // @property (readonly, nonatomic) NSUInteger numberOfUploadedContacts;
        [Export ("numberOfUploadedContacts")]
        nuint NumberOfUploadedContacts { get; }
    }

    // @protocol DGTCompletionViewController <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface DGTCompletionViewController
    {
        // @required -(void)digitsAuthenticationFinishedWithSession:(DGTSession *)session error:(NSError *)error;
        [Abstract]
        [Export ("digitsAuthenticationFinishedWithSession:error:")]
        void Error (DGTSession session, NSError error);
    }

    //[Verify (ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const DGTErrorDomain;
        [Field ("DGTErrorDomain")]
        NSString DGTErrorDomain { get; }
    }

    // @interface DGTOAuthSigning : NSObject <TWTRCoreOAuthSigning>
    [BaseType (typeof(NSObject))]
    interface DGTOAuthSigning : ITWTRCoreOAuthSigning
    {
        // -(instancetype)initWithAuthConfig:(TWTRAuthConfig *)authConfig authSession:(DGTSession *)authSession __attribute__((objc_designated_initializer));
        [Export ("initWithAuthConfig:authSession:")]
        IntPtr Constructor (TWTRAuthConfig authConfig, DGTSession authSession);

        // -(NSDictionary *)OAuthEchoHeadersToVerifyCredentialsWithParams:(NSDictionary *)params;
        [Export ("OAuthEchoHeadersToVerifyCredentialsWithParams:")]
        NSDictionary OAuthEchoHeadersToVerifyCredentialsWithParams (NSDictionary _params);
    }

    // @protocol DGTSessionUpdateDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface DGTSessionUpdateDelegate
    {
        // @required -(void)digitsSessionHasChanged:(DGTSession *)newSession;
        [Abstract]
        [Export ("digitsSessionHasChanged:")]
        void DigitsSessionHasChanged (DGTSession newSession);

        // @required -(void)digitsSessionExpiredForUserID:(NSString *)userID;
        [Abstract]
        [Export ("digitsSessionExpiredForUserID:")]
        void DigitsSessionExpiredForUserID (string userID);
    }

    // @interface DGTUser : NSObject
    [BaseType (typeof(NSObject))]
    interface DGTUser
    {
        // @property (readonly, copy, nonatomic) NSString * userID;
        [Export ("userID")]
        string UserID { get; }
    }

    // @interface DGTAppearance : NSObject <NSCopying>
    [BaseType (typeof(NSObject))]
    interface DGTAppearance : INSCopying
    {
        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export ("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * accentColor;
        [Export ("accentColor", ArgumentSemantic.Strong)]
        UIColor AccentColor { get; set; }

        // @property (nonatomic, strong) UIFont * headerFont;
        [Export ("headerFont", ArgumentSemantic.Strong)]
        UIFont HeaderFont { get; set; }

        // @property (nonatomic, strong) UIFont * labelFont;
        [Export ("labelFont", ArgumentSemantic.Strong)]
        UIFont LabelFont { get; set; }

        // @property (nonatomic, strong) UIFont * bodyFont;
        [Export ("bodyFont", ArgumentSemantic.Strong)]
        UIFont BodyFont { get; set; }

        // @property (nonatomic, strong) UIImage * logoImage;
        [Export ("logoImage", ArgumentSemantic.Strong)]
        UIImage LogoImage { get; set; }
    }

    // @interface DGTSession : NSObject <TWTRAuthSession, NSCoding>
    [BaseType (typeof(NSObject))]
    interface DGTSession : ITWTRAuthSession, INSCoding
    {
        // @property (readonly, copy, nonatomic) NSString * authToken;
        [Export ("authToken")]
        string AuthToken { get; }

        // @property (readonly, copy, nonatomic) NSString * authTokenSecret;
        [Export ("authTokenSecret")]
        string AuthTokenSecret { get; }

        // @property (readonly, copy, nonatomic) NSString * userID;
        [Export ("userID")]
        string UserID { get; }

        // @property (readonly, copy, nonatomic) NSString * phoneNumber;
        [Export ("phoneNumber")]
        string PhoneNumber { get; }

        // -(instancetype)initWithAuthToken:(NSString *)authToken authTokenSecret:(NSString *)authTokenSecret userID:(NSString *)userID phoneNumber:(NSString *)phoneNumber;
        [Export ("initWithAuthToken:authTokenSecret:userID:phoneNumber:")]
        IntPtr Constructor (string authToken, string authTokenSecret, string userID, string phoneNumber);
    }

    // typedef void (^DGTAuthenticationCompletion)(DGTSession *NSError *);
    delegate void DGTAuthenticationCompletion (DGTSession arg0, NSError arg1);

    // @interface DGTAuthenticateButton : UIButton
    [BaseType (typeof(UIButton))]
    interface DGTAuthenticateButton
    {
        // +(instancetype)buttonWithAuthenticationCompletion:(DGTAuthenticationCompletion)completion;
        [Static]
        [Export ("buttonWithAuthenticationCompletion:")]
        DGTAuthenticateButton ButtonWithAuthenticationCompletion (DGTAuthenticationCompletion completion);

        // @property (copy, nonatomic) DGTAppearance * digitsAppearance;
        [Export ("digitsAppearance", ArgumentSemantic.Copy)]
        DGTAppearance DigitsAppearance { get; set; }
    }

    // @interface Digits : NSObject
    [BaseType (typeof(NSObject))]
    interface Digits
    {
        // +(Digits *)sharedInstance;
        [Static]
        [Export ("sharedInstance")]
        //[Verify (MethodToProperty)]
        Digits SharedInstance { get; }

        // -(void)startWithConsumerKey:(NSString *)consumerKey consumerSecret:(NSString *)consumerSecret;
        [Export ("startWithConsumerKey:consumerSecret:")]
        void StartWithConsumerKey (string consumerKey, string consumerSecret);

        // -(DGTSession *)session;
        [Export ("session")]
        //[Verify (MethodToProperty)]
        DGTSession Session { get; }

        // @property (readonly, nonatomic, strong) TWTRAuthConfig * authConfig;
        [Export ("authConfig", ArgumentSemantic.Strong)]
        TWTRAuthConfig AuthConfig { get; }

        [Wrap ("WeakSessionUpdateDelegate")]
        DGTSessionUpdateDelegate SessionUpdateDelegate { get; set; }

        // @property (nonatomic, weak) id<DGTSessionUpdateDelegate> sessionUpdateDelegate;
        [NullAllowed, Export ("sessionUpdateDelegate", ArgumentSemantic.Weak)]
        NSObject WeakSessionUpdateDelegate { get; set; }

        // -(void)authenticateWithCompletion:(DGTAuthenticationCompletion)completion;
        [Export ("authenticateWithCompletion:")]
        void AuthenticateWithCompletion (DGTAuthenticationCompletion completion);

        // -(void)authenticateWithTitle:(NSString *)title completion:(DGTAuthenticationCompletion)completion;
        [Export ("authenticateWithTitle:completion:")]
        void AuthenticateWithTitle (string title, DGTAuthenticationCompletion completion);

        // -(void)authenticateWithViewController:(UIViewController *)viewController title:(NSString *)title completion:(DGTAuthenticationCompletion)completion;
        [Export ("authenticateWithViewController:title:completion:")]
        void AuthenticateWithViewController (UIViewController viewController, string title, DGTAuthenticationCompletion completion);

        // -(void)authenticateWithDigitsAppearance:(DGTAppearance *)appearance viewController:(UIViewController *)viewController title:(NSString *)title completion:(DGTAuthenticationCompletion)completion;
        [Export ("authenticateWithDigitsAppearance:viewController:title:completion:")]
        void AuthenticateWithDigitsAppearance (DGTAppearance appearance, UIViewController viewController, string title, DGTAuthenticationCompletion completion);

        // -(void)authenticateWithPhoneNumber:(NSString *)phoneNumber digitsAppearance:(DGTAppearance *)appearance viewController:(UIViewController *)viewController title:(NSString *)title completion:(DGTAuthenticationCompletion)completion;
        [Export ("authenticateWithPhoneNumber:digitsAppearance:viewController:title:completion:")]
        void AuthenticateWithPhoneNumber (string phoneNumber, DGTAppearance appearance, UIViewController viewController, string title, DGTAuthenticationCompletion completion);

        // -(void)authenticateWithNavigationViewController:(UINavigationController *)navigationController phoneNumber:(NSString *)phoneNumber digitsAppearance:(DGTAppearance *)appearance title:(NSString *)title completionViewController:(UIViewController<DGTCompletionViewController> *)completionViewController;
        [Export ("authenticateWithNavigationViewController:phoneNumber:digitsAppearance:title:completionViewController:")]
        void AuthenticateWithNavigationViewController (UINavigationController navigationController, string phoneNumber, DGTAppearance appearance, string title, DGTCompletionViewController completionViewController);

        // -(void)logOut;
        [Export ("logOut")]
        void LogOut ();
    }

}

