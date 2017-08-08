using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;



namespace TitleInjestion.CommonFunctions
{
    class CommonFuncCalls
    {
        public string[] Get_ONIXFiles( string directory)
        {
            string[] filePaths = Directory.GetFiles(directory,"*.xml", SearchOption.TopDirectoryOnly);

            return filePaths;
        }

        public string[] Get_ExcelFiles(string directory)
        {
            string[] filePaths = Directory.GetFiles(directory, "*.xml", SearchOption.TopDirectoryOnly);

            return filePaths;
        }

        public List<string> Populate_IngestionSource()
        {

       //     string UserName = Environment.UserName.ToString();
            string UserRights = ConfigurationSettings.AppSettings[Environment.UserName.ToString()].ToString();


            List<string> IngestionSource = ConfigurationSettings.AppSettings["Ingestion_Accounts_" + UserRights].ToString().Split(',').Select(p => p.Trim()).ToList();
            return IngestionSource;            
        }

        public bool CheckIf_ApprovalCorrectionsReports_Exists(string Company)
        {

            bool result = true;

            if (Company == "RB")
            {
                try
                {
                    string ReportPaths = ConfigurationSettings.AppSettings["RB_Reports"].ToString();

                    #region 'Approved Titles'
                    string[] files = Directory.GetFiles(ReportPaths, "MetaData_*.xlsx");

                    if (files.Length > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                    #endregion

                }
                catch (Exception ex)
                {
                    result = false;


                }
            }
            else if (Company == "WFH")
            {
                try
                {
                    string ReportPaths = ConfigurationSettings.AppSettings["Reports"].ToString();

                    #region 'Approved Titles'
                    string[] files = Directory.GetFiles(ReportPaths, "WFH_MetaData_*.xlsx");

                    if (files.Length > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                    #endregion

                }
                catch (Exception ex)
                {
                    result = false;


                }
            }
            else
            { }

            return result;

        }
        public bool Upload_ApprovalCorrections_Reports(string Company)
        {

            bool result = true;

            if (Company == "RB")
            {
                #region 'RB'
                try
                {
                    string ReportPaths = ConfigurationSettings.AppSettings["RB_Reports"].ToString();

                    #region 'Approved Titles'
                    string[] files = Directory.GetFiles(ReportPaths, "MetaData_*.xlsx");


                    SQLFunction sqlfunc = new SQLFunction();

                    for (int i = 0; i < files.Length; i++)
                    {
                        string filename = files[i].ToString();
                        result = sqlfunc.UploadFile_RBMetaData(Company, filename);

                        if (result)
                        {
                            result = sqlfunc.ExecuteProc(Company, "UpdateApprovedTitles");
                        }
                         string destinationReportPaths = filename.Replace(ConfigurationSettings.AppSettings["RB_Reports"].ToString(), ConfigurationSettings.AppSettings["RB_Reports"].ToString() + "\\Approved_Processed\\");

                        if (result)
                        {

                            if (File.Exists(destinationReportPaths))
                            {
                                File.Delete(destinationReportPaths);
                            }
                            File.Move(files[i], destinationReportPaths);
                        }


                    }
                    #endregion
                    if (result)
                    {   
                        result = sqlfunc.ExecuteProc(Company, "GenerateContributors");
                    }

                    #region 'Incorrect Titles'
                    //string[] files_corrections = Directory.GetFiles(ReportPaths, "WFH_MetaData_Correction_*.xlsx");



                    //for (int i = 0; i < files.Length; i++)
                    //{
                    //    string filename = files[i].ToString();
                    //    sqlfunc.UploadFile(Company, filename);

                    //    sqlfunc.ExecuteProc(Company, "UpdateApprovedTitles");


                    //}
                    #endregion

                }
                catch (Exception ex)
                {
                    result = false;


                }
                #endregion
            }

            else if (Company == "WFH")
            {
                #region 'WFH'
                try
                {
                    string ReportPaths = ConfigurationSettings.AppSettings["Reports"].ToString();

                    #region 'Approved Titles'
                    string[] files = Directory.GetFiles(ReportPaths, "WFH_MetaData_*.xlsx");


                    SQLFunction sqlfunc = new SQLFunction();

                    for (int i = 0; i < files.Length; i++)
                    {
                        string filename = files[i].ToString();
                        sqlfunc.UploadFile_MetaData(Company, filename);

                        result = sqlfunc.ExecuteProc(Company, "UpdateApprovedTitles");

                        string destinationReportPaths = filename.Replace(ConfigurationSettings.AppSettings["Reports"].ToString(), ConfigurationSettings.AppSettings["Reports"].ToString() + "\\Approved_Processed\\");

                        if (result)
                        {

                            if (File.Exists(destinationReportPaths))
                            {
                                File.Delete(destinationReportPaths);
                            }
                            File.Move(files[i], destinationReportPaths);
                        }


                    }
                    #endregion
                    if (result)
                    {
                        result = sqlfunc.ExecuteProc(Company, "GenerateContributors");
                    }

                    #region 'Incorrect Titles'
                    //string[] files_corrections = Directory.GetFiles(ReportPaths, "WFH_MetaData_Correction_*.xlsx");



                    //for (int i = 0; i < files.Length; i++)
                    //{
                    //    string filename = files[i].ToString();
                    //    sqlfunc.UploadFile(Company, filename);

                    //    sqlfunc.ExecuteProc(Company, "UpdateApprovedTitles");


                    //}
                    #endregion

                }
                catch (Exception ex)
                {
                    result = false;


                }
                #endregion
            }
            else
            { }

            return result;

        }

        public bool CheckIf_ContributorReport_Exists(string Company)
        {

            bool result = true;

            if (Company == "RB")
            {
                try
                {
                    string ReportPaths = ConfigurationSettings.AppSettings["RB_Reports"].ToString();

                    #region 'Approved Titles'
                    string[] files = Directory.GetFiles(ReportPaths, "Contributor_MetaData_*.xlsx");


                    if (files.Length > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                    #endregion


                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            else if (Company == "WFH")
            {
                try
                {
                    string ReportPaths = ConfigurationSettings.AppSettings["Reports"].ToString();

                    #region 'Approved Titles'
                    string[] files = Directory.GetFiles(ReportPaths, "WFH_Contributor_MetaData_*.xlsx");


                    if (files.Length > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                    #endregion


                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            else
            {
            }

            return result;

        }

        public bool Upload_Contributor_Reports(string Company)
        {

            bool result = true;

            if (Company == "RB")
            {
                try
                {
                    string ReportPaths = ConfigurationSettings.AppSettings["RB_Reports"].ToString();

                    #region 'Approved Titles'
                    string[] files = Directory.GetFiles(ReportPaths, "Contributor_MetaData_*.xlsx");


                    SQLFunction sqlfunc = new SQLFunction();

                    for (int i = 0; i < files.Length; i++)
                    {
                        string filename = files[i].ToString();
                        result = sqlfunc.UploadFile_RBContribs(Company, filename);

                        if (result)
                        {
                            result = sqlfunc.ExecuteProc(Company, "UpdateApprovedContributors");

                            string destinationReportPaths = filename.Replace(ConfigurationSettings.AppSettings["RB_Reports"].ToString(), ConfigurationSettings.AppSettings["RB_Reports"].ToString() + "\\Approved_Processed\\");

                            if (File.Exists(destinationReportPaths))
                            {
                                File.Delete(destinationReportPaths);
                            }

                            File.Move(files[i], destinationReportPaths);

                        }



                    }
                    #endregion

                    #region 'Incorrect Titles'
                    //string[] files_corrections = Directory.GetFiles(ReportPaths, "WFH_MetaData_Correction_*.xlsx");



                    //for (int i = 0; i < files.Length; i++)
                    //{
                    //    string filename = files[i].ToString();
                    //    sqlfunc.UploadFile(Company, filename);

                    //    sqlfunc.ExecuteProc(Company, "UpdateApprovedTitles");


                    //}
                    #endregion
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            else if (Company == "WFH")
            {
                try
                {
                    string ReportPaths = ConfigurationSettings.AppSettings["Reports"].ToString();

                    #region 'Approved Titles'
                    string[] files = Directory.GetFiles(ReportPaths, "WFH_Contributor_MetaData_*.xlsx");


                    SQLFunction sqlfunc = new SQLFunction();

                    for (int i = 0; i < files.Length; i++)
                    {
                        string filename = files[i].ToString();
                        result = sqlfunc.UploadFile_Contribs(Company, filename);

                        if (result)
                        {
                            result = sqlfunc.ExecuteProc(Company, "UpdateApprovedContributors");

                            string destinationReportPaths = filename.Replace(ConfigurationSettings.AppSettings["Reports"].ToString(), ConfigurationSettings.AppSettings["Reports"].ToString() + "\\Approved_Processed\\");

                            if (File.Exists(destinationReportPaths))
                            {
                                File.Delete(destinationReportPaths);
                            }

                            File.Move(files[i], destinationReportPaths);

                        }



                    }
                    #endregion

                    #region 'Incorrect Titles'
                    //string[] files_corrections = Directory.GetFiles(ReportPaths, "WFH_MetaData_Correction_*.xlsx");



                    //for (int i = 0; i < files.Length; i++)
                    //{
                    //    string filename = files[i].ToString();
                    //    sqlfunc.UploadFile(Company, filename);

                    //    sqlfunc.ExecuteProc(Company, "UpdateApprovedTitles");


                    //}
                    #endregion
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            else
            {

            }

            return result;

        }



    }
}
