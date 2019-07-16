using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

using TitleInjestion.CommonFunctions;

namespace TitleInjestion
{
    public partial class Stage2 : Form
    {
        private string str_Company = "";
        public Stage2()
        {
            InitializeComponent();

        }

        public Stage2(string Company)
        {
            InitializeComponent();
            str_Company = Company;

        }

        private void Stage2_Load(object sender, EventArgs e)
        {
            RefreshPage();
            if(str_Company =="RB")
            {
                btn_FTPOffRamp.Enabled = false;
                btn_FTPOffRamp.Visible = false;
            }
            else
            {
                btn_FTPOffRamp.Enabled = true;
                btn_FTPOffRamp.Visible = true;

                btn_FilterTitles.Enabled = false;
                btn_FilterTitles.Visible = false;
            }
        }

        private void RefreshPage()
        {
            DisplayTitleCount();
            DisplayTitleCount_Val1();
            DisplayTitleCount_Val2();
            DisplayApprovedTitleCount();
            DisplayContributorCount(); 
            DisplayOfframpTitleCount();
            ErrorLogCount(str_Company);
            
        }
        private void DisplayTitleCount()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.DisplayTitleCount(str_Company, lbl_TitleCount, lbl_Message);
        }


        private void DisplayTitleCount_Val1()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.DisplayTitleCount_Val1(str_Company, lbl_Val1, lbl_Message);
        }
        private void DisplayTitleCount_Val2()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.DisplayTitleCount_Val2(str_Company, lbl_Val2, lbl_Message);
        }
        private void DisplayApprovedTitleCount()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.DisplayApprovedTitleCount(str_Company, lbl_ApprovedTitles, lbl_Message);

        }

        private void DisplayContributorCount()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.DisplayContributorCount(str_Company, lbl_Num_Contributor, lbl_Message);

        } 

        private void DisplayOfframpTitleCount()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.DisplayOfframpTitleCount(str_Company, lbl_OfframpCount, lbl_Message);

        }
        private void ErrorLogCount(string Company)
        {
            SQLFunction sqlfunc = new SQLFunction();

            #region 'Populate the Error Log Count'
            sqlfunc.GetErrorLogCount(Company, btn_ErrorLog);
            #endregion

        }
        private void btn_Validation1_Click(object sender, EventArgs e)
        {
            
            SQLFunction sqlfunc = new SQLFunction();

            if (sqlfunc.DisplayTitleCount_Val1(str_Company) > 0)
            {

                ProgressNotification frm2 = new ProgressNotification(str_Company, "Validation1");
                frm2.Show();

                RefreshPage();
            }
            else
            {
                MessageBox.Show("No Titles Found in the reports to Validate.");
            }


            //    bool result = true;
            //SQLFunction sqlfnction = new SQLFunction();
            //result = sqlfnction.Execute_ValidationProc(str_Company, "01");


        }

        private void btn_GenerateContribs_Click(object sender, EventArgs e)
        {            
            CommonFuncCalls cmnFuncCalls = new CommonFuncCalls();
            
            if(cmnFuncCalls.CheckIf_ApprovalCorrectionsReports_Exists(str_Company))
            {
                ProgressNotification frm2 = new ProgressNotification(str_Company, "GenerateContribs");
                frm2.Show();

                RefreshPage();

            }
            else
            {
                MessageBox.Show("No Reports Found");
            }
            
            
            #region 'Upload the file'
            //CommonFuncCalls cmnFuncCalls = new CommonFuncCalls();
            //cmnFuncCalls.Upload_ApprovalCorrections_Reports(str_Company);

            #endregion


        }



        private void btn_Validation2_Click(object sender, EventArgs e)
        {
            SQLFunction sqlfunc = new SQLFunction();

            if(sqlfunc.DisplayApprovedTitleCount(str_Company) > 0)
            {

                ProgressNotification frm2 = new ProgressNotification(str_Company, "Validation2");
                frm2.Show();

                RefreshPage();

            }
            else
            {
                MessageBox.Show("Please Approve Titles Before you can run Validation 2.");
            }

            //SQLFunction sqlfnction = new SQLFunction();
            //sqlfnction.Execute_ValidationProc(str_Company, "02");

        }

        private void btn_SaveContributors_Click(object sender, EventArgs e)
        {

            CommonFuncCalls cmnFuncCalls = new CommonFuncCalls();

            if (cmnFuncCalls.CheckIf_ContributorReport_Exists(str_Company))
            {
                ProgressNotification frm2 = new ProgressNotification(str_Company, "SaveContributors");
                frm2.Show();

                RefreshPage();
            }
            else
            {
                MessageBox.Show("No Contributor Report Found");
            }
          
            #region 'Upload the file'
            //CommonFuncCalls cmnFuncCalls = new CommonFuncCalls();
            //cmnFuncCalls.Upload_Contributor_Reports(str_Company);

            #endregion
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ErrorLog_Click(object sender, EventArgs e)
        {
            ErrorLogScreen errorlog = new ErrorLogScreen(str_Company);
            errorlog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshPage();        
        }

        private void btn_DeleteID_Click(object sender, EventArgs e)
        {
            DeleteIds deleteIDs = new DeleteIds(str_Company);
            deleteIDs.ShowDialog();
        }

        private void btn_FTPOffRamp_Click(object sender, EventArgs e)
        {


            SQLFunction sqlfunc = new SQLFunction();

            if (sqlfunc.DisplayOfframpTitleCount(str_Company) > 0)
            {

                ProgressNotification frm2 = new ProgressNotification(str_Company, "BackUP");
                frm2.Show();

                RefreshPage();

            }
            else
            {
                MessageBox.Show("Please Approve Titles Before you can run Validation 2.");
            }

            
           

        }

        private void btn_FilterTitles_Click(object sender, EventArgs e)
        {
            ShowTitlesInReports Showtitles = new ShowTitlesInReports(str_Company);
            Showtitles.ShowDialog();

        }
    }
}

