using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeasonTrackerWebApp;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Set up the connection to the database.
        //This also creates the connection string
        Database database = new Database("SeasonTrackerDatabase",
            "SeasonTrackerTable",
            "DESKTOP-9C0DIO8",
            "sa",
            "tucson");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Programatically set the anchor and dock properties of the DataGridView, Panel and Buttons
            //Form sizing (this)
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = new Size(2187, 1241);
            this.BackColor = Color.FromArgb(47, 47, 47);
            
            //DataGridView
            dataGridView1.Anchor = (AnchorStyles.Top | AnchorStyles.Left) ;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Top;

            //Panels
            BottomPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);
            BottomPanel.Dock = DockStyle.Fill;
            BottomPanel.BackColor = Color.FromArgb(47, 47, 47);

            //btnAdd.Height = BottomPanel.Height -100 ;
            //btnAdd.Width = BottomPanel.Width / 2;
            ////btnAdd.Location = new Point((BottomPanel.Width - PanelButtons.Width) / 2, (PanelNavigation.Height - PanelButtons.Height) / 2);)

            ////Align the buttons in the BottomPanel
            ////PanelButtons.Location = new Point((PanelNavigation.Width - PanelButtons.Width) / 2, (PanelNavigation.Height - PanelButtons.Height) / 2);
            ////PanelButtons.Anchor = AnchorStyles.None;


            //BottomPanel.Visible = true;
          


            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            ////Set up the connection to the database.
            ////This also creates the connection string
            //var database = new Database("SeasonTrackerDatabase",
            //    "SeasonTrackerTable",
            //    "DESKTOP-9C0DIO8",
            //    "sa",
            //    "tucson");

            var dataset = new DataSet();

            dataset = database.LoadDataGrid();

            dataGridView1.DataSource = dataset.Tables[0];

        }
    }
}
