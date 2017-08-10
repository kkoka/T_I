using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TitleInjestion.Company.WFHowes.Onix_2_Short_Definition;

using TitleInjestion.MetaData;
using TitleInjestion.CommonFunctions;
using System.Threading;

using System.Configuration;
using System.IO;

namespace TitleInjestion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // SQLBackup sqlbck = new SQLBackup("WFH");
            // sqlbck.BackupDatabase();


            // string filename = string.Format("{0}_{1}.bak", "WFH_OffRamp", DateTime.Now.ToString("yyyyMMdd"));

            //string sfsa =  Path.Combine(@"G:\ExtraBackup\", filename);


            //string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //lbl_Message.Text = "Please wait while you are being redirected to the Application";

            try
            {
                //string ValidUser = ConfigurationSettings.AppSettings["Ingestion_Accounts_" + Environment.UserName.ToString()].ToString();

           
                CommonFuncCalls cmnfunc = new CommonFuncCalls();
       
                #region 'Populate the Ingestion Source'
                drpbx_IngestionSource.DataSource = cmnfunc.Populate_IngestionSource();
                #endregion


                string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                ////////ImpersonateUser iU = new ImpersonateUser();
                ////////// TODO: Replace credentials
                ////////   iU.Impersonate();

                string username1 = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
             //   MessageBox.Show(Environment.UserName.ToString());

                if (Grd_MetaDataPub.Rows.Count > 0)
                {
                    btn_Injestion.BackColor = Color.DodgerBlue;
                    btn_Injestion.Enabled = true;
                    btn_Injestion.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                }
                else
                {
                    btn_Injestion.BackColor = Color.DimGray;
                    btn_Injestion.Enabled = false;
                    btn_Injestion.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                }

                lbl_CompanySelected.Text = "";
                lbl_CompanySelected.Refresh();
                System.Windows.Forms.Application.DoEvents();

            }
            catch (Exception ex)
            {
               MessageBox.Show("Permission to this Application Denied. Please Contact the Admin.");
                this.Close();

            }

        }

        #region 'Dropbox Listbox '
        private void drpbx_IngestionSource_SelectedValueChanged(object sender, EventArgs e)
        {
            bool result = true;


            SQLFunction sqlfunc = new SQLFunction();

            lstbx_MediaType.Items.Clear();
            lstbx_Publisher.Items.Clear();

            if (Grd_MetaDataPub.ColumnCount > 0)
            {
                Grd_MetaDataPub.DataSource = null;
                Grd_MetaDataPub.Columns.Clear();

                btn_Injestion.BackColor = Color.DimGray;
                btn_Injestion.Enabled = false;
                btn_Injestion.Refresh();
                System.Windows.Forms.Application.DoEvents();

                btn_Ingestion2.BackColor = Color.DimGray;
                btn_Ingestion2.Enabled = false;
                btn_Ingestion2.Refresh();
                System.Windows.Forms.Application.DoEvents();


                btn_ErrorLog.BackColor = Color.DimGray;
                btn_ErrorLog.Enabled = false;
                btn_ErrorLog.Refresh();
                System.Windows.Forms.Application.DoEvents();


            }



            if (drpbx_IngestionSource.SelectedValue.ToString() == "Recorded Books")
            {
                lbl_CompanySelected.Text = "RB";
                lbl_CompanySelected.Refresh();
                System.Windows.Forms.Application.DoEvents();

                ErrorLogCount("RB");
                Check_TitleCount("RB");

                lbl_Message.Text = "";
                #region 'Populate the MediaType'
                result = sqlfunc.PopulateMediaType("RB", lstbx_MediaType);
                #endregion
            }
            else if (drpbx_IngestionSource.SelectedValue.ToString() == "W F Howes")
            {
                lbl_CompanySelected.Text = "WFH";
                lbl_CompanySelected.Refresh();
                System.Windows.Forms.Application.DoEvents();



                ImpersonateUser iU = new ImpersonateUser();
                // TODO: Replace credentials
                iU.Impersonate();

                ErrorLogCount("WFH");
                Check_TitleCount("WFH");

                lbl_Message.Text = "";
                #region 'Populate the MediaType'
                result = sqlfunc.PopulateMediaType("WFH", lstbx_MediaType);
                #endregion
            }
            else
            {
                lbl_CompanySelected.Text = "";
                lbl_CompanySelected.Refresh();
                System.Windows.Forms.Application.DoEvents();

                lbl_Message.Text = "";

                lstbx_MediaType.Items.Clear();
                lstbx_Publisher.Items.Clear();
            }

            if (!result)
            {
                lbl_Message.Text = "There has been some problem with your request. Please Check the Error Logs";
            }


        }

        private void lstbx_MediaType_SelectedValueChanged(object sender, EventArgs e)
        {
            bool result = true;
            if (Grd_MetaDataPub.ColumnCount > 0)
            {
                Grd_MetaDataPub.DataSource = null;
                Grd_MetaDataPub.Columns.Clear();
                btn_Injestion.BackColor = Color.DimGray;
                btn_Injestion.Refresh();
                System.Windows.Forms.Application.DoEvents();

            }

            lstbx_Publisher.Items.Clear();

            string item = "";
            foreach (var i in lstbx_MediaType.SelectedIndices)
            {
                item += lstbx_MediaType.Items[(int)i] + ";";
            }
            item = item.TrimEnd(';');

            string[] MediaType = item.Split(';');
           
            SQLFunction sqlfunc = new SQLFunction();


            if (drpbx_IngestionSource.SelectedValue.ToString() == "Recorded Books" && lstbx_MediaType.SelectedItems.Count > 0)
            {
                lbl_CompanySelected.Text = "RB";
                lbl_CompanySelected.Refresh();
                System.Windows.Forms.Application.DoEvents();


                lbl_Message.Text = "";
                #region 'Populate the MediaType'
                    result = sqlfunc.PopulatePublishers("RB", MediaType, lstbx_Publisher );
                #endregion
            }
            else if (drpbx_IngestionSource.SelectedValue.ToString() == "W F Howes" && lstbx_MediaType.SelectedItems.Count > 0)
            {
                lbl_CompanySelected.Text = "WFH";
                lbl_CompanySelected.Refresh();
                System.Windows.Forms.Application.DoEvents();


                lbl_Message.Text = "";
                #region 'Populate the MediaType'
                    result = sqlfunc.PopulatePublishers("WFH", MediaType, lstbx_Publisher );
                #endregion
            }
            else
            {
                lbl_CompanySelected.Text = "";
                lbl_CompanySelected.Refresh();
                System.Windows.Forms.Application.DoEvents();

                lstbx_Publisher.Items.Clear();

            }
            if(!result)
            {
                lbl_Message.Text = "There has been some problem with your request. Please Check the Error Logs";
            }
        }

        private void lstbx_Publisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_Message.Text = "";

        }

        #endregion


        #region 'Button Click'

        private void btn_SearchForFiles_Click(object sender, EventArgs e)
        {
            bool result = true;

            string username = Environment.UserName;

             

            if (Grd_MetaDataPub.Rows.Count > 0)
            {
                 btn_Injestion.Enabled = true;
                 btn_Injestion.BackColor = Color.DodgerBlue;
                 btn_Injestion.Refresh();
                 System.Windows.Forms.Application.DoEvents();

            }
            else
            {
                btn_Injestion.BackColor = Color.DimGray;
                btn_Injestion.Enabled = false;
                btn_Injestion.Refresh();
                System.Windows.Forms.Application.DoEvents();

            }

            #region 'Display list of Available Files'

            if (drpbx_IngestionSource.SelectedValue.ToString() == "Recorded Books")
                    {

                         ErrorLogCount("RB");

                        if (lstbx_MediaType.SelectedItems.Count > 0 )
                        {
                            if(lstbx_Publisher.SelectedItems.Count > 0)
                            {
                                lbl_CompanySelected.Text = "RB";
                                lbl_CompanySelected.Refresh();
                                System.Windows.Forms.Application.DoEvents();

                                lbl_Message.Text = "";
                               

                                string item = "";
                                foreach (var i in lstbx_MediaType.SelectedIndices)
                                {
                                    item += lstbx_MediaType.Items[(int)i] + ";";
                                }
                                item = item.TrimEnd(';');

                                string[] MediaType = item.Split(';');


                                item = "";
                                foreach (var i in lstbx_Publisher.SelectedIndices)
                                {
                                    item += lstbx_Publisher.Items[(int)i] + ";";
                                }
                                item = item.TrimEnd(';');

                                string[] PublisherName = item.Split(';');


                                result = Display_MetadataPubDetails("RB", MediaType, PublisherName);
                            }

                            else
                            {
                                lbl_Message.Text = "Please Select the Publisher";
                            }
                        }
                        else
                        {
                            lbl_Message.Text = "Please Select the Media Type,";
                        }
                    }
                    else if (drpbx_IngestionSource.SelectedValue.ToString() == "W F Howes")
                    {
                        ErrorLogCount("WFH");

                        Check_TitleCount("WFH");
                        if (lstbx_MediaType.SelectedItems.Count > 0)
                        {
                            if (lstbx_Publisher.SelectedItems.Count > 0)
                            {
                                lbl_CompanySelected.Text = "WFH";
                                lbl_CompanySelected.Refresh();
                                System.Windows.Forms.Application.DoEvents();

                                lbl_Message.Text = "";

                                string item = "";

                                {
                                foreach (var i in lstbx_MediaType.SelectedIndices)
                                    item += lstbx_MediaType.Items[(int)i] + ";";
                                }
                                item = item.TrimEnd(';');

                                string[] MediaType = item.Split(';');


                                item = "";
                                foreach (var i in lstbx_Publisher.SelectedIndices)
                                {
                                    item += lstbx_Publisher.Items[(int)i] + ";";
                                }
                                item = item.TrimEnd(';');

                                string[] PublisherName = item.Split(';');

                                result = Display_MetadataPubDetails("WFH", MediaType, PublisherName );

                            }

                            else
                            {
                                lbl_Message.Text = "Please Select the Publisher";
                            }
                        }
                        else
                        {
                            lbl_Message.Text = "Please Select the Media Type,";
                        }
                    }
                    else
                    {
                        lbl_Message.Text = "Please select the Source.";

                        lbl_CompanySelected.Text = "";
                        lbl_CompanySelected.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                        #region 'Empty the Grid'

                            Grd_MetaDataPub.DataSource = null;
                            Grd_MetaDataPub.Columns.Clear();
                
                        #endregion

                    }


                    if(Grd_MetaDataPub.Rows.Count>0)
                    {
                        btn_Injestion.BackColor = Color.DodgerBlue;
                        btn_Injestion.Enabled = true;
                        btn_Injestion.Refresh();
                        System.Windows.Forms.Application.DoEvents();

            }
            else
                    {
                        btn_Injestion.Enabled = false;
                        btn_Injestion.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                        lbl_CompanySelected.Text = "";
                        lbl_CompanySelected.Refresh();

                        lbl_Message.Text = "You do not have any files available.";
                        lbl_Message.Refresh();
                        System.Windows.Forms.Application.DoEvents();

            }


            #endregion
        }
        private void btn_Injestion_Click(object sender, EventArgs e)
        {
            #region 'Process'

            List<MetaDataFileAvailability> mfa_1 = new List<MetaDataFileAvailability>();

            try
            {
                foreach (DataGridViewRow row in Grd_MetaDataPub.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (Convert.ToBoolean(chk.Value))
                    {
                        MetaDataFileAvailability mfa_2 = new MetaDataFileAvailability();

                        DataGridViewTextBoxCell txt_id = (DataGridViewTextBoxCell)row.Cells[1];
                        mfa_2.ID = Convert.ToString(txt_id.Value);

                        DataGridViewTextBoxCell txt_pubid = (DataGridViewTextBoxCell)row.Cells[2];
                        mfa_2.PubID = Convert.ToString(txt_pubid.Value);

                        DataGridViewTextBoxCell txt_publishername = (DataGridViewTextBoxCell)row.Cells[3];
                        mfa_2.PublisherName = Convert.ToString(txt_publishername.Value);

                        DataGridViewTextBoxCell txt_MediaType = (DataGridViewTextBoxCell)row.Cells[4];
                        mfa_2.MediaType = Convert.ToString(txt_MediaType.Value);

                        DataGridViewTextBoxCell txt_FileType = (DataGridViewTextBoxCell)row.Cells[5];
                        mfa_2.FileType = Convert.ToString(txt_FileType.Value);

                        DataGridViewTextBoxCell txt_filelocation = (DataGridViewTextBoxCell)row.Cells[6];
                        mfa_2.PublisherFilelocation = Convert.ToString(txt_filelocation.Value);

                        DataGridViewTextBoxCell txt_FileName = (DataGridViewTextBoxCell)row.Cells[7];
                        mfa_2.FileName = Convert.ToString(txt_FileName.Value);

                        DataGridViewTextBoxCell txt_OnixVersion = (DataGridViewTextBoxCell)row.Cells[8];
                        mfa_2.OnixVersion = Convert.ToString(txt_OnixVersion.Value);

                        DataGridViewTextBoxCell txt_TagType = (DataGridViewTextBoxCell)row.Cells[9];
                        mfa_2.TagType = Convert.ToString(txt_TagType.Value);

                        DataGridViewTextBoxCell txt_XMLEncoding = (DataGridViewTextBoxCell)row.Cells[12];
                        mfa_2.XML_Encoding = Convert.ToString(txt_XMLEncoding.Value);

                        mfa_1.Add(mfa_2);
                    }
                }

                if(mfa_1.Count > 0)
                {
                    RedirectToIngestionPage(drpbx_IngestionSource.SelectedValue.ToString(), mfa_1);
                }


            }
            catch (Exception ex)
            {
                lbl_Message2.Text = "There has been a problem with the request. Please the Error Logs.";
                lbl_Message2.Refresh();
                System.Windows.Forms.Application.DoEvents();

                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(lbl_CompanySelected.Text), "Error at Get_MetaData_Publisher_Info:" + ex.ToString());

            }
            
            #endregion
        }

        private void btn_Ingestion2_Click(object sender, EventArgs e)
        {


            string Company = "";
            if (drpbx_IngestionSource.SelectedValue.ToString() == "W F Howes")
            {
                Company = "WFH";
            }
            else if (drpbx_IngestionSource.SelectedValue.ToString() == "Recorded Books")
            {
                Company = "RB";
            }
            else
            {
                Company = "";
            }

            if (Company == "WFH")
            {
                if (!File.Exists(""))
                {
                    Load_Stage2(Company);
                }
                else
                {
                    MessageBox.Show("Please wait while the WFHSAP_TI database is being Restored.");
                }
            }
            else if(Company =="RB")
            {
                Load_Stage2(Company);
            }
            else { }
           

        }

        private void Load_Stage1(string Company , List<MetaDataFileAvailability> mfa)
        {
            Stage1 Stg1 = new Stage1(Company, mfa);
            Stg1.ShowDialog();

        }
        private void Load_Stage2(string Company)
        {
            Stage2 stage2 = new Stage2(Company);
            stage2.ShowDialog();

        }
        private void btn_ErrorLog_Click(object sender, EventArgs e)
        {
            string Company = "";
            if (drpbx_IngestionSource.SelectedValue.ToString() == "W F Howes")
            {
                Company = "WFH";
            }
            else if (drpbx_IngestionSource.SelectedValue.ToString() == "Recorded Books")
            {
                Company = "RB";
            }
            else
            {
                Company = "";
            }

            ErrorLogScreen errorlog = new ErrorLogScreen(Company);
            errorlog.ShowDialog();

        }
 


        #endregion

        private bool Display_MetadataPubDetails_workingCode(string Company, string[] MediaType, string[] PublisherName)
        {
            bool result = true;

            #region 'Display Available Files per publisher' 

            try
            {

                    if (Grd_MetaDataPub.ColumnCount > 0)
                    {
                        Grd_MetaDataPub.DataSource = null;
                        Grd_MetaDataPub.Columns.Clear();
                    }


                    MetaData_Info mdi = new MetaData_Info();
                    Grd_MetaDataPub.DataSource = mdi.MetaDataPubInfo(Company, MediaType, PublisherName, lbl_Message2);


                    int i = 0;
                    Grd_MetaDataPub.Columns[i].Visible = false;

                    Grd_MetaDataPub.Columns[i + 1].Visible = false;

                    Grd_MetaDataPub.Columns[i + 2].Visible = true;
                    Grd_MetaDataPub.Columns[i + 2].HeaderText = "Publisher Name";
                    Grd_MetaDataPub.Columns[i + 2].Width = 150;
                    Grd_MetaDataPub.Columns[i + 2].ReadOnly = true;

                    Grd_MetaDataPub.Columns[i + 3].Visible = true;
                    Grd_MetaDataPub.Columns[i + 3].HeaderText = "Media Type";
                    Grd_MetaDataPub.Columns[i + 3].Width = 70;
                    Grd_MetaDataPub.Columns[i + 3].ReadOnly = true;

                    Grd_MetaDataPub.Columns[i + 4].Visible = true;
                    Grd_MetaDataPub.Columns[i + 4].HeaderText = "File Type";
                    Grd_MetaDataPub.Columns[i + 4].Width = 70;
                    Grd_MetaDataPub.Columns[i + 4].ReadOnly = true;

                    Grd_MetaDataPub.Columns[i + 5].Visible = true;
                    Grd_MetaDataPub.Columns[i + 5].HeaderText = "File Location";
                    Grd_MetaDataPub.Columns[i + 5].Width = 500;
                    Grd_MetaDataPub.Columns[i + 5].ReadOnly = true;


                    Grd_MetaDataPub.Columns[i + 6].Visible = true;
                    Grd_MetaDataPub.Columns[i + 6].HeaderText = "File Name";
                    Grd_MetaDataPub.Columns[i + 6].Width = 400;
                    Grd_MetaDataPub.Columns[i + 6].ReadOnly = true;

                    Grd_MetaDataPub.Columns[i + 7].Visible = false;
                    Grd_MetaDataPub.Columns[i + 7].HeaderText = "File Count";
                    Grd_MetaDataPub.Columns[i + 7].Width = 70;
                    Grd_MetaDataPub.Columns[i + 7].ReadOnly = true;


                    Grd_MetaDataPub.Columns[i + 8].Visible = true;
                    Grd_MetaDataPub.Columns[i + 8].HeaderText = "File Size (in KB)";
                    Grd_MetaDataPub.Columns[i + 8].Width = 100;
                    Grd_MetaDataPub.Columns[i + 8].ReadOnly = true;



                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = "";
                    checkBoxColumn.Width = 30;
                    checkBoxColumn.Name = "checkBoxColumn";
                    checkBoxColumn.HeaderText = "";
                    checkBoxColumn.ReadOnly = false;
                    Grd_MetaDataPub.Columns.Insert(0, checkBoxColumn);
                    Grd_MetaDataPub.Columns[0].ReadOnly = false;


            }
            catch(Exception ex)
            {
                result = false;
            }


            #endregion

            return result;

        }



        #region 'Select All' 


        private bool Display_MetadataPubDetails(string Company, string[] MediaType, string[] PublisherName)
        {
            bool result = true;

            #region 'Display Available Files per publisher' 

            try
            {

                if (Grd_MetaDataPub.ColumnCount > 0)
                {
                    Grd_MetaDataPub.DataSource = null;
                    Grd_MetaDataPub.Columns.Clear();
                }

                CheckBoxHeader();

                MetaData_Info mdi = new MetaData_Info();
                Grd_MetaDataPub.DataSource = mdi.MetaDataPubInfo(Company, MediaType, PublisherName, lbl_Message2);


                int i = 0;
              //  Grd_MetaDataPub.Columns[i].Width = 30;


                Grd_MetaDataPub.Columns[i ].Visible = false;

                Grd_MetaDataPub.Columns[i + 1].Visible = false;

                Grd_MetaDataPub.Columns[i + 2].Visible = true;
                Grd_MetaDataPub.Columns[i + 2].HeaderText = "Publisher Name";
                Grd_MetaDataPub.Columns[i + 2].Width = 150;
                Grd_MetaDataPub.Columns[i + 2].ReadOnly = true;

                Grd_MetaDataPub.Columns[i + 3].Visible = true;
                Grd_MetaDataPub.Columns[i + 3].HeaderText = "Media Type";
                Grd_MetaDataPub.Columns[i + 3].Width = 90;
                Grd_MetaDataPub.Columns[i + 3].ReadOnly = true;

                Grd_MetaDataPub.Columns[i + 4].Visible = true;
                Grd_MetaDataPub.Columns[i + 4].HeaderText = "File Type";
                Grd_MetaDataPub.Columns[i + 4].Width = 90;
                Grd_MetaDataPub.Columns[i + 4].ReadOnly = true;

                Grd_MetaDataPub.Columns[i + 5].Visible = true;
                Grd_MetaDataPub.Columns[i + 5].HeaderText = "File Location";
                Grd_MetaDataPub.Columns[i + 5].Width = 500;
                Grd_MetaDataPub.Columns[i + 5].ReadOnly = true;


                Grd_MetaDataPub.Columns[i + 6].Visible = true;
                Grd_MetaDataPub.Columns[i + 6].HeaderText = "File Name";
                Grd_MetaDataPub.Columns[i + 6].Width = 400;
                Grd_MetaDataPub.Columns[i + 6].ReadOnly = true;


                Grd_MetaDataPub.Columns[i + 7].Visible = false;
                Grd_MetaDataPub.Columns[i + 7].HeaderText = "OnixVersion";
                Grd_MetaDataPub.Columns[i + 7].ReadOnly = true;


                Grd_MetaDataPub.Columns[i + 8].Visible = false;
                Grd_MetaDataPub.Columns[i + 8].HeaderText = "TagType";
                Grd_MetaDataPub.Columns[i + 8].ReadOnly = true;

                Grd_MetaDataPub.Columns[i + 9].Visible = false;
                Grd_MetaDataPub.Columns[i + 9].HeaderText = "File Count";
                Grd_MetaDataPub.Columns[i + 9].Width = 70;
                Grd_MetaDataPub.Columns[i + 9].ReadOnly = true;


                Grd_MetaDataPub.Columns[i + 10].Visible = true;
                Grd_MetaDataPub.Columns[i + 10].HeaderText = "File Size (in KB)";
                Grd_MetaDataPub.Columns[i + 10].Width = 100;
                Grd_MetaDataPub.Columns[i + 10].ReadOnly = true;


                Grd_MetaDataPub.Columns[i + 11].Visible = false;
                Grd_MetaDataPub.Columns[i + 11].HeaderText = "XML Encoding";
                Grd_MetaDataPub.Columns[i + 11].Width = 70;
                Grd_MetaDataPub.Columns[i + 11].ReadOnly = true;
                

                                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.Width = 30;
                checkBoxColumn.Name = "checkBoxColumn";
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.ReadOnly = false;
                Grd_MetaDataPub.Columns.Insert(0, checkBoxColumn);
                Grd_MetaDataPub.Columns[0].ReadOnly = false;


            }
            catch (Exception ex)
            {
                result = false;
            }


            #endregion

            return result;

        }

        public CheckBox chBox;
        private void CheckBoxHeader()
        {
            //DataGridViewCheckBoxColumn c1 = new DataGridViewCheckBoxColumn();
            //c1.Name = "";
            //c1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.Grd_MetaDataPub.Columns.Add(c1);


            //chBox = new CheckBox();
            //Rectangle rectangle = this.Grd_MetaDataPub.GetCellDisplayRectangle(0, -1, true);
            //chBox.Size = new Size(17, 17);

            //chBox.Location = rectangle.Location;

            //chBox.CheckedChanged += new EventHandler(chBox_CheckedChanged);

            //this.Grd_MetaDataPub.Controls.Add(chBox);


        }
        private void chBox_CheckedChanged(object sender, EventArgs e)

        {

            //for (int j = 0; j < this.Grd_MetaDataPub.RowCount; j++)

            //{

            //    this.Grd_MetaDataPub[0, j].Value = this.chBox.Checked;

            //}

            //this.Grd_MetaDataPub.EndEdit();

        }

        #endregion


        private void Check_TitleCount(string Company)
        {
            btn_Ingestion2.BackColor = Color.DimGray;
            btn_Ingestion2.Refresh();
            System.Windows.Forms.Application.DoEvents();

            SQLFunction sqlfunction = new SQLFunction();
            sqlfunction.DisplayTitleCount(Company, btn_Ingestion2);


        }


        private void RedirectToIngestionPage(string Company, List<MetaDataFileAvailability> mfa)
        {

            /*
                1. Clean Up
                2. Extraction
                3. Insertion
                4. Processing
                5. Finish
            */
            if (Company == "Recorded Books")
            {
                Company = "RB";
            }
            else if (Company == "W F Howes")
            {
                Company = "WFH";

            }

            if (Company == "WFH")
            {
                if (!File.Exists(@"\\rbftp01\WFHowesPublishing\WFHSAP_TI\RestoreWFHSAP_TI.txt"))
                {
                    Load_Stage1(Company, mfa);
                }
                else
                {
                    MessageBox.Show("Please wait while the WFHSAP_TI database is being Restored.");
                }
            }
            else if (Company == "RB")
            {
                Load_Stage1(Company, mfa);
            }
            else { }


            
               

        }

        private void ErrorLogCount(string Company)
        {
            SQLFunction sqlfunc = new SQLFunction();

            #region 'Populate the Error Log Count'
            sqlfunc.GetErrorLogCount(Company, btn_ErrorLog);
            #endregion
                     
        }

   }
}

