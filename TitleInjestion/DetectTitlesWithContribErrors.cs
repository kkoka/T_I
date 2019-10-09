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
    public partial class DetectTitlesWithContribErrors : Form
    {
        private string str_Company = "";
        public DetectTitlesWithContribErrors()
        {
            InitializeComponent();
        }
        public DetectTitlesWithContribErrors(string Company)
        {
            InitializeComponent();
            str_Company = Company;
        }



        private void DetectTitlesWithContribErrors_Load(object sender, EventArgs e)
        {
            RefreshPage();
        }
        private void RefreshPage()
        {
            lbl_Message.Text = "";
            grdView_ContribErrors.DataSource = null;
            grdView_ContribErrors.Rows.Clear();

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("A job is currently running....Please wait.");
            }
        }
     
        private void btn_CheckContribErrors_Click(object sender, EventArgs e)
        {

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("A job is currently running....Please wait.");
            }
           

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(1);

            CheckIncorrectContributors();

            backgroundWorker1.ReportProgress(11);
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

        private void CheckIncorrectContributors()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.IdentifyTitlesWithContribErrors(str_Company, lbl_Message, grdView_ContribErrors);


        }
    }
}
