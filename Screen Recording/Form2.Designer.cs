namespace Screen_Recording
{
    partial class optForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(optForm));
            this.applyBtn = new System.Windows.Forms.PictureBox();
            this.vidFolderBtn = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picFolderBtn = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vocFolderBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.applyBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidFolderBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFolderBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vocFolderBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.applyBtn.Image = ((System.Drawing.Image)(resources.GetObject("applyBtn.Image")));
            this.applyBtn.Location = new System.Drawing.Point(405, 80);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(48, 34);
            this.applyBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.applyBtn.TabIndex = 16;
            this.applyBtn.TabStop = false;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // vidFolderBtn
            // 
            this.vidFolderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vidFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("vidFolderBtn.Image")));
            this.vidFolderBtn.Location = new System.Drawing.Point(3, 28);
            this.vidFolderBtn.Name = "vidFolderBtn";
            this.vidFolderBtn.Size = new System.Drawing.Size(48, 34);
            this.vidFolderBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.vidFolderBtn.TabIndex = 17;
            this.vidFolderBtn.TabStop = false;
            this.vidFolderBtn.Click += new System.EventHandler(this.vidFolderBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Levenim MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(57, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Video Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Levenim MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(347, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Picture Folder";
            // 
            // picFolderBtn
            // 
            this.picFolderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("picFolderBtn.Image")));
            this.picFolderBtn.Location = new System.Drawing.Point(293, 28);
            this.picFolderBtn.Name = "picFolderBtn";
            this.picFolderBtn.Size = new System.Drawing.Size(48, 34);
            this.picFolderBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFolderBtn.TabIndex = 19;
            this.picFolderBtn.TabStop = false;
            this.picFolderBtn.Click += new System.EventHandler(this.picFolderBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Levenim MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(183, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Voice Folder";
            // 
            // vocFolderBtn
            // 
            this.vocFolderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vocFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("vocFolderBtn.Image")));
            this.vocFolderBtn.Location = new System.Drawing.Point(129, 70);
            this.vocFolderBtn.Name = "vocFolderBtn";
            this.vocFolderBtn.Size = new System.Drawing.Size(48, 34);
            this.vocFolderBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.vocFolderBtn.TabIndex = 21;
            this.vocFolderBtn.TabStop = false;
            this.vocFolderBtn.Click += new System.EventHandler(this.vocFolderBtn_Click);
            // 
            // optForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(465, 134);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vocFolderBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picFolderBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vidFolderBtn);
            this.Controls.Add(this.applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "optForm";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.applyBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidFolderBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFolderBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vocFolderBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox applyBtn;
        private System.Windows.Forms.PictureBox vidFolderBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picFolderBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox vocFolderBtn;
    }
}