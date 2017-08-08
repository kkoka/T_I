using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using TitleInjestion.CommonFunctions;

namespace TitleInjestion
{
    public partial class ErrorLogScreen : Form
    {
        private string str_Company;

        public ErrorLogScreen()
        {
            InitializeComponent();
        }
        public ErrorLogScreen(string Company)
        {
            InitializeComponent();
            str_Company = Company;
        }

        private void ErrorLogScreen_Load(object sender, EventArgs e)
        {
          
            DisplayGrid(str_Company);
           

            if (Grd_ErrorLog.Rows.Count > 0)
            {
                btn_Delete.Enabled = true;
                btn_Delete.BackColor = System.Drawing.Color.DodgerBlue;
                btn_Delete.Refresh();
                System.Windows.Forms.Application.DoEvents();

            }
            else
            {
                btn_Delete.Enabled = false;
                btn_Delete.BackColor = System.Drawing.Color.DimGray;
                btn_Delete.Refresh();
                System.Windows.Forms.Application.DoEvents();


            }
        }
        public CheckBox chBox;
        private void CheckBoxHeader()
        {
            DataGridViewCheckBoxColumn c1 = new DataGridViewCheckBoxColumn();
            c1.Name = "";
            c1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Grd_ErrorLog.Columns.Add(c1);


           chBox = new CheckBox();
            Rectangle rectangle = this.Grd_ErrorLog.GetCellDisplayRectangle(0, -1, true);
            chBox.Size = new Size(17, 17);

            chBox.Location = rectangle.Location;

            chBox.CheckedChanged += new EventHandler(chBox_CheckedChanged);

            this.Grd_ErrorLog.Controls.Add(chBox);


        }
       private void chBox_CheckedChanged(object sender, EventArgs e)

        {

            for (int j = 0; j < this.Grd_ErrorLog.RowCount; j++)

            {

                this.Grd_ErrorLog[0, j].Value = this.chBox.Checked;

            }

            this.Grd_ErrorLog.EndEdit();

        }


        private void DisplayGrid(string Company)
        {
            #region 'Display Available Files per publisher' 

            try
            {

                if (Grd_ErrorLog.Rows.Count > 0)
                {
                    Grd_ErrorLog.DataSource = null;
                    Grd_ErrorLog.Columns.Clear();
                }


                SQLFunction sqlfunction = new SQLFunction();

                CheckBoxHeader();

                Grd_ErrorLog.DataSource = sqlfunction.GetErrorLogDetails(str_Company, lbl_Message, Grd_ErrorLog);


                int i = 0;

                Grd_ErrorLog.Columns[i ].Width = 23;

                Grd_ErrorLog.Columns[i + 1].Visible = true;
                Grd_ErrorLog.Columns[i + 1].HeaderText = "ID";
                Grd_ErrorLog.Columns[i + 1].Width = 30;
                Grd_ErrorLog.Columns[i + 1].ReadOnly = true;

                Grd_ErrorLog.Columns[i + 2].Visible = true;
                Grd_ErrorLog.Columns[i + 2].HeaderText = "Error Message";
                Grd_ErrorLog.Columns[i + 2].Width = 600;
                Grd_ErrorLog.Columns[i + 2].ReadOnly = true;

                Grd_ErrorLog.Columns[i + 3].Visible = true;
                Grd_ErrorLog.Columns[i + 3].HeaderText = "LogDateTime";
                Grd_ErrorLog.Columns[i + 3].Width = 130;
                Grd_ErrorLog.Columns[i + 3].ReadOnly = true;


                //DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                //checkBoxColumn.HeaderText = "";
                //checkBoxColumn.Width = 30;
                //checkBoxColumn.Name = "checkBoxColumn";
                //checkBoxColumn.HeaderText = "";
                //checkBoxColumn.ReadOnly = false;
                //Grd_ErrorLog.Columns.Insert(1, checkBoxColumn);
                //Grd_ErrorLog.Columns[1].ReadOnly = false;


                if (Grd_ErrorLog.Rows.Count > 0)
                {
                    btn_Delete.Enabled = true;
                }





            }
            catch (Exception ex)
            {
                lbl_Message.Text = "There has been a problem with the request. Please the Error Logs.";
                lbl_Message.Refresh();
                System.Windows.Forms.Application.DoEvents();

                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error at Get_MetaData_Publisher_Info:" + ex.ToString());

            }


            #endregion
        }
        private void DisplayGrid_workingCode(string Company)
        {
            #region 'Display Available Files per publisher' 

            try
            {

                if (Grd_ErrorLog.Rows.Count > 0)
                {
                    Grd_ErrorLog.DataSource = null;
                    Grd_ErrorLog.Columns.Clear();
                }


                SQLFunction sqlfunction = new SQLFunction();


                Grd_ErrorLog.DataSource = sqlfunction.GetErrorLogDetails(str_Company, lbl_Message, Grd_ErrorLog);


                int i = 0;


                Grd_ErrorLog.Columns[i].Visible = true;
                Grd_ErrorLog.Columns[i].HeaderText = "ID";
                Grd_ErrorLog.Columns[i].Width = 30;
                Grd_ErrorLog.Columns[i].ReadOnly = true;

                Grd_ErrorLog.Columns[i + 1].Visible = true;
                Grd_ErrorLog.Columns[i + 1].HeaderText = "Error Message";
                Grd_ErrorLog.Columns[i + 1].Width = 600;
                Grd_ErrorLog.Columns[i + 1].ReadOnly = true;

                Grd_ErrorLog.Columns[i + 2].Visible = true;
                Grd_ErrorLog.Columns[i + 2].HeaderText = "LogDateTime";
                Grd_ErrorLog.Columns[i + 2].Width = 100;
                Grd_ErrorLog.Columns[i + 2].ReadOnly = true;


                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.Width = 30;
                checkBoxColumn.Name = "checkBoxColumn";
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.ReadOnly = false;
                Grd_ErrorLog.Columns.Insert(0, checkBoxColumn);
                Grd_ErrorLog.Columns[0].ReadOnly = false;


                if (Grd_ErrorLog.Rows.Count > 0)
                {
                    btn_Delete.Enabled = true;
                }





            }
            catch (Exception ex)
            {
                lbl_Message.Text = "There has been a problem with the request. Please the Error Logs.";
                lbl_Message.Refresh();
                System.Windows.Forms.Application.DoEvents();

                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error at Get_MetaData_Publisher_Info:" + ex.ToString());

            }


            #endregion
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string ID = "";
            foreach (DataGridViewRow row in Grd_ErrorLog.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (Convert.ToBoolean(chk.Value))
                {
                    DataGridViewTextBoxCell txt_id = (DataGridViewTextBoxCell)row.Cells[1];

                    if (ID.Length > 0)
                    {
                        ID += "," + Convert.ToString(txt_id.Value);
                    }
                    else
                    {
                        ID += Convert.ToString(txt_id.Value);
                    }

                }
            }

            if(ID.Length >0)
            {             
                #region 'Delete'
                    SQLFunction sqlfunc = new SQLFunction();
                    sqlfunc.Delete_ErrorLogs(str_Company, ID);
                #endregion

                DisplayGrid(str_Company);
            }
            else
            {
              //  lbl_Message.Text = "Please make a Selection";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }
    }
}
