using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSeasonTracker
{
    public partial class StyledMessageBox : Form
    {
        public StyledMessageBox()
        {
            InitializeComponent();
        }

        private void StyledMessageBox_Load(object sender, EventArgs e)
        {
            //Center the panel view show text boxes in the form
            PanelYesNo.Location = new Point((this.Width - PanelYesNo.Width) / 2, (this.Height - PanelYesNo.Height) / 2);
            PanelYesNo.Anchor = AnchorStyles.None;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            //return this.
        }

        private void btnNo_Click(object sender, EventArgs e)
        {

        }

        public DialogResult ShowMyDialog(string text)
        {
            lblMessage.Text = text;
            this.Name = "Hi";

            return this.ShowDialog();
        }
        

    }
}
