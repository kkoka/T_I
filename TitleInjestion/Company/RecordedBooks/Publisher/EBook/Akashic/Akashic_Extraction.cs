using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;

using TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition;
using TitleInjestion.CommonFunctions;


namespace TitleInjestion.Company.RecordedBooks.Publisher.EBook.Akashic
{
    class Akashic_Extraction
    {

     
        public bool RB_Akashic_Extraction(string filePath, int pubid, string FileName, string MediaType,
           System.Windows.Forms.Label lbl_Extraction,
           System.Windows.Forms.Label lbl_Insert,
           System.Windows.Forms.Label lbl_Message)
        {
            bool result = true;
            string Step = "";
            try
            {
                lbl_Extraction.BackColor = System.Drawing.Color.Yellow;
                lbl_Extraction.Refresh();
                System.Windows.Forms.Application.DoEvents();

                #region 'DataTable Creation'

                DataTable dt_MainTitles = new DataTable("MainTitles");
                #region 'Columns Declaration'

                dt_MainTitles.Columns.Add("MetaDataID", typeof(int));
                dt_MainTitles.Columns.Add("ProductID", typeof(int));
                dt_MainTitles.Columns.Add("RowCnt", typeof(int));
                dt_MainTitles.Columns.Add("ISBN", typeof(string));
                dt_MainTitles.Columns.Add("Title", typeof(string));
                dt_MainTitles.Columns.Add("SubTitle", typeof(string));
                dt_MainTitles.Columns.Add("Description", typeof(string));
                dt_MainTitles.Columns.Add("PageCount", typeof(string));
                dt_MainTitles.Columns.Add("Unabridged", typeof(string));
                dt_MainTitles.Columns.Add("Language", typeof(string));
                dt_MainTitles.Columns.Add("BISAC", typeof(string));
                dt_MainTitles.Columns.Add("PublishDate", typeof(string));
                dt_MainTitles.Columns.Add("ReleaseDate", typeof(string));
                dt_MainTitles.Columns.Add("RightsCountry", typeof(string));
                dt_MainTitles.Columns.Add("SeriesName", typeof(string));
                dt_MainTitles.Columns.Add("SeriesPositionNumber", typeof(string));
                dt_MainTitles.Columns.Add("Status", typeof(string));
                dt_MainTitles.Columns.Add("PublisherName", typeof(string));
         

                #endregion


                DataTable dt_Price = new DataTable("Price");
                #region 'Columns Declaration'

                dt_Price.Columns.Add("MetaDataID", typeof(int));
                dt_Price.Columns.Add("ProductID", typeof(int));
                dt_Price.Columns.Add("RowCnt", typeof(int));
                dt_Price.Columns.Add("PriceType_j148", typeof(string));
                dt_Price.Columns.Add("LibraryPrice_j151", typeof(string));
                dt_Price.Columns.Add("CurrencyCode_j152", typeof(string));            
                dt_Price.Columns.Add("j261", typeof(string));
                
                
                #endregion


                DataTable dt_SalesRights = new DataTable("SalesRights");          
                #region 'Columns Declaration'

                dt_SalesRights.Columns.Add("MetaDataID", typeof(int));
                dt_SalesRights.Columns.Add("ProductID", typeof(int));
                dt_SalesRights.Columns.Add("RowCnt", typeof(int));
                dt_SalesRights.Columns.Add("SalesRightsTypeCode_b089", typeof(string));
                dt_SalesRights.Columns.Add("RightsCountry_b090", typeof(string));
                dt_SalesRights.Columns.Add("RightsTerritory_b388", typeof(string));

                #endregion


                DataTable dt_contributor = new DataTable("Contributor");
                #region 'Columns Declaration'

                dt_contributor.Columns.Add("MetaDataID", typeof(int));
                dt_contributor.Columns.Add("ProductID", typeof(int));
                dt_contributor.Columns.Add("RowCnt", typeof(int));
                dt_contributor.Columns.Add("Contribs_SequenceNumber_b034", typeof(string));
                dt_contributor.Columns.Add("Contribs_ContribCode_b035", typeof(string));
                dt_contributor.Columns.Add("Contribs_FNF_b036", typeof(string));
                dt_contributor.Columns.Add("Contribs_LNF_b037", typeof(string));
                dt_contributor.Columns.Add("Contribs_Prefix_b038", typeof(string));
                dt_contributor.Columns.Add("Contribs_FirstName_b039", typeof(string));
                dt_contributor.Columns.Add("Contribs_LastName_b040", typeof(string));
                dt_contributor.Columns.Add("Contribs_CorporateAuthors_b047", typeof(string));

                #endregion


                #endregion

                DataTable dt_Excel = new DataTable();

                SQLFunction sqlfunction = new SQLFunction();

                dt_Excel = sqlfunction.ReadExcel(filePath, dt_Excel);

                if (
                           CheckIfColumnExist(dt_Excel, "publisher") &&
                           CheckIfColumnExist(dt_Excel, "isbn") &&
                           CheckIfColumnExist(dt_Excel, "title") &&
                           CheckIfColumnExist(dt_Excel, "subtitle") &&
                           CheckIfColumnExist(dt_Excel, "author(s)") &&
                           CheckIfColumnExist(dt_Excel, "illustrator(s)") &&
                           CheckIfColumnExist(dt_Excel, "unabridged") &&
                           CheckIfColumnExist(dt_Excel, "bisac code") &&
                           CheckIfColumnExist(dt_Excel, "publish date") &&
                           CheckIfColumnExist(dt_Excel, "release date") &&
                           CheckIfColumnExist(dt_Excel, "page count") &&
                           CheckIfColumnExist(dt_Excel, "library price") &&
                           CheckIfColumnExist(dt_Excel, "currency type") &&
                           CheckIfColumnExist(dt_Excel, "distribution territory") &&
                           CheckIfColumnExist(dt_Excel, "specific countries") &&
                           CheckIfColumnExist(dt_Excel, "description") &&
                          CheckIfColumnExist(dt_Excel, "language (3 digit country code)") &&
                          CheckIfColumnExist(dt_Excel, "series name") &&
                          CheckIfColumnExist(dt_Excel, "series position number") &&
                          CheckIfColumnExist(dt_Excel, "status")
                           )
                {



                    int MetaDataID = InsertMetaData_Info(pubid, FileName, MediaType, "RB");

                    if (MetaDataID > 0)
                    { 

                        for (int i = 0; i < dt_Excel.Rows.Count; i++)
                        {
                            #region 'MainTitles'
                            Step = "MainTitles";
                            dt_MainTitles = MainTitles(dt_MainTitles, dt_Excel, MetaDataID, i);
                            #endregion
                           

                            #region 'Price'
                            Step = "Price";
                            dt_Price = Price( dt_Price, dt_Excel, MetaDataID, i);
                            #endregion


                            #region 'SalesRights'
                            Step = "SalesRights";
                            dt_SalesRights = SalesRights( dt_SalesRights, dt_Excel, MetaDataID, i);

                            #endregion

                            #region 'Contributor'
                            Step = "Contributor";
                            dt_contributor = Contributor( dt_contributor, dt_Excel, MetaDataID, i);

                            #endregion


                        }

                    }
                }

                   
               
              


                lbl_Extraction.BackColor = System.Drawing.Color.Green;
                    lbl_Extraction.Refresh();
                    System.Windows.Forms.Application.DoEvents();



                    lbl_Insert.BackColor = System.Drawing.Color.Yellow;
                    lbl_Insert.Refresh();
                    System.Windows.Forms.Application.DoEvents();


                    #region 'Insert the Data into the SQL Table'

                    int count = 4;

                    result = InsertRecords(dt_MainTitles, "RB");
                    Insertion_Label(lbl_Insert, count);                 
                    count--;


                    if (result)
                    {
                        result = InsertRecords(dt_Price, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;


                    if (result)
                    {
                        result = InsertRecords(dt_SalesRights, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_contributor, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {

                        lbl_Insert.BackColor = System.Drawing.Color.Green;
                        lbl_Insert.Refresh();
                        System.Windows.Forms.Application.DoEvents();


                    }



                    #endregion
                 
            }
            catch (Exception ex)
            {
                result = false;
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString("RB"), "Error at " + Step + " : " + ex.ToString());
            }

            return result;

        }


        public bool CheckIfColumnExist(DataTable dt_Excel, string Columnname)
        {
            bool result = false;

            foreach (DataColumn dc in dt_Excel.Columns)
            {
                if (dc.ColumnName.ToLower() == Columnname)
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
        public void Insertion_Label(System.Windows.Forms.Label lbl_Insertion, int count)
        {
            if (count > 0)
            {
                lbl_Insertion.Text = "Insertion - " + count;
            }
            else
            {
                lbl_Insertion.Text = "Insertion";
            }

            lbl_Insertion.Refresh();
            System.Windows.Forms.Application.DoEvents();



        }

        public void LogStatus()
        {
        }

        public bool InsertRecords(DataTable dt, string Company)
        {
            bool result = false;

            SQLFunction sqlfunction = new SQLFunction();
            result = sqlfunction.SQLInsert(dt, Company);

            return result;

        }
        public int InsertMetaData_Info(int pubid, string FileName, string FileType, string Company)
        {
            int ID;

            SQLFunction sqlfunction = new SQLFunction();
            ID = sqlfunction.InsertMetaData_Info(pubid, FileName, FileType, Company);

            return ID;
        }
        public bool Process_Akashic(string Company, System.Windows.Forms.Label lbl_Processing)
        {
            bool result = false;

            lbl_Processing.BackColor = System.Drawing.Color.Yellow;
            lbl_Processing.Refresh();
            System.Windows.Forms.Application.DoEvents();




            SQLFunction sqlfunction = new SQLFunction();
            result = sqlfunction.ExecuteProc("RB", ConfigurationSettings.AppSettings["RB_Process_Akashic_Ebook"].ToString());

            if (result)
            {
                lbl_Processing.BackColor = System.Drawing.Color.Green;
                lbl_Processing.Refresh();
                System.Windows.Forms.Application.DoEvents();

            }
            else
            {
                lbl_Processing.BackColor = System.Drawing.Color.Red;
                lbl_Processing.Refresh();
                System.Windows.Forms.Application.DoEvents();

            }
            return result;
        }



        #region 'Approved and Confirmed Extraction Rules'

   

        public DataTable MainTitles(DataTable dt_MainTitles, DataTable dt_Excel, int MetaDataID, int rowCount)
        {

             

            DataRow dr = dt_MainTitles.NewRow();
            
                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = rowCount+1;
                    dr["RowCnt"] = rowCount+1;
                    dr["ISBN"] = dt_Excel.Rows[rowCount]["ISBN"].ToString();
                    dr["Title"] = dt_Excel.Rows[rowCount]["Title"].ToString();
                    dr["SubTitle"] = dt_Excel.Rows[rowCount]["Subtitle"].ToString();
                    dr["Description"] = dt_Excel.Rows[rowCount]["Description"].ToString();
                    dr["PageCount"] = dt_Excel.Rows[rowCount]["Page Count"].ToString();
                    dr["Unabridged"] = dt_Excel.Rows[rowCount]["Unabridged"].ToString();
                    dr["Language"] = dt_Excel.Rows[rowCount]["Language (3 Digit Country Code)"].ToString();
                    dr["BISAC"] = dt_Excel.Rows[rowCount]["BISAC Code"].ToString();
                    dr["PublishDate"] = dt_Excel.Rows[rowCount]["Publish Date"].ToString();
                    dr["ReleaseDate"] = dt_Excel.Rows[rowCount]["Release Date"].ToString();
                    dr["RightsCountry"] = dt_Excel.Rows[rowCount][""].ToString();
                    dr["SeriesName"] = dt_Excel.Rows[rowCount]["Series Name"].ToString();
                    dr["SeriesPositionNumber"] = dt_Excel.Rows[rowCount]["Series Position Number"].ToString();
                    dr["Status"] = dt_Excel.Rows[rowCount]["Status"].ToString();
                    dr["PublisherName"] = dt_Excel.Rows[rowCount]["Publisher"].ToString();
            
            dt_MainTitles.Rows.Add(dr);

            return dt_MainTitles;


        }

        public DataTable Price( DataTable dt_Price, DataTable dt_Excel,  int MetaDataID, int rowCount)
        {

            #region 'Price'

             
                                DataRow dr = dt_Price.NewRow();

                                dr["MetaDataID"] = MetaDataID;
                                dr["ProductID"] = rowCount+1;
                                dr["RowCnt"] = rowCount+1;
                                dr["PriceType_j148"] = "";
                                dr["LibraryPrice_j151"] = dt_Excel.Rows[rowCount]["Library Price"].ToString();
                                dr["CurrencyCode_j152"] = dt_Excel.Rows[rowCount]["Currency Type"].ToString();
                                dr["j261"] = "";

                                dt_Price.Rows.Add(dr);
                
               
            #endregion

            return dt_Price;


        }

        public DataTable SalesRights(DataTable dt_SalesRights, DataTable dt_Excel, int MetaDataID, int rowCount)
        {
         
            #region 'SalesRights'

          
                DataRow dr = dt_SalesRights.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = rowCount+1;
                dr["RowCnt"] = rowCount+1;
                dr["SalesRightsTypeCode_b089"] = "";
                dr["RightsCountry_b090"] = dt_Excel.Rows[rowCount]["Distribution Territory"].ToString(); 
                dr["RightsTerritory_b388"] = dt_Excel.Rows[rowCount]["Specific Countries"].ToString();

            dt_SalesRights.Rows.Add(dr);

 

            #endregion


            return dt_SalesRights;


        }

        public DataTable Contributor( DataTable dt_contributor, DataTable dt_Excel, int MetaDataID, int rowCount )
        {

            #region 'Contributor'

           
            
            if (dt_Excel.Rows[rowCount]["Author(s)"].ToString().Trim().Length > 0)
            {
                DataRow dr = dt_contributor.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = rowCount+1;
                dr["RowCnt"] = rowCount+1;
                dr["Contribs_SequenceNumber_b034"] = "";
                dr["Contribs_ContribCode_b035"] = "A01";
                dr["Contribs_FNF_b036"] = "";
                dr["Contribs_LNF_b037"] = dt_Excel.Rows[rowCount]["Author(s)"].ToString().Trim();
                dr["Contribs_Prefix_b038"] = "";
                dr["Contribs_FirstName_b039"] = "";
                dr["Contribs_LastName_b040"] = "";
                dr["Contribs_CorporateAuthors_b047"] = "";

                dt_contributor.Rows.Add(dr);
            }

            if (dt_Excel.Rows[rowCount]["Illustrator(s)"].ToString().Trim().Length > 0)
            {
                DataRow dr1 = dt_contributor.NewRow();

                dr1["MetaDataID"] = MetaDataID;
                dr1["ProductID"] = rowCount+1;
                dr1["RowCnt"] = rowCount+1;
                dr1["Contribs_SequenceNumber_b034"] = "";
                dr1["Contribs_ContribCode_b035"] = "A12";
                dr1["Contribs_FNF_b036"] = "";
                dr1["Contribs_LNF_b037"] = dt_Excel.Rows[rowCount]["Illustrator(s)"].ToString().Trim();
                dr1["Contribs_Prefix_b038"] = "";
                dr1["Contribs_FirstName_b039"] = "";
                dr1["Contribs_LastName_b040"] = "";
                dr1["Contribs_CorporateAuthors_b047"] = "";

                dt_contributor.Rows.Add(dr1);
            }


            #endregion



            return dt_contributor;


        }
      
        #endregion


        public string StringReplace(string stringToSearch, string find, string replaceWith)
        {
            if (stringToSearch == null) return null;
            if (string.IsNullOrEmpty(find) || replaceWith == null) return stringToSearch;
            return stringToSearch.Replace(find, replaceWith);
        }






    }
}
