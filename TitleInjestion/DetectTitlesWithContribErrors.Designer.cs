namespace TitleInjestion
{
    partial class DetectTitlesWithContribErrors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectTitlesWithContribErrors));
            this.btn_CheckContribErrors = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grdView_ContribErrors = new System.Windows.Forms.DataGridView();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_ContribErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CheckContribErrors
            // 
            this.btn_CheckContribErrors.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_CheckContribErrors.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_CheckContribErrors.FlatAppearance.BorderSize = 2;
            this.btn_CheckContribErrors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CheckContribErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_CheckContribErrors.ForeColor = System.Drawing.Color.White;
            this.btn_CheckContribErrors.Location = new System.Drawing.Point(76, 151);
            this.btn_CheckContribErrors.Name = "btn_CheckContribErrors";
            this.btn_CheckContribErrors.Size = new System.Drawing.Size(180, 40);
            this.btn_CheckContribErrors.TabIndex = 28;
            this.btn_CheckContribErrors.Text = "Identity Contributor Errors";
            this.btn_CheckContribErrors.UseVisualStyleBackColor = false;
            this.btn_CheckContribErrors.Click += new System.EventHandler(this.btn_CheckContribErrors_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Close.FlatAppearance.BorderSize = 2;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(696, 151);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(79, 40);
            this.btn_Close.TabIndex = 29;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 50F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(238, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 81);
            this.label1.TabIndex = 30;
            this.label1.Text = "Title Ingestion";
            // 
            // grdView_ContribErrors
            // 
            this.grdView_ContribErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView_ContribErrors.Location = new System.Drawing.Point(76, 261);
            this.grdView_ContribErrors.Name = "grdView_ContribErrors";
            this.grdView_ContribErrors.Size = new System.Drawing.Size(699, 256);
            this.grdView_ContribErrors.TabIndex = 31;
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Message.ForeColor = System.Drawing.Color.Red;
            this.lbl_Message.Location = new System.Drawing.Point(101, 214);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 13);
            this.lbl_Message.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(276, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // DetectTitlesWithContribErrors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(861, 570);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.grdView_ContribErrors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_CheckContribErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DetectTitlesWithContribErrors";
            this.Text = "Title Ingestion:  Identify Titles With Contrib Errors";
            this.Load += new System.EventHandler(this.DetectTitlesWithContribErrors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdView_ContribErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CheckContribErrors;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdView_ContribErrors;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}