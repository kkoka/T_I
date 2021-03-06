﻿namespace TitleInjestion
{
    partial class AddRoyaltyDetails
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
            this.TitleIngestion = new System.Windows.Forms.Label();
            this.txt_imprintaccountno = new System.Windows.Forms.TextBox();
            this.btn_lookupimprintname = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_imprintName = new System.Windows.Forms.Label();
            this.lbl_parentaccount = new System.Windows.Forms.Label();
            this.drpbx_parentaccountname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_AgentCode = new System.Windows.Forms.TextBox();
            this.txt_royaltypercent = new System.Windows.Forms.TextBox();
            this.txt_discountrate = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_parentpubname = new System.Windows.Forms.Label();
            this.btn_lookupparentpub = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_parentaccountno = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.btn_Home = new System.Windows.Forms.Button();
            this.btn_ErrorLog = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_failure_rowsexists = new System.Windows.Forms.Label();
            this.lbl_failurerows = new System.Windows.Forms.Label();
            this.lbl_UploadMessage = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_DisplayMessage = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter the Imprint Account No :";
            // 
            // TitleIngestion
            // 
            this.TitleIngestion.AutoSize = true;
            this.TitleIngestion.Font = new System.Drawing.Font("Bernard MT Condensed", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleIngestion.ForeColor = System.Drawing.Color.Red;
            this.TitleIngestion.Location = new System.Drawing.Point(387, 42);
            this.TitleIngestion.Name = "TitleIngestion";
            this.TitleIngestion.Size = new System.Drawing.Size(401, 81);
            this.TitleIngestion.TabIndex = 10;
            this.TitleIngestion.Text = "Title Ingestion";
            // 
            // txt_imprintaccountno
            // 
            this.txt_imprintaccountno.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F);
            this.txt_imprintaccountno.Location = new System.Drawing.Point(290, 54);
            this.txt_imprintaccountno.Name = "txt_imprintaccountno";
            this.txt_imprintaccountno.Size = new System.Drawing.Size(135, 20);
            this.txt_imprintaccountno.TabIndex = 11;
            // 
            // btn_lookupimprintname
            // 
            this.btn_lookupimprintname.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_lookupimprintname.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_lookupimprintname.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lookupimprintname.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_lookupimprintname.Location = new System.Drawing.Point(449, 46);
            this.btn_lookupimprintname.Name = "btn_lookupimprintname";
            this.btn_lookupimprintname.Size = new System.Drawing.Size(168, 33);
            this.btn_lookupimprintname.TabIndex = 23;
            this.btn_lookupimprintname.Text = "LookUp Imprint Name";
            this.btn_lookupimprintname.UseVisualStyleBackColor = false;
            this.btn_lookupimprintname.Click += new System.EventHandler(this.btn_lookupimprintname_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Imprint Name :";
            // 
            // lbl_imprintName
            // 
            this.lbl_imprintName.AutoSize = true;
            this.lbl_imprintName.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_imprintName.Location = new System.Drawing.Point(287, 94);
            this.lbl_imprintName.Name = "lbl_imprintName";
            this.lbl_imprintName.Size = new System.Drawing.Size(0, 15);
            this.lbl_imprintName.TabIndex = 25;
            // 
            // lbl_parentaccount
            // 
            this.lbl_parentaccount.AutoSize = true;
            this.lbl_parentaccount.Enabled = false;
            this.lbl_parentaccount.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_parentaccount.Location = new System.Drawing.Point(83, 218);
            this.lbl_parentaccount.Name = "lbl_parentaccount";
            this.lbl_parentaccount.Size = new System.Drawing.Size(190, 15);
            this.lbl_parentaccount.TabIndex = 26;
            this.lbl_parentaccount.Text = "Select the Parent Account :";
            // 
            // drpbx_parentaccountname
            // 
            this.drpbx_parentaccountname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpbx_parentaccountname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpbx_parentaccountname.Enabled = false;
            this.drpbx_parentaccountname.FormattingEnabled = true;
            this.drpbx_parentaccountname.Location = new System.Drawing.Point(290, 218);
            this.drpbx_parentaccountname.Name = "drpbx_parentaccountname";
            this.drpbx_parentaccountname.Size = new System.Drawing.Size(199, 21);
            this.drpbx_parentaccountname.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(183, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Agent Code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(150, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Royalty Percent :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(150, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Discount Rate :";
            // 
            // txt_AgentCode
            // 
            this.txt_AgentCode.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F);
            this.txt_AgentCode.Location = new System.Drawing.Point(290, 157);
            this.txt_AgentCode.Name = "txt_AgentCode";
            this.txt_AgentCode.Size = new System.Drawing.Size(199, 20);
            this.txt_AgentCode.TabIndex = 31;
            // 
            // txt_royaltypercent
            // 
            this.txt_royaltypercent.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F);
            this.txt_royaltypercent.Location = new System.Drawing.Point(290, 252);
            this.txt_royaltypercent.Name = "txt_royaltypercent";
            this.txt_royaltypercent.Size = new System.Drawing.Size(49, 20);
            this.txt_royaltypercent.TabIndex = 32;
            // 
            // txt_discountrate
            // 
            this.txt_discountrate.Enabled = false;
            this.txt_discountrate.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F);
            this.txt_discountrate.Location = new System.Drawing.Point(290, 286);
            this.txt_discountrate.Name = "txt_discountrate";
            this.txt_discountrate.Size = new System.Drawing.Size(49, 20);
            this.txt_discountrate.TabIndex = 33;
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_submit.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_submit.Location = new System.Drawing.Point(212, 320);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(106, 33);
            this.btn_submit.TabIndex = 34;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbl_parentpubname);
            this.panel1.Controls.Add(this.btn_lookupparentpub);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbl_parentaccountno);
            this.panel1.Controls.Add(this.lbl_Message);
            this.panel1.Controls.Add(this.txt_imprintaccountno);
            this.panel1.Controls.Add(this.btn_submit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_discountrate);
            this.panel1.Controls.Add(this.btn_lookupimprintname);
            this.panel1.Controls.Add(this.txt_royaltypercent);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_AgentCode);
            this.panel1.Controls.Add(this.lbl_imprintName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbl_parentaccount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.drpbx_parentaccountname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 393);
            this.panel1.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(104, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 15);
            this.label8.TabIndex = 40;
            this.label8.Text = "Parent Publisher Name :";
            // 
            // lbl_parentpubname
            // 
            this.lbl_parentpubname.AutoSize = true;
            this.lbl_parentpubname.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_parentpubname.Location = new System.Drawing.Point(287, 189);
            this.lbl_parentpubname.Name = "lbl_parentpubname";
            this.lbl_parentpubname.Size = new System.Drawing.Size(0, 15);
            this.lbl_parentpubname.TabIndex = 39;
            // 
            // btn_lookupparentpub
            // 
            this.btn_lookupparentpub.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_lookupparentpub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_lookupparentpub.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lookupparentpub.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_lookupparentpub.Location = new System.Drawing.Point(512, 152);
            this.btn_lookupparentpub.Name = "btn_lookupparentpub";
            this.btn_lookupparentpub.Size = new System.Drawing.Size(191, 33);
            this.btn_lookupparentpub.TabIndex = 38;
            this.btn_lookupparentpub.Text = "LookUp Parent Publisher";
            this.btn_lookupparentpub.UseVisualStyleBackColor = false;
            this.btn_lookupparentpub.Click += new System.EventHandler(this.btn_lookupparentpub_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(133, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = "Parent Account No :";
            // 
            // lbl_parentaccountno
            // 
            this.lbl_parentaccountno.AutoSize = true;
            this.lbl_parentaccountno.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_parentaccountno.Location = new System.Drawing.Point(287, 127);
            this.lbl_parentaccountno.Name = "lbl_parentaccountno";
            this.lbl_parentaccountno.Size = new System.Drawing.Size(0, 15);
            this.lbl_parentaccountno.TabIndex = 37;
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Message.ForeColor = System.Drawing.Color.Red;
            this.lbl_Message.Location = new System.Drawing.Point(421, 320);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 13);
            this.lbl_Message.TabIndex = 35;
            // 
            // btn_Home
            // 
            this.btn_Home.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Home.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Home.FlatAppearance.BorderSize = 2;
            this.btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_Home.ForeColor = System.Drawing.Color.White;
            this.btn_Home.Location = new System.Drawing.Point(50, 154);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(127, 40);
            this.btn_Home.TabIndex = 36;
            this.btn_Home.Text = "Home";
            this.btn_Home.UseVisualStyleBackColor = false;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // btn_ErrorLog
            // 
            this.btn_ErrorLog.BackColor = System.Drawing.Color.DimGray;
            this.btn_ErrorLog.Enabled = false;
            this.btn_ErrorLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ErrorLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_ErrorLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_ErrorLog.Location = new System.Drawing.Point(196, 154);
            this.btn_ErrorLog.Name = "btn_ErrorLog";
            this.btn_ErrorLog.Size = new System.Drawing.Size(127, 40);
            this.btn_ErrorLog.TabIndex = 37;
            this.btn_ErrorLog.Text = "Error Log";
            this.btn_ErrorLog.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.tabControl1.Location = new System.Drawing.Point(50, 212);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1070, 450);
            this.tabControl1.TabIndex = 38;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1062, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Single Entry";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.lbl_failure_rowsexists);
            this.tabPage2.Controls.Add(this.lbl_failurerows);
            this.tabPage2.Controls.Add(this.lbl_UploadMessage);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.btn_Upload);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lbl_DisplayMessage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1062, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bulk Upload";
            // 
            // lbl_failure_rowsexists
            // 
            this.lbl_failure_rowsexists.AutoSize = true;
            this.lbl_failure_rowsexists.ForeColor = System.Drawing.Color.Red;
            this.lbl_failure_rowsexists.Location = new System.Drawing.Point(75, 285);
            this.lbl_failure_rowsexists.Name = "lbl_failure_rowsexists";
            this.lbl_failure_rowsexists.Size = new System.Drawing.Size(0, 13);
            this.lbl_failure_rowsexists.TabIndex = 40;
            // 
            // lbl_failurerows
            // 
            this.lbl_failurerows.AutoSize = true;
            this.lbl_failurerows.ForeColor = System.Drawing.Color.Red;
            this.lbl_failurerows.Location = new System.Drawing.Point(75, 253);
            this.lbl_failurerows.Name = "lbl_failurerows";
            this.lbl_failurerows.Size = new System.Drawing.Size(0, 13);
            this.lbl_failurerows.TabIndex = 39;
            // 
            // lbl_UploadMessage
            // 
            this.lbl_UploadMessage.AutoSize = true;
            this.lbl_UploadMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lbl_UploadMessage.ForeColor = System.Drawing.Color.Red;
            this.lbl_UploadMessage.Location = new System.Drawing.Point(446, 383);
            this.lbl_UploadMessage.Name = "lbl_UploadMessage";
            this.lbl_UploadMessage.Size = new System.Drawing.Size(0, 13);
            this.lbl_UploadMessage.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Crimson;
            this.label16.Location = new System.Drawing.Point(25, 211);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 17);
            this.label16.TabIndex = 37;
            this.label16.Text = "* NOTE :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(103, 211);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(865, 17);
            this.label15.TabIndex = 36;
            this.label15.Text = "If you are not able to obtain the Parent_PublisherName value, please contact Kart" +
    "hik / Shweta for further instructions.";
            // 
            // btn_Upload
            // 
            this.btn_Upload.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Upload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Upload.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Upload.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Upload.Location = new System.Drawing.Point(347, 334);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(299, 33);
            this.btn_Upload.TabIndex = 35;
            this.btn_Upload.Text = "Bulk Upload Excel file";
            this.btn_Upload.UseVisualStyleBackColor = false;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Crimson;
            this.label14.Location = new System.Drawing.Point(314, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(601, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "\\\\Pfingestion01\\Incoming\\TitleManagement\\Metadata_Prod\\Reports\\RoyaltyDetails";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(43, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(265, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Please place the file at the following location:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(103, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "d_royalty_percent";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(103, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "d_agent_code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(103, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Imprint_Publisher_AccountNo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(103, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Imprint_PublisherName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(103, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Parent_PublisherName";
            // 
            // lbl_DisplayMessage
            // 
            this.lbl_DisplayMessage.AutoSize = true;
            this.lbl_DisplayMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.lbl_DisplayMessage.ForeColor = System.Drawing.Color.Black;
            this.lbl_DisplayMessage.Location = new System.Drawing.Point(43, 28);
            this.lbl_DisplayMessage.Name = "lbl_DisplayMessage";
            this.lbl_DisplayMessage.Size = new System.Drawing.Size(337, 13);
            this.lbl_DisplayMessage.TabIndex = 0;
            this.lbl_DisplayMessage.Text = "Please use an Excel template with the following columns : ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddRoyaltyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_ErrorLog);
            this.Controls.Add(this.btn_Home);
            this.Controls.Add(this.TitleIngestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddRoyaltyDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title Ingestion:  AddRoyaltyDetails";
            this.Load += new System.EventHandler(this.AddRoyaltyDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitleIngestion;
        private System.Windows.Forms.TextBox txt_imprintaccountno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_imprintName;
        private System.Windows.Forms.Label lbl_parentaccount;
        private System.Windows.Forms.ComboBox drpbx_parentaccountname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_AgentCode;
        private System.Windows.Forms.TextBox txt_royaltypercent;
        private System.Windows.Forms.TextBox txt_discountrate;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Button btn_ErrorLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_parentaccountno;
        private System.Windows.Forms.Label lbl_parentpubname;
        private System.Windows.Forms.Button btn_lookupparentpub;
        private System.Windows.Forms.Button btn_lookupimprintname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_DisplayMessage;
        private System.Windows.Forms.Label lbl_UploadMessage;
        private System.Windows.Forms.Label lbl_failure_rowsexists;
        private System.Windows.Forms.Label lbl_failurerows;
    }
}