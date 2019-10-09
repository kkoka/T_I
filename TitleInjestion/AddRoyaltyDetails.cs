
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;



using TitleInjestion.MetaData;
using TitleInjestion.CommonFunctions;

using System.Configuration;

namespace TitleInjestion
{
    public partial class AddRoyaltyDetails : Form
    {
        private string str_Company;

        public AddRoyaltyDetails()
        {
            InitializeComponent();
        }

        public AddRoyaltyDetails(string Company)
        {
            InitializeComponent();
            str_Company = Company;
            
        }
    

        private void AddRoyaltyDetails_Load(object sender, EventArgs e)
        {
            lbl_Message.Text = "";

            lbl_failurerows.Text = "";
            lbl_failure_rowsexists.Text = "";
           
        }

        public void Display_ParentPublisher()
        {
            SQLFunction sqlfunc = new SQLFunction();
            DataTable dt = new DataTable();
            dt = sqlfunc.Get_Parent_Publisher(str_Company, lbl_Message);

            //for(int i =0; i < dt.Rows.Count; i ++)
            //{
            //    drpbx_parentaccountname.Items.Add(dt.Rows[i]["Publishername"].ToString());
            //}
            drpbx_parentaccountname.DataSource = dt;
            drpbx_parentaccountname.DisplayMember = "Publishername";
            drpbx_parentaccountname.ValueMember = "ID";

           
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {           
                this.Close();         
        }

        private void btn_lookupimprintname_Click(object sender, EventArgs e)
        {
            SQLFunction sqlfunc = new SQLFunction();

            lbl_imprintName.Text = sqlfunc.GetImprintPublisherName(str_Company, txt_imprintaccountno.Text, lbl_imprintName, lbl_parentaccountno);


        }

        private void btn_lookupparentpub_Click(object sender, EventArgs e)
        {
            SQLFunction sqlfunc = new SQLFunction();

            string parentpubname = sqlfunc.GetParentPublisherName(str_Company, txt_AgentCode.Text, lbl_parentpubname);

            if(parentpubname.Length==0)
            {
                lbl_parentaccount.Enabled = true;
                drpbx_parentaccountname.Enabled = true;
                Display_ParentPublisher();
            }
            else
            {
                lbl_parentaccount.Enabled = false;
                drpbx_parentaccountname.Enabled = false;
            }

        }


        private void btn_submit_Click(object sender, EventArgs e)
        {
            lbl_failurerows.Text = "";
            lbl_failure_rowsexists.Text = "";

            string parent_publisher = "";

            if (lbl_parentpubname.Text.Length > 0)
            {
                parent_publisher = lbl_parentpubname.Text;
            }
            else if (drpbx_parentaccountname.SelectedText.Length > 0)
            {
                parent_publisher = drpbx_parentaccountname.SelectedText;
            }
            else
            {
                lbl_Message.Text = "Please enter the PARENT PUBLISHER.";
            }

            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            SQLFunction sqlfunc = new SQLFunction();

            if (txt_AgentCode.Text.Length == 0)
            {
                lbl_Message.Text = "Please Enter the AGENT CODE.";
            }
            else if (txt_royaltypercent.Text.Length == 0)
            {
                lbl_Message.Text = "Please Enter the ROYALTY PERCENT.";
            }

            else
            {


                if (sqlfunc.AddRoyaltyRecord(str_Company, txt_imprintaccountno.Text, lbl_imprintName.Text, parent_publisher, txt_AgentCode.Text, txt_royaltypercent.Text, "", username, lbl_Message))
                {
                    txt_imprintaccountno.Text = "";
                    lbl_imprintName.Text = "";
                    lbl_parentaccountno.Text = "";
                    txt_AgentCode.Text = "";
                    txt_royaltypercent.Text = "";

                    if (lbl_parentpubname.Text.Length > 0)
                    {
                        lbl_parentpubname.Text = "";
                    }else
                    {
                        Display_ParentPublisher();
                    }


                }



            }
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            lbl_failurerows.Text = "";
            lbl_failure_rowsexists.Text = "";

            string failure_rows = "Unable to Upload Records (Rows No): ";
            string failure_existsrows = "Records already Exists (Row No): ";
            DataTable dt_Excel = new DataTable();

            SQLFunction sqlfunction = new SQLFunction();

            dt_Excel = sqlfunction.ReadExcel(str_Company ,@"\\Pfingestion01\Incoming\TitleManagement\Metadata_Prod\Reports\RoyaltyDetails\RRD.xlsx");

            if (
                CheckIfColumnExist(dt_Excel, "Parent_PublisherName") &&
                CheckIfColumnExist(dt_Excel, "Imprint_PublisherName") &&
                CheckIfColumnExist(dt_Excel, "Imprint_Publisher_AccountNo") &&
                CheckIfColumnExist(dt_Excel, "d_agent_code") &&
                CheckIfColumnExist(dt_Excel, "d_royalty_percent")
               )
                {
                    for (int i = 0; i < dt_Excel.Rows.Count; i++)
                    {
                        string Parent_PublisherName = dt_Excel.Rows[i]["Parent_PublisherName"].ToString();
                        string Imprint_PublisherName = dt_Excel.Rows[i]["Imprint_PublisherName"].ToString();
                        string Imprint_Publisher_AccountNo = dt_Excel.Rows[i]["Imprint_Publisher_AccountNo"].ToString();
                        string d_agent_code = dt_Excel.Rows[i]["d_agent_code"].ToString();
                        string d_royalty_percent = dt_Excel.Rows[i]["d_royalty_percent"].ToString();

                        if (Parent_PublisherName.Trim().Length == 0 ||
                         Imprint_PublisherName.Trim().Length == 0 ||
                         Imprint_Publisher_AccountNo.Trim().Length == 0 ||
                         d_agent_code.Trim().Length == 0 ||
                         d_royalty_percent.Trim().Length == 0)
                        {
                            failure_rows += ", " + (i + 2);
                        }
                        else
                        {
                            int count = sqlfunction.CheckIfRoyaltyDetailsRecordExists(str_Company, d_agent_code, Imprint_PublisherName, Parent_PublisherName);
                            if (count == 0)
                            {
                               if(!sqlfunction.AddRoyaltyRecord(str_Company, Parent_PublisherName, Imprint_Publisher_AccountNo, Imprint_PublisherName, d_agent_code, d_royalty_percent, System.Security.Principal.WindowsIdentity.GetCurrent().Name))
                                {
                                    failure_rows += ", " + (i + 2);
                                }
                            
                            }
                            else
                            {
                                failure_existsrows += ", " + (i + 2);
                            }

                        }
                    }

                }
                else
                {
                    lbl_UploadMessage.Text = "The excel file is missing a column. Please check the column headers.";
                }

            lbl_UploadMessage.Text = "Batch Upload process Completed.";

            if (failure_rows != "Unable to Upload Records (Rows No): ")
            {
                 lbl_failurerows.Text = failure_rows;
         
            }
            if (failure_existsrows != "Records already Exists (Row No): ")
            {

                lbl_failure_rowsexists.Text = failure_existsrows;
            }

        }
        private bool CheckIfColumnExist(DataTable dt_Excel, string Columnname)
        {
            bool result = false;

            foreach (DataColumn dc in dt_Excel.Columns)
            {
                if (dc.ColumnName.ToLower() == Columnname.ToLower())
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
