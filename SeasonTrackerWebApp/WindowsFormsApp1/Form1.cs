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
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            //Set up the connection to the database.
            //This also creates the connection string
            var database = new Database("SeasonTrackerDatabase",
                "SeasonTrackerTable",
                "DESKTOP-9C0DIO8",
                "sa",
                "tucson");

            var dataset = new DataSet();

            dataset = database.LoadDataGrid();

            dataGridView1.DataSource = dataset.Tables[0];
            

        }
    }
}
