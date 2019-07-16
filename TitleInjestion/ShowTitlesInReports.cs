using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitleInjestion.CommonFunctions;

using System.Windows.Forms;

namespace TitleInjestion
{
    public partial class ShowTitlesInReports : Form
    {
        private string str_Company = "";

        public ShowTitlesInReports()
        {
            InitializeComponent();
        }

        public ShowTitlesInReports(string Company)
        {

            InitializeComponent();
            str_Company = Company;

        }
        private void ShowTitlesInReports_Load(object sender, EventArgs e)
        {
            RefreshPage();
        }
    

        private void RefreshPage()
        {
            //InitializeComponent();
            lstbx_publisher.Refresh();
            lstbx_delta_New.Refresh();
            lstbx_filetype.Refresh();

            lstbx_publisher.Items.Clear();
            lstbx_delta_New.Items.Clear();
            lstbx_filetype.Items.Clear();

            Display_Count_OfTitlesInReports();
            Display_PublisherName();
            Display_Delta_New();
            Display_FileType();

        }

        private void btn_ShowTitles_Click(object sender, EventArgs e)
        {

            string item_publisher = "";
            foreach (var i in lstbx_publisher.SelectedIndices)
            {
                item_publisher += lstbx_publisher.Items[(int)i] + ";";
            }
            item_publisher = item_publisher.TrimEnd(';');



            //string[] PublisherName = item_publisher.Split(';');


            string item_delta_New = "";
            foreach (var i in lstbx_delta_New.SelectedIndices)
            {
                item_delta_New += lstbx_delta_New.Items[(int)i] + ";";
            }
            item_delta_New = item_delta_New.TrimEnd(';');

            //string[] Delta_New = item_delta_New.Split(';');




            string item_filetype = "";
            foreach (var i in lstbx_filetype.SelectedIndices)
            {
                item_filetype += lstbx_filetype.Items[(int)i] + ";";
            }
            item_filetype = item_filetype.TrimEnd(';');

            //string[] FileType = item_filetype.Split(';');


            if (item_publisher.Length == 0 && item_delta_New.Length == 0 && item_filetype.Length == 0)
            {
                MessageBox.Show("Please make a Selection.");
            }
            else
            {
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.FlagTitlesToShow(str_Company, item_publisher, item_delta_New, item_filetype, lbl_CountOfTitles, lbl_Message);
            }



        }

        private void btn_hideTitles_Click(object sender, EventArgs e)
        {
            string item_publisher = "";
            foreach (var i in lstbx_publisher.SelectedIndices)
            {
                item_publisher += lstbx_publisher.Items[(int)i] + ";";
            }
            item_publisher = item_publisher.TrimEnd(';');



            //string[] PublisherName = item_publisher.Split(';');


            string item_delta_New = "";
            foreach (var i in lstbx_delta_New.SelectedIndices)
            {
                item_delta_New += lstbx_delta_New.Items[(int)i] + ";";
            }
            item_delta_New = item_delta_New.TrimEnd(';');

            //string[] Delta_New = item_delta_New.Split(';');




            string item_filetype = "";
            foreach (var i in lstbx_filetype.SelectedIndices)
            {
                item_filetype += lstbx_filetype.Items[(int)i] + ";";
            }
            item_filetype = item_filetype.TrimEnd(';');

            //string[] FileType = item_filetype.Split(';');


            if (item_publisher.Length == 0 && item_delta_New.Length == 0 && item_filetype.Length == 0)
            {
                MessageBox.Show("Please make a Selection.");
            }
            else
            {
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.FlagTitlesToHide(str_Company, item_publisher, item_delta_New, item_filetype, lbl_CountOfTitles, lbl_Message);

            }

        }

        private void btn_RefreshPage_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region 'private methods'
        private void Display_Count_OfTitlesInReports()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.Display_Count_OfTitlesInReports(str_Company, lbl_CountOfTitles, lbl_Message);

        }
        private void Display_PublisherName()
        {
                       
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.Display_PublisherName(str_Company, lstbx_publisher, lbl_Message);

        }

        private void Display_Delta_New()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.Display_Delta_New(str_Company, lstbx_delta_New, lbl_Message);


        }

        private void Display_FileType()
        {
            SQLFunction sqlfnction = new SQLFunction();
            sqlfnction.Display_FileType(str_Company, lstbx_filetype, lbl_Message);
            

        }



        #endregion

        private void btn_CheckTitleCount_Click(object sender, EventArgs e)
        {


            string item_publisher = "";
            foreach (var i in lstbx_publisher.SelectedIndices)
            {
                item_publisher += lstbx_publisher.Items[(int)i] + ";";
            }
            item_publisher = item_publisher.TrimEnd(';');

             
            
            //string[] PublisherName = item_publisher.Split(';');
            
            
            string item_delta_New = "";
            foreach (var i in lstbx_delta_New.SelectedIndices)
            {
                item_delta_New += lstbx_delta_New.Items[(int)i] + ";";
            }
            item_delta_New = item_delta_New.TrimEnd(';');

            //string[] Delta_New = item_delta_New.Split(';');
            


            
            string item_filetype = "";
            foreach (var i in lstbx_filetype.SelectedIndices)
            {
                item_filetype += lstbx_filetype.Items[(int)i] + ";";
            }
            item_filetype = item_filetype.TrimEnd(';');
          
            //string[] FileType = item_filetype.Split(';');
            

            if(item_publisher.Length == 0 && item_delta_New.Length == 0 && item_filetype.Length == 0)
            {
                MessageBox.Show("Please make a Selection.");
            }
            else
            { 
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Display_SelectedTitleCount(str_Company, item_publisher, item_delta_New, item_filetype, lbl_Message);
            }

        }
    }
}
