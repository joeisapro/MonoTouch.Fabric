using System;

using UIKit;

namespace DigitsKitDemo
{
    public partial class ViewController : UITableViewController
    {
        private string cellIdentifier = "DigitsKitDemoCell";

        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 2;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier) ??
                       new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

            if (indexPath.Row == 0)
                cell.TextLabel.Text = "Sign In with Phone Number";
            else
                cell.TextLabel.Text = "Theme Your Digits App";

            return cell;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var sb = UIStoryboard.FromName("Main", null);
            var ctrl = sb.InstantiateViewController("SignInViewController") as SignInViewController;
            ctrl.ApplyTheme = indexPath.Row == 1;
            NavigationController.PushViewController(ctrl, true);
        }
    }
}

