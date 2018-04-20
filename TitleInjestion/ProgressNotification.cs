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
    public partial class ProgressNotification : Form
    {
        public string TaskName = "";
        public string Company = "";
        public ProgressNotification()
        {
            InitializeComponent();
        }
        public ProgressNotification(string strCompany, string strTask)
        {
            TaskName = strTask;
            Company = strCompany;

            InitializeComponent();
        }

        private void ProgressNotification_Load(object sender, EventArgs e)
        {
          
        }

        private void ExecuteValidation(string ValidationTask)
        {
            bool result = true;
            SQLFunction sqlfnction = new SQLFunction();

            if (ValidationTask == "Validation1")
            {
                result = sqlfnction.Execute_ValidationProc(Company, "01");
            }
            else if (ValidationTask == "Validation2")
            {
                result = sqlfnction.Execute_ValidationProc(Company, "02");
            }
            else
            {

            }

            if (result && ValidationTask == "Validation1")
            {
                MessageBox.Show("The Approval and Corrections Reports are ready for review.");
            }
            else if ( result && ValidationTask == "Validation2")
            {
                MessageBox.Show("The Data has been Validated and they are moved to OffRamp.");
            }
            else
            {
                MessageBox.Show("There has been some issue during Validation.");
            }

            this.Close();

        }

        private void GenerateContributors()
        {
            bool result = true;

            CommonFuncCalls cmnFuncCalls = new CommonFuncCalls();
            result = cmnFuncCalls.Upload_ApprovalCorrections_Reports(Company);
                        
            if (result)
            {
                MessageBox.Show("The Contributor Report is ready for review.");
            }
            else
            {
                MessageBox.Show("There has been some issue during Contributor Generation.");
            }

            this.Close();
        }

        private void SaveContributors()
        {
            bool result = true;
            CommonFuncCalls cmnFuncCalls = new CommonFuncCalls();
            result = cmnFuncCalls.Upload_Contributor_Reports(Company);


            if (result)
            {
                MessageBox.Show("The Contributors are saved.  Please proceed to the Validation 2.");
            }
            else
            {
                MessageBox.Show("There has been some issue saving contributors.");
            }

            this.Close();


        }

        private void BackUp_OffRamp()
        {
            bool result = true;
          
            SQLBackup sqlbckup = new SQLBackup(Company);
            result = sqlbckup.BackupDatabase();


            if (result)
            {
                MessageBox.Show("OffRamp.Bak is available in the FTP Location.");
            }
            else
            {
                MessageBox.Show("There has been some problem backing up the WFH_OffRamp database.Please contact the Admin.");

            }

           

            this.Close();


        }

        private void btn_StartJob_Click(object sender, EventArgs e)
        {
           //  SaveContributors();
            //// BackUp_OffRamp();
            //  GenerateContributors();

            //// ExecuteValidation(TaskName);

            //Initiate_Jobs();



            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("A job is currently running....Please wait.");
            }


        }

        private void Initiate_Jobs()
        {

        
            if (TaskName == "Validation1" || TaskName == "Validation2")
            {
                lbl_Progress.Text = "Please wait while the Validation Job is running...";
                lbl_Progress.Refresh();
                System.Windows.Forms.Application.DoEvents();

                ExecuteValidation(TaskName);
            }
            if (TaskName == "GenerateContribs")
            {
                lbl_Progress.Text = "Please wait while the Contributors are generated ...";
                lbl_Progress.Refresh();
                System.Windows.Forms.Application.DoEvents();

                GenerateContributors();
            }
            if (TaskName == "SaveContributors")
            {
                lbl_Progress.Text = "Please wait while the Contributors are Saved ...";
                lbl_Progress.Refresh();
                System.Windows.Forms.Application.DoEvents();

                SaveContributors();
            }
            if(TaskName == "BackUP")
            {
                lbl_Progress.Text = "Please wait while the database is backed up";
                lbl_Progress.Refresh();
                System.Windows.Forms.Application.DoEvents();

                BackUp_OffRamp();

            }


        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            backgroundWorker1.ReportProgress(1);

            //pictureBox1.Visible = true;

            Initiate_Jobs();

            backgroundWorker1.ReportProgress(11);

            //  pictureBox1.Visible = false;


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }
    }
}
