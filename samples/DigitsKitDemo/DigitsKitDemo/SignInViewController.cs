using System;
using System.CodeDom.Compiler;
using Foundation;
using MonoTouch.Fabric.DigitsKit;
using UIKit;

namespace DigitsKitDemo
{
    partial class SignInViewController : UIViewController
    {
        public SignInViewController(IntPtr handle)
            : base(handle)
        {
        }

        public bool ApplyTheme { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var authButton = DGTAuthenticateButton.ButtonWithAuthenticationCompletion((DGTSession session, NSError error) =>
                {
                    if (session != null && !string.IsNullOrEmpty(session.UserID))
                    {
                        // TODO: associate the session userID with your user model
                        var msg = string.Format("Phone number: {0}", session.PhoneNumber);
                        var alert = new UIAlertView("You are logged in!", msg, null, "OK", null);
                        alert.Show();
                    }
                    else if (error != null)
                        Console.WriteLine(string.Format("Authentication error: {0}", error.LocalizedDescription));
                });

            authButton.Center = View.Center;

            if (ApplyTheme)
                authButton.DigitsAppearance = MakeTheme();

            View.AddSubview(authButton);
        }

        private DGTAppearance MakeTheme()
        {
            var theme = new DGTAppearance();
            theme.BodyFont = UIFont.FromName("Noteworthy-Light", 16);
            theme.LabelFont = UIFont.FromName("Noteworthy-Bold", 17);
            theme.AccentColor = UIColor.FromRGBA(255.0f / 255.0f, 172 / 255.0f, 238 / 255.0f, 1);
            theme.BackgroundColor = UIColor.FromRGBA(240.0f / 255.0f, 255 / 255.0f, 250 / 255.0f, 1);
            // TODO: Set a UIImage as a logo with theme.logoImage
            return theme;
        }
    }
}
