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
    public partial class DeleteIds : Form
    {

        private string str_Company;

        public DeleteIds()
        {
            InitializeComponent();
        }
        public DeleteIds(string Company)
        {
            InitializeComponent();
            str_Company = Company;
        }

        private void DeleteIds_Load(object sender, EventArgs e)
        {

        }

        private void btn_DeleteTitleID_Click(object sender, EventArgs e)
        {
            if (txt_TitleID.Text.Length > 0)
            {
                //bool result = true;
                //SQLFunction sqlfnction = new SQLFunction();
                //result = sqlfnction.Execute_DeleteTitleID_Proc(str_Company, txt_TitleID.Text.ToString());


                //if (txt_TitleID.Text.Length <= 3000)
                //{

                if (!backgroundWorker1.IsBusy && !backgroundWorker2.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("A job is currently running....Please wait.");
                }




                //}
                //else
                //{
                //    MessageBox.Show("The length cannot be more than 3000 characters.");
                //}

            }
            else
            {
                MessageBox.Show("Please Enter the IDs to be deleted.");
            }


           
        }

        private void btn_DeleteContribID_Click(object sender, EventArgs e)
        {



            if (txt_ContribIds.Text.Length > 0)
            {

                //if (txt_ContribIds.Text.Length <= 3000)
                //{
                    if (!backgroundWorker1.IsBusy && !backgroundWorker2.IsBusy)
                    {
                        backgroundWorker2.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("A job is currently running....Please wait.");
                    }

                //}
                //else
                //{
                //    MessageBox.Show("The length cannot be more than 3000 characters.");
                //}


             //   txt_ContribIds.Text = "";
                
            }
            else
            {
                MessageBox.Show("Please Enter the IDs to be deleted.");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            //backgroundWorker1.ReportProgress(1);

            //pictureBox1.Visible = true;

            bool result = true;
            SQLFunction sqlfnction = new SQLFunction();
            result = sqlfnction.Execute_DeleteTitleID_Proc(str_Company, txt_TitleID.Text.ToString());

            if (result)
            {
                MessageBox.Show("Ids Got Deleted Successfully.");

              
            }
            else
            {
                MessageBox.Show("There has been some problem deleting the IDs.");
            }
            //backgroundWorker1.ReportProgress(11);

            //  pictureBox1.Visible = false;


        }

       
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            bool result = true;
            SQLFunction sqlfnction = new SQLFunction();


            result = sqlfnction.Execute_DeleteContributorID_Proc(str_Company, txt_ContribIds.Text.ToString());

            if (result)
            {
                MessageBox.Show("Contributors Ids Got Deleted Successfully.");


            }
            else
            {
                MessageBox.Show("There has been some problem deleting the contributor IDs.");
            }

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy && !backgroundWorker2.IsBusy)
            {
                txt_TitleID.Text = "";
                txt_ContribIds.Text = "";
            }
            else
            {
                MessageBox.Show("A job is currently running....Please wait.");
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy && !backgroundWorker2.IsBusy)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("A job is currently running....Please wait.");
            }
           
        }
    }
}
