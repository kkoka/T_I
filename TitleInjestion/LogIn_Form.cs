using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace TitleInjestion
{
    public partial class LogIn_Form : Form
    {
        public LogIn_Form()
        {
            InitializeComponent();
        }

        private void LogIn_Form_Load(object sender, EventArgs e)
        {
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            lbl_Message.Text = "Please wait while you are being redirected to the Application";

            try
            {
                string ValidUser = ConfigurationSettings.AppSettings["Ingestion_Accounts_"+ Environment.UserName.ToString()].ToString();
                Form1 HomePage = new Form1();
               
                HomePage.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                lbl_Message.Text = "User Does Not Have Permissions to Use this Application. Please Contact the Admin.";   
            }

           


        }
    }
}
