using System;
using System.CodeDom.Compiler;
using Foundation;
using MonoTouch.Fabric.TwitterKit;
using UIKit;

namespace TwitteKitDemo
{
	partial class LoginViewController : UIViewController
	{
		public LoginViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var logInButton = TWTRLogInButton.ButtonWithLogInCompletion((TWTRSession session, NSError error) =>
                {
                    if (session != null)
                    {
                        // Callback for login success or failure. The TWTRSession
                        // is also available on the [Twitter sharedInstance]
                        // singleton.
                        //
                        // Here we pop an alert just to give an example of how
                        // to read Twitter user info out of a TWTRSession.
                        //
                        // TODO: Remove alert and use the TWTRSession's userID
                        // with your app's user model
                        var message = string.Format("{0} logged in! ({1})",
                            session.UserName, session.UserID);
                        UIAlertView alert = new UIAlertView("Logged in!", message, null, "OK", null);
                        alert.Show();
                    }
                    else
                        Console.WriteLine("Login error: {0}", error.LocalizedDescription);
                });

            // TODO: Change where the log in button is positioned in your view
            logInButton.Center = View.Center;
            View.AddSubview(logInButton);
        }
	}
}
