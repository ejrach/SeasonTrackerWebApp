using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SimpleSeasonTracker
{
    public partial class Home : Form
    {
        //TODO: UPDATE TO SEND ALL SHOW DATA
        public delegate void dPassToViewShowForm(int id, string showName, int seasonNumber, int episodeCount, string watchList);

        //Create instances of objects, since the class is inaccessible due to its protection level
        static Type dbtype = typeof(Database);
        Database db = (Database)Activator.CreateInstance(dbtype, true);

        //Create instances of objects, since the class is inaccessible due to its protection level
        static Type sdtype = typeof(SeasonData);
        SeasonData season_data = (SeasonData)Activator.CreateInstance(sdtype, true);

        DataSet ds = new DataSet();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //Center the PanelButtons in the PanelNavigation
            PanelButtons.Location = new Point((PanelNavigation.Width - PanelButtons.Width) / 2, (PanelNavigation.Height - PanelButtons.Height) / 2);
            PanelButtons.Anchor = AnchorStyles.None;

            //Center the program title label in the PanelTitle
            lblProgramTitle.Location = new Point((PanelTitle.Width - lblProgramTitle.Width) / 2, (PanelTitle.Height - lblProgramTitle.Height) / 2);
            lblProgramTitle.Anchor = AnchorStyles.None;

            //LoadHomeGrid();

            LoadLayoutPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddShow addShowForm = new AddShow();
            addShowForm.ShowDialog();

            LoadLayoutPanel();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //TODO: Add try/catch here & status reporting

        //    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //    {
        //        //gets the row index of the selected cell
        //        int row = dataGridView1.CurrentCell.RowIndex;

        //        int id = (int)dataGridView1.Rows[row].Cells[db.ID_COL_NUM].Value;
        //        string showName = dataGridView1.Rows[row].Cells[db.SHOWNAME_COL_NUM].Value.ToString();
        //        int seasonNum = (int)dataGridView1.Rows[row].Cells[db.SEASONNUM_COL_NUM].Value;
        //        int episodeCount = (int)dataGridView1.Rows[row].Cells[db.EPISODECOUNT_COL_NUM].Value;
        //        string watchList = dataGridView1.Rows[row].Cells[db.WATCHLIST_COL_NUM].Value.ToString();

        //        //Set the Watchlist property upon retrievel so that it can be parsed
        //        //season_data.WatchList = watchList;

        //        //With all the data retrieved, show the "ViewShow" form, and pass all the data
        //        ViewShow viewShowForm = new ViewShow();
        //        dPassToViewShowForm del = new dPassToViewShowForm(viewShowForm.ViewShowData);   //TODO: UPDATE TO SEND ALL SHOW DATA
        //        del(id, showName, seasonNum, episodeCount, watchList);

        //        //Show the View Show form
        //        viewShowForm.ShowDialog();

        //        //Load the data from the database - we want to get the latest updates when the child form is closed, and
        //        //focus is set back on this Home form.
        //        LoadHomeGrid();
        //    }
        //}

        //private void LoadHomeGrid()
        //{
        //    DataSet ds = db.LoadDataGrid();
        //    dataGridView1.ReadOnly = true;
        //    dataGridView1.DataSource = ds.Tables[0];
        //    dataGridView1.Sort(dataGridView1.Columns[db.ID_COL_NUM], ListSortDirection.Ascending);
        //    dataGridView1.SendToBack(); //TODO: do this temporarily
        //}

        private void LoadLayoutPanel()
        {
            ds = db.LoadDataGrid();

            int rows = ds.Tables[0].Rows.Count;

            //initialize the episode to 
            //int episode_num = 1;

            //Clear Layoutpanel
            flowLayoutPanel1.Controls.Clear();

            //TODO: if rows are "0" then display text saying add a show, or something.

            for (int i = 0; i < rows; i++)
            {
                //Initialize the season information
                int id = (int)ds.Tables[0].Rows[i][db.ID_COL_NUM];
                string showName = (string)ds.Tables[0].Rows[i][db.SHOWNAME_COL_NUM];
                int seasonNumber = (int)ds.Tables[0].Rows[i][db.SEASONNUM_COL_NUM];
                int episodeCount = (int)ds.Tables[0].Rows[i][db.EPISODECOUNT_COL_NUM];
                string watchList = (string)ds.Tables[0].Rows[i][db.WATCHLIST_COL_NUM];

                //Initialize the properties of the Artwork Control
                ShowArtworkControl artwork_control = new ShowArtworkControl();
                artwork_control.Click += new EventHandler(Season_Click);            //TODO: Need to figure out how to get a click on the picture box from the user control. Something to do with enabling the click event on an control within the user control?
                artwork_control.Anchor = AnchorStyles.None;
                artwork_control.Margin = new Padding(25);
                artwork_control.Tag = i;    //used as row index in click event

                flowLayoutPanel1.Controls.Add(artwork_control);
                                
                artwork_control.LoadArtwork(id, showName, seasonNumber, episodeCount, watchList);
            }
            //for
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
        }

        private void Season_Click(object sender, EventArgs e)
        {
            if (sender is ShowArtworkControl season)
            {
                //Get the View State for the specific button
                int row_index = (int)season.Tag;
                int id = (int)ds.Tables[0].Rows[row_index][db.ID_COL_NUM];
                string showName = (string)ds.Tables[0].Rows[row_index][db.SHOWNAME_COL_NUM];
                int seasonNum = (int)ds.Tables[0].Rows[row_index][db.SEASONNUM_COL_NUM];
                int episodeCount = (int)ds.Tables[0].Rows[row_index][db.EPISODECOUNT_COL_NUM];
                string watchList = (string)ds.Tables[0].Rows[row_index][db.WATCHLIST_COL_NUM];

                //With all the data retrieved, show the "ViewShow" form, and pass all the data
                ViewShow viewShowForm = new ViewShow();
                dPassToViewShowForm del = new dPassToViewShowForm(viewShowForm.ViewShowData);   //TODO: UPDATE TO SEND ALL SHOW DATA
                del(id, showName, seasonNum, episodeCount, watchList);

                //Show the View Show form
                viewShowForm.ShowDialog();

                //Load the data from the database - we want to get the latest updates when the child form is closed, and
                //focus is set back on this Home form.
                LoadLayoutPanel();
            }
        }

        //private void Season_EnterHover(object sender, EventArgs e)
        //{
        //    if (sender is ShowArtworkControl season)
        //    {
        //        //season.BackColor = Color.FromArgb(53, 53, 53);
        //    }
        //}

        //private void Season_LeaveHover(object sender, EventArgs e)
        //{
        //    if (sender is ShowArtworkControl season)
        //    {
        //        //season.BackColor = Color.FromArgb(47, 47, 47);
        //    }
        //}

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        //{

        //}
    }
}
