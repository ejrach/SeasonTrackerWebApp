namespace SimpleSeasonTracker
{
    partial class ShowArtworkControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureCover = new System.Windows.Forms.PictureBox();
            this.tbShowName = new System.Windows.Forms.TextBox();
            this.tbEpisodeCount = new System.Windows.Forms.TextBox();
            this.tbSeasonNumber = new System.Windows.Forms.TextBox();
            this.btnInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCover
            // 
            this.pictureCover.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureCover.Location = new System.Drawing.Point(0, 0);
            this.pictureCover.Name = "pictureCover";
            this.pictureCover.Size = new System.Drawing.Size(498, 425);
            this.pictureCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCover.TabIndex = 0;
            this.pictureCover.TabStop = false;
            this.pictureCover.Click += new System.EventHandler(this.pictureCover_Click);
            this.pictureCover.MouseLeave += new System.EventHandler(this.pictureCover_MouseLeave);
            this.pictureCover.MouseHover += new System.EventHandler(this.pictureCover_MouseHover);
            // 
            // tbShowName
            // 
            this.tbShowName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.tbShowName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbShowName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShowName.ForeColor = System.Drawing.Color.White;
            this.tbShowName.Location = new System.Drawing.Point(36, 453);
            this.tbShowName.Name = "tbShowName";
            this.tbShowName.Size = new System.Drawing.Size(428, 44);
            this.tbShowName.TabIndex = 1;
            this.tbShowName.Text = "Show Name";
            this.tbShowName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbShowName.MouseLeave += new System.EventHandler(this.tbShowName_MouseLeave);
            this.tbShowName.MouseHover += new System.EventHandler(this.tbShowName_MouseHover);
            // 
            // tbEpisodeCount
            // 
            this.tbEpisodeCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.tbEpisodeCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEpisodeCount.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEpisodeCount.ForeColor = System.Drawing.Color.White;
            this.tbEpisodeCount.Location = new System.Drawing.Point(36, 581);
            this.tbEpisodeCount.Name = "tbEpisodeCount";
            this.tbEpisodeCount.Size = new System.Drawing.Size(428, 44);
            this.tbEpisodeCount.TabIndex = 2;
            this.tbEpisodeCount.Text = "Episode Count";
            this.tbEpisodeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbEpisodeCount.MouseLeave += new System.EventHandler(this.tbShowName_MouseLeave);
            this.tbEpisodeCount.MouseHover += new System.EventHandler(this.tbShowName_MouseHover);
            // 
            // tbSeasonNumber
            // 
            this.tbSeasonNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.tbSeasonNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSeasonNumber.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSeasonNumber.ForeColor = System.Drawing.Color.White;
            this.tbSeasonNumber.Location = new System.Drawing.Point(36, 517);
            this.tbSeasonNumber.Name = "tbSeasonNumber";
            this.tbSeasonNumber.Size = new System.Drawing.Size(428, 44);
            this.tbSeasonNumber.TabIndex = 3;
            this.tbSeasonNumber.Text = "Season Number";
            this.tbSeasonNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSeasonNumber.MouseLeave += new System.EventHandler(this.tbShowName_MouseLeave);
            this.tbSeasonNumber.MouseHover += new System.EventHandler(this.tbShowName_MouseHover);
            // 
            // btnInfo
            // 
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Font = new System.Drawing.Font("Candara", 12F);
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Location = new System.Drawing.Point(445, 626);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(50, 50);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.Text = "i";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // ShowArtworkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.tbSeasonNumber);
            this.Controls.Add(this.tbEpisodeCount);
            this.Controls.Add(this.tbShowName);
            this.Controls.Add(this.pictureCover);
            this.Name = "ShowArtworkControl";
            this.Size = new System.Drawing.Size(498, 679);
            this.Load += new System.EventHandler(this.ShowArtworkControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ShowArtworkControl_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCover;
        private System.Windows.Forms.TextBox tbShowName;
        private System.Windows.Forms.TextBox tbEpisodeCount;
        private System.Windows.Forms.TextBox tbSeasonNumber;
        private System.Windows.Forms.Button btnInfo;
    }
}
