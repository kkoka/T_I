namespace TitleInjestion
{
    partial class ErrorLogScreen
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
            this.Grd_ErrorLog = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_ErrorLog)).BeginInit();
            this.SuspendLayout();
            // 
            // Grd_ErrorLog
            // 
            this.Grd_ErrorLog.AllowUserToAddRows = false;
            this.Grd_ErrorLog.AllowUserToDeleteRows = false;
            this.Grd_ErrorLog.AllowUserToResizeColumns = false;
            this.Grd_ErrorLog.AllowUserToResizeRows = false;
            this.Grd_ErrorLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grd_ErrorLog.Location = new System.Drawing.Point(48, 274);
            this.Grd_ErrorLog.Name = "Grd_ErrorLog";
            this.Grd_ErrorLog.Size = new System.Drawing.Size(842, 305);
            this.Grd_ErrorLog.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 72F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(197, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 114);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title Ingestion";
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Location = new System.Drawing.Point(178, 242);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 13);
            this.lbl_Message.TabIndex = 2;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Delete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Delete.FlatAppearance.BorderSize = 3;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Delete.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btn_Delete.Location = new System.Drawing.Point(216, 607);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(138, 39);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(416, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Error Log";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(600, 607);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorLogScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(943, 698);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Grd_ErrorLog);
            this.Name = "ErrorLogScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErrorLogScreen";
            this.Load += new System.EventHandler(this.ErrorLogScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_ErrorLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grd_ErrorLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}