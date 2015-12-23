using System;

namespace MonoTouch.Fabric.MoPubKit
{
	public enum MPNativeAdOrientation : uint
	{
		Any,
		Portrait,
		Landscape
	}

	public enum MPNativeAdErrorCode
	{
		Unknown = -1,
		HTTPError = -1000,
		InvalidServerResponse = -1001,
		NoInventory = -1002,
		ImageDownloadFailed = -1003,
		AdUnitWarmingUp = -1004,
		ContentDisplayError = -1100
	}

	public enum MPRewardedVideoErrorCode
	{
		Unknown = -1,
		Timeout = -1000,
		AdUnitWarmingUp = -1001,
		NoAdsAvailable = -1100,
		InvalidCustomEvent = -1200,
		MismatchingAdTypes = -1300,
		AdAlreadyPlayed = -1400,
		InvalidAdUnitID = -1500
	}
}

