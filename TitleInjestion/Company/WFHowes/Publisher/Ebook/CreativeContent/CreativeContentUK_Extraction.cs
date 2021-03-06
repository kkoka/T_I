﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;
using System.Configuration;

using System.Data.OleDb;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Linq;

using TitleInjestion.Company.WFHowes.Excel;

using TitleInjestion.CommonFunctions;

namespace TitleInjestion.Company.WFHowes.Publisher.Ebook.CreativeContent
{
    class CreativeContentUK_Extraction
    {
        public List<string> d101_productID = new List<string>();

        public bool CreativeContent_UK_Extraction(int pubid, string FileName_Path, string FileName, string MediaType,
            System.Windows.Forms.Label lbl_CleanUp,
            System.Windows.Forms.Label lbl_Extraction,
            System.Windows.Forms.Label lbl_Insert,
            System.Windows.Forms.Label lbl_Message)
        {
           

            bool result = true;
            string Step = "";
            DataTable dt_TitleCollection = new DataTable();
            try
            {

                lbl_CleanUp.BackColor = System.Drawing.Color.Yellow;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();

                lbl_CleanUp.BackColor = System.Drawing.Color.Green;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();


                lbl_Extraction.BackColor = System.Drawing.Color.Yellow;
                lbl_Extraction.Refresh();
                System.Windows.Forms.Application.DoEvents();

                Step = "Load Excel data into DataTable";

         
                if (FileName.ToLower().Contains(".xls"))
                {
                    if (result)
                    {
                        SQLFunction sqlfunction = new SQLFunction();
                      
                        dt_TitleCollection = sqlfunction.ReadExcel("WFH", FileName_Path);
                        //ReadExcel(FileName_Path);
                    }
                  
                }
 


                bool BOOK_TITLE = false;
                bool CATEGORY = false;
                bool ISBN_1 = false;
                bool LANGUAGE = false;
                bool PUBLISHER = false;
                bool PRIMARY_AUTHOR = false;
                bool SECONDARY_AUTHOR = false;
                bool SERIES = false;
                bool RELEASE_DATE = false;
                //bool SHORT_DESCRIPTION = false;
                bool LONG_DESCRIPTION = false;
                bool NO_OF_PAGES = false;
                bool NO_OF_CHAPTERS = false;
                bool TERRITORY = false;
                bool BISAC1 = false;
                //bool BISAC2 = false;
                //bool BISCAC3 = false;
                bool PRICE_GBP = false;
                //bool PRICE_USD = false;
                bool PRICE_EUR = false;

                #region ''
                foreach (DataColumn column in dt_TitleCollection.Columns)
                {
                    if (column.ColumnName == "BOOK TITLE")
                    {
                        BOOK_TITLE = true;
                    }
                    else if (column.ColumnName == "CATEGORY")
                    {
                        CATEGORY = true;
                    }
                    else if (column.ColumnName == "Digital - 13 digit ISBN")
                    {
                        ISBN_1 = true;
                    }
                    else if (column.ColumnName == "LANGUAGE")
                    {
                        LANGUAGE = true;
                    }
                    else if (column.ColumnName == "PUBLISHER")
                    {
                        PUBLISHER = true;
                    }
                    else if (column.ColumnName == "PRIMARY AUTHOR")
                    {
                        PRIMARY_AUTHOR = true;
                    }
                    else if (column.ColumnName == "SECONDARY AUTHOR")
                    {
                        SECONDARY_AUTHOR = true;
                    }
                    else if (column.ColumnName == "SERIES")
                    {
                        SERIES = true;
                    }
                    else if (column.ColumnName == "RELEASE-DATE")
                    {
                        RELEASE_DATE = true;
                    }
                    //else if (column.ColumnName == "SHORT DESCRIPTION")
                    //{
                    //    SHORT_DESCRIPTION = true;
                    //}
                    else if (column.ColumnName == "LONG DESCRIPTION")
                    {
                        LONG_DESCRIPTION = true;
                    }
                    else if (column.ColumnName == "NO OF PAGES")
                    {
                        NO_OF_PAGES = true;
                    }
                    else if (column.ColumnName == "NO OF CHAPTERS")
                    {
                        NO_OF_CHAPTERS = true;
                    }
                    else if (column.ColumnName == "TERRITORY")
                    {
                        TERRITORY = true;
                    }
                    else if (column.ColumnName == "BISAC 1")
                    {
                        BISAC1 = true;
                    }
                    //else if (column.ColumnName == "BISAC 2")
                    //{
                    //    BISAC2 = true;
                    //}
                    //else if (column.ColumnName == "BISCAC 3")
                    //{
                    //    BISCAC3 = true;
                    //}
                    else if (column.ColumnName == "PRICE GBP")
                    {
                        PRICE_GBP = true;
                    }
                    //else if (column.ColumnName == "PRICE USD")
                    //{
                    //    PRICE_USD = true;
                    //}
                    else if (column.ColumnName == "PRICE EUR")
                    {
                        PRICE_EUR = true;
                    }
                    else { }
                    //   Console.WriteLine(column.ColumnName);
                }

                #endregion


             
                Step = "Column Mapping check";

                if (BOOK_TITLE && CATEGORY && ISBN_1 && LANGUAGE && PUBLISHER && PRIMARY_AUTHOR && SECONDARY_AUTHOR && SERIES && RELEASE_DATE
                    //&& SHORT_DESCRIPTION 
                    && LONG_DESCRIPTION
                    && NO_OF_PAGES
                    //&& NO_OF_CHAPTERS 
                    && TERRITORY
                    && BISAC1 // && BISAC2 && BISCAC3 
                    && PRICE_GBP
                    //&& PRICE_USD 
                    && PRICE_EUR)
                {

                    #region 'main code'
                    //  List<Excel_Template> ExcelRecords = new List<Excel_Template>();

                    // ExcelRecords = LoadExcel(dt_Table, FileName);

                    #region 'DataTable Creation'


                    DataTable dt_RH_MetaDataInfo = new DataTable("MetaDataInfo");
                    #region 'Columns Declaration'

                    dt_RH_MetaDataInfo.Columns.Add("Pub_ID", typeof(int));
                    dt_RH_MetaDataInfo.Columns.Add("FileName", typeof(string));
                    dt_RH_MetaDataInfo.Columns.Add("FileType", typeof(string));

                    #endregion

                    DataTable dt_ISBN = new DataTable("ISBN");
                    #region 'Columns Declaration'

                    dt_ISBN.Columns.Add("MetaDataID", typeof(int));
                    dt_ISBN.Columns.Add("ProductID", typeof(int));
                    dt_ISBN.Columns.Add("RowCnt", typeof(int));
                    //  dt_ISBN.Columns.Add("b221", typeof(string));
                    dt_ISBN.Columns.Add("ISBN_b244", typeof(string));

                    #endregion

                    //DataTable dt_RH_b213 = new DataTable("b213");
                    //#region 'Columns Declaration'

                    //dt_RH_b213.Columns.Add("ProductID", typeof(int));
                    //dt_RH_b213.Columns.Add("b213", typeof(string));

                    //#endregion

                    DataTable dt_Title_Subtitle = new DataTable("Title_Subtitle");
                    #region 'Columns Declaration'

                    dt_Title_Subtitle.Columns.Add("MetaDataID", typeof(int));
                    dt_Title_Subtitle.Columns.Add("ProductID", typeof(int));
                    dt_Title_Subtitle.Columns.Add("RowCnt", typeof(int));
                    dt_Title_Subtitle.Columns.Add("SubTitle_b029", typeof(string));
                    dt_Title_Subtitle.Columns.Add("TitleType_b202", typeof(string));
                    dt_Title_Subtitle.Columns.Add("Title_b203", typeof(string));

                    #endregion

                    DataTable dt_Publisher = new DataTable("Publisher");
                    #region 'Columns Declaration'

                    dt_Publisher.Columns.Add("MetaDataID", typeof(int));
                    dt_Publisher.Columns.Add("ProductID", typeof(int));
                    dt_Publisher.Columns.Add("RowCnt", typeof(int));
                    dt_Publisher.Columns.Add("Publisher_b081", typeof(string));

                    #endregion

                    //DataTable dt_RH_Publisher2 = new DataTable("Publisher2");
                    //#region 'Columns Declaration'

                    //dt_RH_Publisher2.Columns.Add("ProductID", typeof(int));
                    //dt_RH_Publisher2.Columns.Add("RowCnt", typeof(int));
                    //dt_RH_Publisher2.Columns.Add("Publisher_b081", typeof(string));

                    //#endregion

                    DataTable dt_Imprint = new DataTable("Imprint");
                    #region 'Columns Declaration'

                    dt_Imprint.Columns.Add("MetaDataID", typeof(int));
                    dt_Imprint.Columns.Add("ProductID", typeof(int));
                    dt_Imprint.Columns.Add("RowCnt", typeof(int));
                    dt_Imprint.Columns.Add("Imprint_b079", typeof(string));

                    #endregion

                    //DataTable dt_DigitalFormat_b333 = new DataTable("DigitalFormat");
                    //#region 'Columns Declaration'

                    //dt_DigitalFormat_b333.Columns.Add("MetaDataID", typeof(int));
                    //dt_DigitalFormat_b333.Columns.Add("ProductID", typeof(int));
                    //dt_DigitalFormat_b333.Columns.Add("RowCnt", typeof(int));
                    //dt_DigitalFormat_b333.Columns.Add("DigitalFormat_b333", typeof(string));

                    //#endregion;

                    //DataTable dt_UnAbridged = new DataTable("UnAbridged");
                    //#region 'Columns Declaration'

                    //dt_UnAbridged.Columns.Add("MetaDataID", typeof(int));
                    //dt_UnAbridged.Columns.Add("ProductID", typeof(int));
                    //dt_UnAbridged.Columns.Add("RowCnt", typeof(int));
                    //dt_UnAbridged.Columns.Add("Unabridged_b056", typeof(string));

                    //#endregion;

                    DataTable dt_Language = new DataTable("Language");
                    #region 'Columns Declaration'

                    dt_Language.Columns.Add("MetaDataID", typeof(int));
                    dt_Language.Columns.Add("ProductID", typeof(int));
                    dt_Language.Columns.Add("RowCnt", typeof(int));
                    dt_Language.Columns.Add("Language_b252", typeof(string));

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


                    //DataTable dt_Description = new DataTable("Description");
                    //#region 'Columns Declaration'

                    //dt_Description.Columns.Add("MetaDataID", typeof(int));
                    //dt_Description.Columns.Add("ProductID", typeof(int));
                    //dt_Description.Columns.Add("RowCnt", typeof(int));
                    //dt_Description.Columns.Add("DescriptionType_d102", typeof(string));
                    //dt_Description.Columns.Add("TextFormat_d103", typeof(string));
                    //dt_Description.Columns.Add("Description_d104", typeof(string));

                    //#endregion

                    DataTable dt_Description_d101 = new DataTable("Description_d101");
                    #region 'Columns Declaration'

                    dt_Description_d101.Columns.Add("MetaDataID", typeof(int));
                    dt_Description_d101.Columns.Add("ProductID", typeof(int));
                    dt_Description_d101.Columns.Add("RowCnt", typeof(int));
                    dt_Description_d101.Columns.Add("Description_d101", typeof(string));

                    #endregion


                    //DataTable dt_Bisac = new DataTable("Bisac");
                    //#region 'Columns Declaration'

                    //dt_Bisac.Columns.Add("MetaDataID", typeof(int));
                    //dt_Bisac.Columns.Add("ProductID", typeof(int));
                    //dt_Bisac.Columns.Add("RowCnt", typeof(int));
                    //dt_Bisac.Columns.Add("Bisac_b067", typeof(string));
                    //dt_Bisac.Columns.Add("Bisac_b069", typeof(string));

                    //#endregion

                    //DataTable dt_MainBisacBic = new DataTable("MainBisacBic");
                    //#region 'Columns Declaration'

                    //dt_MainBisacBic.Columns.Add("MetaDataID", typeof(int));
                    //dt_MainBisacBic.Columns.Add("ProductID", typeof(int));
                    //dt_MainBisacBic.Columns.Add("RowCnt", typeof(int));
                    //dt_MainBisacBic.Columns.Add("Bisac_b191", typeof(string));
                    //dt_MainBisacBic.Columns.Add("Bisac_b069", typeof(string));

                    //#endregion

                    DataTable dt_BisacBic_b064_b065 = new DataTable("BisacBic");
                    #region 'Columns Declaration'

                    dt_BisacBic_b064_b065.Columns.Add("MetaDataID", typeof(int));
                    dt_BisacBic_b064_b065.Columns.Add("ProductID", typeof(int));
                    dt_BisacBic_b064_b065.Columns.Add("RowCnt", typeof(int));
                    dt_BisacBic_b064_b065.Columns.Add("BisacBic", typeof(string));

                    #endregion

                    //DataTable dt_Bic_b065 = new DataTable("Bic_b065");
                    //#region 'Columns Declaration'

                    //dt_Bic_b065.Columns.Add("MetaDataID", typeof(int));
                    //dt_Bic_b065.Columns.Add("ProductID", typeof(int));
                    //dt_Bic_b065.Columns.Add("RowCnt", typeof(int));
                    //dt_Bic_b065.Columns.Add("Bic_b065", typeof(string));

                    //#endregion

                    //DataTable dt_Audience = new DataTable("Audience");
                    //#region 'Columns Declaration'

                    //dt_Audience.Columns.Add("MetaDataID", typeof(int));
                    //dt_Audience.Columns.Add("ProductID", typeof(int));
                    //dt_Audience.Columns.Add("RowCnt", typeof(int));
                    //dt_Audience.Columns.Add("Audience", typeof(string));

                    //#endregion

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

                    DataTable dt_Series = new DataTable("Series");
                    #region 'Columns Declaration'

                    dt_Series.Columns.Add("MetaDataID", typeof(int));
                    dt_Series.Columns.Add("ProductID", typeof(int));
                    dt_Series.Columns.Add("RowCnt", typeof(int));
                    dt_Series.Columns.Add("SeriesName_b018", typeof(string));
                    dt_Series.Columns.Add("SeriesNumber_b019", typeof(string));
                    dt_Series.Columns.Add("SeriesName_b203", typeof(string));

                    #endregion

                    //DataTable dt_Status_b394 = new DataTable("Status_b394");
                    //#region 'Columns Declaration'

                    //dt_Status_b394.Columns.Add("MetaDataID", typeof(int));
                    //dt_Status_b394.Columns.Add("ProductID", typeof(int));
                    //dt_Status_b394.Columns.Add("RowCnt", typeof(int));
                    //dt_Status_b394.Columns.Add("Status_b394", typeof(string));
                    ////dt_RH_Status_b394.Columns.Add("Status_j141", typeof(string));

                    //#endregion

                    //DataTable dt_Status_j141 = new DataTable("Status_j141");
                    //#region 'Columns Declaration'

                    //dt_Status_j141.Columns.Add("MetaDataID", typeof(int));
                    //dt_Status_j141.Columns.Add("ProductID", typeof(int));
                    //dt_Status_j141.Columns.Add("RowCnt", typeof(int));
                    //dt_Status_j141.Columns.Add("Status_j141", typeof(string));
                    //dt_Status_j141.Columns.Add("Status_j396", typeof(string));

                    //#endregion


                    //DataTable dt_Status_j396 = new DataTable("Status_j396");
                    //#region 'Columns Declaration'

                    //dt_Status_j396.Columns.Add("ProductID", typeof(int));
                    //dt_Status_j396.Columns.Add("RowCnt", typeof(int));
                    //dt_Status_j396.Columns.Add("Status_j396", typeof(string));

                    //#endregion


                    DataTable dt_SalesRights = new DataTable("SalesRights");
                    #region 'Columns Declaration'

                    dt_SalesRights.Columns.Add("MetaDataID", typeof(int));
                    dt_SalesRights.Columns.Add("ProductID", typeof(int));
                    dt_SalesRights.Columns.Add("RowCnt", typeof(int));
                    dt_SalesRights.Columns.Add("SalesRightsTypeCode_b089", typeof(string));
                    dt_SalesRights.Columns.Add("RightsCountry_b090", typeof(string));
                    dt_SalesRights.Columns.Add("RightsTerritory_b388", typeof(string));

                    #endregion

                    //DataTable dt_SalesRights_NotForSale = new DataTable("SalesRights_NotForSale");
                    //#region 'Columns Declaration'

                    //dt_SalesRights_NotForSale.Columns.Add("MetaDataID", typeof(int));
                    //dt_SalesRights_NotForSale.Columns.Add("ProductID", typeof(int));
                    //dt_SalesRights_NotForSale.Columns.Add("RowCnt", typeof(int));
                    //dt_SalesRights_NotForSale.Columns.Add("NotForSale_b090", typeof(string));

                    //#endregion



                    DataTable dt_PageCount = new DataTable("PageCount");
                    #region 'Columns Declaration'

                    dt_PageCount.Columns.Add("MetaDataID", typeof(int));
                    dt_PageCount.Columns.Add("ProductID", typeof(int));
                    dt_PageCount.Columns.Add("RowCnt", typeof(int));
                    dt_PageCount.Columns.Add("PageCount_b061", typeof(string));

                    #endregion

                    //DataTable dt_SalesRestriction = new DataTable("SalesRestriction");
                    //#region 'Columns Declaration'

                    //dt_SalesRestriction.Columns.Add("MetaDataID", typeof(int));
                    //dt_SalesRestriction.Columns.Add("ProductID", typeof(int));
                    //dt_SalesRestriction.Columns.Add("RowCnt", typeof(int));
                    //dt_SalesRestriction.Columns.Add("SalesRestriction_b383", typeof(string));

                    //#endregion

                    DataTable dt_ReleaseDate_b003 = new DataTable("ReleaseDate_b003");
                    #region 'Columns Declaration'

                    dt_ReleaseDate_b003.Columns.Add("MetaDataID", typeof(int));
                    dt_ReleaseDate_b003.Columns.Add("ProductID", typeof(int));
                    dt_ReleaseDate_b003.Columns.Add("RowCnt", typeof(int));
                    dt_ReleaseDate_b003.Columns.Add("ReleaseDate_b003", typeof(string));

                    #endregion

                    //DataTable dt_ReleaseDate_j143 = new DataTable("ReleaseDate_j143");
                    //#region 'Columns Declaration'

                    //dt_ReleaseDate_j143.Columns.Add("MetaDataID", typeof(int));
                    //dt_ReleaseDate_j143.Columns.Add("ProductID", typeof(int));
                    //dt_ReleaseDate_j143.Columns.Add("RowCnt", typeof(int));
                    //dt_ReleaseDate_j143.Columns.Add("ReleaseDate_j143", typeof(string));

                    //#endregion


                    //DataTable dt_MinAge = new DataTable("MinAge");
                    //#region 'Columns Declaration'

                    //dt_MinAge.Columns.Add("MetaDataID", typeof(int));
                    //dt_MinAge.Columns.Add("ProductID", typeof(int));
                    //dt_MinAge.Columns.Add("RowCnt", typeof(int));
                    //dt_MinAge.Columns.Add("b075", typeof(string));
                    //dt_MinAge.Columns.Add("b076", typeof(string));

                    //#endregion

                    //DataTable dt_b211 = new DataTable("b211");
                    //#region 'Columns Declaration'

                    //dt_b211.Columns.Add("MetaDataID", typeof(int));
                    //dt_b211.Columns.Add("ProductID", typeof(int));
                    //dt_b211.Columns.Add("RowCnt", typeof(int));
                    //dt_b211.Columns.Add("b211", typeof(string));

                    //#endregion

                    //DataTable dt_EditionNumber_b057 = new DataTable("EditionNumber_b057");
                    //#region 'Columns Declaration'

                    //dt_EditionNumber_b057.Columns.Add("MetaDataID", typeof(int));
                    //dt_EditionNumber_b057.Columns.Add("ProductID", typeof(int));
                    //dt_EditionNumber_b057.Columns.Add("RowCnt", typeof(int));
                    //dt_EditionNumber_b057.Columns.Add("EditionNumber_b057", typeof(string));

                    //#endregion

                    //DataTable dt_ProductFormCode_b012 = new DataTable("ProductFormCode_b012");
                    //#region 'Columns Declaration'

                    //dt_ProductFormCode_b012.Columns.Add("MetaDataID", typeof(int));
                    //dt_ProductFormCode_b012.Columns.Add("ProductID", typeof(int));
                    //dt_ProductFormCode_b012.Columns.Add("RowCnt", typeof(int));
                    //dt_ProductFormCode_b012.Columns.Add("ProductFormCode_b012", typeof(string));

                    //#endregion

                    #endregion

                    int MetaDataID = InsertMetaData_Info(pubid, FileName, MediaType, "WFH");

                    if (MetaDataID > 0)
                    {
                        for (int i = 0; i < dt_TitleCollection.Rows.Count; i++)
                        {
                            //for (int j = 0; j < dt_TitleCollection.Columns.Count; j++)
                            //{
                            #region 'Populate DataTable'




                            // for each product
                            #region 'ISBN'
                            Step = "ISBN";


                            dt_ISBN = ISBN(dt_TitleCollection, i, dt_ISBN, MetaDataID, (i + 1));
                            #endregion



                            //// for each product
                            //#region 'b213'
                            ////Step = "b213";
                            ////dt_RH_b213 = b213(fileinfo_1.obj_product_List[i], dt_RH_b213, MetaDataID, (i + 1));
                            //#endregion





                            #region 'Title_Subtitle'
                            Step = "Title_Subtitle";
                            dt_Title_Subtitle = TitleSubtitle(dt_TitleCollection, i, dt_Title_Subtitle, MetaDataID, (i + 1));
                            #endregion

                            #region 'Publisher'
                            Step = "Publisher";
                            dt_Publisher = Publisher(dt_TitleCollection, i, dt_Publisher, MetaDataID, (i + 1));
                            #endregion

                            ////#region 'Publisher2'
                            ////dt_RH_Publisher2 = Publisher2(fileinfo_1.obj_product_List[i], dt_RH_Publisher, (i + 1));
                            ////#endregion

                            #region 'Imprint'
                            Step = "Imprint";
                            dt_Imprint = Imprint(dt_TitleCollection, i, dt_Imprint, MetaDataID, (i + 1));
                            #endregion

                            //#region 'UnAbridged'
                            //Step = "UnAbridged";
                            //dt_UnAbridged = UnAbridged(fileinfo_1.obj_product_List[i], dt_UnAbridged, MetaDataID, (i + 1));
                            //#endregion

                            #region 'Language'
                            Step = "Language";
                            dt_Language = Language(dt_TitleCollection, i, dt_Language, MetaDataID, (i + 1));
                            #endregion

                            #region 'Price'
                            Step = "Price";
                            dt_Price = Price(dt_TitleCollection, i, dt_Price, MetaDataID, (i + 1));
                            #endregion

                            #region 'Description'
                            Step = "Description1";
                            dt_Description_d101 = Description_d101(dt_TitleCollection, i, dt_Description_d101, MetaDataID, (i + 1));

                            //Step = "Description2";
                            //dt_Description = Description(fileinfo_1.obj_product_List[i], dt_Description, MetaDataID, (i + 1));

                            #endregion

                            //#region 'DigitalFormat_AudibleWma_b333'

                            //Step = "DigitalFormat_b333";
                            //dt_DigitalFormat_b333 = DigitalFormat_b333(fileinfo_1.obj_product_List[i], dt_DigitalFormat_b333, MetaDataID, (i + 1));

                            //#endregion

                            #region 'Bisac'
                            //Step = "dt_RH_Bisac";
                            //dt_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_Bisac, MetaDataID, (i + 1));

                            //Step = "dt_RH_MainBisacBic";
                            //dt_MainBisacBic = MainBisacBic(fileinfo_1.obj_product_List[i], dt_MainBisacBic, MetaDataID, (i + 1));

                            Step = "dt_BisacBic_b064_b065";
                            dt_BisacBic_b064_b065 = BisacBic_b064_b065(dt_TitleCollection, i, dt_BisacBic_b064_b065, MetaDataID, (i + 1));

                            ////Step = "dt_RH_Bic_b065";
                            ////dt_RH_Bic_b065 = Bic_b065(fileinfo_1.obj_product_List[i], dt_RH_Bic_b065, (i + 1));


                            #endregion

                            //#region 'Audience'
                            //////Step = "dt_RH_Bisac";
                            //////dt_RH_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_RH_Bisac, (i + 1));

                            //Step = "dt_RH_Audience";
                            //dt_Audience = Audience(dt_TitleCollection, i, dt_Audience, MetaDataID, (i + 1));
                            //Step = "dt_RH_Audience";
                            //#endregion

                            //#region 'MinAge'
                            ////Step = "dt_RH_Bisac";
                            ////dt_RH_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_RH_Bisac, (i + 1));

                            //Step = "dt_RH_MinAge";
                            //dt_MinAge = MinAge(fileinfo_1.obj_product_List[i], dt_MinAge, MetaDataID, (i + 1));
                            //Step = "dt_RH_MinAge";



                            //#endregion

                            #region 'Contributors'
                            Step = "Contributors";
                            dt_contributor = Contributor(dt_TitleCollection, i, dt_contributor, MetaDataID, (i + 1));

                            #endregion

                            #region 'Series'
                            Step = "Series";
                            dt_Series = Series(dt_TitleCollection, i, dt_Series, MetaDataID, (i + 1));
                            #endregion

                            //#region 'Status'
                            //Step = "Status_b394";
                            //dt_Status_b394 = Status_b394(fileinfo_1.obj_product_List[i], dt_Status_b394, MetaDataID, (i + 1));

                            //Step = "Status_j141";
                            //dt_Status_j141 = Status_j141(fileinfo_1.obj_product_List[i], dt_Status_j141, MetaDataID, (i + 1));


                            //#endregion

                            #region 'SalesRights'

                            Step = "SalesRights";
                            dt_SalesRights = SalesRights(dt_TitleCollection, i, dt_SalesRights, MetaDataID, (i + 1));

                            //Step = "SalesRights_NotForSale";
                            //dt_SalesRights_NotForSale = SalesRights_NotForSale(fileinfo_1.obj_product_List[i], dt_SalesRights_NotForSale, MetaDataID, (i + 1));

                            #endregion

                            #region 'Page Count'
                            Step = "Page Count";
                            dt_PageCount = PageCount(dt_TitleCollection, i, dt_PageCount, MetaDataID, (i + 1));
                            #endregion

                            //#region 'SalesRestriction'
                            //Step = "SalesRestriction";
                            //dt_SalesRestriction = SalesRestriction(fileinfo_1.obj_product_List[i], dt_SalesRestriction, MetaDataID, (i + 1));
                            //#endregion

                            #region 'ReleaseDate'
                            Step = "ReleaseDate";
                            dt_ReleaseDate_b003 = ReleaseDate_b003(dt_TitleCollection, i, dt_ReleaseDate_b003, MetaDataID, (i + 1));

                            //Step = "Page Count";
                            //dt_ReleaseDate_j143 = ReleaseDate_j143(fileinfo_1.obj_product_List[i], dt_ReleaseDate_j143, MetaDataID, (i + 1));
                            #endregion

                            ////#region 'b211'

                            ////Step = "b211";
                            ////dt_RH_b211 = b211(fileinfo_1.obj_product_List[i], dt_RH_b211, (i + 1));

                            ////#endregion

                            //#region 'EditionNumber_b057'

                            //Step = "EditionNumber_b057";
                            //dt_EditionNumber_b057 = EditionNumber_b057(fileinfo_1.obj_product_List[i], dt_EditionNumber_b057, MetaDataID, (i + 1));

                            //#endregion

                            //#region 'ProductFormCode_b012'

                            //Step = "ProductFormCode_b012";
                            //dt_ProductFormCode_b012 = ProductFormCode_b012(fileinfo_1.obj_product_List[i], dt_ProductFormCode_b012, MetaDataID, (i + 1));

                            //#endregion


                            #endregion
                            //}
                        }

                        lbl_Extraction.BackColor = System.Drawing.Color.Green;
                        lbl_Extraction.Refresh();
                        System.Windows.Forms.Application.DoEvents();



                        lbl_Insert.BackColor = System.Drawing.Color.Yellow;
                        lbl_Insert.Refresh();
                        System.Windows.Forms.Application.DoEvents();


                        #region 'Insert the Data into the SQL Table'

                        int count = 12;

                        result = InsertRecords(dt_ISBN, "WFH");
                        Insertion_Label(lbl_Insert, count);

                        //result = InsertRecords(dt_RH_b213, "WFH");
                        //Insertion_Label(lbl_Insert, count);

                        count--;

                        if (result)
                        {
                            result = InsertRecords(dt_Title_Subtitle, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        if (result)
                        {
                            result = InsertRecords(dt_Publisher, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //InsertRecords(dt_RH_Publisher2);

                        if (result)
                        {
                            result = InsertRecords(dt_Imprint, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_UnAbridged, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        if (result)
                        {
                            result = InsertRecords(dt_Language, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        if (result)
                        {
                            result = InsertRecords(dt_Price, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_Description, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        if (result)
                        {
                            result = InsertRecords(dt_Description_d101, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_DigitalFormat_b333, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_Bisac, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;


                        //if (result)
                        //{
                        //    result = InsertRecords(dt_MainBisacBic, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        if (result)
                        {
                            result = InsertRecords(dt_BisacBic_b064_b065, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_Audience, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_MinAge, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;


                        //if (result)
                        //{
                        //    result = InsertRecords(dt_Bisac2, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        if (result)
                        {
                            result = InsertRecords(dt_contributor, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        if (result)
                        {
                            result = InsertRecords(dt_Series, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_Status_b394, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_Status_j141, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        if (result)
                        {
                            result = InsertRecords(dt_SalesRights, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_SalesRights_NotForSale, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        if (result)
                        {
                            result = InsertRecords(dt_PageCount, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_SalesRestriction, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        // count--;

                        if (result)
                        {
                            result = InsertRecords(dt_ReleaseDate_b003, "WFH");
                            Insertion_Label(lbl_Insert, count);
                        }
                        count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_ReleaseDate_j143, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_RH_b211, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_EditionNumber_b057, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}
                        //count--;

                        //if (result)
                        //{
                        //    result = InsertRecords(dt_ProductFormCode_b012, "WFH");
                        //    Insertion_Label(lbl_Insert, count);
                        //}


                        if (result)
                        {

                            lbl_Insert.BackColor = System.Drawing.Color.Green;
                            lbl_Insert.Refresh();
                            System.Windows.Forms.Application.DoEvents();


                        }



                        #endregion
                    }


                    #endregion
                }
                else
                {

                    #region 'checked the false bool values'

                    string false_values = "";

                    if (!BOOK_TITLE)
                    {
                        false_values = false_values + "BOOK_TITLE";
                    }
                    if (!CATEGORY)
                    {
                        false_values = false_values + ", CATEGORY";
                    }
                    if (!ISBN_1)
                    {
                        false_values = false_values + ", ISBN";
                    }
                    if (!LANGUAGE)
                    {
                        false_values = false_values + ", LANGUAGE";
                    }
                    if (!PUBLISHER)
                    {
                        false_values = false_values + ", PUBLISHER";
                    }
                    if (!PRIMARY_AUTHOR)
                    {
                        false_values = false_values + ", PRIMARY_AUTHOR";
                    }
                    if (!SECONDARY_AUTHOR)
                    {
                        false_values = false_values + ", SECONDARY_AUTHOR";
                    }
                    if (!SERIES)
                    {
                        false_values = false_values + ", SERIES";
                    }
                    if (!RELEASE_DATE)
                    {
                        false_values = false_values + ", RELEASE_DATE";
                    }
                    //if (!SHORT_DESCRIPTION)
                    //{
                    //    false_values = false_values + ", SHORT_DESCRIPTION";
                    //}
                    if (!LONG_DESCRIPTION)
                    {
                        false_values = false_values + ", LONG_DESCRIPTION";
                    }
                    if (!NO_OF_PAGES)
                    {
                        false_values = false_values + ", NO_OF_PAGES";
                    }
                    if (!NO_OF_CHAPTERS)
                    {
                        false_values = false_values + ", NO_OF_CHAPTERS";
                    }
                    if (!TERRITORY)
                    {
                        false_values = false_values + ", TERRITORY";
                    }
                    if (!BISAC1)
                    {
                        false_values = false_values + ", BISAC1";
                    }
                    //if (!BISAC2)
                    //{
                    //    false_values = false_values + ", BISAC2";
                    //}
                    //if (!BISCAC3)
                    //{
                    //    false_values = false_values + ", BISCAC3";
                    //}
                    if (!PRICE_GBP)
                    {
                        false_values = false_values + ", PRICE_GBP";
                    }
                    //if (!PRICE_USD)
                    //{
                    //    false_values = false_values + ", PRICE_USD";
                    //}
                    if (!PRICE_EUR)
                    {
                        false_values = false_values + ", PRICE_EUR";
                    }

                    #endregion

                    result = false;
                    SQLFunction sqlfnction = new SQLFunction();
                    sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString("WFH"), "Error at " + Step + " : The following required columns are missing:  " + false_values);

                }


            }
            catch (Exception ex)
            {
                result = false;
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString("WFH"), "Error at " + Step + " : " + ex.ToString());
            }

            return result;

        }




     
        //private DataTable ReadExcel(string filePath)
        //{

        //    ImpersonateUser iU = new ImpersonateUser();
        //    iU.Undo();


   
        //    //    string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"", filePath);
        //    DataTable table = new DataTable();
        //        DataTable dtSchema = new DataTable();
        //    string step = "";
        //    try
        //    {
        //        int i1 = 0;




        //        //  ArrayList SheetName = new ArrayList();

        //        string strConn = "";

        //        if (filePath.ToLower().EndsWith("xls"))
        //        {
        //            strConn = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34 + "';";
        //        }
        //        else if (filePath.ToLower().EndsWith("xlsx"))
        //        {
        //            //     strConn_working = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=YES" + (char)34;
        //            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34;
        //            //      strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel14.0;HDR=YES;IMEX=1;" + (char)34; 
        //        }
          
        //          using (OleDbConnection dbConnection = new OleDbConnection(strConn))
        //        {
        //            dbConnection.Open();
        //            dtSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

        //            //      string filep = "\\\\rbencode02\\incoming\\titlemanagement\\metadata\\highbridge\\Library_HighBridge_091912.xls"

        //            string[] worksheet_names = new string[dtSchema.Rows.Count];
        //            string SheetName = "";

        //            string[] SheetName_1 = filePath.Split('\\');

        //            //if (SheetName_1[5].ToString().ToLower() == "highbridgeaudio")
        //            //{
        //            //    SheetName = "Metadata$";
        //            //}
        //            //else if(SheetName_1[6].ToString().ToLower() == "audiogo" && SheetName_1[7].ToLower().EndsWith(".xlsx"))
        //            //{                         
        //            //    for (int i = 0; i < dtSchema.Rows.Count; i++)
        //            //    {
        //            //        worksheet_names[i] = dtSchema.Rows[i]["TABLE_NAME"].ToString();
        //            //    }
        //            //}
        //            //else
        //            //{
                  
        //            SheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
        //            for (int ii = 0; ii < dtSchema.Rows.Count; ii++)
        //            {
        //                string sheeetname = dtSchema.Rows[ii]["TABLE_NAME"].ToString();
        //                if (sheeetname != "_xlnm#_FilterDatabase")
        //                {
        //                    SheetName = sheeetname;
        //                    break;
        //                }
        //            }
        //            //}

        //           #region 'Load Excel Data in Result Dataset'

        //            #region 'comment'
        //            //if (SheetName_1[6].ToString().ToLower() == "audiogo" && SheetName_1[7].ToLower().EndsWith(".xlsx"))
        //            //{
        //            //    for (int i = 0; i < dtSchema.Rows.Count; i++)
        //            //    {
        //            //        using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [" + worksheet_names[i] + "]", dbConnection)) //rename sheet if required!

        //            //        dbAdapter.Fill(result,worksheet_names[i].ToString());
        //            //        //result.Tables.Add(table);
        //            //        //int rows = table.Rows.Count;
        //            //    }
        //            //}
        //            #endregion

     
        //            using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [" + SheetName + "]", dbConnection)) //rename sheet if required!
        //                dbAdapter.Fill(table);


        //            table = table.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
          

        //            //for( int r=0; r< table.Rows.Count; r++)
        //            //{
        //            //    for( int i=0; i< table.Columns.Count; i++)
        //            //    {
        //            //        Console.WriteLine(i + ": " + table.Rows[r][i].ToString());
        //            //    }
        //            //     Console.WriteLine(r + " New row ----------------------------- "); 


        //            //}
        //            //result.Tables.Add(table);
        //            int rows = table.Rows.Count;

        //            #endregion

        //            dbConnection.Close();
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        SQLFunction sqlfnction = new SQLFunction();
        //        sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString("WFH"), "Error at ReadExcel : --" + step + "--" + ex.ToString());

        //    }
        //    finally
        //    {
        //        iU.Impersonate();
        //    }


        //    return table;
        //}

        private List<Excel_Template> LoadExcel(DataTable dt, string FileName)
        {
            List<Excel_Template> Excel_Records = new List<Excel_Template>();

            if (dt.Rows.Count>0)
            {
              
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    Excel_Template excelTemplate = new Excel_Template();

                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        /*
                                        BOOK TITLE
                                        CATEGORY
                                        Digital - 13 digit ISBN
                                        LANGUAGE
                                        PUBLISHER
                                        PRIMARY AUTHOR
                                        SECONDARY AUTHOR
                                        SERIES
                                        RELEASE - DATE
                                        SHORT DESCRIPTION
                                        LONG DESCRIPTION
                                        NO OF PAGES
                                        NO OF CHAPTERS
                                        TERRITORY
                                        BISAC 1
                                        BISAC 2
                                        BISCAC 3
                                        PRICE GBP
                                        PRICE USD
                                        PRICE EUR
                        */


                    
                        excelTemplate.Title = dt.Rows[row]["BOOK TITLE"].ToString();
                        excelTemplate.Category = dt.Rows[row]["CATEGORY"].ToString();
                        excelTemplate.ISBN = dt.Rows[row]["Digital - 13 digit ISBN"].ToString();
                        excelTemplate.Language = dt.Rows[row]["LANGUAGE"].ToString();
                        excelTemplate.PublisherName = dt.Rows[row]["PUBLISHER"].ToString();
                        excelTemplate.Authors = dt.Rows[row]["PRIMARY AUTHOR"].ToString();
                        excelTemplate.Authors = excelTemplate.Authors + dt.Rows[row]["SECONDARY AUTHOR"].ToString();
                        excelTemplate.Title = dt.Rows[row]["SERIES"].ToString();
                        excelTemplate.Title = dt.Rows[row]["RELEASE - DATE"].ToString();
                        excelTemplate.Title = dt.Rows[row]["SHORT DESCRIPTION"].ToString();
                        excelTemplate.Title = dt.Rows[row]["LONG DESCRIPTION"].ToString();
                        excelTemplate.Title = dt.Rows[row]["NO OF PAGES"].ToString();
                        excelTemplate.Title = dt.Rows[row]["NO OF CHAPTERS"].ToString();
                        excelTemplate.Title = dt.Rows[row]["TERRITORY"].ToString();
                        excelTemplate.Title = dt.Rows[row]["BISAC 1"].ToString();
                        excelTemplate.Title = dt.Rows[row]["BISAC 2"].ToString();
                        excelTemplate.Title = dt.Rows[row]["BISCAC 3"].ToString();
                        excelTemplate.Title = dt.Rows[row]["PRICE GBP"].ToString();
                        excelTemplate.Title = dt.Rows[row]["PRICE USD"].ToString();
                        excelTemplate.Title = dt.Rows[row]["PRICE EUR"].ToString();
                        excelTemplate.FileName = FileName;

                    }
                    Excel_Records.Add(excelTemplate);
                }
            }

            return Excel_Records;
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
        public bool Process_CreativeContentUK(string Company, System.Windows.Forms.Label lbl_Processing)
        {
            bool result = false;

            lbl_Processing.BackColor = System.Drawing.Color.Yellow;
            lbl_Processing.Refresh();
            System.Windows.Forms.Application.DoEvents();




            SQLFunction sqlfunction = new SQLFunction();
            result = sqlfunction.ExecuteProc("WFH", ConfigurationSettings.AppSettings["WFH_Process_CreativeContent_Ebook_UK"].ToString());

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

        //public DataTable b213(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_b213, int MetaDataID, int productCount)
        //{
        //    DataRow dr = dt_b213.NewRow();

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'dt_b213'
        //    int i = 0;
        //    for (int a = 0; a < product.obj_b213_List.Count; a++)
        //    {


        //        dr["ProductID"] = productCount;
        //        //   dr["RowCnt"] = i;
        //        dr["b213"] = product.obj_b213_List[a].ToString();
        //        dt_b213.Rows.Add(dr);


        //    }
        //    #endregion



        //    return dt_b213;


        //}

        public DataTable ISBN(DataTable dt_TitleCollection, int row,  DataTable dt_ISBN, int MetaDataID, int productCount)
        {
            
            DataRow dr = dt_ISBN.NewRow();

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ISBN_b244'
           
                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = 1;
                    dr["ISBN_b244"] = dt_TitleCollection.Rows[row]["Digital - 13 digit ISBN"].ToString();

                 
            #endregion


            dt_ISBN.Rows.Add(dr);

            return dt_ISBN;


        }
        public DataTable TitleSubtitle(DataTable dt_TitleCollection, int row,  DataTable dt_Title_Subtitle, int MetaDataID, int productCount)
        {

            #region 'Title'

          
                    DataRow dr = dt_Title_Subtitle.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = 1;
                    dr["SubTitle_b029"] = "";
                    dr["TitleType_b202"] = "";
                    dr["Title_b203"] = dt_TitleCollection.Rows[row]["BOOK TITLE"].ToString();

                    dt_Title_Subtitle.Rows.Add(dr);
          
                  
            #endregion


            return dt_Title_Subtitle;

        }
        public DataTable Publisher(DataTable dt_TitleCollection, int row,  DataTable dt_Publisher, int MetaDataID, int productCount)
        {

            #region 'Publisher'
            if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["PUBLISHER"].ToString()))
            {
                DataRow dr = dt_Publisher.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = 1;
                dr["Publisher_b081"] = dt_TitleCollection.Rows[row]["PUBLISHER"].ToString();

                dt_Publisher.Rows.Add(dr);
            }
            #endregion

            return dt_Publisher;

        }
        public DataTable Imprint(DataTable dt_TitleCollection, int row, DataTable dt_Imprint, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Imprint'
          

                if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["PUBLISHER"].ToString()))
                {
                    //if (product.obj_imprint_List[a].b241_product_imprint == "01")
                    //{
                    DataRow dr = dt_Imprint.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = 1;
                    dr["Imprint_b079"] = dt_TitleCollection.Rows[row]["PUBLISHER"].ToString();

                    dt_Imprint.Rows.Add(dr);
                    //}
                }
                 
            #endregion



            return dt_Imprint;


        }
        //public DataTable UnAbridged(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_UnAbridged, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'UnAbridged'
        //    for (int a = 0; a < product.obj_b056_List.Count; a++)
        //    {

        //        DataRow dr = dt_UnAbridged.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["Unabridged_b056"] = product.obj_b056_List[a];

        //        dt_UnAbridged.Rows.Add(dr);

        //    }
        //    #endregion

        //    return dt_UnAbridged;


        //}
        public DataTable Language(DataTable dt_TitleCollection, int row,  DataTable dt_Language, int MetaDataID, int productCount)
        {

            #region 'Language'
        

                DataRow dr = dt_Language.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = 1;
                dr["Language_b252"] = dt_TitleCollection.Rows[row]["LANGUAGE"].ToString();


            dt_Language.Rows.Add(dr);

 
            #endregion

            return dt_Language;


        }
        public DataTable Price(DataTable dt_TitleCollection, int row,  DataTable dt_Price, int MetaDataID, int productCount)
        {

            #region 'Price'



            #region 'GBP'

            if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["PRICE GBP"].ToString()))
            {

                DataRow dr = dt_Price.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = 1;
                dr["PriceType_j148"] = "";
                dr["LibraryPrice_j151"] = dt_TitleCollection.Rows[row]["PRICE GBP"].ToString();
                dr["CurrencyCode_j152"] = "GBP";
                dr["j261"] = "";

                dt_Price.Rows.Add(dr);
            }

            #endregion

            #region 'EUR'

            if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["PRICE EUR"].ToString()))
            {
                DataRow dr1 = dt_Price.NewRow();

                dr1["MetaDataID"] = MetaDataID;
                dr1["ProductID"] = productCount;
                dr1["RowCnt"] = 1;
                dr1["PriceType_j148"] = "";
                dr1["LibraryPrice_j151"] = dt_TitleCollection.Rows[row]["PRICE EUR"].ToString();
                dr1["CurrencyCode_j152"] = "EUR";
                dr1["j261"] = "";

                dt_Price.Rows.Add(dr1);
            }
                   #endregion

                   #region 'USD - Commented Out'

                                //DataRow dr1 = dt_Price.NewRow();

                                //dr["MetaDataID"] = MetaDataID;
                                //dr["ProductID"] = productCount;
                                //dr["RowCnt"] = 1;
                                //dr["PriceType_j148"] = "";
                                //dr["LibraryPrice_j151"] = dt_TitleCollection.Rows[row]["PRICE USD"].ToString();
                                //dr["CurrencyCode_j152"] = "USD";
                                //dr["j261"] = "";

                                //dt_Price.Rows.Add(dr1);

                    #endregion


            #endregion

            return dt_Price;


        }
        public DataTable Description_d101(DataTable dt_TitleCollection, int row,  DataTable dt_Description_d101, int MetaDataID, int productCount)
        {
 
            #region 'Description'

                    DataRow dr = dt_Description_d101.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = 1;

                    if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["LONG DESCRIPTION"].ToString()))
                    {
                        if (dt_TitleCollection.Rows[row]["LONG DESCRIPTION"].ToString().Length > 3500)
                        {
                            //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                            dr["Description_d101"] = dt_TitleCollection.Rows[row]["LONG DESCRIPTION"].ToString().Substring(0, 3500);
                        }
                        else
                        {
                            dr["Description_d101"] = dt_TitleCollection.Rows[row]["LONG DESCRIPTION"].ToString();
                        }
                    }
                    //else if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["SHORT DESCRIPTION"].ToString()))
                    //{
                    //    if (dt_TitleCollection.Rows[row]["SHORT DESCRIPTION"].ToString().Length > 3500)
                    //    {
                    //        //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                    //        dr["Description_d101"] = dt_TitleCollection.Rows[row]["SHORT DESCRIPTION"].ToString().Substring(0, 3500);
                    //    }
                    //    else
                    //    {
                    //        dr["Description_d101"] = dt_TitleCollection.Rows[row]["SHORT DESCRIPTION"].ToString();
                    //    }
                    //}
                    else
                    {
                        //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                        dr["Description_d101"] = "";
                    }

                   dt_Description_d101.Rows.Add(dr);

              


            #endregion



            return dt_Description_d101;


        }
        //public DataTable Description(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_Description, int MetaDataID, int productCount)
        //{

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Description'

        //    for (int a = 0; a < product.obj_product_othertext_List.Count; a++)
        //    {
        //        if (product.obj_product_othertext_List[a].d102_product_othertext == "03" ||
        //            product.obj_product_othertext_List[a].d102_product_othertext == "01" ||
        //            product.obj_product_othertext_List[a].d102_product_othertext == "02" ||
        //            product.obj_product_othertext_List[a].d102_product_othertext == "25")
        //        {
        //            DataRow dr = dt_Description.NewRow();

        //            dr["MetaDataID"] = MetaDataID;
        //            dr["ProductID"] = productCount;
        //            dr["RowCnt"] = (a + 1);
        //            dr["DescriptionType_d102"] = product.obj_product_othertext_List[a].d102_product_othertext;
        //            dr["TextFormat_d103"] = product.obj_product_othertext_List[a].d103_product_othertext;

        //            if (!string.IsNullOrEmpty(product.obj_product_othertext_List[a].d104_product_othertext))
        //            {
        //                if (product.obj_product_othertext_List[a].d104_product_othertext.Length > 3500)
        //                {
        //                    //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
        //                    dr["Description_d104"] = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
        //                }
        //                else
        //                {
        //                    //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
        //                    dr["Description_d104"] = product.obj_product_othertext_List[a].d104_product_othertext;
        //                }
        //            }
        //            else
        //            {
        //                dr["Description_d104"] = "";
        //            }

        //            dt_Description.Rows.Add(dr);
        //        }

        //    }
        //    #endregion



        //    return dt_Description;


        //}
        public DataTable Contributor(DataTable dt_TitleCollection, int row,  DataTable dt_contributor, int MetaDataID, int productCount)
        {

            #region 'Contributor'

            if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["PRIMARY AUTHOR"].ToString()))
            {
                DataRow dr = dt_contributor.NewRow();

                string[] str_contributor = dt_TitleCollection.Rows[row]["PRIMARY AUTHOR"].ToString().Split(' ');
                int cnt = str_contributor.Count();

                string LastName = str_contributor[cnt-1];
                string FirstName = "";

                for (int i=0; i< cnt-1;i++)
                {
                    FirstName += " " + str_contributor[i]; 
                }

                FirstName = FirstName.Trim();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = 1;
                dr["Contribs_SequenceNumber_b034"] = "1";
                dr["Contribs_ContribCode_b035"] = "A01";
                dr["Contribs_FNF_b036"] = dt_TitleCollection.Rows[row]["PRIMARY AUTHOR"].ToString();
                dr["Contribs_LNF_b037"] = "";
                dr["Contribs_Prefix_b038"] = "";
                dr["Contribs_FirstName_b039"] = FirstName;
                dr["Contribs_LastName_b040"] = LastName;
                dr["Contribs_CorporateAuthors_b047"] = "";

                dt_contributor.Rows.Add(dr);
            }


            if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["SECONDARY AUTHOR"].ToString()))
            {
                DataRow dr1 = dt_contributor.NewRow();

                string[] str_contributor = dt_TitleCollection.Rows[row]["SECONDARY AUTHOR"].ToString().Split(' ');
                int cnt = str_contributor.Count();

                string LastName = str_contributor[cnt - 1];
                string FirstName = "";

                for (int i = 0; i < cnt - 1; i++)
                {
                    FirstName += " " + str_contributor[i];
                }

                FirstName = FirstName.Trim();



                dr1["MetaDataID"] = MetaDataID;
                dr1["ProductID"] = productCount;
                dr1["RowCnt"] = 1;
                dr1["Contribs_SequenceNumber_b034"] = "2";
                dr1["Contribs_ContribCode_b035"] = "A01";
                dr1["Contribs_FNF_b036"] = dt_TitleCollection.Rows[row]["SECONDARY AUTHOR"].ToString();
                dr1["Contribs_LNF_b037"] = "";
                dr1["Contribs_Prefix_b038"] = "";
                dr1["Contribs_FirstName_b039"] = FirstName;
                dr1["Contribs_LastName_b040"] = LastName;
                dr1["Contribs_CorporateAuthors_b047"] = "";

                dt_contributor.Rows.Add(dr1);
            }

            #endregion



            return dt_contributor;


        }
        //public DataTable DigitalFormat_b333(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_DigitalFormat_b333, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'DigitalFormat_b333'

        //    if (product.obj_b333_List.Count == 0)
        //    {

        //        DataRow dr = dt_DigitalFormat_b333.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (1);
        //        dr["DigitalFormat_b333"] = "Reflowable";
        //        dt_DigitalFormat_b333.Rows.Add(dr);

        //    }

        //    for (int a = 0; a < product.obj_b333_List.Count; a++)
        //    {

        //        DataRow dr = dt_DigitalFormat_b333.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        //  dr["DigitalFormat_b333"] = "Reflowable";

        //        if (!string.IsNullOrEmpty(product.obj_b333_List[a]))
        //        {

        //            //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);

        //            if (product.obj_b333_List[a].ToString().ToLower() == "e200")
        //            {
        //                //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
        //                // dr["DigitalFormat_b333"] = product.obj_b333_List[a]; 
        //                dr["DigitalFormat_b333"] = "Reflowable";
        //            }
        //            else if (product.obj_b333_List[a].ToString().ToLower() == "e101")
        //            {
        //                //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
        //                // dr["DigitalFormat_b333"] = product.obj_b333_List[a]; 
        //                dr["DigitalFormat_b333"] = "Reflowable";
        //            }
        //            else if (product.obj_b333_List[a].ToString().ToLower() == "e201")
        //            {
        //                //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
        //                // dr["DigitalFormat_b333"] = product.obj_b333_List[a]; 
        //                dr["DigitalFormat_b333"] = "Fixed Layout";
        //            }
        //            else
        //            {
        //                if (product.obj_b333_List[a].Trim().Length > 0)
        //                {
        //                    dr["DigitalFormat_b333"] = product.obj_b333_List[a].Trim();
        //                }
        //                else
        //                {
        //                    dr["DigitalFormat_b333"] = "Reflowable";
        //                }
        //            }



        //        }
        //        else
        //        {
        //            dr["DigitalFormat_b333"] = "Reflowable";
        //        }

        //        dt_DigitalFormat_b333.Rows.Add(dr);


        //    }

        //    #endregion



        //    return dt_DigitalFormat_b333;


        //}
        //public DataTable MainBisacBic(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_MainBisacBic, int MetaDataID, int productCount)
        //{
        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Bisac'

        //    for (int a = 0; a < product.obj_product_mainsubject_List.Count; a++)
        //    {
        //        if (product.obj_product_mainsubject_List[a].b191_product_mainsubject == "10" || product.obj_product_mainsubject_List[a].b191_product_mainsubject == "12")
        //        {
        //            DataRow dr = dt_MainBisacBic.NewRow();

        //            dr["MetaDataID"] = MetaDataID;
        //            dr["ProductID"] = productCount;
        //            dr["RowCnt"] = (a + 1);
        //            dr["Bisac_b191"] = product.obj_product_mainsubject_List[a].b191_product_mainsubject;
        //            dr["Bisac_b069"] = product.obj_product_mainsubject_List[a].b069_product_mainsubject;

        //            dt_MainBisacBic.Rows.Add(dr);
        //        }
        //    }

        //    #endregion



        //    return dt_MainBisacBic;


        //}
        //public DataTable Bisac(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_Bisac, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Bisac'

        //    for (int a = 0; a < product.obj_product_subject_List.Count; a++)
        //    {
        //        if (product.obj_product_subject_List[a].b067_product_subject == "10" || product.obj_product_subject_List[a].b067_product_subject == "12")
        //        {
        //            DataRow dr = dt_Bisac.NewRow();
        //            dr["MetaDataID"] = MetaDataID;

        //            dr["ProductID"] = productCount;
        //            dr["RowCnt"] = (a + 1);
        //            dr["Bisac_b067"] = product.obj_product_subject_List[a].b067_product_subject;
        //            dr["Bisac_b069"] = product.obj_product_subject_List[a].b069_product_subject;

        //            dt_Bisac.Rows.Add(dr);
        //        }
        //    }

        //    return dt_Bisac;

        //    #endregion

        //}
        public DataTable BisacBic_b064_b065(DataTable dt_TitleCollection, int row,  DataTable dt_BisacBic_b064_b065, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'BisacBic_b064_b065'
         
            string Bisac_Bic = "";

            if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["BISAC 1"].ToString()))
            {
                Bisac_Bic = dt_TitleCollection.Rows[row]["BISAC 1"].ToString();
            }
            //else if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["BISAC 2"].ToString()))
            //{
            //    Bisac_Bic = dt_TitleCollection.Rows[row]["BISAC 2"].ToString();
            //}
            //else if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["BISCAC 3"].ToString()))
            //{
            //    Bisac_Bic = dt_TitleCollection.Rows[row]["BISCAC 3"].ToString();
            //}
            else
            {
                Bisac_Bic = "";
            }
            


 
            if (Bisac_Bic.Length > 0)
            {
                DataRow dr = dt_BisacBic_b064_b065.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = 1;
                dr["BisacBic"] = Bisac_Bic;

                dt_BisacBic_b064_b065.Rows.Add(dr);

            }

            #endregion



            return dt_BisacBic_b064_b065;


        }
        //public DataTable Audience(DataTable dt_TitleCollection, int row,  DataTable dt_Audience, int MetaDataID, int productCount)
        //{
        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Audience'

        //    string Audience = "";

        //    //if (!string.IsNullOrEmpty(product.obj_productaudience_List[a].b204_product.ToString()))
        //    //{
        //    //    if (Convert.ToInt32(product.obj_productaudience_List[a].b204_product.ToString()) == 1)
        //    //    {
        //    //        if (!string.IsNullOrEmpty(product.obj_productaudience_List[a].b206_product.ToString()))
        //    //        {

        //    //            if (Convert.ToInt32(product.obj_productaudience_List[a].b206_product.ToString()) == 1)
        //    //            {
        //    //                Audience = "Adult";
        //    //            }
        //    //            else if (Convert.ToInt32(product.obj_productaudience_List[a].b206_product.ToString()) == 2 ||
        //    //                     Convert.ToInt32(product.obj_productaudience_List[a].b206_product.ToString()) == 3 ||
        //    //                     Convert.ToInt32(product.obj_productaudience_List[a].b206_product.ToString()) == 4)
        //    //            {
        //    //                Audience = "Children/YA";
        //    //            }
        //    //            else
        //    //            {
        //    //                Audience = "";
        //    //            }

        //                    //Audience = dt_TitleCollection.Rows[row]["CATEGORY"].ToString();

        //                    //if (Audience.Length > 0)
        //                    //{
        //                    //    DataRow dr = dt_Audience.NewRow();

        //                    //    dr["MetaDataID"] = MetaDataID;
        //                    //    dr["ProductID"] = productCount;
        //                    //    dr["RowCnt"] = 1;
        //                    //    dr["Audience"] = Audience;

        //                    //    dt_Audience.Rows.Add(dr);
        //                    //}

        //    //            }
        //    //        }
        //    //    }
           



        //    #endregion



        //    return dt_Audience;


        //}
        //public DataTable MinAge(DataTable dt_TitleCollection, int row,  DataTable dt_MinAge, int MetaDataID, int productCount)
        //{
        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'MinAge'

        //    string MinAge = "";
        //    for (int a = 0; a < product.obj_productaudiencerange_List.Count; a++)
        //    {
        //        if (!string.IsNullOrEmpty(product.obj_productaudiencerange_List[a].b074_product.ToString()))
        //        {
        //            if (product.obj_productaudiencerange_List[a].b074_product.ToString() == "17")
        //            {
        //                // if b075 = 3 then get b076 value. if b075 = 3 not available then find b075 = 4 . if neither then no value.
        //                for (int i = 0; i < product.obj_productaudiencerange_List[a].b075_product.Count; i++)
        //                {
        //                    if (!string.IsNullOrEmpty(product.obj_productaudiencerange_List[a].b075_product[i].ToString()))
        //                    {
        //                        if (Convert.ToInt32(product.obj_productaudiencerange_List[a].b075_product[i].ToString()) == 3)
        //                        {
        //                            DataRow dr = dt_MinAge.NewRow();

        //                            dr["MetaDataID"] = MetaDataID;
        //                            dr["ProductID"] = productCount;
        //                            dr["RowCnt"] = (a + 1);
        //                            // dr["b074"] = Audience;
        //                            dr["b075"] = product.obj_productaudiencerange_List[a].b075_product[i].ToString();
        //                            dr["b076"] = product.obj_productaudiencerange_List[a].b076_product[i].ToString();

        //                            dt_MinAge.Rows.Add(dr);

        //                            // exit out of loop.
        //                            break;
        //                        }
        //                        else if (Convert.ToInt32(product.obj_productaudiencerange_List[a].b075_product[i].ToString()) == 4)
        //                        {
        //                            DataRow dr = dt_MinAge.NewRow();

        //                            dr["ProductID"] = productCount;
        //                            dr["RowCnt"] = (a + 1);
        //                            // dr["b074"] = Audience;
        //                            dr["b075"] = product.obj_productaudiencerange_List[a].b075_product[i].ToString();
        //                            dr["b076"] = product.obj_productaudiencerange_List[a].b076_product[i].ToString(); ;

        //                            dt_MinAge.Rows.Add(dr);
        //                        }
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    #endregion

        //    return dt_MinAge;
        //}
        public DataTable Series(DataTable dt_TitleCollection, int row,  DataTable dt_Series, int MetaDataID, int productCount)
        {       
                    #region 'Series'

                        DataRow dr = dt_Series.NewRow();

                        dr["MetaDataID"] = MetaDataID;
                        dr["ProductID"] = productCount;
                        dr["RowCnt"] =  1;
                        dr["SeriesName_b018"] = dt_TitleCollection.Rows[row]["SERIES"].ToString();
                        dr["SeriesNumber_b019"] = "";
                        dr["SeriesName_b203"] = ""; // product.obj_product_series_List[a].obj_product_series_title_List[b].b203_product_series_title;

                        dt_Series.Rows.Add(dr);
            
                 
                    #endregion

            return dt_Series;

        }
        //public DataTable Status_b394(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_Status_b394, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Status_b394'

        //    for (int a = 0; a < product.obj_b394_List.Count; a++)
        //    {

        //        DataRow dr = dt_Status_b394.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["Status_b394"] = product.obj_b394_List[a];
        //        //dr["Status_j141"] = product.obj_product_series_List[a].b019_product_series;

        //        dt_Status_b394.Rows.Add(dr);

        //    }

        //    #endregion



        //    return dt_Status_b394;


        //}
        //public DataTable Status_j141(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_Status_j141, int MetaDataID, int productCount)
        //{

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Status_j141'

        //    for (int a = 0; a < product.obj_product_supplydetail_List.Count; a++)
        //    {
        //        DataRow dr = dt_Status_j141.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["Status_j141"] = product.obj_product_supplydetail_List[a].j141_product_supplydetail;
        //        dr["Status_j396"] = product.obj_product_supplydetail_List[a].j396_product_supplydetail;


        //        dt_Status_j141.Rows.Add(dr);

        //    }

        //    #endregion


        //    return dt_Status_j141;


        //}
        public DataTable SalesRights(DataTable dt_TitleCollection, int row,  DataTable dt_SalesRights, int MetaDataID, int productCount)
        {

            #region 'SalesRights'
            


                DataRow dr = dt_SalesRights.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = 1;
                dr["SalesRightsTypeCode_b089"] = "";
                dr["RightsCountry_b090"] = dt_TitleCollection.Rows[row]["TERRITORY"].ToString();
                dr["RightsTerritory_b388"] = "";

                dt_SalesRights.Rows.Add(dr);


            #endregion


            return dt_SalesRights;


        }
        //public DataTable SalesRights_NotForSale(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_SalesRights_NotForSale, int MetaDataID, int productCount)
        //{

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'SalesRights'

        //    for (int a = 0; a < product.obj_notforsale_List.Count; a++)
        //    {
        //        for (int b = 0; b < product.obj_notforsale_List[a].obj_b090_List.Count; b++)
        //        {
        //            DataRow dr = dt_SalesRights_NotForSale.NewRow();

        //            dr["MetaDataID"] = MetaDataID;
        //            dr["ProductID"] = productCount;
        //            dr["RowCnt"] = (b + 1);
        //            dr["NotForSale_b090"] = product.obj_notforsale_List[a].obj_b090_List[b].Replace(" ", "");

        //            dt_SalesRights_NotForSale.Rows.Add(dr);
        //        }

        //    }
        //    #endregion

        //    return dt_SalesRights_NotForSale;


        //}
        public DataTable PageCount(DataTable dt_TitleCollection, int row,  DataTable dt_PageCount, int MetaDataID, int productCount)
        {

            #region 'PageCount'

            if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["NO OF PAGES"].ToString()))
            {
                DataRow dr = dt_PageCount.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = 1;
                dr["PageCount_b061"] = dt_TitleCollection.Rows[row]["NO OF PAGES"].ToString();

                dt_PageCount.Rows.Add(dr);
            }
        

         
            #endregion

            return dt_PageCount;


        }
        //public DataTable SalesRestriction(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_SalesRestriction, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'SalesRestriction'

        //    for (int a = 0; a < product.obj_product_salesrestriction_List.Count; a++)
        //    {
        //        DataRow dr = dt_SalesRestriction.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["SalesRestriction_b383"] = product.obj_product_salesrestriction_List[a].b383_product_salesrestriction;

        //        dt_SalesRestriction.Rows.Add(dr);
        //    }

        //    #endregion


        //    return dt_SalesRestriction;


        //}
        public DataTable ReleaseDate_b003(DataTable dt_TitleCollection, int row,  DataTable dt_ReleaseDate_b003, int MetaDataID, int productCount)
        {

            #region 'ReleaseDate_b003'

            if (!string.IsNullOrEmpty(dt_TitleCollection.Rows[row]["RELEASE-DATE"].ToString()))
            {

                DataRow dr = dt_ReleaseDate_b003.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = 1;
                dr["ReleaseDate_b003"] = Convert.ToDateTime(dt_TitleCollection.Rows[row]["RELEASE-DATE"].ToString()).ToShortDateString();

                dt_ReleaseDate_b003.Rows.Add(dr);
            }
            #endregion


            return dt_ReleaseDate_b003;


        }
        //public DataTable ReleaseDate_j143(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_ReleaseDate_j143, int MetaDataID, int productCount)
        //{

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'ReleaseDate_j143'

        //    for (int a = 0; a < product.obj_product_supplydetail_List.Count; a++)
        //    {
        //        DataRow dr = dt_ReleaseDate_j143.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["ReleaseDate_j143"] = product.obj_product_supplydetail_List[a].j143_product_supplydetail;

        //        dt_ReleaseDate_j143.Rows.Add(dr);
        //    }
        //    #endregion



        //    return dt_ReleaseDate_j143;


        //}
        //public DataTable EditionNumber_b057(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_EditionNumber_b057, int MetaDataID, int productCount)
        //{
        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'EditionNumber_b057'

        //    for (int a = 0; a < product.obj_b057_List.Count; a++)
        //    {
        //        DataRow dr = dt_EditionNumber_b057.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["EditionNumber_b057"] = product.obj_b057_List[a];

        //        dt_EditionNumber_b057.Rows.Add(dr);

        //    }

        //    #endregion


        //    return dt_EditionNumber_b057;


        //}
        //public DataTable ProductFormCode_b012(TitleInjestion.Company.WFHowes.Onix_2_Short_Definition.product product, DataTable dt_ProductFormCode_b012, int MetaDataID, int productCount)
        //{

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'ProductFormCode_b012'

        //    for (int a = 0; a < product.obj_b012_List.Count; a++)
        //    {

        //        if (product.obj_b012_List[a].ToLower().ToString() == "dg")
        //        {
        //            DataRow dr = dt_ProductFormCode_b012.NewRow();

        //            dr["MetaDataID"] = MetaDataID;
        //            dr["ProductID"] = productCount;
        //            dr["RowCnt"] = (a + 1);
        //            dr["ProductFormCode_b012"] = product.obj_b012_List[a];

        //            dt_ProductFormCode_b012.Rows.Add(dr);
        //        }
        //    }

        //    #endregion

        //    return dt_ProductFormCode_b012;


        //}


        #endregion


        //public DataTable Publisher2(TitleInjestion.Onix_Definition.product product, DataTable dt_Publisher2, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Publisher'
        //    for (int a = 0; a < product.obj_b081_List.Count; a++)
        //    {
        //        DataRow dr = dt_RH_Publisher2.NewRow();

        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["Publisher_b081"] = product.obj_b081_List[a];

        //        dt_Publisher2.Rows.Add(dr);
        //    }
        //    #endregion



        //    return dt_Publisher2;


        //}



        //        public DataTable Bisac(TitleInjestion.Onix_Definition.product product, DataTable dt_Bisac, int productCount)
        //        {


        //            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //#region 'Bisac'

        //            for (int a = 0; a < product.obj_product_subject_List.Count; a++)
        //            {
        //                if (product.obj_product_subject_List[a].b067_product_subject == "10")
        //                {
        //                    DataRow dr = dt_Bisac.NewRow();

        //                    dr["ProductID"] = productCount;
        //                    dr["RowCnt"] = (a + 1);
        //                    dr["Bisac_b067"] = product.obj_product_subject_List[a].b067_product_subject;
        //                    dr["Bisac_b069"] = product.obj_product_subject_List[a].b069_product_subject;

        //                    dt_Bisac.Rows.Add(dr);
        //                }
        //            }
        //#endregion



        //            return dt_Bisac;


        //        }                

        //public DataTable Bisac2_b069(TitleInjestion.Onix_Definition.product product, DataTable dt_Bisac2_b069, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Bisac_b064'

        //    for (int a = 0; a < product.ob.Count; a++)
        //    {

        //        DataRow dr = dt_Bisac2_b069.NewRow();

        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["Bisac_b064"] = product.obj_b064_List[a];

        //        dt_Bisac2_b069.Rows.Add(dr);

        //    }
        //    #endregion



        //    return dt_Bisac2_b069;


        //}




        public string StringReplace(string stringToSearch, string find, string replaceWith)
        {
            if (stringToSearch == null) return null;
            if (string.IsNullOrEmpty(find) || replaceWith == null) return stringToSearch;
            return stringToSearch.Replace(find, replaceWith);
        }



        //        public DataTable b211(TitleInjestion.Onix_Definition.product product, DataTable dt_211, int productCount)
        //        {


        //            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //#region 'ReleaseDate_j143'

        //            for (int a = 0; a < product.obj_b211_List.Count; a++)
        //            {

        //                DataRow dr = dt_b211.NewRow();

        //                dr["ProductID"] = productCount;
        //                dr["RowCnt"] = (a + 1);
        //                dr["b211"] = product.obj_b211_List[a];

        //                dt_b211.Rows.Add(dr);
        //            }
        //#endregion



        //            return dt_b211;


        //        }
    }
}
