
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


    }
}
