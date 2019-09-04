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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                PictureBox pic = new PictureBox();

                //char viewState = season_data.Watchlist_GetEpisodeViewState(episodeNum);

                //Set properties for the buttons
                pic.Click += new EventHandler(Pic_Click); //assign each button to the defined button click handler
                pic.Tag = i;                 //gives the button an index number
                pic.ImageLocation = @"C:\Users\Eric\Desktop\artwork.png";
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Size = new Size(300, 300);
                pic.Margin = new Padding(25);

                //b.Text = "EPISODE " + episodeNum;

                //b.AutoSize = true;
                //if (viewState == 'Y') //if viewed, darken button
                //    b.BackColor = Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
                //else    //if not viewed, highlight button
                //    b.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
                //b.FlatAppearance.BorderSize = 0;
                //b.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
                //b.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
                //b.FlatStyle = FlatStyle.Flat;
                //b.Font = new Font("Candara Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //b.ForeColor = Color.White;
                //b.Size = new Size(PanelWatchlist.Width - 50, 100);
                //b.UseVisualStyleBackColor = false;

                //episodeNum++;           //increment the episode number count

                flowLayoutPanel1.Controls.Add(pic);
            }
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;
            //flowLayoutPanel1.Margin = new Padding(50, 50, 50, 50);
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pic)
            {
                //Get the View State for the specific button
                int index = (int)pic.Tag;
                
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
