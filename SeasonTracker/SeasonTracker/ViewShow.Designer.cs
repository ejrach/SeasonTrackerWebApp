namespace SeasonTracker
{
    partial class ViewShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.PanelOKCancelDelete = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelWatchlist = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelDetailsArea = new System.Windows.Forms.Panel();
            this.PanelButtons.SuspendLayout();
            this.PanelOKCancelDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.lblId);
            this.PanelButtons.Controls.Add(this.PanelOKCancelDelete);
            this.PanelButtons.Controls.Add(this.label1);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButtons.Location = new System.Drawing.Point(0, 996);
            this.PanelButtons.Margin = new System.Windows.Forms.Padding(7);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(1930, 297);
            this.PanelButtons.TabIndex = 3;
            this.PanelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelButtons_Paint);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.White;
            this.lblId.Location = new System.Drawing.Point(54, 251);
            this.lblId.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(56, 37);
            this.lblId.TabIndex = 12;
            this.lblId.Text = "n/a";
            // 
            // PanelOKCancelDelete
            // 
            this.PanelOKCancelDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PanelOKCancelDelete.Controls.Add(this.btnDelete);
            this.PanelOKCancelDelete.Controls.Add(this.btnCancel);
            this.PanelOKCancelDelete.Controls.Add(this.btnOK);
            this.PanelOKCancelDelete.Location = new System.Drawing.Point(630, 35);
            this.PanelOKCancelDelete.Margin = new System.Windows.Forms.Padding(7);
            this.PanelOKCancelDelete.Name = "PanelOKCancelDelete";
            this.PanelOKCancelDelete.Size = new System.Drawing.Size(708, 223);
            this.PanelOKCancelDelete.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Candara Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(469, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(239, 223);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Candara Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(234, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(233, 223);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Candara Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Margin = new System.Windows.Forms.Padding(7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(233, 223);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 251);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "Id:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1930, 128);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PanelWatchlist
            // 
            this.PanelWatchlist.AutoScroll = true;
            this.PanelWatchlist.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.PanelWatchlist.AutoScrollMinSize = new System.Drawing.Size(5, 0);
            this.PanelWatchlist.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelWatchlist.Location = new System.Drawing.Point(1382, 128);
            this.PanelWatchlist.Name = "PanelWatchlist";
            this.PanelWatchlist.Size = new System.Drawing.Size(548, 868);
            this.PanelWatchlist.TabIndex = 14;
            // 
            // PanelDetailsArea
            // 
            this.PanelDetailsArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDetailsArea.Location = new System.Drawing.Point(0, 128);
            this.PanelDetailsArea.Name = "PanelDetailsArea";
            this.PanelDetailsArea.Size = new System.Drawing.Size(1382, 868);
            this.PanelDetailsArea.TabIndex = 15;
            this.PanelDetailsArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDetailsArea_Paint);
            // 
            // ViewShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(1930, 1293);
            this.Controls.Add(this.PanelDetailsArea);
            this.Controls.Add(this.PanelWatchlist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ViewShow";
            this.Load += new System.EventHandler(this.ViewShow_Load);
            this.PanelButtons.ResumeLayout(false);
            this.PanelButtons.PerformLayout();
            this.PanelOKCancelDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel PanelWatchlist;
        private System.Windows.Forms.Panel PanelDetailsArea;
        private System.Windows.Forms.Panel PanelOKCancelDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDelete;
    }
}