namespace TitleInjestion
{
    partial class Stage1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stage1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_MediaType = new System.Windows.Forms.Label();
            this.lbl_Publisher = new System.Windows.Forms.Label();
            this.lbl_CleanUp = new System.Windows.Forms.Label();
            this.lbl_Extraction = new System.Windows.Forms.Label();
            this.lbl_Processing = new System.Windows.Forms.Label();
            this.lbl_Complete = new System.Windows.Forms.Label();
            this.Grd_MetaDataPub = new System.Windows.Forms.DataGridView();
            this.TitleIngestion = new System.Windows.Forms.Label();
            this.lbl_PublisheraName = new System.Windows.Forms.Label();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.lbl_Insertion = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Home = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.btn_ErrorLog = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_MetaDataPub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(405, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Publisher :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(392, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Media Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(398, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "File Name  :";
            // 
            // lbl_MediaType
            // 
            this.lbl_MediaType.AutoSize = true;
            this.lbl_MediaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_MediaType.Location = new System.Drawing.Point(504, 483);
            this.lbl_MediaType.Name = "lbl_MediaType";
            this.lbl_MediaType.Size = new System.Drawing.Size(0, 22);
            this.lbl_MediaType.TabIndex = 3;
            // 
            // lbl_Publisher
            // 
            this.lbl_Publisher.AutoSize = true;
            this.lbl_Publisher.Location = new System.Drawing.Point(468, 511);
            this.lbl_Publisher.Name = "lbl_Publisher";
            this.lbl_Publisher.Size = new System.Drawing.Size(0, 13);
            this.lbl_Publisher.TabIndex = 4;
            // 
            // lbl_CleanUp
            // 
            this.lbl_CleanUp.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_CleanUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_CleanUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CleanUp.Location = new System.Drawing.Point(65, 590);
            this.lbl_CleanUp.Name = "lbl_CleanUp";
            this.lbl_CleanUp.Size = new System.Drawing.Size(150, 43);
            this.lbl_CleanUp.TabIndex = 6;
            this.lbl_CleanUp.Text = "Clean Up";
            this.lbl_CleanUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Extraction
            // 
            this.lbl_Extraction.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_Extraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Extraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Extraction.Location = new System.Drawing.Point(290, 590);
            this.lbl_Extraction.Name = "lbl_Extraction";
            this.lbl_Extraction.Size = new System.Drawing.Size(150, 43);
            this.lbl_Extraction.TabIndex = 7;
            this.lbl_Extraction.Text = "Extraction";
            this.lbl_Extraction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Processing
            // 
            this.lbl_Processing.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_Processing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Processing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Processing.Location = new System.Drawing.Point(746, 590);
            this.lbl_Processing.Name = "lbl_Processing";
            this.lbl_Processing.Size = new System.Drawing.Size(150, 43);
            this.lbl_Processing.TabIndex = 8;
            this.lbl_Processing.Text = "Processing";
            this.lbl_Processing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Complete
            // 
            this.lbl_Complete.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_Complete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Complete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Complete.Location = new System.Drawing.Point(975, 590);
            this.lbl_Complete.Name = "lbl_Complete";
            this.lbl_Complete.Size = new System.Drawing.Size(150, 43);
            this.lbl_Complete.TabIndex = 9;
            this.lbl_Complete.Text = "Complete";
            this.lbl_Complete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Grd_MetaDataPub
            // 
            this.Grd_MetaDataPub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_MetaDataPub.Location = new System.Drawing.Point(24, 204);
            this.Grd_MetaDataPub.Name = "Grd_MetaDataPub";
            this.Grd_MetaDataPub.Size = new System.Drawing.Size(1134, 189);
            this.Grd_MetaDataPub.TabIndex = 14;
            // 
            // TitleIngestion
            // 
            this.TitleIngestion.AutoSize = true;
            this.TitleIngestion.Font = new System.Drawing.Font("Bernard MT Condensed", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleIngestion.ForeColor = System.Drawing.Color.Red;
            this.TitleIngestion.Location = new System.Drawing.Point(387, 42);
            this.TitleIngestion.Name = "TitleIngestion";
            this.TitleIngestion.Size = new System.Drawing.Size(401, 81);
            this.TitleIngestion.TabIndex = 15;
            this.TitleIngestion.Text = "Title Ingestion";
            // 
            // lbl_PublisheraName
            // 
            this.lbl_PublisheraName.AutoSize = true;
            this.lbl_PublisheraName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_PublisheraName.Location = new System.Drawing.Point(504, 511);
            this.lbl_PublisheraName.Name = "lbl_PublisheraName";
            this.lbl_PublisheraName.Size = new System.Drawing.Size(0, 22);
            this.lbl_PublisheraName.TabIndex = 17;
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_FileName.Location = new System.Drawing.Point(504, 542);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(0, 22);
            this.lbl_FileName.TabIndex = 18;
            // 
            // lbl_Insertion
            // 
            this.lbl_Insertion.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_Insertion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Insertion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Insertion.Location = new System.Drawing.Point(518, 590);
            this.lbl_Insertion.Name = "lbl_Insertion";
            this.lbl_Insertion.Size = new System.Drawing.Size(150, 43);
            this.lbl_Insertion.TabIndex = 19;
            this.lbl_Insertion.Text = "Insertion";
            this.lbl_Insertion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.DimGray;
            this.btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Start.FlatAppearance.BorderSize = 2;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Start.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Start.Location = new System.Drawing.Point(499, 405);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(156, 50);
            this.btn_Start.TabIndex = 20;
            this.btn_Start.Text = "Start Ingestion";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Home
            // 
            this.btn_Home.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Home.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Home.FlatAppearance.BorderSize = 2;
            this.btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_Home.ForeColor = System.Drawing.Color.White;
            this.btn_Home.Location = new System.Drawing.Point(31, 147);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(127, 40);
            this.btn_Home.TabIndex = 27;
            this.btn_Home.Text = "Home";
            this.btn_Home.UseVisualStyleBackColor = false;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(226, 596);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 28;
            this.label4.Text = "---->";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(449, 596);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "---->";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(682, 596);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "---->";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(911, 596);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 25);
            this.label7.TabIndex = 31;
            this.label7.Text = "---->";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.ForeColor = System.Drawing.Color.Red;
            this.lbl_Message.Location = new System.Drawing.Point(409, 213);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 13);
            this.lbl_Message.TabIndex = 32;
            // 
            // btn_ErrorLog
            // 
            this.btn_ErrorLog.BackColor = System.Drawing.Color.DimGray;
            this.btn_ErrorLog.Enabled = false;
            this.btn_ErrorLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ErrorLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_ErrorLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_ErrorLog.Location = new System.Drawing.Point(174, 147);
            this.btn_ErrorLog.Name = "btn_ErrorLog";
            this.btn_ErrorLog.Size = new System.Drawing.Size(127, 40);
            this.btn_ErrorLog.TabIndex = 33;
            this.btn_ErrorLog.Text = "Error Log";
            this.btn_ErrorLog.UseVisualStyleBackColor = false;
            this.btn_ErrorLog.Click += new System.EventHandler(this.btn_ErrorLog_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(677, 405);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Stage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_ErrorLog);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Home);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lbl_Insertion);
            this.Controls.Add(this.lbl_FileName);
            this.Controls.Add(this.lbl_PublisheraName);
            this.Controls.Add(this.TitleIngestion);
            this.Controls.Add(this.Grd_MetaDataPub);
            this.Controls.Add(this.lbl_Complete);
            this.Controls.Add(this.lbl_Processing);
            this.Controls.Add(this.lbl_Extraction);
            this.Controls.Add(this.lbl_CleanUp);
            this.Controls.Add(this.lbl_Publisher);
            this.Controls.Add(this.lbl_MediaType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Stage1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title Ingestion:  Ingestion Page";
            this.Load += new System.EventHandler(this.Stage1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_MetaDataPub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_MediaType;
        private System.Windows.Forms.Label lbl_Publisher;
        private System.Windows.Forms.Label lbl_CleanUp;
        private System.Windows.Forms.Label lbl_Extraction;
        private System.Windows.Forms.Label lbl_Processing;
        private System.Windows.Forms.Label lbl_Complete;
        private System.Windows.Forms.DataGridView Grd_MetaDataPub;
        private System.Windows.Forms.Label TitleIngestion;
        private System.Windows.Forms.Label lbl_PublisheraName;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Label lbl_Insertion;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Button btn_ErrorLog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}