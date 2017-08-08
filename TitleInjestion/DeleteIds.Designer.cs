namespace TitleInjestion
{
    partial class DeleteIds
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TitleID = new System.Windows.Forms.TextBox();
            this.txt_ContribIds = new System.Windows.Forms.TextBox();
            this.btn_DeleteTitleID = new System.Windows.Forms.Button();
            this.btn_DeleteContribID = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "DELETE ID\'S";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter IDs from Approval and Correction Reports: (comma seperated )";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter the Contributor- ID\'s  :";
            // 
            // txt_TitleID
            // 
            this.txt_TitleID.Location = new System.Drawing.Point(203, 233);
            this.txt_TitleID.Multiline = true;
            this.txt_TitleID.Name = "txt_TitleID";
            this.txt_TitleID.Size = new System.Drawing.Size(356, 93);
            this.txt_TitleID.TabIndex = 3;
            // 
            // txt_ContribIds
            // 
            this.txt_ContribIds.Location = new System.Drawing.Point(203, 372);
            this.txt_ContribIds.Multiline = true;
            this.txt_ContribIds.Name = "txt_ContribIds";
            this.txt_ContribIds.Size = new System.Drawing.Size(356, 107);
            this.txt_ContribIds.TabIndex = 4;
            // 
            // btn_DeleteTitleID
            // 
            this.btn_DeleteTitleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteTitleID.Location = new System.Drawing.Point(589, 246);
            this.btn_DeleteTitleID.Name = "btn_DeleteTitleID";
            this.btn_DeleteTitleID.Size = new System.Drawing.Size(129, 57);
            this.btn_DeleteTitleID.TabIndex = 5;
            this.btn_DeleteTitleID.Text = "Delete Product ID";
            this.btn_DeleteTitleID.UseVisualStyleBackColor = true;
            this.btn_DeleteTitleID.Click += new System.EventHandler(this.btn_DeleteTitleID_Click);
            // 
            // btn_DeleteContribID
            // 
            this.btn_DeleteContribID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteContribID.Location = new System.Drawing.Point(589, 398);
            this.btn_DeleteContribID.Name = "btn_DeleteContribID";
            this.btn_DeleteContribID.Size = new System.Drawing.Size(129, 63);
            this.btn_DeleteContribID.TabIndex = 6;
            this.btn_DeleteContribID.Text = "Delete Contributor ID";
            this.btn_DeleteContribID.UseVisualStyleBackColor = true;
            this.btn_DeleteContribID.Click += new System.EventHandler(this.btn_DeleteContribID_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Refresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Refresh.FlatAppearance.BorderSize = 2;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(40, 96);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(129, 48);
            this.btn_Refresh.TabIndex = 28;
            this.btn_Refresh.Text = "Refresh Page";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(175, 96);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 48);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DeleteIds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(764, 519);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_DeleteContribID);
            this.Controls.Add(this.btn_DeleteTitleID);
            this.Controls.Add(this.txt_ContribIds);
            this.Controls.Add(this.txt_TitleID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeleteIds";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title Ingestion: DeleteIds";
            this.Load += new System.EventHandler(this.DeleteIds_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TitleID;
        private System.Windows.Forms.TextBox txt_ContribIds;
        private System.Windows.Forms.Button btn_DeleteTitleID;
        private System.Windows.Forms.Button btn_DeleteContribID;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btnClose;
    }
}