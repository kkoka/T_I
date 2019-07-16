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
    public partial class Stage1 : Form
    {

        private List<MetaDataFileAvailability> mfa_1 = null;
        private string str_Company;
        private string str_Extraction;
        private string str_Processing;
        private string str_complete;

        public Stage1()
        {
            InitializeComponent();           
        }
        public Stage1(string Company, List<MetaDataFileAvailability> mfa)
        {

            /*
                1. Clean Up
                2. Extraction
                3. Insertion
                4. Processing
                5. Finish
            */
            InitializeComponent();

            str_Company = Company;
            mfa_1 = mfa;

        }

        private void Stage1_Load(object sender, EventArgs e)
        {
            lbl_Message.Text = "";
            lbl_Message.Refresh();
            System.Windows.Forms.Application.DoEvents();

            DisplayGrid(str_Company, mfa_1);
            //BeginIngestion(mfa_1);
            ErrorLogCount(str_Company);
             
            if (Grd_MetaDataPub.Rows.Count> 0)
            {
                btn_Start.Enabled = true;
                btn_Start.BackColor = Color.DodgerBlue;
                btn_Start.Refresh();
                System.Windows.Forms.Application.DoEvents();

            }
            else
            {
                btn_Start.Enabled = false;
                btn_Start.BackColor = Color.DimGray;
                btn_Start.Refresh();
                System.Windows.Forms.Application.DoEvents();

            }
        }


        private void btn_Start_Click(object sender, EventArgs e)
        {

            if (System.Configuration.ConfigurationManager.AppSettings["Platform"].ToString().ToLower() == "dev")
            {
                BeginIngestion(mfa_1);
            }
            else
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



        }


        private void btn_Home_Click(object sender, EventArgs e)
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

        private void btn_ErrorLog_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                ErrorLogScreen errorlog = new ErrorLogScreen(str_Company);
                errorlog.ShowDialog();
            }
            else
            {
                MessageBox.Show("A job is currently running....Please wait.");
            }

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(1);

            BeginIngestion(mfa_1);

            backgroundWorker1.ReportProgress(11);

        }
    
        private void BeginIngestion(List<MetaDataFileAvailability> mfa_1)
        {
            try
            {
                bool result = true;

                ResetLabel();

                if (mfa_1.Count > 0)
                {
                    int PubID = Convert.ToInt32(mfa_1[0].PubID);
                    string PublisherName = Convert.ToString(mfa_1[0].PublisherName);
                    string MediaType = Convert.ToString(mfa_1[0].MediaType);
                    string FileType = Convert.ToString(mfa_1[0].FileType);
                    string PublisherFilelocation = Convert.ToString(mfa_1[0].PublisherFilelocation);
                    string FileName = Convert.ToString(mfa_1[0].FileName);
                    string OnixVersion = Convert.ToString(mfa_1[0].OnixVersion);
                    string TagType = Convert.ToString(mfa_1[0].TagType);
                    string XML_Encoding = Convert.ToString(mfa_1[0].XML_Encoding);


                    result = Ingestion(PubID, PublisherName, MediaType, FileType, PublisherFilelocation, FileName, OnixVersion, TagType, XML_Encoding);

                    if (result)
                    {
                        //#region 'Move the files into the processed folder'
                            //string processed_Folder = PublisherFilelocation + "\\Processed";

                            //if (!System.IO.Directory.Exists(processed_Folder))
                            //{
                            //    System.IO.Directory.CreateDirectory(processed_Folder);
                            //}

                            //string processed_Folder_filename = PublisherFilelocation + "\\Processed\\Processed_" + FileName;

                            //if (System.IO.File.Exists(processed_Folder_filename))
                            //{
                            //    System.IO.File.Delete(processed_Folder_filename);
                            //}

                            //System.IO.File.Move(PublisherFilelocation + "\\" + FileName, processed_Folder_filename);
                        //#endregion

                        mfa_1.RemoveAt(0);
                        DisplayGrid(str_Company, mfa_1);
                        Grd_MetaDataPub.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                        BeginIngestion(mfa_1);

                        if (Grd_MetaDataPub.Rows.Count > 0)
                        {
                            btn_Start.BackColor = Color.DodgerBlue;
                            btn_Start.Refresh();
                            System.Windows.Forms.Application.DoEvents();

                        }
                        else
                        {
                            btn_Start.BackColor = Color.DimGray;
                            btn_Start.Refresh();
                            System.Windows.Forms.Application.DoEvents();

                        }
                    }
                    else
                    {
                        lbl_Message.Text = "There has been a problem processing the file : " + FileName;
                        lbl_Message.Refresh();
                        System.Windows.Forms.Application.DoEvents();


                        SQLFunction sqlfnction = new SQLFunction();
                        sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error Processing the " + MediaType + " file : " + FileName + " from the publisher - " + PublisherName);


                        mfa_1.RemoveAt(0);
                        DisplayGrid(str_Company, mfa_1);
                        Grd_MetaDataPub.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                        BeginIngestion(mfa_1);

                        if (Grd_MetaDataPub.Rows.Count > 0)
                        {
                            btn_Start.BackColor = Color.DodgerBlue;
                            btn_Start.Refresh();
                            System.Windows.Forms.Application.DoEvents();

                        }
                        else
                        {
                            btn_Start.BackColor = Color.DimGray;
                            btn_Start.Refresh();
                            System.Windows.Forms.Application.DoEvents();

                        }
                    }

                }
                else
                {

                    lbl_MediaType.Text = "";
                    lbl_PublisheraName.Text = "";
                    lbl_FileName.Text = "";

                    lbl_MediaType.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    lbl_PublisheraName.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    lbl_FileName.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    if (Grd_MetaDataPub.Rows.Count > 0)
                    {
                        btn_Start.BackColor = Color.DodgerBlue;
                        btn_Start.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                    }
                    else
                    {
                        btn_Start.BackColor = Color.DimGray;
                        btn_Start.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                    }

                }

            }
            catch(Exception ex)
            {
                lbl_Message.Text = "There has been a problem with the request. Please see the Error Logs.";
                lbl_Message.Refresh();
                System.Windows.Forms.Application.DoEvents();
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error at BeginIngestion:" + ex.ToString());

            }
            #region 'Commented'

            /*
            foreach (DataGridViewRow row in Grd_MetaDataPub.Rows)
               {
                DataGridViewTextBoxCell txt_id = (DataGridViewTextBoxCell)row.Cells[0];
                string ID = Convert.ToString(txt_id.Value);

                DataGridViewTextBoxCell txt_pubid = (DataGridViewTextBoxCell)row.Cells[1];
                int PubID =  Convert.ToInt32(txt_pubid.Value);

                DataGridViewTextBoxCell txt_publishername = (DataGridViewTextBoxCell)row.Cells[2];
                string PublisherName = Convert.ToString(txt_publishername.Value);

                DataGridViewTextBoxCell txt_MediaType = (DataGridViewTextBoxCell)row.Cells[3];
                string MediaType = Convert.ToString(txt_MediaType.Value);

                DataGridViewTextBoxCell txt_FileType = (DataGridViewTextBoxCell)row.Cells[4];
                string FileType = Convert.ToString(txt_FileType.Value);

                DataGridViewTextBoxCell txt_filelocation = (DataGridViewTextBoxCell)row.Cells[5];
                string PublisherFilelocation = Convert.ToString(txt_filelocation.Value);

                DataGridViewTextBoxCell txt_FileName = (DataGridViewTextBoxCell)row.Cells[6];
                string FileName = Convert.ToString(txt_FileName.Value);
               }
            */

            #endregion



        }

        private void DisplayGrid(string Company, List<MetaDataFileAvailability> mfa)
        {
            #region 'Display Available Files per publisher' 
            List<MetaDataFileAvailability> mfa1 = null;
            try
            {
                //MessageBox.Show("1");
                if (Grd_MetaDataPub.Rows.Count > 0)
                {

                    //this.Grd_MetaDataPub.Refresh(); // Make sure this comes first
                    //this.Grd_MetaDataPub.Parent.Refresh();
                  
                   
                    if(Grd_MetaDataPub.InvokeRequired)
                    {
                        Grd_MetaDataPub.Invoke(new MethodInvoker(() => Grd_MetaDataPub.DataSource = mfa1));
                    }
                    else
                    {
                        Grd_MetaDataPub.DataSource = mfa1;
                    }


                    //MessageBox.Show("1.1");
                    // Grd_MetaDataPub.DataSource =null;
                   //  Grd_MetaDataPub.DataSource = mfa1;
                    // //   Grd_MetaDataPub.DataSource = typeof(List<MetaDataFileAvailability>);

                    //MessageBox.Show("1.2");
                     Grd_MetaDataPub.Columns.Clear();
                    //    //Grd_MetaDataPub.Refresh();
                    //    //System.Windows.Forms.Application.DoEvents();
                    //    MessageBox.Show("1.3");

                }

                //MessageBox.Show("2");

                MetaData_Info mdi = new MetaData_Info();
                Grd_MetaDataPub.DataSource = mfa;

                //MessageBox.Show("3");

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
                Grd_MetaDataPub.Columns[i + 7].HeaderText = "OnixVersion";


                Grd_MetaDataPub.Columns[i + 8].Visible = false;
                Grd_MetaDataPub.Columns[i + 8].HeaderText = "TagType";


                Grd_MetaDataPub.Columns[i + 9].Visible = false;
                Grd_MetaDataPub.Columns[i + 9].HeaderText = "File Count";


                Grd_MetaDataPub.Columns[i + 10].Visible = false;
                Grd_MetaDataPub.Columns[i + 10].HeaderText = "File Size (in KB)";


                Grd_MetaDataPub.ReadOnly = true;

               

                if (Grd_MetaDataPub.Rows.Count > 0)
                {
               
                    btn_Start.BackColor = Color.DodgerBlue;
                    btn_Start.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                }
                else
                {
                 
                    btn_Start.BackColor = Color.DimGray;
                    btn_Start.Refresh();
                    System.Windows.Forms.Application.DoEvents();
                }

            }
            catch (Exception ex)
            {
                lbl_Message.Text = "There has been a problem with the request. Please the Error Logs.";
                lbl_Message.Refresh();
                System.Windows.Forms.Application.DoEvents();
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error at DisplayGrid:" + ex.ToString());

            }


            #endregion
        }

        private void ResetLabel()
        {
            //MessageBox.Show("ResetLabel");

            lbl_CleanUp.BackColor = Color.PaleTurquoise;
            lbl_Extraction.BackColor = Color.PaleTurquoise;
            lbl_Insertion.BackColor = Color.PaleTurquoise;
            lbl_Processing.BackColor = Color.PaleTurquoise;
            lbl_Complete.BackColor = Color.PaleTurquoise;

            lbl_CleanUp.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_Extraction.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_Insertion.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_Processing.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_Complete.Refresh();
            System.Windows.Forms.Application.DoEvents();

        }
    
        private bool Ingestion(int PubID, string PublisherName, string MediaType, string FileType, string FileLocation, string FileName, string OnixVersion, string TagType, string XML_Encoding)
        {
           // MessageBox.Show("Ingestion");

            bool result = true;

            //lbl_Complete.Text = "";
            //lbl_Processing.Text = "";
            //lbl_CleanUp.Text = "";
            //lbl_Extraction.Text = "";
            //lbl_Insertion.Text = "";

            lbl_MediaType.Text = MediaType;
            lbl_PublisheraName.Text = PublisherName;
            lbl_FileName.Text = FileName;

            lbl_MediaType.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_PublisheraName.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_FileName.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_CleanUp.BackColor = Color.PaleTurquoise;
            lbl_Extraction.BackColor = Color.PaleTurquoise;
            lbl_Insertion.BackColor = Color.PaleTurquoise;
            lbl_Processing.BackColor = Color.PaleTurquoise;
            lbl_Complete.BackColor = Color.PaleTurquoise;

            lbl_CleanUp.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_Extraction.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_Insertion.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_Processing.Refresh();
            System.Windows.Forms.Application.DoEvents();

            lbl_Complete.Refresh();
            System.Windows.Forms.Application.DoEvents();

            #region 'Ingestion Process'

            SQLFunction sqlfunction = new SQLFunction();
            result = sqlfunction.ExecuteProc(str_Company, ConfigurationSettings.AppSettings["PreInjestionCleanUp"].ToString());



            #region'Stage 1, 2, 3'

            
            if(result)
            { 
                if(str_Company == "WFH")
                { 
                    WFH_Ingestion_Stages( str_Company, PubID, PublisherName, MediaType, FileType, FileLocation, FileName, OnixVersion, TagType, XML_Encoding);
                }

                else if(str_Company == "RB")
                {
                    RB_Ingestion_Stages(str_Company, PubID, PublisherName, MediaType, FileType, FileLocation, FileName, OnixVersion, TagType, XML_Encoding);
                }
                else
                { }
            }

            #endregion


            #region'Stage 4: Complete'

            lbl_Complete.BackColor = Color.Yellow;
            lbl_Complete.Refresh();
            System.Windows.Forms.Application.DoEvents();


            lbl_Complete.BackColor = Color.Green;
            lbl_Complete.Refresh();
            System.Windows.Forms.Application.DoEvents();


            #endregion

          


            //var thread1 = new Thread(DisplayExtractionNotification);
            //thread1.IsBackground = true;
            //thread1.Start();

            #endregion

            return result;
        }

        private void RB_Ingestion_Stages(string Company, int PubID, string PublisherName, string MediaType, string FileType, string FileLocation, string FileName, string OnixVersion, string TagType, string XML_Encoding)
        {
            bool result = true;

            #region 'Stage 1 : Clean Up and Read ONIX'

            TitleInjestion.Company.RecordedBooks.ReadOnix read_Onix = new TitleInjestion.Company.RecordedBooks.ReadOnix();

            TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.ONIXmessage fileinfo_2short = new TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.ONIXmessage();

            TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton.ONIXMessage fileinfo_2reference = new TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton.ONIXMessage();

            TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition.ONIXmessage fileinfo_3short = new TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition.ONIXmessage();

            TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton.ONIXMessage fileinfo_3reference = new TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton.ONIXMessage();

            string filePath = FileLocation + "\\" + FileName;

            if (result)
            {

                try
                {
              //      string filePath = FileLocation + "\\" + FileName;

                    // filePath = @"C:\Users\kkoka\Desktop\wfh\harpercollins\Metadata_Only_Random_House_UK_Metadata_20160926050922.xml";
                    // filePath = @"C:\Users\kkoka\Desktop\wfh\harpercollins\HCUK_ONIX_full_20141107.xml";
                    if (OnixVersion == "2.1" && TagType == "short")
                    {
                        fileinfo_2short = read_Onix.Work_With_Onix2shortTags(filePath, lbl_Message, lbl_CleanUp, str_Company, MediaType, FileName, PublisherName, OnixVersion, TagType,XML_Encoding);
                    }
                    if (OnixVersion == "2.1" && TagType == "reference")
                    {
                        fileinfo_2reference = read_Onix.Work_With_Onix2referenceTags(filePath, lbl_Message, lbl_CleanUp, str_Company, MediaType, FileName, PublisherName, OnixVersion, TagType, XML_Encoding);
                    }
                    if (OnixVersion == "3.0" && TagType == "short")
                    {
                        fileinfo_3short = read_Onix.Work_With_Onix3shortTags(filePath, lbl_Message, lbl_CleanUp, str_Company, MediaType, FileName, PublisherName, OnixVersion, TagType, XML_Encoding);
                    }
                    if (OnixVersion == "3.0" && TagType == "reference")
                    {
                        fileinfo_3reference = read_Onix.Work_With_Onix3ReferenceTags(filePath, lbl_Message, lbl_CleanUp, str_Company, MediaType, FileName, PublisherName, OnixVersion, TagType, XML_Encoding);
                    }

                }
                catch (Exception ex)
                {
                    result = false;
                    SQLFunction sqlfnction = new SQLFunction();
                    sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error at RB_Ingestion_Stages (Stage 1) :" + ex.ToString());

                }
            }

            #endregion

            #region'Stage 2 & 3 : Extraction & Insert & Process'

            if (result)
            {

                try
                {
                    // System.IO.FileInfo file_1 = new System.IO.FileInfo(@"C:\Users\kkoka\Desktop\wfh\harpercollins\HCUK_ONIX_full_20141107.xml");


                    if (str_Company == "RB" && PubID == 1 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RandomHouse'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.RandomHouse.RandomHouse_Extraction RandomHouse = new Company.RecordedBooks.Publisher.EBook.RandomHouse.RandomHouse_Extraction();
                        result = RandomHouse.RB_RandomHouse_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_RandomHouseEbook
                            result = RandomHouse.Process_RandomHouse(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 2 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Penguin'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Penquin.Penquin_Extraction Penquin = new Company.RecordedBooks.Publisher.EBook.Penquin.Penquin_Extraction();
                        result = Penquin.RB_Penguin_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PenquinEbook
                            result =  Penquin.Process_Penguin(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 3 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Baker'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Baker.Baker_Extraction Baker = new Company.RecordedBooks.Publisher.EBook.Baker.Baker_Extraction();
                        result = Baker.RB_Baker_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PenquinEbook
                            result = Baker.Process_Baker(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 4 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Hachette'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Hachette.Hachette_Extraction Hachette = new Company.RecordedBooks.Publisher.EBook.Hachette.Hachette_Extraction();
                        result = Hachette.RB_Hachette_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PenquinEbook
                            result = Hachette.Process_Hachette(str_Company, lbl_Processing);


                            if (result)
                            {
                                //  MoveFileToProcessedFolder(FileLocation, FileName);

                                if (File.Exists(FileLocation + "\\" + FileName))
                                {
                                    File.Copy(FileLocation + "\\" + FileName, @"\\pfingestion01\incoming\TitleManagement\CustomExtract_Source\Hachette\" + FileName);
                                }

                                }
                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 5 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Barbour'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Barbour.Barbour_Extraction Barbour = new Company.RecordedBooks.Publisher.EBook.Barbour.Barbour_Extraction();
                        result = Barbour.RB_Barbour_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PenquinEbook
                            result = Barbour.Process_Barbour(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 6 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'SimonSchuster'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.SimonSchuster.SimonSchuster_Extraction SimonSchuster = new Company.RecordedBooks.Publisher.EBook.SimonSchuster.SimonSchuster_Extraction();
                        result = SimonSchuster.RB_SimonSchuster_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_SimonSchusterEbook
                            result = SimonSchuster.Process_SimonSchuster(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 7 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'HMH'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.HMH.HMH_Extraction HMH = new Company.RecordedBooks.Publisher.EBook.HMH.HMH_Extraction();
                        result = HMH.RB_HMH_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_SimonSchusterEbook
                            result = HMH.Process_HMH(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 8 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'PoisonedPen'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.PoisonedPenPress.PoisonedPenPress_Extraction PoisonedPen = new Company.RecordedBooks.Publisher.EBook.PoisonedPenPress.PoisonedPenPress_Extraction();
                        result = PoisonedPen.RB_PoisonedPenPress_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PoisonedPenEbook
                            result = PoisonedPen.Process_PoisonedPenPress(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 9 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Workman Ebook'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Workman.Workman_Extraction Workman = new Company.RecordedBooks.Publisher.EBook.Workman.Workman_Extraction();
                        result = Workman.RB_WorkmanEbook_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PoisonedPenEbook
                            result = Workman.Process_WorkmanEbook(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 10 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Macmillan'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Macmillan.Macmillan_Extraction Macmillan = new Company.RecordedBooks.Publisher.EBook.Macmillan.Macmillan_Extraction();
                        result = Macmillan.RB_Macmillan_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MacmillanEbook
                            result = Macmillan.Process_Macmillan(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 11 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'ChronicleBooks'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.ChronicleBooks.ChronicleBooks_Extraction ChronicleBooks = new Company.RecordedBooks.Publisher.EBook.ChronicleBooks.ChronicleBooks_Extraction();
                        result = ChronicleBooks.RB_ChronicleBooks_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ChronicleBooksEbook
                            result = ChronicleBooks.Process_ChronicleBooks(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 12 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Bloomsbury'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.BloomsburyUSA.Bloomsbury_Extraction Bloomsbury = new Company.RecordedBooks.Publisher.EBook.BloomsburyUSA.Bloomsbury_Extraction();
                        result = Bloomsbury.RB_BloomsburyUSA_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_BloomsburyEbook
                            result = Bloomsbury.Process_BloomsburyUSA(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 13 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Open Road'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.OpenRoad.OpenRoad_Extraction OpenRoad = new Company.RecordedBooks.Publisher.EBook.OpenRoad.OpenRoad_Extraction();
                        result = OpenRoad.RB_OpenRoad_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_OpenRoadEbook
                            result = OpenRoad.Process_OpenRoad(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 14 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'DK Publishing'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.DKPublishing.DKPublishing_Extraction DKPublishing = new Company.RecordedBooks.Publisher.EBook.DKPublishing.DKPublishing_Extraction();
                        result = DKPublishing.RB_DKPublishing_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_DKPublishingEbook
                            result = DKPublishing.Process_DKPublishing(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 15 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Groundwood Books'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.GroundwoodBooks.GroundwoodBooks_Extraction GroundwoodBooks = new Company.RecordedBooks.Publisher.EBook.GroundwoodBooks.GroundwoodBooks_Extraction();
                        result = GroundwoodBooks.RB_GroundwoodBooks_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_GroundwoodEbook
                            result = GroundwoodBooks.Process_GroundwoodBooks(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 16 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'OrcaBookPublishers'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.OrcaBookPublishers.OrcaBookPublishers_Extraction OrcaBookPublishers = new Company.RecordedBooks.Publisher.EBook.OrcaBookPublishers.OrcaBookPublishers_Extraction();
                        result = OrcaBookPublishers.RB_OrcaBookPublishers_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_OrcaEbook
                            result = OrcaBookPublishers.Process_OrcaBookPublishers(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 17 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'GalaxyPress'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.GalaxyPress.GalaxyPress_Extraction GalaxyPress = new Company.RecordedBooks.Publisher.EBook.GalaxyPress.GalaxyPress_Extraction();
                        result = GalaxyPress.RB_GalaxyPress_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_GalaxyPressEbook
                            result = GalaxyPress.Process_GalaxyPress(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 18 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Harlequin'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Harlequin.Harlequin_Extraction Harlequin = new Company.RecordedBooks.Publisher.EBook.Harlequin.Harlequin_Extraction();
                        result = Harlequin.RB_Harlequin_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarlequinEbook
                            result = Harlequin.Process_Harlequin(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 19 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Perseus'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Perseus.Perseus_Extraction Perseus = new Company.RecordedBooks.Publisher.EBook.Perseus.Perseus_Extraction();
                        result = Perseus.RB_Perseus_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PerseusEbook
                            result = Perseus.Process_Perseus(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }                    
                    if (str_Company == "RB" && PubID == 20 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'PerseusDistribution'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.PerseusDistribution.PerseusDistribution_Extraction PerseusDistribution = new Company.RecordedBooks.Publisher.EBook.PerseusDistribution.PerseusDistribution_Extraction();
                        result = PerseusDistribution.RB_PerseusDistribution_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PerseusDistributionEbook
                            result = PerseusDistribution.Process_PerseusDistribution(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 21 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Sourcebooks'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Sourcebooks.Sourcebooks_Extraction Sourcebooks = new Company.RecordedBooks.Publisher.EBook.Sourcebooks.Sourcebooks_Extraction();
                        result = Sourcebooks.RB_Sourcebooks_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_SourcebooksEbook
                            result = Sourcebooks.Process_Sourcebooks(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 22 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Thomas Nelson'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.ThomasNelson.ThomasNelson_Extraction ThomasNelson = new Company.RecordedBooks.Publisher.EBook.ThomasNelson.ThomasNelson_Extraction();
                        result = ThomasNelson.RB_ThomasNelson_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ThomasNelsonEbook
                            result = ThomasNelson.Process_ThomasNelson(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 23 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'HarperCollins UK'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.HarperCollinsUK.HarperCollinsUK_Extraction HarperCollinsUK = new Company.RecordedBooks.Publisher.EBook.HarperCollinsUK.HarperCollinsUK_Extraction();
                        result = HarperCollinsUK.RB_HarperCollinsUK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperCollinsUK
                            result = HarperCollinsUK.Process_HarperCollinsUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 24 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Zondervan'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Zondervan.Zondervan_Extraction Zondervan = new Company.RecordedBooks.Publisher.EBook.Zondervan.Zondervan_Extraction();
                        result = Zondervan.RB_Zondervan_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ZondervanEbook
                            result = Zondervan.Process_Zondervan(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 25 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'HarperCollins'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.HarperCollins.HarperCollins_Extraction HarperCollins = new Company.RecordedBooks.Publisher.EBook.HarperCollins.HarperCollins_Extraction();
                        result = HarperCollins.RB_HarperCollins_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperCollinsEbook
                            result = HarperCollins.Process_HarperCollins(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 27 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RandomHouseDistributed'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.RandomHouseDistributed.RandomHouseDistributed_Extraction RandomHouseDistributed = new Company.RecordedBooks.Publisher.EBook.RandomHouseDistributed.RandomHouseDistributed_Extraction();
                        result = RandomHouseDistributed.RB_RandomHouseDistributed_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_RandomHouseDistributedEbook
                            result = RandomHouseDistributed.Process_RandomHouseDistributed(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 17 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'GalaxyPress'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.GalaxyPress.GalaxyPress_Extraction GalaxyPress = new Company.RecordedBooks.Publisher.EAudio.GalaxyPress.GalaxyPress_Extraction();
                        result = GalaxyPress.RB_GalaxyPress_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_GalaxyPressEAudio
                            result = GalaxyPress.Process_GalaxyPress_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 28 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'eChristian'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.eChristian.eChristian_Extraction eChristian = new Company.RecordedBooks.Publisher.EAudio.eChristian.eChristian_Extraction();
                        result = eChristian.RB_eChristian_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_eChristianAudio
                            result = eChristian.Process_eChristian_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 29 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Oasis'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Oasis.Oasis_Extraction Oasis = new Company.RecordedBooks.Publisher.EAudio.Oasis.Oasis_Extraction();
                        result = Oasis.RB_Oasis_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_eChristianAudio
                            result = Oasis.Process_Oasis_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 1  && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RandomHouse'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.RandomHouse.RandomHouse_Extraction RandomHouse = new Company.RecordedBooks.Publisher.EAudio.RandomHouse.RandomHouse_Extraction();
                        result = RandomHouse.RB_RandomHouse_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_RandomHouseAudio
                            result = RandomHouse.Process_RandomHouse_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 30 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Tantor'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Tantor.Tantor_Extraction Tantor = new Company.RecordedBooks.Publisher.EAudio.Tantor.Tantor_Extraction();
                        result = Tantor.RB_Tantor_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_RandomHouseAudio
                            result = Tantor.Process_Tantor_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 6 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'SimonSchuster'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.SimonSchuster.SimonSchuster_Extraction SimonSchuster = new Company.RecordedBooks.Publisher.EAudio.SimonSchuster.SimonSchuster_Extraction();
                        result = SimonSchuster.RB_SimonSchuster_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_SimonSchusterAudio
                            result = SimonSchuster.Process_SimonSchuster_EAudio(str_Company, lbl_Processing);

                            //if (result)
                            //{
                            //  //  MoveFileToProcessedFolder(FileLocation, FileName);

                            //    if (File.Exists(FileLocation+"\\"+ FileName))
                            //    {
                            //        File.Copy(FileLocation+"\\"+ FileName, @"\\pfingestion01\incoming\TitleManagement\CustomExtract_Source\SimonandSchuster\" + FileName);
                            //    }

                            //}
                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 31 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'HighBridge'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.HighBridge.HighBridge_Extraction HighBridge = new Company.RecordedBooks.Publisher.EAudio.HighBridge.HighBridge_Extraction();
                        result = HighBridge.RB_HighBridge_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HighBridgeAudio
                            result = HighBridge.Process_HighBridge_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 32 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'MYBooksLtd'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.MYBooks.MYBooks_Extraction MYBooks = new Company.RecordedBooks.Publisher.EAudio.MYBooks.MYBooks_Extraction();
                        result = MYBooks.RB_MYBooks_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_SimonSchusterAudio
                            result = MYBooks.Process_MYBooks_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                   
                    if (str_Company == "RB" && PubID == 4 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Hachette'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Hachette.Hachette_Extraction Hachette = new Company.RecordedBooks.Publisher.EAudio.Hachette.Hachette_Extraction();
                        result = Hachette.RB_Hachette_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HachetteAudio
                            result = Hachette.Process_Hachette_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 10 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Macmillan'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Macmillan.Macmillan_Extraction Macmillan = new Company.RecordedBooks.Publisher.EAudio.Macmillan.Macmillan_Extraction();
                        result = Macmillan.RB_Macmillan_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MacmillanAudio
                            result = Macmillan.Process_Macmillan_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 25 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'HarperCollins'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.HarperCollins.HarperCollins_Extraction HarperCollins = new Company.RecordedBooks.Publisher.EAudio.HarperCollins.HarperCollins_Extraction();
                        result = HarperCollins.RB_HarperCollins_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperCollinsAudio
                            result = HarperCollins.Process_HarperCollins_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 24 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Zondervan'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Zondervan.Zondervan_Extraction Zondervan = new Company.RecordedBooks.Publisher.EAudio.Zondervan.Zondervan_Extraction();
                        result = Zondervan.RB_Zondervan_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ZondervanAudio
                            result = Zondervan.Process_Zondervan_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                  
                    if (str_Company == "RB" && PubID == 22 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Thomas Nelson'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.ThomasNelson.ThomasNelson_Extraction ThomasNelson = new Company.RecordedBooks.Publisher.EAudio.ThomasNelson.ThomasNelson_Extraction();
                        result = ThomasNelson.RB_ThomasNelson_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ThomasNelsonAudio
                            result = ThomasNelson.Process_ThomasNelson_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 33 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'ECW Press'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.ECWPress.ECW_Press_Extraction ECWPress = new Company.RecordedBooks.Publisher.EBook.ECWPress.ECW_Press_Extraction();
                        result = ECWPress.RB_ECWPress_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ECWPressEbook
                            result = ECWPress.Process_ECWPress(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 34 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Abrams'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Abrams.Abrams_Extraction Abrams = new Company.RecordedBooks.Publisher.EBook.Abrams.Abrams_Extraction();
                        result = Abrams.RB_Abrams_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_AbramsEbook
                            result = Abrams.Process_Abrams(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 35 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Wiley'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Wiley.Wiley_Extraction Wiley = new Company.RecordedBooks.Publisher.EBook.Wiley.Wiley_Extraction();
                        result = Wiley.RB_Wiley_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_WileyEbook
                            result = Wiley.Process_Wiley(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 36 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'HarperAU'
                        //TitleInjestion.Company.RecordedBooks.Publisher.EBook.HarperAU.HarperAU_Extraction HarperAU = new Company.RecordedBooks.Publisher.EBook.HarperAU.HarperAU_Extraction();
                        //result = HarperAU.RB_HarperAU_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.HarperAU.HarperAU_Short_Extraction HarperAU = new Company.RecordedBooks.Publisher.EBook.HarperAU.HarperAU_Short_Extraction();
                        result = HarperAU.RB_HarperAU_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_WileyEbook
                            result = HarperAU.Process_HarperAU(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 37 && MediaType.ToLower()== "eaudio" && FileType.ToLower() == "excel")
                    {
                        #region 'Akashic'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Akashic.Akashic_Extraction Akashic = new Company.RecordedBooks.Publisher.EBook.Akashic.Akashic_Extraction();
                        result = Akashic.RB_Akashic_Extraction(filePath, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_WileyEbook
                            result = Akashic.Process_Akashic(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 38 && MediaType.ToLower() == "eaudio" && OnixVersion == "3.0" && TagType == "short")
                    {
                        #region 'Blackstone'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Blackstone.Blackstone_Extraction Blackstone = new Company.RecordedBooks.Publisher.EAudio.Blackstone.Blackstone_Extraction();
                        result = Blackstone.RB_Blackstone_Extraction(fileinfo_3short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_WileyEbook
                            result = Blackstone.Process_Blackstone_EAudio(str_Company, lbl_Processing);


                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                
                    if (str_Company == "RB" && PubID == 40 && MediaType.ToLower() == "ebook" && OnixVersion == "3.0" && TagType == "short")
                    {
                        #region 'NorthStar'

                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.NorthStar.NorthStar_Extraction NorthStar = new Company.RecordedBooks.Publisher.EBook.NorthStar.NorthStar_Extraction();
                        result = NorthStar.RB_NorthStar_Extraction(fileinfo_3short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_NorthStarEbook
                            result = NorthStar.Process_NorthStar_EBook(str_Company, lbl_Processing);


                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 39 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Lerner'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Lerner.Lerner_Extraction Lerner = new Company.RecordedBooks.Publisher.EBook.Lerner.Lerner_Extraction();
                        result = Lerner.RB_Lerner_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_LernerEbook
                            result = Lerner.Process_Lerner(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 39 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Lerner'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Lerner.Lerner_Extraction Lerner = new Company.RecordedBooks.Publisher.EAudio.Lerner.Lerner_Extraction();
                        result = Lerner.RB_Lerner_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_LernerAudio
                            result = Lerner.Process_Lerner_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 41 && MediaType.ToLower() == "eaudio" && FileType.ToLower() == "excel")
                    {
                        #region 'Scholastic'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Scholastic.Scholastic_Extraction Scholastic = new Company.RecordedBooks.Publisher.EAudio.Scholastic.Scholastic_Extraction();
                        result = Scholastic.RB_Scholastic_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ScholasticEbook
                            result = Scholastic.Process_Scholastic_Extraction(str_Company, lbl_Processing);


                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 42 && MediaType.ToLower() == "ebook" && OnixVersion == "3.0" && TagType == "short")
                    {
                        #region 'Tyndale'
                        //TitleInjestion.Company.RecordedBooks.Publisher.EBook.Tyndale.Tyndale_Extraction Tyndale = new Company.RecordedBooks.Publisher.EBook.Tyndale.Tyndale_Extraction();
                        //result = Tyndale.RB_Tyndale_Extraction(fileinfo_3reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Tyndale.Tyndale_shorttag_Extraction Tyndale = new Company.RecordedBooks.Publisher.EBook.Tyndale.Tyndale_shorttag_Extraction();
                        result = Tyndale.RB_Tyndaleshorttag_Extraction(fileinfo_3short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);
                       
                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_TyndaleEbook
                            result = Tyndale.Process_Tyndale_Extraction(str_Company, lbl_Processing);


                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 43 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Peachtree'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.PeachTree.PeachTree_Extraction Peachtree = new Company.RecordedBooks.Publisher.EBook.PeachTree.PeachTree_Extraction();
                        result = Peachtree.RB_PeachTree_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MacmillanEbook
                            result = Peachtree.Process_PeachTree(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 44 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RandomHouse'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Gildan.Gildan_Extraction Gildan = new Company.RecordedBooks.Publisher.EAudio.Gildan.Gildan_Extraction();
                        result = Gildan.RB_Gildan_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_GildaneAudio
                            result = Gildan.Process_Gildan_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 45 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Pottermore'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Pottermore.Pottermore_Extraction Pottermore = new Company.RecordedBooks.Publisher.EAudio.Pottermore.Pottermore_Extraction();
                        result = Pottermore.RB_Pottermore_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PottermoreAudio
                            result = Pottermore.Process_Pottermore_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 45 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Pottermore'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.Pottermore.Pottermore_Extraction Pottermore = new Company.RecordedBooks.Publisher.EBook.Pottermore.Pottermore_Extraction();
                        result = Pottermore.RB_Pottermore_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PottermoreAudio
                            result = Pottermore.Process_Pottermore_EBook(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "RB" && PubID == 46 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Insatiable'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Insatiable.Insatiable_Extraction Insatiable = new Company.RecordedBooks.Publisher.EAudio.Insatiable.Insatiable_Extraction();
                        result = Insatiable.RB_Insatiable_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_InsatiableeAudio
                            result = Insatiable.Process_Insatiable_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 47 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'ChildsWorld'
                        TitleInjestion.Company.RecordedBooks.Publisher.EBook.ChildsWorld.ChildsWorld_Extraction ChildsWorld = new Company.RecordedBooks.Publisher.EBook.ChildsWorld.ChildsWorld_Extraction();
                        result = ChildsWorld.RB_ChildsWorld_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ChildsWorldEBook
                            result = ChildsWorld.Process_ChildsWorld(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "RB" && PubID == 16 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Orca'
                        TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Orca.Orca_Extraction Orca = new Company.RecordedBooks.Publisher.EAudio.Orca.Orca_Extraction();
                        result = Orca.RB_Orca_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_OrcaAudio
                            result = Orca.Process_Orca_EAudio(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }


                }
                catch (Exception ex)
                {
                    result = false;
                    SQLFunction sqlfnction = new SQLFunction();
                    sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error at RB_Ingestion_Stages (Stage 2 and 3) :" + ex.ToString());

                }


            }

            #endregion

            // return result;
        }
        private void WFH_Ingestion_Stages(string Company, int PubID, string PublisherName, string MediaType, string FileType, string FileLocation,  string FileName, string OnixVersion, string TagType, string XML_Encoding)
        {
            bool result = true;

            #region 'Stage 1 : Clean Up and Read ONIX'

            
           TitleInjestion.Company.WFHowes.ReadOnix read_Onix = new TitleInjestion.Company.WFHowes.ReadOnix();

           TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.ONIXmessage fileinfo_2short = new TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.ONIXmessage();

           TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton.ONIXMessage  fileinfo_2reference = new TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton.ONIXMessage();

            string filePath = FileLocation + "\\" + FileName;

            if (result)
            {

                try
                {
                   
                    // filePath = @"C:\Users\kkoka\Desktop\wfh\harpercollins\Metadata_Only_Random_House_UK_Metadata_20160926050922.xml";
                    // filePath = @"C:\Users\kkoka\Desktop\wfh\harpercollins\HCUK_ONIX_full_20141107.xml";
                    if (OnixVersion == "2.1" && TagType == "short")
                    {
                        fileinfo_2short = read_Onix.Work_With_Onix2shortTags(filePath, lbl_Message, lbl_CleanUp, str_Company, MediaType, FileName, PublisherName, OnixVersion, TagType, XML_Encoding );
                    }
                    if (OnixVersion == "2.1" && TagType == "reference")
                    {
                        fileinfo_2reference = read_Onix.Work_With_Onix2referenceTags(filePath, lbl_Message, lbl_CleanUp, str_Company, MediaType, FileName, PublisherName, OnixVersion, TagType, XML_Encoding);
                    }

                }
                catch (Exception ex)
                {
                    result = false;
                    SQLFunction sqlfnction = new SQLFunction();
                    sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error at WFH_Ingestion_Stages (Stage 1) :" + ex.ToString());

                }
            }

            #endregion

            #region'Stage 2 & 3 : Extraction & Insert & Process'

            if (result)
            {

                try
                {
                    // System.IO.FileInfo file_1 = new System.IO.FileInfo(@"C:\Users\kkoka\Desktop\wfh\harpercollins\HCUK_ONIX_full_20141107.xml");


                    if (str_Company == "WFH" && PubID == 1 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Harper UK'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.HarperCollins_UK.HarperUK_Extraction HarperUK = new Company.WFHowes.Publisher.Ebook.HarperCollins_UK.HarperUK_Extraction();
                        result = HarperUK.Harper_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = HarperUK.Process_HarperUK(str_Company, lbl_Processing);


                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }


                    if (str_Company == "WFH" && PubID == 2 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Harper AU'
                        //TitleInjestion.Company.WFHowes.Publisher.Ebook.HarperCollins_AU.HarperAU_Extraction HarperAU = new Company.WFHowes.Publisher.Ebook.HarperCollins_AU.HarperAU_Extraction();

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.HarperCollins_AU.HarperAU_ShortTag_Extraction HarperAU = new Company.WFHowes.Publisher.Ebook.HarperCollins_AU.HarperAU_ShortTag_Extraction();

                        result = HarperAU.Harper_AU_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = HarperAU.Process_HarperAU(str_Company, lbl_Processing);


                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }


                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 3 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Penguin UK'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Penguin_UK.PenguinUK_Extraction PenguinUK = new Company.WFHowes.Publisher.Ebook.Penguin_UK.PenguinUK_Extraction();
                        result = PenguinUK.Penguin_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = PenguinUK.Process_PenguinUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 4 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RandomHouse UK'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.RandomHouse_UK.RandomHouseUK_Extraction RandomHouseUK = new Company.WFHowes.Publisher.Ebook.RandomHouse_UK.RandomHouseUK_Extraction();
                        result = RandomHouseUK.RandomHouse_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = RandomHouseUK.Process_RandomHouseUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 5 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Bloomsbury UK'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Bloomsbury_UK.Bloomsbury_Extraction BloomsburyUK = new Company.WFHowes.Publisher.Ebook.Bloomsbury_UK.Bloomsbury_Extraction();
                        result = BloomsburyUK.Bloomsbury_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_BloomsburyEbookUK
                            result = BloomsburyUK.Process_Bloomsbury_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 6 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Macmillan UK'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Macmillan_UK.MacmillanUK_Extraction MacmillanUK = new Company.WFHowes.Publisher.Ebook.Macmillan_UK.MacmillanUK_Extraction();
                        result = MacmillanUK.Macmillan_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MacmillanEbookUK
                            result = MacmillanUK.Process_Macmillan_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 7 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Macmillan AU'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Macmillan_AU.MacmillanAU_Extraction MacmillanAU = new Company.WFHowes.Publisher.Ebook.Macmillan_AU.MacmillanAU_Extraction();
                        result = MacmillanAU.Macmillan_AU_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MacmillanEbookAU
                            result = MacmillanAU.Process_Macmillan_AU(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 8 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Faber Factory'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Faber_Factory.FaberFactory_Extraction FaberFactory = new Company.WFHowes.Publisher.Ebook.Faber_Factory.FaberFactory_Extraction();
                        result = FaberFactory.FaberFactory_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_FaberFactoryEbookUK
                            result = FaberFactory.Process_FaberFactoryUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 9 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Faber And Factory'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.FaberAndFaber.FaberAndFaber_Extraction FaberAndFaber = new Company.WFHowes.Publisher.Ebook.FaberAndFaber.FaberAndFaber_Extraction();
                        result = FaberAndFaber.FaberAndFaber_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_FaberAndFaberEbookUK
                            result = FaberAndFaber.Process_FaberAndFaberUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 10 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Canongate'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Canongate.CanongateUK_Extraction Canongate = new Company.WFHowes.Publisher.Ebook.Canongate.CanongateUK_Extraction();
                        result = Canongate.Canongate_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_FaberAndFaberEbookUK
                            result = Canongate.Process_CanongateUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 11 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Pottermore'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Pottermore.PottermoreUK_ShortTag_Extraction Pottermore = new Company.WFHowes.Publisher.Ebook.Pottermore.PottermoreUK_ShortTag_Extraction();
                        result = Pottermore.Pottermore_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PottermoreEbookUK
                            result = Pottermore.Process_PottermoreUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 12 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'SevernHouse'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.SevernHouse.SevernHouseUK_Extraction SevernHouse = new Company.WFHowes.Publisher.Ebook.SevernHouse.SevernHouseUK_Extraction();
                        result = SevernHouse.SevernHouse_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_SevernHouseEbookUK
                            result = SevernHouse.Process_SevernHouseUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 13 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Vearsa'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Vearsa.Vearsa_Extraction Vearsa = new Company.WFHowes.Publisher.Ebook.Vearsa.Vearsa_Extraction();
                        result = Vearsa.Vearsa_UK_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_VearsaEbookUK
                            result = Vearsa.Process_VearsaUK(str_Company, lbl_Processing);

                            if (result)
                            {
                               MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 14 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'MyBooks'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.MyBooks.MyBooksUK_Extraction MyBooks = new Company.WFHowes.Publisher.Ebook.MyBooks.MyBooksUK_Extraction();
                        result = MyBooks.MyBooks_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MyBooksEbookUK
                            result = MyBooks.Process_MyBooks(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 15 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'ScribePublications'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.ScribePublications.ScribePublicationsUK_Extraction ScribePublications = new Company.WFHowes.Publisher.Ebook.ScribePublications.ScribePublicationsUK_Extraction();
                        result = ScribePublications.ScribePublications_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ScribePublicationsUKEbookUK
                            result = ScribePublications.Process_ScribePublicationsUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 16 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'AccentPress'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.AccentPress.AccentPressUK_Extraction AccentPress = new Company.WFHowes.Publisher.Ebook.AccentPress.AccentPressUK_Extraction();
                        result = AccentPress.AccentPress_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_AccentPressUKEbookUK
                            result = AccentPress.Process_AccentPressUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 1 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Harper Collins eaudio'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.HarperCollins_UK.HarperUK_Extraction HarperCollins_UK = new Company.WFHowes.Publisher.EAudio.HarperCollins_UK.HarperUK_Extraction();
                        result = HarperCollins_UK.Harper_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_AccentPressUKEbookUK
                            result = HarperCollins_UK.Process_HarperUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 17 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Black_Inc_Books '
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.BlackBooks_UK.BlackBooks_Extraction BlackBooks_UK = new Company.WFHowes.Publisher.Ebook.BlackBooks_UK.BlackBooks_Extraction();
                        result = BlackBooks_UK.BlackBooks_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_BlackBooksUK
                            result = BlackBooks_UK.Process_BlackBooksUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 18 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Michael_OMara_Books'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Michael_OMara.Michael_OMara_Extraction MichaelOMara_UK = new Company.WFHowes.Publisher.Ebook.Michael_OMara.Michael_OMara_Extraction();
                        result = MichaelOMara_UK.MichaelOMara_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MichaelOMara
                            result = MichaelOMara_UK.Process_MichaelOMara(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }


                    if (str_Company == "WFH" && PubID == 19 && MediaType.ToLower() == "ebook" &&  FileType.ToLower() == "excel" )
                    {
                        #region 'CreativeContent_Books'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.CreativeContent.CreativeContentUK_Extraction CreativeContent_UK = new Company.WFHowes.Publisher.Ebook.CreativeContent.CreativeContentUK_Extraction();
                        result = CreativeContent_UK.CreativeContent_UK_Extraction( PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_CreativeContent
                            result = CreativeContent_UK.Process_CreativeContentUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 11 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Pottermore eaudio'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Pottermore_UK.PottermoreUK_Extraction Pottermore_UK = new Company.WFHowes.Publisher.EAudio.Pottermore_UK.PottermoreUK_Extraction();
                        result = Pottermore_UK.Pottermore_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_AccentPressUKEbookUK
                            result = Pottermore_UK.Process_PottermoreUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 3 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Penguin eaudio'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Penguin_UK.PenguinUK_Extraction Penguin_UK = new Company.WFHowes.Publisher.EAudio.Penguin_UK.PenguinUK_Extraction();
                        result = Penguin_UK.Penguin_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_AccentPressUKEbookUK
                            result = Penguin_UK.Process_PenguinUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 4 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RandomHouse eaudio'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.RandomHouse_UK.RandomHouseUK_Extraction RandomHouse_UK = new Company.WFHowes.Publisher.EAudio.RandomHouse_UK.RandomHouseUK_Extraction();
                        result = RandomHouse_UK.RandomHouse_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_AccentPressUKEbookUK
                            result = RandomHouse_UK.Process_RandomHouseUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    
                    if (str_Company == "WFH" && PubID == 21 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RecordedBooks eaudio'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.RecordedBooks_UK.RecordedBooksUK_Extraction RecordedBooks_UK = new Company.WFHowes.Publisher.EAudio.RecordedBooks_UK.RecordedBooksUK_Extraction();
                        result = RecordedBooks_UK.RecordedBooks_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);
 
                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_RecordedBookseAudioUK
                            result = RecordedBooks_UK.Process_RecordedBooksUK(str_Company, lbl_Processing);
 
                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }
 
                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 22 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'Rebellion'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Rebellion.RebellionUK_Extraction Rebellion_UK = new Company.WFHowes.Publisher.Ebook.Rebellion.RebellionUK_Extraction();
                        result = Rebellion_UK.Rebellion_UK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_RebellionUK
                            result = Rebellion_UK.Process_RebellionUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 18 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Michael_OMara_Books'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Michael_OMara.Michael_OMara_Extraction MichaelOMara_UK = new Company.WFHowes.Publisher.EAudio.Michael_OMara.Michael_OMara_Extraction();
                        result = MichaelOMara_UK.MichaelOMara_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MichaelOMara
                            result = MichaelOMara_UK.Process_MichaelOMara(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 23 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Penguin_AU'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Penguin_AU.PenguinAU_Extraction Penguin_AU = new Company.WFHowes.Publisher.EAudio.Penguin_AU.PenguinAU_Extraction();
                        result = Penguin_AU.Penguin_AU_Extraction( fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Penguin_AU
                            result = Penguin_AU.Process_PenguinAU(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 24 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RandomHouse_AU'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.RandomHouse_AU.RandomHouseAU_Extraction RandomHouse_AU = new Company.WFHowes.Publisher.EAudio.RandomHouse_AU.RandomHouseAU_Extraction();
                        result = RandomHouse_AU.RandomHouse_AU_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_RandomHouse_AU
                            result = RandomHouse_AU.Process_RandomHouseAU(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 25 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'YLolfa_UK'

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.YLolfa.YLolfa_Extraction YLolfa_UK = new Company.WFHowes.Publisher.Ebook.YLolfa.YLolfa_Extraction();
                        result = YLolfa_UK.YLolfa_UK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);

                       
                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_YLolfanUK
                            result = YLolfa_UK.Process_YLolfanUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 26 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Tantor_WFH'

                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Tantor_WFH.TantorWFH_Extraction Tantor_WFH = new Company.WFHowes.Publisher.EAudio.Tantor_WFH.TantorWFH_Extraction();
                        result = Tantor_WFH.Tantor_WFH_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_TantorWFH
                            result = Tantor_WFH.Process_TantorWFH(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 27 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Gildan_WFH'

                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Gildan_WFH.GildanWFH_Extraction Gildan_WFH = new Company.WFHowes.Publisher.EAudio.Gildan_WFH.GildanWFH_Extraction();
                        result = Gildan_WFH.Gildan_WFH_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Gildan_WFH
                            result = Gildan_WFH.Process_Gildan_WFH(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 28 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Highbridge_WFH'

                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Highbridge_WFH.HighbridgeWFH_Extraction Highbridge_WFH = new Company.WFHowes.Publisher.EAudio.Highbridge_WFH.HighbridgeWFH_Extraction();
                        result = Highbridge_WFH.Highbridge_WFH_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HighbridgeWFH
                            result = Highbridge_WFH.Process_HighbridgeWFH(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 29 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'LionHudson UK'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.LionHudson.LionHudson_Extraction LionHudsonUK = new Company.WFHowes.Publisher.Ebook.LionHudson.LionHudson_Extraction();
                        result = LionHudsonUK.LionHudson_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = LionHudsonUK.Process_LionHudson(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 30 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Simon&Schuster_AU'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.SimonSchuster_AU.SimonSchuster_AU_Extraction SimonSchuster_AU = new Company.WFHowes.Publisher.Ebook.SimonSchuster_AU.SimonSchuster_AU_Extraction();
                        result = SimonSchuster_AU.SimonSchusterAU_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = SimonSchuster_AU.Process_SimonSchuster_AU(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 31 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'DreamscapeRB'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Dreamscape_RB.DreamscapeRB_Extraction DreamscapeRB = new Company.WFHowes.Publisher.EAudio.Dreamscape_RB.DreamscapeRB_Extraction();
                        result = DreamscapeRB.Dreamscape_RB_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = DreamscapeRB.Process_DreamscapeRB(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 32 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Troubador'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Troubador.Troubador_Extraction Troubador_UK = new Company.WFHowes.Publisher.Ebook.Troubador.Troubador_Extraction();
                        result = Troubador_UK.TroubadorUK_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Troubador
                            result = Troubador_UK.Process_Troubador(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 33 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Infinite Ideas'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Infinite_Ideas.InfiniteIdeas_Extraction Infinite_Ideas = new Company.WFHowes.Publisher.Ebook.Infinite_Ideas.InfiniteIdeas_Extraction();
                        result = Infinite_Ideas.InfiniteIdeasUK_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Troubador
                            result = Infinite_Ideas.Process_InfiniteIdeas(str_Company, lbl_Processing);
                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }
                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 34 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RoughGuides'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.RoughGuides.RoughGuides_Extraction RoughGuides = new Company.WFHowes.Publisher.Ebook.RoughGuides.RoughGuides_Extraction();
                        result = RoughGuides.RoughGuides_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = RoughGuides.Process_RoughGuides(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 35 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'OasisRB'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Oasis_RB.OasisRB_Extraction Oasis_RB = new Company.WFHowes.Publisher.EAudio.Oasis_RB.OasisRB_Extraction();
                        result = Oasis_RB.Oasis_RB_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperEbook
                            result = Oasis_RB.Process_OasisRB(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }

                    if (str_Company == "WFH" && PubID == 36 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'AlnpeteLimited_UK'

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Alnpete_Limited.AlnpeteLimited_Extraction Alnpete_Limited = new Company.WFHowes.Publisher.Ebook.Alnpete_Limited.AlnpeteLimited_Extraction();
                        result = Alnpete_Limited.AlnpeteLimited_UK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_AlnpeteLimitedEbookUK
                            result = Alnpete_Limited.Process_AlnpeteLimitedUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 37 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'Allen&Unwin_UK'

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Allen_Unwin.Allen_Unwin_Extraction Allen_Unwin = new Company.WFHowes.Publisher.Ebook.Allen_Unwin.Allen_Unwin_Extraction();
                        result = Allen_Unwin.Allen_Unwin_UK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Allen_UnwinEbookUK
                            result = Allen_Unwin.Process_Allen_UnwinUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 38 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'LernerRB'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Lerner_RB.LernerRB_Extraction LernerRB = new Company.WFHowes.Publisher.EAudio.Lerner_RB.LernerRB_Extraction();
                        result = LernerRB.Lerner_RB_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_LernerEAudio
                            result = LernerRB.Process_LernerRB(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 39 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'ListenLiveRB'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.ListenLive_RB.ListenLiveRB_Extraction ListenLiveRB = new Company.WFHowes.Publisher.EAudio.ListenLive_RB.ListenLiveRB_Extraction();
                        result = ListenLiveRB.ListenLive_RB_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_ListenLiveEAudio
                            result = ListenLiveRB.Process_ListenLiveRB(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 20 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'WalkerBooks'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.WalkerBooks.WalkerBooks_Extraction WalkerBooks = new Company.WFHowes.Publisher.Ebook.WalkerBooks.WalkerBooks_Extraction();
                        result = WalkerBooks.WalkerBooks_UK_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_VearsaEbookUK
                            result = WalkerBooks.Process_WalkerBooksUK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 40 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Simon&Schuster_UK'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.SimonSchuster_UK.SimonSchuster_UK_Extraction SimonSchuster_UK = new Company.WFHowes.Publisher.Ebook.SimonSchuster_UK.SimonSchuster_UK_Extraction();
                        result = SimonSchuster_UK.SimonSchusterUK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_SimonSchuster_UKEbook
                            result = SimonSchuster_UK.Process_SimonSchuster_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 41 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Lonely Planet'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.LonelyPlanet.LonelyPlanet_Extraction LonelyPlanet = new Company.WFHowes.Publisher.Ebook.LonelyPlanet.LonelyPlanet_Extraction();
                        result = LonelyPlanet.LonelyPlanetUK_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_LonelyPlanet
                            result = LonelyPlanet.Process_LonelyPlanet(str_Company, lbl_Processing);
                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }



 
                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 42 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'Andrews_UK'

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Andrews_UK.Andrews_UK_Extraction Andrews_UK = new Company.WFHowes.Publisher.Ebook.Andrews_UK.Andrews_UK_Extraction();
                        result = Andrews_UK.AndrewsUK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Andrews_UK
                            result = Andrews_UK.Process_Andrews_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 42 && MediaType.ToLower() == "eaudio" && FileType.ToLower() == "excel")
                    {
                        #region 'Andrews_UK'

                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Andrews_UK.Andrews_UK_Extraction Andrews_UK = new Company.WFHowes.Publisher.EAudio.Andrews_UK.Andrews_UK_Extraction();
                        result = Andrews_UK.AndrewsUK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Andrews_UK
                            result = Andrews_UK.Process_Andrews_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 43 && MediaType.ToLower() == "eaudio" && FileType.ToLower() == "excel")
                    {
                        #region 'Sodalite'

                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Sodalite_UK.Sodalite_UK_Extraction Sodalite_UK = new Company.WFHowes.Publisher.EAudio.Sodalite_UK.Sodalite_UK_Extraction();
                        result = Sodalite_UK.SodaliteUK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Sodalite_UK
                            result = Sodalite_UK.Process_Sodalite_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }                    
                    if (str_Company == "WFH" && PubID == 44 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'Macleod_Trotter'

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Macleod_Trotter.Macleod_Trotter_Extraction Macleod_Trotter_UK = new Company.WFHowes.Publisher.Ebook.Macleod_Trotter.Macleod_Trotter_Extraction();
                        result = Macleod_Trotter_UK.Macleod_Trotter_UK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Macleod_Trotter_UK
                            result = Macleod_Trotter_UK.Process_Macleod_Trotter_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 23 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Penguin_AU'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Penguin_AU.Penguin_AU_Extraction Penguin_AU = new Company.WFHowes.Publisher.Ebook.Penguin_AU.Penguin_AU_Extraction();
                        result = Penguin_AU.PenguinAU_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Penguin_AU
                            result = Penguin_AU.Process_Penguin_AU(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 24 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'RandomHouse_AU'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.RandomHouse_AU.RandomHouse_AU_Extraction RandomHouse_AU = new Company.WFHowes.Publisher.Ebook.RandomHouse_AU.RandomHouse_AU_Extraction();
                        result = RandomHouse_AU.RandomHouseAU_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_RandomHouse_AU
                            result = RandomHouse_AU.Process_RandomHouse_AU(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 43 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'Sodalite_UK'

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Sodalite_UK.Sodalite_UK_Extraction Sodalite_UK = new Company.WFHowes.Publisher.Ebook.Sodalite_UK.Sodalite_UK_Extraction();
                        result = Sodalite_UK.SodaliteUK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Sodalite_UK
                            result = Sodalite_UK.Process_Sodalite_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 45 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'LATheatreWorks_RB'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.LATheatreWorks_RB.LATheatreWorksRB_Extraction LATheatreWorks_RB = new Company.WFHowes.Publisher.EAudio.LATheatreWorks_RB.LATheatreWorksRB_Extraction();
                        result = LATheatreWorks_RB.LATheatreWorks_RB_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_LATheatreWorkseAudioRB
                            result = LATheatreWorks_RB.Process_LATheatreWorksRB(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 46 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Haus'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Haus.Haus_Extraction Haus = new Company.WFHowes.Publisher.Ebook.Haus.Haus_Extraction();
                        result = Haus.HausUK_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Haus
                            result = Haus.Process_Haus(str_Company, lbl_Processing);
                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }




                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 47 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Blackstone_RB'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.Blackstone_RB.BlackstoneRB_Extraction Blackstone_RB = new Company.WFHowes.Publisher.EAudio.Blackstone_RB.BlackstoneRB_Extraction();
                        result = Blackstone_RB.Blackstone_RB_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_BlackstoneeAudioRB
                            result = Blackstone_RB.Process_BlackstoneRB(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 48 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "reference")
                    {
                        #region 'Gingko'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Gingko.Gingko_Extraction Gingko = new Company.WFHowes.Publisher.Ebook.Gingko.Gingko_Extraction();
                        result = Gingko.GingkoUK_Extraction(fileinfo_2reference, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Haus
                            result = Gingko.Process_Gingko(str_Company, lbl_Processing);
                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }




                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 49 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'Telos_UK'

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Telos.Telos_Extraction Telos = new Company.WFHowes.Publisher.Ebook.Telos.Telos_Extraction();
                        result = Telos.TelosUK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Andrews_UK
                            result = Telos.Process_Telos_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 50 && MediaType.ToLower() == "ebook" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'Gardners'
                        TitleInjestion.Company.WFHowes.Publisher.Ebook.Gardners.Gardners_Extraction Gardners = new Company.WFHowes.Publisher.Ebook.Gardners.Gardners_Extraction();
                        result = Gardners.Gardners_UK_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_Gardners
                            result = Gardners.Process_Gardners(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 51 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'HarperCollins_US_RB_Extraction'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.HarperCollinUS_RB.HarperCollinUS_RB_Extraction HarperCollinsUS_RB = new Company.WFHowes.Publisher.EAudio.HarperCollinUS_RB.HarperCollinUS_RB_Extraction();
                        result = HarperCollinsUS_RB.HarperCollins_US_RB_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_HarperCollinUS_RB
                            result = HarperCollinsUS_RB.Process_HarperCollinUS_RB(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 52 && MediaType.ToLower() == "ebook" && FileType.ToLower() == "excel")
                    {
                        #region 'PneumaSprings_UK'

                        TitleInjestion.Company.WFHowes.Publisher.Ebook.PneumaSprings.PneumaSprings_UK_Extraction PneumaSprings_UK = new Company.WFHowes.Publisher.Ebook.PneumaSprings.PneumaSprings_UK_Extraction();
                        result = PneumaSprings_UK.PneumaSpringsUK_Extraction(PubID, filePath, FileName, MediaType, lbl_CleanUp, lbl_Extraction, lbl_Insertion, lbl_Message);


                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_PneumaSprings_UK
                            result = PneumaSprings_UK.Process_PneumaSprings_UK(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }
                            #endregion
                        }

                        #endregion
                    }
                    if (str_Company == "WFH" && PubID == 53 && MediaType.ToLower() == "eaudio" && OnixVersion == "2.1" && TagType == "short")
                    {
                        #region 'MyBooksRB'
                        TitleInjestion.Company.WFHowes.Publisher.EAudio.MyBooks_RB.MyBooksRB_Extraction MyBooksRB = new Company.WFHowes.Publisher.EAudio.MyBooks_RB.MyBooksRB_Extraction();
                        result = MyBooksRB.MyBooks_RB_Extraction(fileinfo_2short, PubID, FileName, MediaType, lbl_Extraction, lbl_Insertion, lbl_Message);

                        if (result)
                        {
                            #region'Stage 4: Processing'
                            //Process_MyBooksRB
                            result = MyBooksRB.Process_MyBooksRB(str_Company, lbl_Processing);

                            if (result)
                            {
                                MoveFileToProcessedFolder(FileLocation, FileName);
                            }

                            #endregion
                        }

                        #endregion
                    }


                }
                catch (Exception ex)
                {
                    result = false;
                    SQLFunction sqlfnction = new SQLFunction();
                    sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(str_Company), "Error at WFH_Ingestion_Stages (Stage 2 and 3) :" + ex.ToString());
                    
                }


            }

            #endregion

           // return result;
        }


        private void MoveFileToProcessedFolder( string PublisherFilelocation, string FileName)
        {
            #region 'Move the files into the processed folder'
            string processed_Folder = PublisherFilelocation + "\\Processed";

            if (!System.IO.Directory.Exists(processed_Folder))
            {
                System.IO.Directory.CreateDirectory(processed_Folder);
            }

            string processed_Folder_filename = PublisherFilelocation + "\\Processed\\Processed_" + FileName;

            if (System.IO.File.Exists(processed_Folder_filename))
            {
                System.IO.File.Delete(processed_Folder_filename);
            }

            System.IO.File.Move(PublisherFilelocation + "\\" + FileName, processed_Folder_filename);

            #endregion

        }
        private void ErrorLogCount(string Company)
        {
            SQLFunction sqlfunc = new SQLFunction();

            #region 'Populate the Error Log Count'
            sqlfunc.GetErrorLogCount(Company, btn_ErrorLog);
            #endregion

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
