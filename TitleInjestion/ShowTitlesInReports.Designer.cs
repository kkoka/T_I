namespace TitleInjestion
{
    partial class ShowTitlesInReports
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ShowTitles = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lstbx_publisher = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_RefreshPage = new System.Windows.Forms.Button();
            this.btn_hideTitles = new System.Windows.Forms.Button();
            this.lstbx_delta_New = new System.Windows.Forms.ListBox();
            this.lstbx_filetype = new System.Windows.Forms.ListBox();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.btn_CheckTitleCount = new System.Windows.Forms.Button();
            this.lbl_CountOfTitles = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 50F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(335, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title Ingestion";
            // 
            // btn_ShowTitles
            // 
            this.btn_ShowTitles.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ShowTitles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowTitles.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_ShowTitles.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_ShowTitles.Location = new System.Drawing.Point(339, 241);
            this.btn_ShowTitles.Name = "btn_ShowTitles";
            this.btn_ShowTitles.Size = new System.Drawing.Size(114, 46);
            this.btn_ShowTitles.TabIndex = 1;
            this.btn_ShowTitles.Text = "Show Titles In Reports";
            this.btn_ShowTitles.UseVisualStyleBackColor = false;
            this.btn_ShowTitles.Click += new System.EventHandler(this.btn_ShowTitles_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Close.FlatAppearance.BorderSize = 2;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(159, 140);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 40);
            this.btn_Close.TabIndex = 40;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lstbx_publisher
            // 
            this.lstbx_publisher.FormattingEnabled = true;
            this.lstbx_publisher.Location = new System.Drawing.Point(215, 26);
            this.lstbx_publisher.Name = "lstbx_publisher";
            this.lstbx_publisher.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstbx_publisher.Size = new System.Drawing.Size(362, 134);
            this.lstbx_publisher.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(70, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "List of Publisher(s) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(107, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Kind of Titles : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.lbl_CountOfTitles);
            this.panel1.Controls.Add(this.btn_CheckTitleCount);
            this.panel1.Controls.Add(this.lbl_Message);
            this.panel1.Controls.Add(this.lstbx_filetype);
            this.panel1.Controls.Add(this.lstbx_delta_New);
            this.panel1.Controls.Add(this.btn_hideTitles);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_ShowTitles);
            this.panel1.Controls.Add(this.lstbx_publisher);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(159, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 358);
            this.panel1.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(376, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "File Type :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(129, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "Number of Titles Shown in Reports :  ";
            // 
            // btn_RefreshPage
            // 
            this.btn_RefreshPage.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_RefreshPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RefreshPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RefreshPage.ForeColor = System.Drawing.Color.White;
            this.btn_RefreshPage.Location = new System.Drawing.Point(664, 140);
            this.btn_RefreshPage.Name = "btn_RefreshPage";
            this.btn_RefreshPage.Size = new System.Drawing.Size(249, 40);
            this.btn_RefreshPage.TabIndex = 46;
            this.btn_RefreshPage.Text = "Refresh Page";
            this.btn_RefreshPage.UseVisualStyleBackColor = false;
            this.btn_RefreshPage.Click += new System.EventHandler(this.btn_RefreshPage_Click);
            // 
            // btn_hideTitles
            // 
            this.btn_hideTitles.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_hideTitles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hideTitles.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_hideTitles.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_hideTitles.Location = new System.Drawing.Point(463, 241);
            this.btn_hideTitles.Name = "btn_hideTitles";
            this.btn_hideTitles.Size = new System.Drawing.Size(114, 46);
            this.btn_hideTitles.TabIndex = 48;
            this.btn_hideTitles.Text = "Hide Titles In Reports";
            this.btn_hideTitles.UseVisualStyleBackColor = false;
            this.btn_hideTitles.Click += new System.EventHandler(this.btn_hideTitles_Click);
            // 
            // lstbx_delta_New
            // 
            this.lstbx_delta_New.FormattingEnabled = true;
            this.lstbx_delta_New.Location = new System.Drawing.Point(215, 176);
            this.lstbx_delta_New.Name = "lstbx_delta_New";
            this.lstbx_delta_New.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstbx_delta_New.Size = new System.Drawing.Size(122, 43);
            this.lstbx_delta_New.TabIndex = 49;
            // 
            // lstbx_filetype
            // 
            this.lstbx_filetype.FormattingEnabled = true;
            this.lstbx_filetype.Location = new System.Drawing.Point(455, 176);
            this.lstbx_filetype.Name = "lstbx_filetype";
            this.lstbx_filetype.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstbx_filetype.Size = new System.Drawing.Size(122, 43);
            this.lstbx_filetype.TabIndex = 50;
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Message.ForeColor = System.Drawing.Color.Red;
            this.lbl_Message.Location = new System.Drawing.Point(212, 222);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 13);
            this.lbl_Message.TabIndex = 51;
            // 
            // btn_CheckTitleCount
            // 
            this.btn_CheckTitleCount.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CheckTitleCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CheckTitleCount.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_CheckTitleCount.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_CheckTitleCount.Location = new System.Drawing.Point(215, 241);
            this.btn_CheckTitleCount.Name = "btn_CheckTitleCount";
            this.btn_CheckTitleCount.Size = new System.Drawing.Size(114, 46);
            this.btn_CheckTitleCount.TabIndex = 52;
            this.btn_CheckTitleCount.Text = "Check Title Count";
            this.btn_CheckTitleCount.UseVisualStyleBackColor = false;
            this.btn_CheckTitleCount.Click += new System.EventHandler(this.btn_CheckTitleCount_Click);
            // 
            // lbl_CountOfTitles
            // 
            this.lbl_CountOfTitles.AutoSize = true;
            this.lbl_CountOfTitles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_CountOfTitles.Location = new System.Drawing.Point(376, 321);
            this.lbl_CountOfTitles.Name = "lbl_CountOfTitles";
            this.lbl_CountOfTitles.Size = new System.Drawing.Size(0, 17);
            this.lbl_CountOfTitles.TabIndex = 54;
            // 
            // ShowTitlesInReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1044, 661);
            this.Controls.Add(this.btn_RefreshPage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label1);
            this.Name = "ShowTitlesInReports";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title Ingestion: ShowTitles";
            this.Load += new System.EventHandler(this.ShowTitlesInReports_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ShowTitles;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ListBox lstbx_publisher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_RefreshPage;
        private System.Windows.Forms.Button btn_hideTitles;
        private System.Windows.Forms.ListBox lstbx_filetype;
        private System.Windows.Forms.ListBox lstbx_delta_New;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Button btn_CheckTitleCount;
        private System.Windows.Forms.Label lbl_CountOfTitles;
    }
}