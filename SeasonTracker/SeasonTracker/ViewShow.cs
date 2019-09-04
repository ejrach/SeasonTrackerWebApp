using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeasonTracker
{
    public partial class ViewShow : Form
    {
        //Create instances of objects, since the class is inaccessible due to its protection level
        static Type dbtype = typeof(Database);
        Database db = (Database)Activator.CreateInstance(dbtype, true);

        //Create instances of objects, since the class is inaccessible due to its protection level
        static Type sdtype = typeof(SeasonData);
        SeasonData season_data = (SeasonData)Activator.CreateInstance(sdtype, true);

        //Create instances of objects, since the class is inaccessible due to its protection level
        //static Type artworktype = typeof(Artwork);
        //Artwork artwork = (Artwork)Activator.CreateInstance(artworktype, true);

        public ViewShow()
        {
            InitializeComponent();
        }

        private void ViewShow_Load(object sender, EventArgs e)
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

            //Place the Panel OK Cancel buttons center to the Panel Button panel
            PanelOKCancelDelete.Location = new Point((PanelButtons.Width - PanelOKCancelDelete.Width) / 2, (PanelButtons.Height - PanelOKCancelDelete.Height) / 2);
        }

        /// <summary>
        /// Delegate function to receive the show data from the home page
        /// </summary>
        /// <param name="showName"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="episodeCount"></param>
        public void ViewShowData(int id, string showName, int seasonNumber, int episodeCount, string watchList)
        {
            //Initialize the season data for currently viewed show
            season_data.ID = id;
            season_data.ShowName = showName;
            season_data.SeasonNumber = seasonNumber;
            season_data.EpisodeCount = episodeCount;
            season_data.WatchList = watchList;
            //season_data.Watchlist_SetSeasonViewState();

            lblId.Text = id.ToString();

            //Placement of the Artwork
            ShowArtworkControl artwork_control = new ShowArtworkControl();
            artwork_control.Location = new Point((PanelDetailsArea.Width - artwork_control.Width) / 2, (PanelDetailsArea.Height - artwork_control.Height) / 2);
            artwork_control.Anchor = AnchorStyles.None;
            PanelDetailsArea.Controls.Add(artwork_control);
            
            //Update with the show details
            artwork_control.LoadArtwork(id, showName, seasonNumber, episodeCount, watchList);
            artwork_control.BringToFront();

            SetupWatchlist(episodeCount);
        }

        private void SetupWatchlist(int count)
        {
            PanelWatchlist.Controls.Clear();
            int episodeNum = 1;     //always start at episode 1

            for (int i = 0; i < count; i++)
            {
                Button b = new Button();
                
                char viewState = season_data.Watchlist_GetSingleEpisodeViewState(episodeNum);

                //Set properties for the buttons
                b.Click += new EventHandler(WatchListButton_Click); //assign each button to the defined button click handler
                b.Text = "EPISODE " + episodeNum;
                b.Tag = episodeNum;                 //gives the button an index number
                b.AutoSize = true;
                if (viewState == 'Y') //if viewed, darken button
                    b.BackColor = Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
                else    //if not viewed, highlight button
                    b.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
                 b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
                b.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
                b.FlatStyle = FlatStyle.Flat;
                b.Font = new Font("Candara Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                b.ForeColor = Color.White;
                b.Size = new Size(PanelWatchlist.Width - 50, 100);
                b.UseVisualStyleBackColor = false;

                episodeNum++;           //increment the episode number count

                PanelWatchlist.Controls.Add(b);
            }
            PanelWatchlist.AutoScroll = true;
        }

        /// <summary>
        /// Button Click Event for the dynamically created "Watchlist" buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatchListButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                //Get the View State for the specific button
                int episodeIndex = (int)button.Tag;
                char viewState = season_data.Watchlist_GetSingleEpisodeViewState(episodeIndex);

                //If Y, change to N and change color to highlighted
                if (viewState == 'Y')
                {
                    button.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
                    season_data.Watchlist_SetSingleEpisodeViewState(episodeIndex, 'N');
                }
                else    //If N, change to Y and change color to dark
                {
                    button.BackColor = Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
                    season_data.Watchlist_SetSingleEpisodeViewState(episodeIndex, 'Y');
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //TODO: Need to figure out a better way to update. 
            //Maybe use a message box like my "StyledMessageBox", then allow user to enter

            //"Update" the record to the database and close the form
            db.UpdateRecord(season_data.ID,
                            season_data.ShowName,
                            season_data.SeasonNumber,
                            season_data.EpisodeCount,
                            season_data.WatchList);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //User has decided to cancel. Don't update records.
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StyledMessageBox myMessageBox = new StyledMessageBox();
            DialogResult result = myMessageBox.ShowMyDialog("Delete Season?");

            if (result == DialogResult.Yes)
            {
                //"Delete" the record in the database and close the form
                db.DeleteRecord(Convert.ToInt32(lblId.Text));
                this.Close();
            }
        }

        private void PanelDetailsArea_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
