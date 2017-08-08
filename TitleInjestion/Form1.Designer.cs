namespace TitleInjestion
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Injestion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.TitleIngestion = new System.Windows.Forms.Label();
            this.btn_SearchForFiles = new System.Windows.Forms.Button();
            this.Grd_MetaDataPub = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstbx_Publisher = new System.Windows.Forms.ListBox();
            this.lstbx_MediaType = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.drpbx_IngestionSource = new System.Windows.Forms.ComboBox();
            this.lbl_Message2 = new System.Windows.Forms.Label();
            this.btn_Ingestion2 = new System.Windows.Forms.Button();
            this.lbl_CompanySelected = new System.Windows.Forms.Label();
            this.lbl_ErrorLogDetails = new System.Windows.Forms.Label();
            this.btn_ErrorLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_MetaDataPub)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Injestion
            // 
            this.btn_Injestion.BackColor = System.Drawing.Color.DimGray;
            this.btn_Injestion.Enabled = false;
            this.btn_Injestion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Injestion.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Injestion.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Injestion.Location = new System.Drawing.Point(520, 599);
            this.btn_Injestion.Name = "btn_Injestion";
            this.btn_Injestion.Size = new System.Drawing.Size(168, 42);
            this.btn_Injestion.TabIndex = 0;
            this.btn_Injestion.Text = "Ingestion - Stage 1";
            this.btn_Injestion.UseVisualStyleBackColor = false;
            this.btn_Injestion.Click += new System.EventHandler(this.btn_Injestion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select the Ingestion Source : ";
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Message.ForeColor = System.Drawing.Color.Red;
            this.lbl_Message.Location = new System.Drawing.Point(527, 118);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 13);
            this.lbl_Message.TabIndex = 8;
            // 
            // TitleIngestion
            // 
            this.TitleIngestion.AutoSize = true;
            this.TitleIngestion.Font = new System.Drawing.Font("Bernard MT Condensed", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleIngestion.ForeColor = System.Drawing.Color.Red;
            this.TitleIngestion.Location = new System.Drawing.Point(387, 42);
            this.TitleIngestion.Name = "TitleIngestion";
            this.TitleIngestion.Size = new System.Drawing.Size(401, 81);
            this.TitleIngestion.TabIndex = 9;
            this.TitleIngestion.Text = "Title Ingestion";
            // 
            // btn_SearchForFiles
            // 
            this.btn_SearchForFiles.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_SearchForFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_SearchForFiles.FlatAppearance.BorderSize = 3;
            this.btn_SearchForFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SearchForFiles.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SearchForFiles.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_SearchForFiles.Location = new System.Drawing.Point(525, 15);
            this.btn_SearchForFiles.Name = "btn_SearchForFiles";
            this.btn_SearchForFiles.Size = new System.Drawing.Size(137, 74);
            this.btn_SearchForFiles.TabIndex = 12;
            this.btn_SearchForFiles.Text = "Search for Available Files";
            this.btn_SearchForFiles.UseVisualStyleBackColor = false;
            this.btn_SearchForFiles.Click += new System.EventHandler(this.btn_SearchForFiles_Click);
            // 
            // Grd_MetaDataPub
            // 
            this.Grd_MetaDataPub.AllowUserToAddRows = false;
            this.Grd_MetaDataPub.AllowUserToDeleteRows = false;
            this.Grd_MetaDataPub.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.Grd_MetaDataPub.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Grd_MetaDataPub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_MetaDataPub.Location = new System.Drawing.Point(13, 380);
            this.Grd_MetaDataPub.Name = "Grd_MetaDataPub";
            this.Grd_MetaDataPub.Size = new System.Drawing.Size(1152, 199);
            this.Grd_MetaDataPub.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lstbx_Publisher);
            this.panel2.Controls.Add(this.lstbx_MediaType);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.drpbx_IngestionSource);
            this.panel2.Controls.Add(this.btn_SearchForFiles);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_Message);
            this.panel2.Location = new System.Drawing.Point(93, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 212);
            this.panel2.TabIndex = 14;
            // 
            // lstbx_Publisher
            // 
            this.lstbx_Publisher.FormattingEnabled = true;
            this.lstbx_Publisher.Location = new System.Drawing.Point(266, 115);
            this.lstbx_Publisher.Name = "lstbx_Publisher";
            this.lstbx_Publisher.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbx_Publisher.Size = new System.Drawing.Size(199, 82);
            this.lstbx_Publisher.TabIndex = 19;
            this.lstbx_Publisher.SelectedIndexChanged += new System.EventHandler(this.lstbx_Publisher_SelectedIndexChanged);
            // 
            // lstbx_MediaType
            // 
            this.lstbx_MediaType.FormattingEnabled = true;
            this.lstbx_MediaType.Location = new System.Drawing.Point(266, 48);
            this.lstbx_MediaType.Name = "lstbx_MediaType";
            this.lstbx_MediaType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbx_MediaType.Size = new System.Drawing.Size(199, 56);
            this.lstbx_MediaType.TabIndex = 18;
            this.lstbx_MediaType.SelectedValueChanged += new System.EventHandler(this.lstbx_MediaType_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Select the Media Type(s) : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Select the Publisher(s) : ";
            // 
            // drpbx_IngestionSource
            // 
            this.drpbx_IngestionSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpbx_IngestionSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpbx_IngestionSource.FormattingEnabled = true;
            this.drpbx_IngestionSource.Location = new System.Drawing.Point(266, 16);
            this.drpbx_IngestionSource.Name = "drpbx_IngestionSource";
            this.drpbx_IngestionSource.Size = new System.Drawing.Size(199, 21);
            this.drpbx_IngestionSource.TabIndex = 13;
            this.drpbx_IngestionSource.SelectedValueChanged += new System.EventHandler(this.drpbx_IngestionSource_SelectedValueChanged);
            // 
            // lbl_Message2
            // 
            this.lbl_Message2.AutoSize = true;
            this.lbl_Message2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Message2.ForeColor = System.Drawing.Color.Red;
            this.lbl_Message2.Location = new System.Drawing.Point(369, 358);
            this.lbl_Message2.Name = "lbl_Message2";
            this.lbl_Message2.Size = new System.Drawing.Size(0, 17);
            this.lbl_Message2.TabIndex = 18;
            this.lbl_Message2.Visible = false;
            // 
            // btn_Ingestion2
            // 
            this.btn_Ingestion2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Ingestion2.Enabled = false;
            this.btn_Ingestion2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Ingestion2.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ingestion2.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Ingestion2.Location = new System.Drawing.Point(771, 599);
            this.btn_Ingestion2.Name = "btn_Ingestion2";
            this.btn_Ingestion2.Size = new System.Drawing.Size(168, 42);
            this.btn_Ingestion2.TabIndex = 19;
            this.btn_Ingestion2.Text = "Ingestion - Stage 2";
            this.btn_Ingestion2.UseVisualStyleBackColor = false;
            this.btn_Ingestion2.Click += new System.EventHandler(this.btn_Ingestion2_Click);
            // 
            // lbl_CompanySelected
            // 
            this.lbl_CompanySelected.AutoSize = true;
            this.lbl_CompanySelected.Location = new System.Drawing.Point(383, 221);
            this.lbl_CompanySelected.Name = "lbl_CompanySelected";
            this.lbl_CompanySelected.Size = new System.Drawing.Size(0, 13);
            this.lbl_CompanySelected.TabIndex = 20;
            this.lbl_CompanySelected.Visible = false;
            // 
            // lbl_ErrorLogDetails
            // 
            this.lbl_ErrorLogDetails.AutoSize = true;
            this.lbl_ErrorLogDetails.Location = new System.Drawing.Point(52, 864);
            this.lbl_ErrorLogDetails.Name = "lbl_ErrorLogDetails";
            this.lbl_ErrorLogDetails.Size = new System.Drawing.Size(0, 13);
            this.lbl_ErrorLogDetails.TabIndex = 21;
            // 
            // btn_ErrorLog
            // 
            this.btn_ErrorLog.BackColor = System.Drawing.Color.DimGray;
            this.btn_ErrorLog.Enabled = false;
            this.btn_ErrorLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ErrorLog.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ErrorLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_ErrorLog.Location = new System.Drawing.Point(264, 599);
            this.btn_ErrorLog.Name = "btn_ErrorLog";
            this.btn_ErrorLog.Size = new System.Drawing.Size(168, 42);
            this.btn_ErrorLog.TabIndex = 22;
            this.btn_ErrorLog.Text = "Error Log";
            this.btn_ErrorLog.UseVisualStyleBackColor = false;
            this.btn_ErrorLog.Click += new System.EventHandler(this.btn_ErrorLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btn_ErrorLog);
            this.Controls.Add(this.lbl_ErrorLogDetails);
            this.Controls.Add(this.lbl_CompanySelected);
            this.Controls.Add(this.btn_Ingestion2);
            this.Controls.Add(this.lbl_Message2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Grd_MetaDataPub);
            this.Controls.Add(this.TitleIngestion);
            this.Controls.Add(this.btn_Injestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title Ingestion:  HomePage";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_MetaDataPub)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Injestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Label TitleIngestion;
        private System.Windows.Forms.Button btn_SearchForFiles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView Grd_MetaDataPub;
        private System.Windows.Forms.Label lbl_Message2;
        private System.Windows.Forms.ComboBox drpbx_IngestionSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstbx_MediaType;
        private System.Windows.Forms.ListBox lstbx_Publisher;
        private System.Windows.Forms.Button btn_Ingestion2;
        private System.Windows.Forms.Label lbl_CompanySelected;
        private System.Windows.Forms.Label lbl_ErrorLogDetails;
        private System.Windows.Forms.Button btn_ErrorLog;
    }
}

