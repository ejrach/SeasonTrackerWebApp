using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;

namespace SimpleSeasonTracker
{
    public partial class ShowArtworkControl : UserControl
    {
        //Create instances of objects, since the class is inaccessible due to its protection level
        static Type artworktype = typeof(Artwork);
        Artwork artwork = (Artwork)Activator.CreateInstance(artworktype, true);

        private int _id;
        private string _showPath;
        private int _episodesWatched;
        private bool _seasonComplete;

        private const int HOVER_COLOR = 56;
        private const int REG_COLOR = 47;

        public event EventHandler ArtworkControlClicked;

        public ShowArtworkControl()
        {
            InitializeComponent();
        }

        protected virtual void OnArtworkControlClicked(EventArgs e)
        {
            var handler = ArtworkControlClicked;
            if (handler != null)
                handler(this, e);
        }

        private void ArtworkControl_Click(object sender, EventArgs e)
        {
            OnArtworkControlClicked(e);
        }

        private void ShowArtworkControl_Paint(object sender, PaintEventArgs e)
        {
            //TODO: This loads
            //Pen p = new Pen(Color.White);
            //Graphics g = e.Graphics;
            //int variance = 10;
            //g.DrawRectangle(p, new Rectangle(tbShowName.Location.X - variance, tbShowName.Location.Y - variance, tbShowName.Width + variance, tbShowName.Height + variance));
        }

        /// <summary>
        /// Load the artwork card, including information to be displayed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="showName"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="episodeCount"></param>
        public void LoadArtwork(int id, string showName, int seasonNumber, int episodeCount, string watchList)
        {
            _id = id;   //set id for access in this module
            _showPath = artwork.GetSeasonArtwork(id);
            _episodesWatched = 0;
            _seasonComplete = false;

            //Calculate the Season View State
            foreach (char c in watchList)
            {
                if (c == 'Y')
                    _episodesWatched++;
            }
            if (_episodesWatched == episodeCount)
                _seasonComplete = true;

            //pictureCover.Click += (sender, EventArgs) => { PicBox_Click(sender, EventArgs, id); };

            //With the id, load the Season Artwork. A default image will be loaded, if the actual doesn't exist. 
            pictureCover.ImageLocation = _showPath;
            pictureCover.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureCover.BringToFront();
            
            //Set the text information
            tbShowName.Text = showName;
            tbSeasonNumber.Text = "Season " + seasonNumber.ToString();
            tbEpisodeCount.Text = episodeCount.ToString() + " Episodes";
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            //For now, this uses the windows file dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Artwork Cover";
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "png file (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //get the path and filename of the current specified file
                    string filePath = openFileDialog.FileName;

                    //Rename it and copy the file into the show path folder (based on id)
                    File.Copy(filePath, artwork.GetArtworkPathWithIDAndFileName(_id), true);

                    //Now reload the image after selecting it
                    pictureCover.ImageLocation = artwork.GetArtworkPathWithIDAndFileName(_id);
                    pictureCover.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        //private void PicBox_Click(object sender, EventArgs e, int id)
        //{
        //    int test = id;
        //}


        private void pictureCover_Click(object sender, EventArgs e)
        {
            //if (sender is ShowArtworkControl season)
            //{
            //}
        }

        private void ShowArtworkControl_Load(object sender, EventArgs e)
        {

        }

        private void pictureCover_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(HOVER_COLOR, HOVER_COLOR, HOVER_COLOR);
            //pictureCover.BackColor = Color.FromArgb(76, 76, 76);
            tbShowName.BackColor = Color.FromArgb(HOVER_COLOR, HOVER_COLOR, HOVER_COLOR);
            tbSeasonNumber.BackColor = Color.FromArgb(HOVER_COLOR, HOVER_COLOR, HOVER_COLOR);
            tbEpisodeCount.BackColor = Color.FromArgb(HOVER_COLOR, HOVER_COLOR, HOVER_COLOR);
        }

        private void pictureCover_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(REG_COLOR, REG_COLOR, REG_COLOR);
            //pictureCover.BackColor = Color.FromArgb(47, 47, 47);
            tbShowName.BackColor = Color.FromArgb(REG_COLOR, REG_COLOR, REG_COLOR);
            tbSeasonNumber.BackColor = Color.FromArgb(REG_COLOR, REG_COLOR, REG_COLOR);
            tbEpisodeCount.BackColor = Color.FromArgb(REG_COLOR, REG_COLOR, REG_COLOR);
        }

        private void tbShowName_MouseHover(object sender, EventArgs e)
        {

        }

        private void tbShowName_MouseLeave(object sender, EventArgs e)
        {

        }

        //private void pictureCover_MouseHover(object sender, EventArgs e)
        //{
        //    this.BackColor = Color.Red;
        //}

        //private void pictureCover_MouseLeave(object sender, EventArgs e)
        //{
        //    this.BackColor = Color.Blue;
        //}
    }
}
