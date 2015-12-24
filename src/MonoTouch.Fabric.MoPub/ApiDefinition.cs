using System;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace MonoTouch.Fabric.MoPubKit
{
	// @interface MPNativeAd : NSObject
	[BaseType (typeof(NSObject))]
	interface MPNativeAd
	{
		[Wrap ("WeakDelegate")]
		MPNativeAdDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MPNativeAdDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) NSDictionary * properties;
		[Export ("properties")]
		NSDictionary Properties { get; }

		// @property (readonly, nonatomic) NSURL * defaultActionURL;
		[Export ("defaultActionURL")]
		NSUrl DefaultActionURL { get; }

		// @property (readonly, nonatomic) NSNumber * starRating;
		[Export ("starRating")]
		NSNumber StarRating { get; }

		// -(instancetype)initWithAdAdapter:(id<MPNativeAdAdapter>)adAdapter;
		[Export ("initWithAdAdapter:")]
		IntPtr Constructor (MPNativeAdAdapter adAdapter);

		// -(void)prepareForDisplayInView:(UIView *)view;
		[Export ("prepareForDisplayInView:")]
		void PrepareForDisplayInView (UIView view);

		// -(void)trackImpression;
		[Export ("trackImpression")]
		void TrackImpression ();

		// -(void)trackClick;
		[Export ("trackClick")]
		void TrackClick ();

		// -(void)displayContentFromRootViewController:(UIViewController *)controller completion:(void (^)(BOOL, NSError *))completionBlock __attribute__((deprecated("")));
		[Export ("displayContentFromRootViewController:completion:")]
		void DisplayContentFromRootViewController (UIViewController controller, Action<bool, NSError> completionBlock);

		// -(void)displayContentForURL:(NSURL *)URL rootViewController:(UIViewController *)controller completion:(void (^)(BOOL, NSError *))completionBlock __attribute__((deprecated("")));
		[Export ("displayContentForURL:rootViewController:completion:")]
		void DisplayContentForURL (NSUrl URL, UIViewController controller, Action<bool, NSError> completionBlock);

		// -(void)displayContentWithCompletion:(void (^)(BOOL, NSError *))completionBlock;
		[Export ("displayContentWithCompletion:")]
		void DisplayContentWithCompletion (Action<bool, NSError> completionBlock);

		// -(void)displayContentForURL:(NSURL *)URL completion:(void (^)(BOOL, NSError *))completionBlock;
		[Export ("displayContentForURL:completion:")]
		void DisplayContentForURL (NSUrl URL, Action<bool, NSError> completionBlock);

		// -(void)trackMetricForURL:(NSURL *)URL;
		[Export ("trackMetricForURL:")]
		void TrackMetricForURL (NSUrl URL);

		// -(void)loadIconIntoImageView:(UIImageView *)imageView;
		[Export ("loadIconIntoImageView:")]
		void LoadIconIntoImageView (UIImageView imageView);

		// -(void)loadImageIntoImageView:(UIImageView *)imageView;
		[Export ("loadImageIntoImageView:")]
		void LoadImageIntoImageView (UIImageView imageView);

		// -(void)loadTitleIntoLabel:(UILabel *)label;
		[Export ("loadTitleIntoLabel:")]
		void LoadTitleIntoLabel (UILabel label);

		// -(void)loadTextIntoLabel:(UILabel *)label;
		[Export ("loadTextIntoLabel:")]
		void LoadTextIntoLabel (UILabel label);

		// -(void)loadCallToActionTextIntoLabel:(UILabel *)label;
		[Export ("loadCallToActionTextIntoLabel:")]
		void LoadCallToActionTextIntoLabel (UILabel label);

		// -(void)loadCallToActionTextIntoButton:(UIButton *)button;
		[Export ("loadCallToActionTextIntoButton:")]
		void LoadCallToActionTextIntoButton (UIButton button);

		// -(void)loadImageForURL:(NSURL *)imageURL intoImageView:(UIImageView *)imageView;
		[Export ("loadImageForURL:intoImageView:")]
		void LoadImageForURL (NSUrl imageURL, UIImageView imageView);
	}

	// @protocol MPNativeAdRendering <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPNativeAdRendering
	{
		// @required -(void)layoutAdAssets:(MPNativeAd *)adObject;
		[Abstract]
		[Export ("layoutAdAssets:")]
		void LayoutAdAssets (MPNativeAd adObject);

		// @optional +(CGSize)sizeWithMaximumWidth:(CGFloat)maximumWidth;
		[Static]
		[Export ("sizeWithMaximumWidth:")]
		CGSize SizeWithMaximumWidth (nfloat maximumWidth);

		// @optional +(UINib *)nibForAd;
		[Static]
		[Export ("nibForAd")]
		//[Verify (MethodToProperty)]
		UINib NibForAd { get; }
	}

	// @interface MPNativeAdSampleTableViewCell : UITableViewCell <MPNativeAdRendering>
	[BaseType (typeof(UITableViewCell))]
	interface MPNativeAdSampleTableViewCell : MPNativeAdRendering
	{
		// @property (nonatomic, strong) UILabel * titleLabel;
		[Export ("titleLabel", ArgumentSemantic.Strong)]
		UILabel TitleLabel { get; set; }

		// @property (nonatomic, strong) UILabel * mainTextLabel;
		[Export ("mainTextLabel", ArgumentSemantic.Strong)]
		UILabel MainTextLabel { get; set; }

		// @property (nonatomic, strong) UIImageView * iconImageView;
		[Export ("iconImageView", ArgumentSemantic.Strong)]
		UIImageView IconImageView { get; set; }

		// @property (nonatomic, strong) UIImageView * mainImageView;
		[Export ("mainImageView", ArgumentSemantic.Strong)]
		UIImageView MainImageView { get; set; }

		// @property (nonatomic, strong) UILabel * ctaLabel;
		[Export ("ctaLabel", ArgumentSemantic.Strong)]
		UILabel CtaLabel { get; set; }
	}

	// @interface MPAdConversionTracker : NSObject <NSURLConnectionDataDelegate>
	[BaseType (typeof(NSObject))]
	interface MPAdConversionTracker : INSUrlConnectionDataDelegate
	{
		// +(MPAdConversionTracker *)sharedConversionTracker;
		[Static]
		[Export ("sharedConversionTracker")]
		//[Verify (MethodToProperty)]
		MPAdConversionTracker SharedConversionTracker { get; }

		// -(void)reportApplicationOpenForApplicationID:(NSString *)appID;
		[Export ("reportApplicationOpenForApplicationID:")]
		void ReportApplicationOpenForApplicationID (string appID);
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CGSize MOPUB_BANNER_SIZE;
		[Field ("MOPUB_BANNER_SIZE")]
		CGSize MOPUB_BANNER_SIZE { get; }

		// extern const CGSize MOPUB_MEDIUM_RECT_SIZE;
		[Field ("MOPUB_MEDIUM_RECT_SIZE")]
		CGSize MOPUB_MEDIUM_RECT_SIZE { get; }

		// extern const CGSize MOPUB_LEADERBOARD_SIZE;
		[Field ("MOPUB_LEADERBOARD_SIZE")]
		CGSize MOPUB_LEADERBOARD_SIZE { get; }

		// extern const CGSize MOPUB_WIDE_SKYSCRAPER_SIZE;
		[Field ("MOPUB_WIDE_SKYSCRAPER_SIZE")]
		CGSize MOPUB_WIDE_SKYSCRAPER_SIZE { get; }
	}

	// @interface MPAdView : UIView
	[BaseType (typeof(UIView))]
	interface MPAdView
	{
		// -(id)initWithAdUnitId:(NSString *)adUnitId size:(CGSize)size;
		[Export ("initWithAdUnitId:size:")]
		IntPtr Constructor (string adUnitId, CGSize size);

		[Wrap ("WeakDelegate")]
		MPAdViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MPAdViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) NSString * adUnitId;
		[Export ("adUnitId")]
		string AdUnitId { get; set; }

		// @property (copy, nonatomic) NSString * keywords;
		[Export ("keywords")]
		string Keywords { get; set; }

		// @property (copy, nonatomic) CLLocation * location;
		[Export ("location", ArgumentSemantic.Copy)]
		CLLocation Location { get; set; }

		// @property (getter = isTesting, assign, nonatomic) BOOL testing;
		[Export ("testing")]
		bool Testing { [Bind ("isTesting")] get; set; }

		// -(void)loadAd;
		[Export ("loadAd")]
		void LoadAd ();

		// -(void)refreshAd;
		[Export ("refreshAd")]
		void RefreshAd ();

		// -(void)forceRefreshAd;
		[Export ("forceRefreshAd")]
		void ForceRefreshAd ();

		// -(void)rotateToOrientation:(UIInterfaceOrientation)newOrientation;
		[Export ("rotateToOrientation:")]
		void RotateToOrientation (UIInterfaceOrientation newOrientation);

		// -(void)lockNativeAdsToOrientation:(MPNativeAdOrientation)orientation;
		[Export ("lockNativeAdsToOrientation:")]
		void LockNativeAdsToOrientation (MPNativeAdOrientation orientation);

		// -(void)unlockNativeAdsOrientation;
		[Export ("unlockNativeAdsOrientation")]
		void UnlockNativeAdsOrientation ();

		// -(MPNativeAdOrientation)allowedNativeAdsOrientation;
		[Export ("allowedNativeAdsOrientation")]
		//[Verify (MethodToProperty)]
		MPNativeAdOrientation AllowedNativeAdsOrientation { get; }

		// -(CGSize)adContentViewSize;
		[Export ("adContentViewSize")]
		//[Verify (MethodToProperty)]
		CGSize AdContentViewSize { get; }

		// -(void)stopAutomaticallyRefreshingContents;
		[Export ("stopAutomaticallyRefreshingContents")]
		void StopAutomaticallyRefreshingContents ();

		// -(void)startAutomaticallyRefreshingContents;
		[Export ("startAutomaticallyRefreshingContents")]
		void StartAutomaticallyRefreshingContents ();

		// -(void)customEventDidLoadAd;
		[Export ("customEventDidLoadAd")]
		void CustomEventDidLoadAd ();

		// -(void)customEventDidFailToLoadAd;
		[Export ("customEventDidFailToLoadAd")]
		void CustomEventDidFailToLoadAd ();

		// -(void)customEventActionWillBegin;
		[Export ("customEventActionWillBegin")]
		void CustomEventActionWillBegin ();

		// -(void)customEventActionDidEnd;
		[Export ("customEventActionDidEnd")]
		void CustomEventActionDidEnd ();

		// -(void)setAdContentView:(UIView *)view;
		[Export ("setAdContentView:")]
		void SetAdContentView (UIView view);

		// @property (assign, nonatomic) BOOL ignoresAutorefresh;
		[Export ("ignoresAutorefresh")]
		bool IgnoresAutorefresh { get; set; }
	}

	// @protocol MPAdViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPAdViewDelegate
	{
		// @required -(UIViewController *)viewControllerForPresentingModalView;
		[Abstract]
		[Export ("viewControllerForPresentingModalView")]
		//[Verify (MethodToProperty)]
		UIViewController ViewControllerForPresentingModalView { get; }

		// @optional -(void)adViewDidLoadAd:(MPAdView *)view;
		[Export ("adViewDidLoadAd:")]
		void AdViewDidLoadAd (MPAdView view);

		// @optional -(void)adViewDidFailToLoadAd:(MPAdView *)view;
		[Export ("adViewDidFailToLoadAd:")]
		void AdViewDidFailToLoadAd (MPAdView view);

		// @optional -(void)willPresentModalViewForAd:(MPAdView *)view;
		[Export ("willPresentModalViewForAd:")]
		void WillPresentModalViewForAd (MPAdView view);

		// @optional -(void)didDismissModalViewForAd:(MPAdView *)view;
		[Export ("didDismissModalViewForAd:")]
		void DidDismissModalViewForAd (MPAdView view);

		// @optional -(void)willLeaveApplicationFromAd:(MPAdView *)view;
		[Export ("willLeaveApplicationFromAd:")]
		void WillLeaveApplicationFromAd (MPAdView view);
	}

	// @protocol MPBannerCustomEventDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPBannerCustomEventDelegate
	{
		// @required -(UIViewController *)viewControllerForPresentingModalView;
		[Abstract]
		[Export ("viewControllerForPresentingModalView")]
		//[Verify (MethodToProperty)]
		UIViewController ViewControllerForPresentingModalView { get; }

		// @required -(CLLocation *)location;
		[Abstract]
		[Export ("location")]
		//[Verify (MethodToProperty)]
		CLLocation Location { get; }

		// @required -(void)bannerCustomEvent:(MPBannerCustomEvent *)event didLoadAd:(UIView *)ad;
		[Abstract]
		[Export ("bannerCustomEvent:didLoadAd:")]
		void BannerCustomEvent (MPBannerCustomEvent _event, UIView ad);

		// @required -(void)bannerCustomEvent:(MPBannerCustomEvent *)event didFailToLoadAdWithError:(NSError *)error;
		[Abstract]
		[Export ("bannerCustomEvent:didFailToLoadAdWithError:")]
		void BannerCustomEvent (MPBannerCustomEvent _event, NSError error);

		// @required -(void)bannerCustomEventWillBeginAction:(MPBannerCustomEvent *)event;
		[Abstract]
		[Export ("bannerCustomEventWillBeginAction:")]
		void BannerCustomEventWillBeginAction (MPBannerCustomEvent _event);

		// @required -(void)bannerCustomEventDidFinishAction:(MPBannerCustomEvent *)event;
		[Abstract]
		[Export ("bannerCustomEventDidFinishAction:")]
		void BannerCustomEventDidFinishAction (MPBannerCustomEvent _event);

		// @required -(void)bannerCustomEventWillLeaveApplication:(MPBannerCustomEvent *)event;
		[Abstract]
		[Export ("bannerCustomEventWillLeaveApplication:")]
		void BannerCustomEventWillLeaveApplication (MPBannerCustomEvent _event);

		// @required -(void)trackImpression;
		[Abstract]
		[Export ("trackImpression")]
		void TrackImpression ();

		// @required -(void)trackClick;
		[Abstract]
		[Export ("trackClick")]
		void TrackClick ();
	}

	// @interface MPBannerCustomEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface MPBannerCustomEvent
	{
		// -(void)requestAdWithSize:(CGSize)size customEventInfo:(NSDictionary *)info;
		[Export ("requestAdWithSize:customEventInfo:")]
		void RequestAdWithSize (CGSize size, NSDictionary info);

		// -(void)rotateToOrientation:(UIInterfaceOrientation)newOrientation;
		[Export ("rotateToOrientation:")]
		void RotateToOrientation (UIInterfaceOrientation newOrientation);

		// -(void)didDisplayAd;
		[Export ("didDisplayAd")]
		void DidDisplayAd ();

		// -(BOOL)enableAutomaticImpressionAndClickTracking;
		[Export ("enableAutomaticImpressionAndClickTracking")]
		//[Verify (MethodToProperty)]
		bool EnableAutomaticImpressionAndClickTracking { get; }

		[Wrap ("WeakDelegate")]
		MPBannerCustomEventDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MPBannerCustomEventDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @interface MPInterstitialAdController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface MPInterstitialAdController
	{
		// +(MPInterstitialAdController *)interstitialAdControllerForAdUnitId:(NSString *)adUnitId;
		[Static]
		[Export ("interstitialAdControllerForAdUnitId:")]
		MPInterstitialAdController InterstitialAdControllerForAdUnitId (string adUnitId);

		[Wrap ("WeakDelegate")]
		MPInterstitialAdControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MPInterstitialAdControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) NSString * adUnitId;
		[Export ("adUnitId")]
		string AdUnitId { get; set; }

		// @property (copy, nonatomic) NSString * keywords;
		[Export ("keywords")]
		string Keywords { get; set; }

		// @property (copy, nonatomic) CLLocation * location;
		[Export ("location", ArgumentSemantic.Copy)]
		CLLocation Location { get; set; }

		// @property (getter = isTesting, assign, nonatomic) BOOL testing;
		[Export ("testing")]
		bool Testing { [Bind ("isTesting")] get; set; }

		// -(void)loadAd;
		[Export ("loadAd")]
		void LoadAd ();

		// @property (readonly, assign, nonatomic) BOOL ready;
		[Export ("ready")]
		bool Ready { get; }

		// -(void)showFromViewController:(UIViewController *)controller;
		[Export ("showFromViewController:")]
		void ShowFromViewController (UIViewController controller);

		// +(void)removeSharedInterstitialAdController:(MPInterstitialAdController *)controller;
		[Static]
		[Export ("removeSharedInterstitialAdController:")]
		void RemoveSharedInterstitialAdController (MPInterstitialAdController controller);

		// +(NSMutableArray *)sharedInterstitialAdControllers;
		[Static]
		[Export ("sharedInterstitialAdControllers")]
		//[Verify (MethodToProperty)]
		NSMutableArray SharedInterstitialAdControllers { get; }

		// -(void)customEventDidLoadAd __attribute__((deprecated("")));
		[Export ("customEventDidLoadAd")]
		void CustomEventDidLoadAd ();

		// -(void)customEventDidFailToLoadAd __attribute__((deprecated("")));
		[Export ("customEventDidFailToLoadAd")]
		void CustomEventDidFailToLoadAd ();

		// -(void)customEventActionWillBegin __attribute__((deprecated("")));
		[Export ("customEventActionWillBegin")]
		void CustomEventActionWillBegin ();
	}

	// @protocol MPInterstitialAdControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPInterstitialAdControllerDelegate
	{
		// @optional -(void)interstitialDidLoadAd:(MPInterstitialAdController *)interstitial;
		[Export ("interstitialDidLoadAd:")]
		void InterstitialDidLoadAd (MPInterstitialAdController interstitial);

		// @optional -(void)interstitialDidFailToLoadAd:(MPInterstitialAdController *)interstitial;
		[Export ("interstitialDidFailToLoadAd:")]
		void InterstitialDidFailToLoadAd (MPInterstitialAdController interstitial);

		// @optional -(void)interstitialWillAppear:(MPInterstitialAdController *)interstitial;
		[Export ("interstitialWillAppear:")]
		void InterstitialWillAppear (MPInterstitialAdController interstitial);

		// @optional -(void)interstitialDidAppear:(MPInterstitialAdController *)interstitial;
		[Export ("interstitialDidAppear:")]
		void InterstitialDidAppear (MPInterstitialAdController interstitial);

		// @optional -(void)interstitialWillDisappear:(MPInterstitialAdController *)interstitial;
		[Export ("interstitialWillDisappear:")]
		void InterstitialWillDisappear (MPInterstitialAdController interstitial);

		// @optional -(void)interstitialDidDisappear:(MPInterstitialAdController *)interstitial;
		[Export ("interstitialDidDisappear:")]
		void InterstitialDidDisappear (MPInterstitialAdController interstitial);

		// @optional -(void)interstitialDidExpire:(MPInterstitialAdController *)interstitial;
		[Export ("interstitialDidExpire:")]
		void InterstitialDidExpire (MPInterstitialAdController interstitial);

		// @optional -(void)interstitialDidReceiveTapEvent:(MPInterstitialAdController *)interstitial;
		[Export ("interstitialDidReceiveTapEvent:")]
		void InterstitialDidReceiveTapEvent (MPInterstitialAdController interstitial);

		// @optional -(void)dismissInterstitial:(MPInterstitialAdController *)interstitial __attribute__((deprecated("")));
		[Export ("dismissInterstitial:")]
		void DismissInterstitial (MPInterstitialAdController interstitial);
	}

	// @protocol MPInterstitialCustomEventDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPInterstitialCustomEventDelegate
	{
		// @required -(CLLocation *)location;
		[Abstract]
		[Export ("location")]
		//[Verify (MethodToProperty)]
		CLLocation Location { get; }

		// @required -(void)interstitialCustomEvent:(MPInterstitialCustomEvent *)customEvent didLoadAd:(id)ad;
		[Abstract]
		[Export ("interstitialCustomEvent:didLoadAd:")]
		void InterstitialCustomEvent (MPInterstitialCustomEvent customEvent, NSObject ad);

		// @required -(void)interstitialCustomEvent:(MPInterstitialCustomEvent *)customEvent didFailToLoadAdWithError:(NSError *)error;
		[Abstract]
		[Export ("interstitialCustomEvent:didFailToLoadAdWithError:")]
		void InterstitialCustomEvent (MPInterstitialCustomEvent customEvent, NSError error);

		// @required -(void)interstitialCustomEventDidExpire:(MPInterstitialCustomEvent *)customEvent;
		[Abstract]
		[Export ("interstitialCustomEventDidExpire:")]
		void InterstitialCustomEventDidExpire (MPInterstitialCustomEvent customEvent);

		// @required -(void)interstitialCustomEventWillAppear:(MPInterstitialCustomEvent *)customEvent;
		[Abstract]
		[Export ("interstitialCustomEventWillAppear:")]
		void InterstitialCustomEventWillAppear (MPInterstitialCustomEvent customEvent);

		// @required -(void)interstitialCustomEventDidAppear:(MPInterstitialCustomEvent *)customEvent;
		[Abstract]
		[Export ("interstitialCustomEventDidAppear:")]
		void InterstitialCustomEventDidAppear (MPInterstitialCustomEvent customEvent);

		// @required -(void)interstitialCustomEventWillDisappear:(MPInterstitialCustomEvent *)customEvent;
		[Abstract]
		[Export ("interstitialCustomEventWillDisappear:")]
		void InterstitialCustomEventWillDisappear (MPInterstitialCustomEvent customEvent);

		// @required -(void)interstitialCustomEventDidDisappear:(MPInterstitialCustomEvent *)customEvent;
		[Abstract]
		[Export ("interstitialCustomEventDidDisappear:")]
		void InterstitialCustomEventDidDisappear (MPInterstitialCustomEvent customEvent);

		// @required -(void)interstitialCustomEventDidReceiveTapEvent:(MPInterstitialCustomEvent *)customEvent;
		[Abstract]
		[Export ("interstitialCustomEventDidReceiveTapEvent:")]
		void InterstitialCustomEventDidReceiveTapEvent (MPInterstitialCustomEvent customEvent);

		// @required -(void)interstitialCustomEventWillLeaveApplication:(MPInterstitialCustomEvent *)customEvent;
		[Abstract]
		[Export ("interstitialCustomEventWillLeaveApplication:")]
		void InterstitialCustomEventWillLeaveApplication (MPInterstitialCustomEvent customEvent);

		// @required -(void)trackImpression;
		[Abstract]
		[Export ("trackImpression")]
		void TrackImpression ();

		// @required -(void)trackClick;
		[Abstract]
		[Export ("trackClick")]
		void TrackClick ();
	}

	// @interface MPInterstitialCustomEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface MPInterstitialCustomEvent
	{
		// -(void)requestInterstitialWithCustomEventInfo:(NSDictionary *)info;
		[Export ("requestInterstitialWithCustomEventInfo:")]
		void RequestInterstitialWithCustomEventInfo (NSDictionary info);

		// -(void)showInterstitialFromRootViewController:(UIViewController *)rootViewController;
		[Export ("showInterstitialFromRootViewController:")]
		void ShowInterstitialFromRootViewController (UIViewController rootViewController);

		// -(BOOL)enableAutomaticImpressionAndClickTracking;
		[Export ("enableAutomaticImpressionAndClickTracking")]
		//[Verify (MethodToProperty)]
		bool EnableAutomaticImpressionAndClickTracking { get; }

		[Wrap ("WeakDelegate")]
		MPInterstitialCustomEventDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MPInterstitialCustomEventDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @protocol MPNativeAdAdapterDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPNativeAdAdapterDelegate
	{
		// @required -(UIViewController *)viewControllerForPresentingModalView;
		[Abstract]
		[Export ("viewControllerForPresentingModalView")]
		//[Verify (MethodToProperty)]
		UIViewController ViewControllerForPresentingModalView { get; }

		// @optional -(void)nativeAdWillLogImpression:(id<MPNativeAdAdapter>)adAdapter;
		[Export ("nativeAdWillLogImpression:")]
		void NativeAdWillLogImpression (MPNativeAdAdapter adAdapter);

		// @optional -(void)nativeAdDidClick:(id<MPNativeAdAdapter>)adAdapter;
		[Export ("nativeAdDidClick:")]
		void NativeAdDidClick (MPNativeAdAdapter adAdapter);
	}

	// @protocol MPNativeAdAdapter <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPNativeAdAdapter
	{
		// @required @property (readonly, nonatomic) NSDictionary * properties;
		[Abstract]
		[Export ("properties")]
		NSDictionary Properties { get; }

		// @required @property (readonly, nonatomic) NSURL * defaultActionURL;
		[Abstract]
		[Export ("defaultActionURL")]
		NSUrl DefaultActionURL { get; }

		// @optional -(void)displayContentForURL:(NSURL *)URL rootViewController:(UIViewController *)controller completion:(void (^)(BOOL, NSError *))completionBlock;
		[Export ("displayContentForURL:rootViewController:completion:")]
		void DisplayContentForURL (NSUrl URL, UIViewController controller, Action<bool, NSError> completionBlock);

		// @optional -(BOOL)enableThirdPartyImpressionTracking;
		[Export ("enableThirdPartyImpressionTracking")]
		//[Verify (MethodToProperty)]
		bool EnableThirdPartyImpressionTracking { get; }

		// @optional -(BOOL)enableThirdPartyClickTracking;
		[Export ("enableThirdPartyClickTracking")]
		//[Verify (MethodToProperty)]
		bool EnableThirdPartyClickTracking { get; }

		// @optional -(void)trackImpression;
		[Export ("trackImpression")]
		void TrackImpression ();

		// @optional -(void)trackClick;
		[Export ("trackClick")]
		void TrackClick ();

		[Wrap ("WeakDelegate")]
		MPNativeAdAdapterDelegate Delegate { get; set; }

		// @optional @property (nonatomic, weak) id<MPNativeAdAdapterDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @optional @property (readonly, nonatomic) NSTimeInterval requiredSecondsForImpression;
		[Export ("requiredSecondsForImpression")]
		double RequiredSecondsForImpression { get; }

		// @optional -(void)willAttachToView:(UIView *)view;
		[Export ("willAttachToView:")]
		void WillAttachToView (UIView view);

		// @optional -(void)didDetachFromView:(UIView *)view;
		[Export ("didDetachFromView:")]
		void DidDetachFromView (UIView view);
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CGFloat kUniversalStarRatingScale;
		[Field ("kUniversalStarRatingScale")]
		nfloat kUniversalStarRatingScale { get; }

		// extern const CGFloat kStarRatingMaxValue;
		[Field ("kStarRatingMaxValue")]
		nfloat kStarRatingMaxValue { get; }

		// extern const CGFloat kStarRatingMinValue;
		[Field ("kStarRatingMinValue")]
		nfloat kStarRatingMinValue { get; }

		// extern const NSTimeInterval kDefaultRequiredSecondsForImpression;
		[Field ("kDefaultRequiredSecondsForImpression")]
		double kDefaultRequiredSecondsForImpression { get; }

		// extern const NSString * kAdTitleKey;
		[Field ("kAdTitleKey")]
		NSString kAdTitleKey { get; }

		// extern const NSString * kAdTextKey;
		[Field ("kAdTextKey")]
		NSString kAdTextKey { get; }

		// extern const NSString * kAdIconImageKey;
		[Field ("kAdIconImageKey")]
		NSString kAdIconImageKey { get; }

		// extern const NSString * kAdMainImageKey;
		[Field ("kAdMainImageKey")]
		NSString kAdMainImageKey { get; }

		// extern const NSString * kAdCTATextKey;
		[Field ("kAdCTATextKey")]
		NSString kAdCTATextKey { get; }

		// extern const NSString * kAdStarRatingKey;
		[Field ("kAdStarRatingKey")]
		NSString kAdStarRatingKey { get; }
	}

	// @protocol MPNativeCustomEventDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPNativeCustomEventDelegate
	{
		// @required -(void)nativeCustomEvent:(MPNativeCustomEvent *)event didLoadAd:(MPNativeAd *)adObject;
		[Abstract]
		[Export ("nativeCustomEvent:didLoadAd:")]
		void DidLoadAd (MPNativeCustomEvent _event, MPNativeAd adObject);

		// @required -(void)nativeCustomEvent:(MPNativeCustomEvent *)event didFailToLoadAdWithError:(NSError *)error;
		[Abstract]
		[Export ("nativeCustomEvent:didFailToLoadAdWithError:")]
		void DidFailToLoadAdWithError (MPNativeCustomEvent _event, NSError error);
	}

	// @interface MPNativeCustomEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface MPNativeCustomEvent
	{
		// -(void)requestAdWithCustomEventInfo:(NSDictionary *)info;
		[Export ("requestAdWithCustomEventInfo:")]
		void RequestAdWithCustomEventInfo (NSDictionary info);

		// -(void)precacheImagesWithURLs:(NSArray *)imageURLs completionBlock:(void (^)(NSArray *))completionBlock;
		[Export ("precacheImagesWithURLs:completionBlock:")]
		//[Verify (StronglyTypedNSArray)]
		void PrecacheImagesWithURLs (NSObject[] imageURLs, Action<NSArray> completionBlock);

		[Wrap ("WeakDelegate")]
		MPNativeCustomEventDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MPNativeCustomEventDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const MoPubNativeAdsSDKDomain;
		[Field ("MoPubNativeAdsSDKDomain")]
		NSString MoPubNativeAdsSDKDomain { get; }
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const MPNativeAdErrorContentDisplayErrorReasonKey;
		[Field ("MPNativeAdErrorContentDisplayErrorReasonKey")]
		NSString MPNativeAdErrorContentDisplayErrorReasonKey { get; }
	}

	// typedef void (^MPNativeAdRequestHandler)(MPNativeAdRequest *MPNativeAd *NSError *);
	delegate void MPNativeAdRequestHandler (MPNativeAdRequest arg0, MPNativeAd arg1, NSError arg2);

	// @interface MPNativeAdRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface MPNativeAdRequest
	{
		// @property (nonatomic, strong) MPNativeAdRequestTargeting * targeting;
		[Export ("targeting", ArgumentSemantic.Strong)]
		MPNativeAdRequestTargeting Targeting { get; set; }

		// +(MPNativeAdRequest *)requestWithAdUnitIdentifier:(NSString *)identifier;
		[Static]
		[Export ("requestWithAdUnitIdentifier:")]
		MPNativeAdRequest RequestWithAdUnitIdentifier (string identifier);

		// -(void)startWithCompletionHandler:(MPNativeAdRequestHandler)handler;
		[Export ("startWithCompletionHandler:")]
		void StartWithCompletionHandler (MPNativeAdRequestHandler handler);
	}

	// @interface MPNativeAdRequestTargeting : NSObject
	[BaseType (typeof(NSObject))]
	interface MPNativeAdRequestTargeting
	{
		// +(MPNativeAdRequestTargeting *)targeting;
		[Static]
		[Export ("targeting")]
		//[Verify (MethodToProperty)]
		MPNativeAdRequestTargeting Targeting { get; }

		// @property (copy, nonatomic) NSString * keywords;
		[Export ("keywords")]
		string Keywords { get; set; }

		// @property (copy, nonatomic) CLLocation * location;
		[Export ("location", ArgumentSemantic.Copy)]
		CLLocation Location { get; set; }

		// @property (nonatomic, strong) NSSet * desiredAssets;
		[Export ("desiredAssets", ArgumentSemantic.Strong)]
		NSSet DesiredAssets { get; set; }
	}

	// @interface MPTableViewAdManager : NSObject
	[BaseType (typeof(NSObject))]
	interface MPTableViewAdManager
	{
		// -(id)initWithTableView:(UITableView *)tableView __attribute__((deprecated("")));
		[Export ("initWithTableView:")]
		IntPtr Constructor (UITableView tableView);

		// -(UITableViewCell *)adCellForAd:(MPNativeAd *)adObject cellClass:(Class)cellClass __attribute__((deprecated("")));
		[Export ("adCellForAd:cellClass:")]
		UITableViewCell AdCellForAd (MPNativeAd adObject, Class cellClass);
	}

	// @interface MPAdPositioning : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface MPAdPositioning : INSCopying
	{
		// @property (assign, nonatomic) NSUInteger repeatingInterval;
		[Export ("repeatingInterval", ArgumentSemantic.Assign)]
		nuint RepeatingInterval { get; set; }

		// @property (readonly, nonatomic, strong) NSMutableOrderedSet * fixedPositions;
		[Export ("fixedPositions", ArgumentSemantic.Strong)]
		NSMutableOrderedSet FixedPositions { get; }
	}

	// @interface MPClientAdPositioning : MPAdPositioning
	[BaseType (typeof(MPAdPositioning))]
	interface MPClientAdPositioning
	{
		// +(instancetype)positioning;
		[Static]
		[Export ("positioning")]
		MPClientAdPositioning Positioning ();

		// -(void)addFixedIndexPath:(NSIndexPath *)indexPath;
		[Export ("addFixedIndexPath:")]
		void AddFixedIndexPath (NSIndexPath indexPath);

		// -(void)enableRepeatingPositionsWithInterval:(NSUInteger)interval;
		[Export ("enableRepeatingPositionsWithInterval:")]
		void EnableRepeatingPositionsWithInterval (nuint interval);
	}

	// @interface MPServerAdPositioning : MPAdPositioning
	[BaseType (typeof(MPAdPositioning))]
	interface MPServerAdPositioning
	{
		// +(instancetype)positioning;
		[Static]
		[Export ("positioning")]
		MPServerAdPositioning Positioning ();
	}

	// @interface MPCollectionViewAdPlacer : NSObject
	[BaseType (typeof(NSObject))]
	interface MPCollectionViewAdPlacer
	{
		// +(instancetype)placerWithCollectionView:(UICollectionView *)collectionView viewController:(UIViewController *)controller defaultAdRenderingClass:(Class)defaultAdRenderingClass;
		[Static]
		[Export ("placerWithCollectionView:viewController:defaultAdRenderingClass:")]
		MPCollectionViewAdPlacer PlacerWithCollectionView (UICollectionView collectionView, UIViewController controller, Class defaultAdRenderingClass);

		// +(instancetype)placerWithCollectionView:(UICollectionView *)collectionView viewController:(UIViewController *)controller adPositioning:(MPAdPositioning *)positioning defaultAdRenderingClass:(Class)defaultAdRenderingClass;
		[Static]
		[Export ("placerWithCollectionView:viewController:adPositioning:defaultAdRenderingClass:")]
		MPCollectionViewAdPlacer PlacerWithCollectionView (UICollectionView collectionView, UIViewController controller, MPAdPositioning positioning, Class defaultAdRenderingClass);

		// -(void)loadAdsForAdUnitID:(NSString *)adUnitID;
		[Export ("loadAdsForAdUnitID:")]
		void LoadAdsForAdUnitID (string adUnitID);

		// -(void)loadAdsForAdUnitID:(NSString *)adUnitID targeting:(MPNativeAdRequestTargeting *)targeting;
		[Export ("loadAdsForAdUnitID:targeting:")]
		void LoadAdsForAdUnitID (string adUnitID, MPNativeAdRequestTargeting targeting);
	}

	// @interface MPCollectionViewAdPlacer (UICollectionView)
	[Category]
	[BaseType (typeof(UICollectionView))]
	interface UICollectionView_MPCollectionViewAdPlacer
	{
		// -(void)mp_setAdPlacer:(MPCollectionViewAdPlacer *)placer;
		[Export ("mp_setAdPlacer:")]
		void Mp_setAdPlacer (MPCollectionViewAdPlacer placer);

		// -(MPCollectionViewAdPlacer *)mp_adPlacer;
		[Export ("mp_adPlacer")]
		[Static]
		//[Verify (MethodToProperty)]
		MPCollectionViewAdPlacer Mp_adPlacer { get; }

		// -(void)mp_setDataSource:(id<UICollectionViewDataSource>)dataSource;
		[Export ("mp_setDataSource:")]
		void Mp_setDataSource (UICollectionViewDataSource dataSource);

		// -(id<UICollectionViewDataSource>)mp_dataSource;
		[Export ("mp_dataSource")]
		[Static]
		//[Verify (MethodToProperty)]
		UICollectionViewDataSource Mp_dataSource { get; }

		// -(void)mp_setDelegate:(id<UICollectionViewDelegate>)delegate;
		[Export ("mp_setDelegate:")]
		void Mp_setDelegate (UICollectionViewDelegate _delegate);

		// -(id<UICollectionViewDelegate>)mp_delegate;
		[Export ("mp_delegate")]
		[Static]
		//[Verify (MethodToProperty)]
		UICollectionViewDelegate Mp_delegate { get; }

		// -(void)mp_reloadData;
		[Export ("mp_reloadData")]
		void Mp_reloadData ();

		// -(void)mp_insertItemsAtIndexPaths:(NSArray *)indexPaths;
		[Export ("mp_insertItemsAtIndexPaths:")]
		//[Verify (StronglyTypedNSArray)]
		void Mp_insertItemsAtIndexPaths (NSObject[] indexPaths);

		// -(void)mp_deleteItemsAtIndexPaths:(NSArray *)indexPaths;
		[Export ("mp_deleteItemsAtIndexPaths:")]
		//[Verify (StronglyTypedNSArray)]
		void Mp_deleteItemsAtIndexPaths (NSObject[] indexPaths);

		// -(void)mp_reloadItemsAtIndexPaths:(NSArray *)indexPaths;
		[Export ("mp_reloadItemsAtIndexPaths:")]
		//[Verify (StronglyTypedNSArray)]
		void Mp_reloadItemsAtIndexPaths (NSObject[] indexPaths);

		// -(void)mp_moveItemAtIndexPath:(NSIndexPath *)indexPath toIndexPath:(NSIndexPath *)newIndexPath;
		[Export ("mp_moveItemAtIndexPath:toIndexPath:")]
		void Mp_moveItemAtIndexPath (NSIndexPath indexPath, NSIndexPath newIndexPath);

		// -(void)mp_insertSections:(NSIndexSet *)sections;
		[Export ("mp_insertSections:")]
		void Mp_insertSections (NSIndexSet sections);

		// -(void)mp_deleteSections:(NSIndexSet *)sections;
		[Export ("mp_deleteSections:")]
		void Mp_deleteSections (NSIndexSet sections);

		// -(void)mp_reloadSections:(NSIndexSet *)sections;
		[Export ("mp_reloadSections:")]
		void Mp_reloadSections (NSIndexSet sections);

		// -(void)mp_moveSection:(NSInteger)section toSection:(NSInteger)newSection;
		[Export ("mp_moveSection:toSection:")]
		void Mp_moveSection (nint section, nint newSection);

		// -(UICollectionViewCell *)mp_cellForItemAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("mp_cellForItemAtIndexPath:")]
		UICollectionViewCell Mp_cellForItemAtIndexPath (NSIndexPath indexPath);

		// -(id)mp_dequeueReusableCellWithReuseIdentifier:(NSString *)identifier forIndexPath:(NSIndexPath *)indexPath;
		[Export ("mp_dequeueReusableCellWithReuseIdentifier:forIndexPath:")]
		NSObject Mp_dequeueReusableCellWithReuseIdentifier (string identifier, NSIndexPath indexPath);

		// -(void)mp_deselectItemAtIndexPath:(NSIndexPath *)indexPath animated:(BOOL)animated;
		[Export ("mp_deselectItemAtIndexPath:animated:")]
		void Mp_deselectItemAtIndexPath (NSIndexPath indexPath, bool animated);

		// -(NSIndexPath *)mp_indexPathForCell:(UICollectionViewCell *)cell;
		[Export ("mp_indexPathForCell:")]
		NSIndexPath Mp_indexPathForCell (UICollectionViewCell cell);

		// -(NSIndexPath *)mp_indexPathForItemAtPoint:(CGPoint)point;
		[Export ("mp_indexPathForItemAtPoint:")]
		NSIndexPath Mp_indexPathForItemAtPoint (CGPoint point);

		// -(NSArray *)mp_indexPathsForSelectedItems;
		[Export ("mp_indexPathsForSelectedItems")]
		[Static]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Mp_indexPathsForSelectedItems { get; }

		// -(NSArray *)mp_indexPathsForVisibleItems;
		[Export ("mp_indexPathsForVisibleItems")]
		[Static]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Mp_indexPathsForVisibleItems { get; }

		// -(UICollectionViewLayoutAttributes *)mp_layoutAttributesForItemAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("mp_layoutAttributesForItemAtIndexPath:")]
		UICollectionViewLayoutAttributes Mp_layoutAttributesForItemAtIndexPath (NSIndexPath indexPath);

		// -(void)mp_scrollToItemAtIndexPath:(NSIndexPath *)indexPath atScrollPosition:(UICollectionViewScrollPosition)scrollPosition animated:(BOOL)animated;
		[Export ("mp_scrollToItemAtIndexPath:atScrollPosition:animated:")]
		void Mp_scrollToItemAtIndexPath (NSIndexPath indexPath, UICollectionViewScrollPosition scrollPosition, bool animated);

		// -(void)mp_selectItemAtIndexPath:(NSIndexPath *)indexPath animated:(BOOL)animated scrollPosition:(UICollectionViewScrollPosition)scrollPosition;
		[Export ("mp_selectItemAtIndexPath:animated:scrollPosition:")]
		void Mp_selectItemAtIndexPath (NSIndexPath indexPath, bool animated, UICollectionViewScrollPosition scrollPosition);

		// -(NSArray *)mp_visibleCells;
		[Export ("mp_visibleCells")]
		[Static]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Mp_visibleCells { get; }
	}

	// @interface MPTableViewAdPlacer : NSObject
	[BaseType (typeof(NSObject))]
	interface MPTableViewAdPlacer
	{
		// +(instancetype)placerWithTableView:(UITableView *)tableView viewController:(UIViewController *)controller defaultAdRenderingClass:(Class)defaultAdRenderingClass;
		[Static]
		[Export ("placerWithTableView:viewController:defaultAdRenderingClass:")]
		MPTableViewAdPlacer PlacerWithTableView (UITableView tableView, UIViewController controller, Class defaultAdRenderingClass);

		// +(instancetype)placerWithTableView:(UITableView *)tableView viewController:(UIViewController *)controller adPositioning:(MPAdPositioning *)positioning defaultAdRenderingClass:(Class)defaultAdRenderingClass;
		[Static]
		[Export ("placerWithTableView:viewController:adPositioning:defaultAdRenderingClass:")]
		MPTableViewAdPlacer PlacerWithTableView (UITableView tableView, UIViewController controller, MPAdPositioning positioning, Class defaultAdRenderingClass);

		// -(void)loadAdsForAdUnitID:(NSString *)adUnitID;
		[Export ("loadAdsForAdUnitID:")]
		void LoadAdsForAdUnitID (string adUnitID);

		// -(void)loadAdsForAdUnitID:(NSString *)adUnitID targeting:(MPNativeAdRequestTargeting *)targeting;
		[Export ("loadAdsForAdUnitID:targeting:")]
		void LoadAdsForAdUnitID (string adUnitID, MPNativeAdRequestTargeting targeting);
	}

	// @interface MPTableViewAdPlacer (UITableView)
	[Category]
	[BaseType (typeof(UITableView))]
	interface UITableView_MPTableViewAdPlacer
	{
		// -(void)mp_setAdPlacer:(MPTableViewAdPlacer *)placer;
		[Export ("mp_setAdPlacer:")]
		void Mp_setAdPlacer (MPTableViewAdPlacer placer);

		// -(MPTableViewAdPlacer *)mp_adPlacer;
		[Export ("mp_adPlacer")]
		[Static]
		//[Verify (MethodToProperty)]
		MPTableViewAdPlacer Mp_adPlacer { get; }

		// -(void)mp_setDataSource:(id<UITableViewDataSource>)dataSource;
		[Export ("mp_setDataSource:")]
		void Mp_setDataSource (UITableViewDataSource dataSource);

		// -(id<UITableViewDataSource>)mp_dataSource;
		[Export ("mp_dataSource")]
		[Static]
		//[Verify (MethodToProperty)]
		UITableViewDataSource Mp_dataSource { get; }

		// -(void)mp_setDelegate:(id<UITableViewDelegate>)delegate;
		[Export ("mp_setDelegate:")]
		void Mp_setDelegate (UITableViewDelegate _delegate);

		// -(id<UITableViewDelegate>)mp_delegate;
		[Export ("mp_delegate")]
		[Static]
		//[Verify (MethodToProperty)]
		UITableViewDelegate Mp_delegate { get; }

		// -(void)mp_beginUpdates;
		[Export ("mp_beginUpdates")]
		void Mp_beginUpdates ();

		// -(void)mp_endUpdates;
		[Export ("mp_endUpdates")]
		void Mp_endUpdates ();

		// -(void)mp_reloadData;
		[Export ("mp_reloadData")]
		void Mp_reloadData ();

		// -(void)mp_insertRowsAtIndexPaths:(NSArray *)indexPaths withRowAnimation:(UITableViewRowAnimation)animation;
		[Export ("mp_insertRowsAtIndexPaths:withRowAnimation:")]
		//[Verify (StronglyTypedNSArray)]
		void Mp_insertRowsAtIndexPaths (NSObject[] indexPaths, UITableViewRowAnimation animation);

		// -(void)mp_deleteRowsAtIndexPaths:(NSArray *)indexPaths withRowAnimation:(UITableViewRowAnimation)animation;
		[Export ("mp_deleteRowsAtIndexPaths:withRowAnimation:")]
		//[Verify (StronglyTypedNSArray)]
		void Mp_deleteRowsAtIndexPaths (NSObject[] indexPaths, UITableViewRowAnimation animation);

		// -(void)mp_reloadRowsAtIndexPaths:(NSArray *)indexPaths withRowAnimation:(UITableViewRowAnimation)animation;
		[Export ("mp_reloadRowsAtIndexPaths:withRowAnimation:")]
		//[Verify (StronglyTypedNSArray)]
		void Mp_reloadRowsAtIndexPaths (NSObject[] indexPaths, UITableViewRowAnimation animation);

		// -(void)mp_moveRowAtIndexPath:(NSIndexPath *)indexPath toIndexPath:(NSIndexPath *)newIndexPath;
		[Export ("mp_moveRowAtIndexPath:toIndexPath:")]
		void Mp_moveRowAtIndexPath (NSIndexPath indexPath, NSIndexPath newIndexPath);

		// -(void)mp_insertSections:(NSIndexSet *)sections withRowAnimation:(UITableViewRowAnimation)animation;
		[Export ("mp_insertSections:withRowAnimation:")]
		void Mp_insertSections (NSIndexSet sections, UITableViewRowAnimation animation);

		// -(void)mp_deleteSections:(NSIndexSet *)sections withRowAnimation:(UITableViewRowAnimation)animation;
		[Export ("mp_deleteSections:withRowAnimation:")]
		void Mp_deleteSections (NSIndexSet sections, UITableViewRowAnimation animation);

		// -(void)mp_reloadSections:(NSIndexSet *)sections withRowAnimation:(UITableViewRowAnimation)animation;
		[Export ("mp_reloadSections:withRowAnimation:")]
		void Mp_reloadSections (NSIndexSet sections, UITableViewRowAnimation animation);

		// -(void)mp_moveSection:(NSInteger)section toSection:(NSInteger)newSection;
		[Export ("mp_moveSection:toSection:")]
		void Mp_moveSection (nint section, nint newSection);

		// -(UITableViewCell *)mp_cellForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("mp_cellForRowAtIndexPath:")]
		UITableViewCell Mp_cellForRowAtIndexPath (NSIndexPath indexPath);

		// -(id)mp_dequeueReusableCellWithIdentifier:(NSString *)identifier forIndexPath:(NSIndexPath *)indexPath;
		[Export ("mp_dequeueReusableCellWithIdentifier:forIndexPath:")]
		NSObject Mp_dequeueReusableCellWithIdentifier (string identifier, NSIndexPath indexPath);

		// -(void)mp_deselectRowAtIndexPath:(NSIndexPath *)indexPath animated:(BOOL)animated;
		[Export ("mp_deselectRowAtIndexPath:animated:")]
		void Mp_deselectRowAtIndexPath (NSIndexPath indexPath, bool animated);

		// -(NSIndexPath *)mp_indexPathForCell:(UITableViewCell *)cell;
		[Export ("mp_indexPathForCell:")]
		NSIndexPath Mp_indexPathForCell (UITableViewCell cell);

		// -(NSIndexPath *)mp_indexPathForRowAtPoint:(CGPoint)point;
		[Export ("mp_indexPathForRowAtPoint:")]
		NSIndexPath Mp_indexPathForRowAtPoint (CGPoint point);

		// -(NSIndexPath *)mp_indexPathForSelectedRow;
		[Export ("mp_indexPathForSelectedRow")]
		[Static]
		//[Verify (MethodToProperty)]
		NSIndexPath Mp_indexPathForSelectedRow { get; }

		// -(NSArray *)mp_indexPathsForRowsInRect:(CGRect)rect;
		[Export ("mp_indexPathsForRowsInRect:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Mp_indexPathsForRowsInRect (CGRect rect);

		// -(NSArray *)mp_indexPathsForSelectedRows;
		[Export ("mp_indexPathsForSelectedRows")]
		[Static]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Mp_indexPathsForSelectedRows { get; }

		// -(NSArray *)mp_indexPathsForVisibleRows;
		[Export ("mp_indexPathsForVisibleRows")]
		[Static]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Mp_indexPathsForVisibleRows { get; }

		// -(CGRect)mp_rectForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("mp_rectForRowAtIndexPath:")]
		CGRect Mp_rectForRowAtIndexPath (NSIndexPath indexPath);

		// -(void)mp_scrollToRowAtIndexPath:(NSIndexPath *)indexPath atScrollPosition:(UITableViewScrollPosition)scrollPosition animated:(BOOL)animated;
		[Export ("mp_scrollToRowAtIndexPath:atScrollPosition:animated:")]
		void Mp_scrollToRowAtIndexPath (NSIndexPath indexPath, UITableViewScrollPosition scrollPosition, bool animated);

		// -(void)mp_selectRowAtIndexPath:(NSIndexPath *)indexPath animated:(BOOL)animated scrollPosition:(UITableViewScrollPosition)scrollPosition;
		[Export ("mp_selectRowAtIndexPath:animated:scrollPosition:")]
		void Mp_selectRowAtIndexPath (NSIndexPath indexPath, bool animated, UITableViewScrollPosition scrollPosition);

		// -(NSArray *)mp_visibleCells;
		[Export ("mp_visibleCells")]
		[Static]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Mp_visibleCells { get; }
	}

	// @protocol MPNativeAdDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPNativeAdDelegate
	{
		// @required -(UIViewController *)viewControllerForPresentingModalView;
		[Abstract]
		[Export ("viewControllerForPresentingModalView")]
		//[Verify (MethodToProperty)]
		UIViewController ViewControllerForPresentingModalView { get; }
	}

	// @protocol MPMediationSettingsProtocol <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPMediationSettingsProtocol
	{
	}

	// @interface MPRewardedVideo : NSObject
	[BaseType (typeof(NSObject))]
	interface MPRewardedVideo
	{
		// +(void)loadRewardedVideoAdWithAdUnitID:(NSString *)adUnitID withMediationSettings:(NSArray *)mediationSettings;
		[Static]
		[Export ("loadRewardedVideoAdWithAdUnitID:withMediationSettings:")]
		//[Verify (StronglyTypedNSArray)]
		void LoadRewardedVideoAdWithAdUnitID (string adUnitID, NSObject[] mediationSettings);

		// +(BOOL)hasAdAvailableForAdUnitID:(NSString *)adUnitID;
		[Static]
		[Export ("hasAdAvailableForAdUnitID:")]
		bool HasAdAvailableForAdUnitID (string adUnitID);

		// +(void)presentRewardedVideoAdForAdUnitID:(NSString *)adUnitID fromViewController:(UIViewController *)viewController;
		[Static]
		[Export ("presentRewardedVideoAdForAdUnitID:fromViewController:")]
		void PresentRewardedVideoAdForAdUnitID (string adUnitID, UIViewController viewController);
	}

	// @protocol MPRewardedVideoDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPRewardedVideoDelegate
	{
		// @optional -(void)rewardedVideoAdDidLoadForAdUnitID:(NSString *)adUnitID;
		[Export ("rewardedVideoAdDidLoadForAdUnitID:")]
		void RewardedVideoAdDidLoadForAdUnitID (string adUnitID);

		// @optional -(void)rewardedVideoAdDidFailToLoadForAdUnitID:(NSString *)adUnitID error:(NSError *)error;
		[Export ("rewardedVideoAdDidFailToLoadForAdUnitID:error:")]
		void RewardedVideoAdDidFailToLoadForAdUnitID (string adUnitID, NSError error);

		// @optional -(void)rewardedVideoAdDidExpireForAdUnitID:(NSString *)adUnitID;
		[Export ("rewardedVideoAdDidExpireForAdUnitID:")]
		void RewardedVideoAdDidExpireForAdUnitID (string adUnitID);

		// @optional -(void)rewardedVideoAdDidFailToPlayForAdUnitID:(NSString *)adUnitID error:(NSError *)error;
		[Export ("rewardedVideoAdDidFailToPlayForAdUnitID:error:")]
		void RewardedVideoAdDidFailToPlayForAdUnitID (string adUnitID, NSError error);

		// @optional -(void)rewardedVideoAdWillAppearForAdUnitID:(NSString *)adUnitID;
		[Export ("rewardedVideoAdWillAppearForAdUnitID:")]
		void RewardedVideoAdWillAppearForAdUnitID (string adUnitID);

		// @optional -(void)rewardedVideoAdDidAppearForAdUnitID:(NSString *)adUnitID;
		[Export ("rewardedVideoAdDidAppearForAdUnitID:")]
		void RewardedVideoAdDidAppearForAdUnitID (string adUnitID);

		// @optional -(void)rewardedVideoAdWillDisappearForAdUnitID:(NSString *)adUnitID;
		[Export ("rewardedVideoAdWillDisappearForAdUnitID:")]
		void RewardedVideoAdWillDisappearForAdUnitID (string adUnitID);

		// @optional -(void)rewardedVideoAdDidDisappearForAdUnitID:(NSString *)adUnitID;
		[Export ("rewardedVideoAdDidDisappearForAdUnitID:")]
		void RewardedVideoAdDidDisappearForAdUnitID (string adUnitID);

		// @optional -(void)rewardedVideoAdDidReceiveTapEventForAdUnitID:(NSString *)adUnitID;
		[Export ("rewardedVideoAdDidReceiveTapEventForAdUnitID:")]
		void RewardedVideoAdDidReceiveTapEventForAdUnitID (string adUnitID);

		// @optional -(void)rewardedVideoAdWillLeaveApplicationForAdUnitID:(NSString *)adUnitID;
		[Export ("rewardedVideoAdWillLeaveApplicationForAdUnitID:")]
		void RewardedVideoAdWillLeaveApplicationForAdUnitID (string adUnitID);

		// @optional -(void)rewardedVideoAdShouldRewardForAdUnitID:(NSString *)adUnitID reward:(MPRewardedVideoReward *)reward;
		[Export ("rewardedVideoAdShouldRewardForAdUnitID:reward:")]
		void RewardedVideoAdShouldRewardForAdUnitID (string adUnitID, MPRewardedVideoReward reward);
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kMPRewardedVideoRewardCurrencyTypeUnspecified;
		[Field ("kMPRewardedVideoRewardCurrencyTypeUnspecified")]
		NSString kMPRewardedVideoRewardCurrencyTypeUnspecified { get; }

		// extern const NSInteger kMPRewardedVideoRewardCurrencyAmountUnspecified;
		[Field ("kMPRewardedVideoRewardCurrencyAmountUnspecified")]
		nint kMPRewardedVideoRewardCurrencyAmountUnspecified { get; }
	}

	// @interface MPRewardedVideoReward : NSObject
	[BaseType (typeof(NSObject))]
	interface MPRewardedVideoReward
	{
		// @property (readonly, nonatomic) NSString * currencyType;
		[Export ("currencyType")]
		string CurrencyType { get; }

		// @property (readonly, nonatomic) NSNumber * amount;
		[Export ("amount")]
		NSNumber Amount { get; }

		// -(instancetype)initWithCurrencyAmount:(NSNumber *)amount;
		[Export ("initWithCurrencyAmount:")]
		IntPtr Constructor (NSNumber amount);

		// -(instancetype)initWithCurrencyType:(NSString *)currencyType amount:(NSNumber *)amount;
		[Export ("initWithCurrencyType:amount:")]
		IntPtr Constructor (string currencyType, NSNumber amount);
	}

	// @interface MPRewardedVideoCustomEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface MPRewardedVideoCustomEvent
	{
		[Wrap ("WeakDelegate")]
		MPRewardedVideoCustomEventDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MPRewardedVideoCustomEventDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)requestRewardedVideoWithCustomEventInfo:(NSDictionary *)info;
		[Export ("requestRewardedVideoWithCustomEventInfo:")]
		void RequestRewardedVideoWithCustomEventInfo (NSDictionary info);

		// -(BOOL)hasAdAvailable;
		[Export ("hasAdAvailable")]
		//[Verify (MethodToProperty)]
		bool HasAdAvailable { get; }

		// -(void)presentRewardedVideoFromViewController:(UIViewController *)viewController;
		[Export ("presentRewardedVideoFromViewController:")]
		void PresentRewardedVideoFromViewController (UIViewController viewController);

		// -(BOOL)enableAutomaticImpressionAndClickTracking;
		[Export ("enableAutomaticImpressionAndClickTracking")]
		//[Verify (MethodToProperty)]
		bool EnableAutomaticImpressionAndClickTracking { get; }

		// -(void)handleAdPlayedForCustomEventNetwork;
		[Export ("handleAdPlayedForCustomEventNetwork")]
		void HandleAdPlayedForCustomEventNetwork ();

		// -(void)handleCustomEventInvalidated;
		[Export ("handleCustomEventInvalidated")]
		void HandleCustomEventInvalidated ();
	}

	// @protocol MPRewardedVideoCustomEventDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPRewardedVideoCustomEventDelegate
	{
		// @required -(id<MPMediationSettingsProtocol>)instanceMediationSettingsForClass:(Class)aClass;
		[Abstract]
		[Export ("instanceMediationSettingsForClass:")]
		MPMediationSettingsProtocol InstanceMediationSettingsForClass (Class aClass);

		// @required -(void)rewardedVideoDidLoadAdForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent;
		[Abstract]
		[Export ("rewardedVideoDidLoadAdForCustomEvent:")]
		void RewardedVideoDidLoadAdForCustomEvent (MPRewardedVideoCustomEvent customEvent);

		// @required -(void)rewardedVideoDidFailToLoadAdForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent error:(NSError *)error;
		[Abstract]
		[Export ("rewardedVideoDidFailToLoadAdForCustomEvent:error:")]
		void RewardedVideoDidFailToLoadAdForCustomEvent (MPRewardedVideoCustomEvent customEvent, NSError error);

		// @required -(void)rewardedVideoDidExpireForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent;
		[Abstract]
		[Export ("rewardedVideoDidExpireForCustomEvent:")]
		void RewardedVideoDidExpireForCustomEvent (MPRewardedVideoCustomEvent customEvent);

		// @required -(void)rewardedVideoDidFailToPlayForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent error:(NSError *)error;
		[Abstract]
		[Export ("rewardedVideoDidFailToPlayForCustomEvent:error:")]
		void RewardedVideoDidFailToPlayForCustomEvent (MPRewardedVideoCustomEvent customEvent, NSError error);

		// @required -(void)rewardedVideoWillAppearForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent;
		[Abstract]
		[Export ("rewardedVideoWillAppearForCustomEvent:")]
		void RewardedVideoWillAppearForCustomEvent (MPRewardedVideoCustomEvent customEvent);

		// @required -(void)rewardedVideoDidAppearForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent;
		[Abstract]
		[Export ("rewardedVideoDidAppearForCustomEvent:")]
		void RewardedVideoDidAppearForCustomEvent (MPRewardedVideoCustomEvent customEvent);

		// @required -(void)rewardedVideoWillDisappearForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent;
		[Abstract]
		[Export ("rewardedVideoWillDisappearForCustomEvent:")]
		void RewardedVideoWillDisappearForCustomEvent (MPRewardedVideoCustomEvent customEvent);

		// @required -(void)rewardedVideoDidDisappearForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent;
		[Abstract]
		[Export ("rewardedVideoDidDisappearForCustomEvent:")]
		void RewardedVideoDidDisappearForCustomEvent (MPRewardedVideoCustomEvent customEvent);

		// @required -(void)rewardedVideoWillLeaveApplicationForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent;
		[Abstract]
		[Export ("rewardedVideoWillLeaveApplicationForCustomEvent:")]
		void RewardedVideoWillLeaveApplicationForCustomEvent (MPRewardedVideoCustomEvent customEvent);

		// @required -(void)rewardedVideoDidReceiveTapEventForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent;
		[Abstract]
		[Export ("rewardedVideoDidReceiveTapEventForCustomEvent:")]
		void RewardedVideoDidReceiveTapEventForCustomEvent (MPRewardedVideoCustomEvent customEvent);

		// @required -(void)rewardedVideoShouldRewardUserForCustomEvent:(MPRewardedVideoCustomEvent *)customEvent reward:(MPRewardedVideoReward *)reward;
		[Abstract]
		[Export ("rewardedVideoShouldRewardUserForCustomEvent:reward:")]
		void RewardedVideoShouldRewardUserForCustomEvent (MPRewardedVideoCustomEvent customEvent, MPRewardedVideoReward reward);

		// @required -(void)trackImpression;
		[Abstract]
		[Export ("trackImpression")]
		void TrackImpression ();

		// @required -(void)trackClick;
		[Abstract]
		[Export ("trackClick")]
		void TrackClick ();
	}

	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const MoPubRewardedVideoAdsSDKDomain;
		[Field ("MoPubRewardedVideoAdsSDKDomain")]
		NSString MoPubRewardedVideoAdsSDKDomain { get; }
	}

	// @interface MoPub : NSObject
	[BaseType (typeof(NSObject))]
	interface MoPub
	{
		// +(MoPub *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		MoPub SharedInstance { get; }

		// @property (assign, nonatomic) BOOL locationUpdatesEnabled;
		[Export ("locationUpdatesEnabled")]
		bool LocationUpdatesEnabled { get; set; }

		// -(void)initializeRewardedVideoWithGlobalMediationSettings:(NSArray *)globalMediationSettings delegate:(id<MPRewardedVideoDelegate>)delegate;
		[Export ("initializeRewardedVideoWithGlobalMediationSettings:delegate:")]
		//[Verify (StronglyTypedNSArray)]
		void InitializeRewardedVideoWithGlobalMediationSettings (NSObject[] globalMediationSettings, MPRewardedVideoDelegate _delegate);

		// -(id<MPMediationSettingsProtocol>)globalMediationSettingsForClass:(Class)aClass;
		[Export ("globalMediationSettingsForClass:")]
		MPMediationSettingsProtocol GlobalMediationSettingsForClass (Class aClass);

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(NSString *)version;
		[Export ("version")]
		//[Verify (MethodToProperty)]
		string Version { get; }

		// -(NSString *)bundleIdentifier;
		[Export ("bundleIdentifier")]
		//[Verify (MethodToProperty)]
		string BundleIdentifier { get; }
	}
}

