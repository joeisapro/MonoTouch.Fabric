using System;
using System.CodeDom.Compiler;
using Foundation;
using MonoTouch.Fabric.TwitterKit;
using UIKit;

namespace TwitteKitDemo
{
    partial class EmbedTweetViewController : UIViewController
    {
        public EmbedTweetViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var twitter = MonoTouch.Fabric.TwitterKit.Twitter.SharedInstance;
            // TODO: Base this Tweet ID on some data from elsewhere in your app
            twitter.APIClient.LoadTweetWithID("631879971628183552", (TWTRTweet tweet, NSError error) =>
                {
                    if (tweet != null)
                    {
                        var tweetView = new TWTRTweetView(tweet, TWTRTweetViewStyle.Regular);
                        tweetView.ShowActionButtons = true;
                        tweetView.ShowBorder = true;

                        tweetView.Center = new CoreGraphics.CGPoint(View.Center.X, TopLayoutGuide.Length + tweetView.Frame.Size.Height / 2 + 22);
                        View.AddSubview(tweetView);
                    }
                    else
                        Console.WriteLine("Tweet load error: {0}", error.LocalizedDescription);
                });
        }
    }
}
