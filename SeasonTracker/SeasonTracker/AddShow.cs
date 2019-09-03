using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * TODO: use this to change the border color of the textboxes
 * https://stackoverflow.com/questions/9768938/change-the-bordercolor-of-the-textbox
 */

namespace SimpleSeasonTracker
{
    public partial class AddShow : Form
    {
        //Create instances of objects, since the class is inaccessible due to its protection level
        static Type dbtype = typeof(Database);
        Database db = (Database)Activator.CreateInstance(dbtype, true);

        //Create instances of objects, since the class is inaccessible due to its protection level
        static Type sdtype = typeof(SeasonData);
        SeasonData season_data = (SeasonData)Activator.CreateInstance(sdtype, true);

        public AddShow()
        {
            InitializeComponent();
        }

        private void AddShow_Load(object sender, EventArgs e)
        {
            //Find the size of the Home form
            Home frmHome = new Home();
            int width = frmHome.Width;
            int height = frmHome.Height;
            //Define the size of this form
            this.Width = width;
            this.Height = height;
            //Center this form to the screen
            this.CenterToParent();

            //Center the panel add show text boxes in the form
            PanelAddShowTextBoxes.Location = new Point((this.Width - PanelAddShowTextBoxes.Width) / 2, (this.Height - PanelAddShowTextBoxes.Height) / 2);
            PanelAddShowTextBoxes.Anchor = AnchorStyles.None;

            //Place the Panel OK Cancel buttons center to the Panel Button panel
            PanelOKCancel.Location = new Point((PanelButtons.Width - PanelOKCancel.Width) / 2, (PanelButtons.Height - PanelOKCancel.Height) / 2);

            //Auto Select the first text box
            this.ActiveControl = tbShowName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Initialize the watchlist
            season_data.WatchList_Init(Convert.ToInt32(tbEpisodeCount.Text));
            
            //Add a new record
            db.AddRecord(tbShowName.Text, 
                        Convert.ToInt32(tbSeasonNumber.Text), 
                        Convert.ToInt32(tbEpisodeCount.Text), 
                        season_data.WatchList);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbShowName_Click(object sender, EventArgs e)
        {
            tbShowName.SelectAll();
        }

        private void tbSeasonNumber_Leave(object sender, EventArgs e)
        {
            bool valid = ValidateNumber(tbSeasonNumber.Text);
            if (!valid)
                this.ActiveControl = tbSeasonNumber;
        }

        private void tbEpisodeCount_Leave(object sender, EventArgs e)
        {
            bool valid = ValidateNumber(tbEpisodeCount.Text);
            if (!valid)
                this.ActiveControl = tbEpisodeCount;
        }

        private bool ValidateNumber(string value)
        {
            bool valid = false;
            int number = 0;

            try
            {
                number = Convert.ToInt32(value);
                if ((number > 0) && (number <= 30))
                {
                    valid = true;
                }
            }
            catch(Exception exc)
            {
                valid = false;
            }
            return valid;
        }
    }
}
