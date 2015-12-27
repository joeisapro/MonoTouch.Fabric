using System;

using UIKit;

namespace TwitteKitDemo
{
    public partial class ViewController : UITableViewController
    {
        private string cellIdentifier = "TwitterKitCell";

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
            return 3;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier) ??
                       new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

            if (indexPath.Row == 0)
                cell.TextLabel.Text = "Log In With Twitter";
            else if (indexPath.Row == 1)
                cell.TextLabel.Text = "Embedded Tweet";
            else
                cell.TextLabel.Text = "Embedded User Timeline";

            return cell;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            if (indexPath.Row == 0)
            {
                var sb = UIStoryboard.FromName("Main", null);
                var ctlr = sb.InstantiateViewController("LoginViewController");
                NavigationController.PushViewController(ctlr, true);
            }
            else if (indexPath.Row == 1)
            {
                var sb = UIStoryboard.FromName("Main", null);
                var ctlr = sb.InstantiateViewController("EmbedTweetViewController");
                NavigationController.PushViewController(ctlr, true);
            }
            else
            {
                var ctlr = new UserTimelineViewController();
                NavigationController.PushViewController(ctlr, true);
            }
        }
    }
}

