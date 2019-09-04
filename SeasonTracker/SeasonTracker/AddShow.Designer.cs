namespace SeasonTracker
{
    partial class AddShow
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
            this.PanelOKCancel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbShowName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEpisodeCount = new System.Windows.Forms.TextBox();
            this.tbSeasonNumber = new System.Windows.Forms.TextBox();
            this.PanelAddShowTextBoxes = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PanelButtons.SuspendLayout();
            this.PanelOKCancel.SuspendLayout();
            this.PanelAddShowTextBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.PanelOKCancel);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButtons.Location = new System.Drawing.Point(0, 921);
            this.PanelButtons.Margin = new System.Windows.Forms.Padding(7);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(1889, 297);
            this.PanelButtons.TabIndex = 2;
            // 
            // PanelOKCancel
            // 
            this.PanelOKCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PanelOKCancel.Controls.Add(this.btnCancel);
            this.PanelOKCancel.Controls.Add(this.btnOK);
            this.PanelOKCancel.Location = new System.Drawing.Point(743, 43);
            this.PanelOKCancel.Margin = new System.Windows.Forms.Padding(7);
            this.PanelOKCancel.Name = "PanelOKCancel";
            this.PanelOKCancel.Size = new System.Drawing.Size(466, 223);
            this.PanelOKCancel.TabIndex = 5;
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
            this.btnCancel.TabIndex = 4;
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
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbShowName
            // 
            this.tbShowName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbShowName.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShowName.Location = new System.Drawing.Point(51, 127);
            this.tbShowName.Margin = new System.Windows.Forms.Padding(7);
            this.tbShowName.Name = "tbShowName";
            this.tbShowName.Size = new System.Drawing.Size(555, 51);
            this.tbShowName.TabIndex = 0;
            this.tbShowName.Text = "Show Name";
            this.tbShowName.Click += new System.EventHandler(this.tbShowName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(155, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 88);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add Show";
            // 
            // tbEpisodeCount
            // 
            this.tbEpisodeCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEpisodeCount.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEpisodeCount.Location = new System.Drawing.Point(347, 192);
            this.tbEpisodeCount.Margin = new System.Windows.Forms.Padding(7);
            this.tbEpisodeCount.Name = "tbEpisodeCount";
            this.tbEpisodeCount.Size = new System.Drawing.Size(259, 51);
            this.tbEpisodeCount.TabIndex = 2;
            this.tbEpisodeCount.Text = "Episode Count";
            this.tbEpisodeCount.Leave += new System.EventHandler(this.tbEpisodeCount_Leave);
            // 
            // tbSeasonNumber
            // 
            this.tbSeasonNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSeasonNumber.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSeasonNumber.Location = new System.Drawing.Point(51, 192);
            this.tbSeasonNumber.Margin = new System.Windows.Forms.Padding(7);
            this.tbSeasonNumber.Name = "tbSeasonNumber";
            this.tbSeasonNumber.Size = new System.Drawing.Size(282, 51);
            this.tbSeasonNumber.TabIndex = 1;
            this.tbSeasonNumber.Text = "Season Number";
            this.tbSeasonNumber.Leave += new System.EventHandler(this.tbSeasonNumber_Leave);
            // 
            // PanelAddShowTextBoxes
            // 
            this.PanelAddShowTextBoxes.Controls.Add(this.label3);
            this.PanelAddShowTextBoxes.Controls.Add(this.label2);
            this.PanelAddShowTextBoxes.Controls.Add(this.label1);
            this.PanelAddShowTextBoxes.Controls.Add(this.tbSeasonNumber);
            this.PanelAddShowTextBoxes.Controls.Add(this.tbShowName);
            this.PanelAddShowTextBoxes.Controls.Add(this.tbEpisodeCount);
            this.PanelAddShowTextBoxes.Location = new System.Drawing.Point(645, 363);
            this.PanelAddShowTextBoxes.Name = "PanelAddShowTextBoxes";
            this.PanelAddShowTextBoxes.Size = new System.Drawing.Size(660, 332);
            this.PanelAddShowTextBoxes.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "(1 - 30)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(347, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "(1 - 30)";
            // 
            // AddShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(1889, 1218);
            this.Controls.Add(this.PanelAddShowTextBoxes);
            this.Controls.Add(this.PanelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "AddShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddShow";
            this.Load += new System.EventHandler(this.AddShow_Load);
            this.PanelButtons.ResumeLayout(false);
            this.PanelOKCancel.ResumeLayout(false);
            this.PanelAddShowTextBoxes.ResumeLayout(false);
            this.PanelAddShowTextBoxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.TextBox tbShowName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEpisodeCount;
        private System.Windows.Forms.TextBox tbSeasonNumber;
        private System.Windows.Forms.Panel PanelAddShowTextBoxes;
        private System.Windows.Forms.Panel PanelOKCancel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}