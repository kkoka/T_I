using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;


using TitleInjestion.Onix_2_Short_Definition;

using TitleInjestion.CommonFunctions;



namespace TitleInjestion.Company.WFHowes.Publisher.Ebook.Michael_OMara
{
    class Michael_OMara_Extraction
    {
        public List<string> d101_productID = new List<string>();

        public bool MichaelOMara_Extraction(TitleInjestion.Onix_2_Reference_Definiton.ONIXMessage fileinfo_1, int pubid, string FileName, string MediaType,
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


                DataTable dt_RH_ISBN = new DataTable("ISBN");
                #region 'Columns Declaration'

                dt_RH_ISBN.Columns.Add("MetaDataID", typeof(int));
                dt_RH_ISBN.Columns.Add("ProductID", typeof(int));
                dt_RH_ISBN.Columns.Add("RowCnt", typeof(int));
                //  dt_RH_ISBN.Columns.Add("b221", typeof(string));
                dt_RH_ISBN.Columns.Add("ISBN_b244", typeof(string));

                #endregion

                //DataTable dt_RH_b213 = new DataTable("b213");
                //#region 'Columns Declaration'

                //dt_RH_b213.Columns.Add("ProductID", typeof(int));
                //dt_RH_b213.Columns.Add("b213", typeof(string));

                //#endregion

                DataTable dt_RH_Title_Subtitle = new DataTable("Title_Subtitle");
                #region 'Columns Declaration'

                dt_RH_Title_Subtitle.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Title_Subtitle.Columns.Add("ProductID", typeof(int));
                dt_RH_Title_Subtitle.Columns.Add("RowCnt", typeof(int));
                dt_RH_Title_Subtitle.Columns.Add("SubTitle_b029", typeof(string));
                dt_RH_Title_Subtitle.Columns.Add("TitleType_b202", typeof(string));
                dt_RH_Title_Subtitle.Columns.Add("Title_b203", typeof(string));

                #endregion

                DataTable dt_RH_Publisher = new DataTable("Publisher");
                #region 'Columns Declaration'

                dt_RH_Publisher.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Publisher.Columns.Add("ProductID", typeof(int));
                dt_RH_Publisher.Columns.Add("RowCnt", typeof(int));
                dt_RH_Publisher.Columns.Add("Publisher_b081", typeof(string));

                #endregion

                //DataTable dt_RH_Publisher2 = new DataTable("Publisher2");
                //#region 'Columns Declaration'

                //dt_RH_Publisher2.Columns.Add("ProductID", typeof(int));
                //dt_RH_Publisher2.Columns.Add("RowCnt", typeof(int));
                //dt_RH_Publisher2.Columns.Add("Publisher_b081", typeof(string));

                //#endregion

                DataTable dt_RH_Imprint = new DataTable("Imprint");
                #region 'Columns Declaration'

                dt_RH_Imprint.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Imprint.Columns.Add("ProductID", typeof(int));
                dt_RH_Imprint.Columns.Add("RowCnt", typeof(int));
                dt_RH_Imprint.Columns.Add("Imprint_b079", typeof(string));

                #endregion

                DataTable dt_RH_DigitalFormat_b333 = new DataTable("DigitalFormat");
                #region 'Columns Declaration'

                dt_RH_DigitalFormat_b333.Columns.Add("MetaDataID", typeof(int));
                dt_RH_DigitalFormat_b333.Columns.Add("ProductID", typeof(int));
                dt_RH_DigitalFormat_b333.Columns.Add("RowCnt", typeof(int));
                dt_RH_DigitalFormat_b333.Columns.Add("DigitalFormat_b333", typeof(string));

                #endregion;

                DataTable dt_RH_UnAbridged = new DataTable("UnAbridged");
                #region 'Columns Declaration'

                dt_RH_UnAbridged.Columns.Add("MetaDataID", typeof(int));
                dt_RH_UnAbridged.Columns.Add("ProductID", typeof(int));
                dt_RH_UnAbridged.Columns.Add("RowCnt", typeof(int));
                dt_RH_UnAbridged.Columns.Add("Unabridged_b056", typeof(string));

                #endregion;

                DataTable dt_RH_Language = new DataTable("Language");
                #region 'Columns Declaration'

                dt_RH_Language.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Language.Columns.Add("ProductID", typeof(int));
                dt_RH_Language.Columns.Add("RowCnt", typeof(int));
                dt_RH_Language.Columns.Add("Language_b252", typeof(string));

                #endregion

                DataTable dt_RH_Price = new DataTable("Price");
                #region 'Columns Declaration'

                dt_RH_Price.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Price.Columns.Add("ProductID", typeof(int));
                dt_RH_Price.Columns.Add("RowCnt", typeof(int));
                dt_RH_Price.Columns.Add("PriceType_j148", typeof(string));
                dt_RH_Price.Columns.Add("LibraryPrice_j151", typeof(string));
                dt_RH_Price.Columns.Add("CurrencyCode_j152", typeof(string));
                dt_RH_Price.Columns.Add("j261", typeof(string));
                dt_RH_Price.Columns.Add("b251", typeof(string));

                #endregion


                DataTable dt_RH_Description = new DataTable("Description");
                #region 'Columns Declaration'

                dt_RH_Description.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Description.Columns.Add("ProductID", typeof(int));
                dt_RH_Description.Columns.Add("RowCnt", typeof(int));
                dt_RH_Description.Columns.Add("DescriptionType_d102", typeof(string));
                dt_RH_Description.Columns.Add("TextFormat_d103", typeof(string));
                dt_RH_Description.Columns.Add("Description_d104", typeof(string));

                #endregion

                DataTable dt_RH_Description_d101 = new DataTable("Description_d101");
                #region 'Columns Declaration'

                dt_RH_Description_d101.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Description_d101.Columns.Add("ProductID", typeof(int));
                dt_RH_Description_d101.Columns.Add("RowCnt", typeof(int));
                dt_RH_Description_d101.Columns.Add("Description_d101", typeof(string));

                #endregion

                //DataTable dt_RH_Bisac = new DataTable("Bisac");
                //#region 'Columns Declaration'

                //dt_RH_Bisac.Columns.Add("MetaDataID", typeof(int));
                //dt_RH_Bisac.Columns.Add("ProductID", typeof(int));
                //dt_RH_Bisac.Columns.Add("RowCnt", typeof(int));
                //dt_RH_Bisac.Columns.Add("Bisac_b067", typeof(string));
                //dt_RH_Bisac.Columns.Add("Bisac_b069", typeof(string));

                //#endregion

                DataTable dt_RH_MainBisacBic = new DataTable("MainBisacBic");
                #region 'Columns Declaration'

                dt_RH_MainBisacBic.Columns.Add("MetaDataID", typeof(int));
                dt_RH_MainBisacBic.Columns.Add("ProductID", typeof(int));
                dt_RH_MainBisacBic.Columns.Add("RowCnt", typeof(int));
                dt_RH_MainBisacBic.Columns.Add("Bisac_b191", typeof(string));
                dt_RH_MainBisacBic.Columns.Add("Bisac_b069", typeof(string));

                #endregion

                DataTable dt_BisacBic_b064_b065 = new DataTable("BisacBic");
                #region 'Columns Declaration'

                dt_BisacBic_b064_b065.Columns.Add("MetaDataID", typeof(int));
                dt_BisacBic_b064_b065.Columns.Add("ProductID", typeof(int));
                dt_BisacBic_b064_b065.Columns.Add("RowCnt", typeof(int));
                dt_BisacBic_b064_b065.Columns.Add("BisacBic", typeof(string));

                #endregion

                //DataTable dt_RH_Bic_b065 = new DataTable("Bic_b065");
                //#region 'Columns Declaration'

                //dt_RH_Bic_b065.Columns.Add("MetaDataID", typeof(int));
                //dt_RH_Bic_b065.Columns.Add("ProductID", typeof(int));
                //dt_RH_Bic_b065.Columns.Add("RowCnt", typeof(int));
                //dt_RH_Bic_b065.Columns.Add("Bic_b065", typeof(string));

                //#endregion

                DataTable dt_RH_Audience = new DataTable("Audience");
                #region 'Columns Declaration'

                dt_RH_Audience.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Audience.Columns.Add("ProductID", typeof(int));
                dt_RH_Audience.Columns.Add("RowCnt", typeof(int));
                dt_RH_Audience.Columns.Add("Audience", typeof(string));

                #endregion

                DataTable dt_RH_contributor = new DataTable("Contributor");
                #region 'Columns Declaration'

                dt_RH_contributor.Columns.Add("MetaDataID", typeof(int));
                dt_RH_contributor.Columns.Add("ProductID", typeof(int));
                dt_RH_contributor.Columns.Add("RowCnt", typeof(int));
                dt_RH_contributor.Columns.Add("Contribs_SequenceNumber_b034", typeof(string));
                dt_RH_contributor.Columns.Add("Contribs_ContribCode_b035", typeof(string));
                dt_RH_contributor.Columns.Add("Contribs_FNF_b036", typeof(string));
                dt_RH_contributor.Columns.Add("Contribs_LNF_b037", typeof(string));
                dt_RH_contributor.Columns.Add("Contribs_Prefix_b038", typeof(string));
                dt_RH_contributor.Columns.Add("Contribs_FirstName_b039", typeof(string));
                dt_RH_contributor.Columns.Add("Contribs_LastName_b040", typeof(string));
                dt_RH_contributor.Columns.Add("Contribs_CorporateAuthors_b047", typeof(string));

                #endregion

                DataTable dt_RH_Series = new DataTable("Series");
                #region 'Columns Declaration'

                dt_RH_Series.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Series.Columns.Add("ProductID", typeof(int));
                dt_RH_Series.Columns.Add("RowCnt", typeof(int));
                dt_RH_Series.Columns.Add("SeriesName_b018", typeof(string));
                dt_RH_Series.Columns.Add("SeriesNumber_b019", typeof(string));
                dt_RH_Series.Columns.Add("SeriesName_b203", typeof(string));

                #endregion

                DataTable dt_RH_Status_b394 = new DataTable("Status_b394");
                #region 'Columns Declaration'

                dt_RH_Status_b394.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Status_b394.Columns.Add("ProductID", typeof(int));
                dt_RH_Status_b394.Columns.Add("RowCnt", typeof(int));
                dt_RH_Status_b394.Columns.Add("Status_b394", typeof(string));
                //dt_RH_Status_b394.Columns.Add("Status_j141", typeof(string));

                #endregion

                DataTable dt_RH_Status_j141 = new DataTable("Status_j141");
                #region 'Columns Declaration'

                dt_RH_Status_j141.Columns.Add("MetaDataID", typeof(int));
                dt_RH_Status_j141.Columns.Add("ProductID", typeof(int));
                dt_RH_Status_j141.Columns.Add("RowCnt", typeof(int));
                dt_RH_Status_j141.Columns.Add("Status_j141", typeof(string));
                dt_RH_Status_j141.Columns.Add("Status_j396", typeof(string));

                #endregion


                //DataTable dt_RH_Status_j396 = new DataTable("Status_j396");
                //#region 'Columns Declaration'

                //dt_RH_Status_j396.Columns.Add("ProductID", typeof(int));
                //dt_RH_Status_j396.Columns.Add("RowCnt", typeof(int));
                //dt_RH_Status_j396.Columns.Add("Status_j396", typeof(string));

                //#endregion


                DataTable dt_RH_SalesRights = new DataTable("SalesRights");
                #region 'Columns Declaration'

                dt_RH_SalesRights.Columns.Add("MetaDataID", typeof(int));
                dt_RH_SalesRights.Columns.Add("ProductID", typeof(int));
                dt_RH_SalesRights.Columns.Add("RowCnt", typeof(int));
                dt_RH_SalesRights.Columns.Add("SalesRightsTypeCode_b089", typeof(string));
                dt_RH_SalesRights.Columns.Add("RightsCountry_b090", typeof(string));
                dt_RH_SalesRights.Columns.Add("RightsTerritory_b388", typeof(string));

                #endregion

                //DataTable dt_RH_SalesRights_NotForSale = new DataTable("SalesRights_NotForSale");
                //#region 'Columns Declaration'

                //dt_RH_SalesRights_NotForSale.Columns.Add("MetaDataID", typeof(int));
                //dt_RH_SalesRights_NotForSale.Columns.Add("ProductID", typeof(int));
                //dt_RH_SalesRights_NotForSale.Columns.Add("RowCnt", typeof(int));
                //dt_RH_SalesRights_NotForSale.Columns.Add("NotForSale_b090", typeof(string));

                //#endregion



                DataTable dt_RH_PageCount = new DataTable("PageCount");
                #region 'Columns Declaration'

                dt_RH_PageCount.Columns.Add("MetaDataID", typeof(int));
                dt_RH_PageCount.Columns.Add("ProductID", typeof(int));
                dt_RH_PageCount.Columns.Add("RowCnt", typeof(int));
                dt_RH_PageCount.Columns.Add("PageCount_b061", typeof(string));

                #endregion

                //DataTable dt_RH_SalesRestriction = new DataTable("SalesRestriction");
                //#region 'Columns Declaration'

                //dt_RH_SalesRestriction.Columns.Add("MetaDataID", typeof(int));
                //dt_RH_SalesRestriction.Columns.Add("ProductID", typeof(int));
                //dt_RH_SalesRestriction.Columns.Add("RowCnt", typeof(int));
                //dt_RH_SalesRestriction.Columns.Add("SalesRestriction_b383", typeof(string));

                //#endregion

                DataTable dt_RH_ReleaseDate_b003 = new DataTable("ReleaseDate_b003");
                #region 'Columns Declaration'

                dt_RH_ReleaseDate_b003.Columns.Add("MetaDataID", typeof(int));
                dt_RH_ReleaseDate_b003.Columns.Add("ProductID", typeof(int));
                dt_RH_ReleaseDate_b003.Columns.Add("RowCnt", typeof(int));
                dt_RH_ReleaseDate_b003.Columns.Add("ReleaseDate_b003", typeof(string));

                #endregion

                DataTable dt_RH_ReleaseDate_j143 = new DataTable("ReleaseDate_j143");
                #region 'Columns Declaration'

                dt_RH_ReleaseDate_j143.Columns.Add("MetaDataID", typeof(int));
                dt_RH_ReleaseDate_j143.Columns.Add("ProductID", typeof(int));
                dt_RH_ReleaseDate_j143.Columns.Add("RowCnt", typeof(int));
                dt_RH_ReleaseDate_j143.Columns.Add("ReleaseDate_j143", typeof(string));

                #endregion


                DataTable dt_RH_MinAge = new DataTable("MinAge");
                #region 'Columns Declaration'

                dt_RH_MinAge.Columns.Add("MetaDataID", typeof(int));
                dt_RH_MinAge.Columns.Add("ProductID", typeof(int));
                dt_RH_MinAge.Columns.Add("RowCnt", typeof(int));
                dt_RH_MinAge.Columns.Add("b075", typeof(string));
                dt_RH_MinAge.Columns.Add("b076", typeof(string));

                #endregion

                //DataTable dt_RH_b211 = new DataTable("b211");
                //#region 'Columns Declaration'

                //dt_RH_b211.Columns.Add("MetaDataID", typeof(int));
                //dt_RH_b211.Columns.Add("ProductID", typeof(int));
                //dt_RH_b211.Columns.Add("RowCnt", typeof(int));
                //dt_RH_b211.Columns.Add("b211", typeof(string));

                //#endregion

                DataTable dt_RH_EditionNumber_b057 = new DataTable("EditionNumber_b057");
                #region 'Columns Declaration'

                dt_RH_EditionNumber_b057.Columns.Add("MetaDataID", typeof(int));
                dt_RH_EditionNumber_b057.Columns.Add("ProductID", typeof(int));
                dt_RH_EditionNumber_b057.Columns.Add("RowCnt", typeof(int));
                dt_RH_EditionNumber_b057.Columns.Add("EditionNumber_b057", typeof(string));

                #endregion

                DataTable dt_RH_ProductFormCode_b012 = new DataTable("ProductFormCode_b012");
                #region 'Columns Declaration'

                dt_RH_ProductFormCode_b012.Columns.Add("MetaDataID", typeof(int));
                dt_RH_ProductFormCode_b012.Columns.Add("ProductID", typeof(int));
                dt_RH_ProductFormCode_b012.Columns.Add("RowCnt", typeof(int));
                dt_RH_ProductFormCode_b012.Columns.Add("ProductFormCode_b012", typeof(string));

                #endregion

                #endregion

                int MetaDataID = InsertMetaData_Info(pubid, FileName, MediaType, "WFH");

                if (MetaDataID > 0)
                {
                    for (int i = 0; i < fileinfo_1.obj_product_List.Count; i++)
                    {

                        #region 'Populate DataTable'




                        // for each product
                        #region 'ISBN'
                        Step = "ISBN";
                        dt_RH_ISBN = ISBN(fileinfo_1.obj_product_List[i], dt_RH_ISBN, MetaDataID, (i + 1));
                        #endregion



                        // for each product
                        #region 'b213'
                        //Step = "b213";
                        //dt_RH_b213 = b213(fileinfo_1.obj_product_List[i], dt_RH_b213, MetaDataID, (i + 1));
                        #endregion





                        #region 'Title_Subtitle'
                        Step = "Title_Subtitle";
                        dt_RH_Title_Subtitle = TitleSubtitle(fileinfo_1.obj_product_List[i], dt_RH_Title_Subtitle, MetaDataID, (i + 1));
                        #endregion

                        #region 'Publisher'
                        Step = "Publisher";
                        dt_RH_Publisher = Publisher(fileinfo_1.obj_product_List[i], dt_RH_Publisher, MetaDataID, (i + 1));
                        #endregion

                        //#region 'Publisher2'
                        //dt_RH_Publisher2 = Publisher2(fileinfo_1.obj_product_List[i], dt_RH_Publisher, (i + 1));
                        //#endregion

                        #region 'Imprint'
                        Step = "Imprint";
                        dt_RH_Imprint = Imprint(fileinfo_1.obj_product_List[i], dt_RH_Imprint, MetaDataID, (i + 1));
                        #endregion

                        #region 'UnAbridged'
                        Step = "UnAbridged";
                        dt_RH_UnAbridged = UnAbridged(fileinfo_1.obj_product_List[i], dt_RH_UnAbridged, MetaDataID, (i + 1));
                        #endregion

                        #region 'Language'
                        Step = "Language";
                        dt_RH_Language = Language(fileinfo_1.obj_product_List[i], dt_RH_Language, MetaDataID, (i + 1));
                        #endregion

                        #region 'Price'
                        Step = "Price";
                        dt_RH_Price = Price(fileinfo_1.obj_product_List[i], dt_RH_Price, MetaDataID, (i + 1));
                        #endregion

                        #region 'Description'
                        //Step = "Description1";
                        //dt_RH_Description_d101 = Description_d101(fileinfo_1.obj_product_List[i], dt_RH_Description_d101, MetaDataID, (i + 1));

                        Step = "Description2";
                        dt_RH_Description = Description(fileinfo_1.obj_product_List[i], dt_RH_Description, MetaDataID, (i + 1));

                        #endregion

                        #region 'DigitalFormat_AudibleWma_b333'

                        Step = "DigitalFormat_b333";
                        dt_RH_DigitalFormat_b333 = DigitalFormat_b333(fileinfo_1.obj_product_List[i], dt_RH_DigitalFormat_b333, MetaDataID, (i + 1));

                        #endregion

                        #region 'Bisac'
                        //Step = "dt_RH_Bisac";
                        //dt_RH_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_RH_Bisac, (i + 1));

                        Step = "dt_RH_MainBisacBic";
                        dt_RH_MainBisacBic = MainBisacBic(fileinfo_1.obj_product_List[i], dt_RH_MainBisacBic, MetaDataID, (i + 1));

                        Step = "dt_BisacBic_b064_b065";
                        dt_BisacBic_b064_b065 = BisacBic_b064_b065(fileinfo_1.obj_product_List[i], dt_BisacBic_b064_b065, MetaDataID, (i + 1));

                        //Step = "dt_RH_Bic_b065";
                        //dt_RH_Bic_b065 = Bic_b065(fileinfo_1.obj_product_List[i], dt_RH_Bic_b065, (i + 1));


                        #endregion

                        #region 'Audience'
                        //Step = "dt_RH_Bisac";
                        //dt_RH_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_RH_Bisac, (i + 1));

                        Step = "dt_RH_Audience";
                        dt_RH_Audience = Audience(fileinfo_1.obj_product_List[i], dt_RH_Audience, MetaDataID, (i + 1));
                        Step = "dt_RH_Audience";



                        #endregion

                        #region 'MinAge'
                        //Step = "dt_RH_Bisac";
                        //dt_RH_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_RH_Bisac, (i + 1));

                        Step = "dt_RH_MinAge";
                        dt_RH_MinAge = MinAge(fileinfo_1.obj_product_List[i], dt_RH_MinAge, MetaDataID, (i + 1));
                        Step = "dt_RH_MinAge";



                        #endregion

                        #region 'Contributors'
                        Step = "Contributors";
                        dt_RH_contributor = Contributor(fileinfo_1.obj_product_List[i], dt_RH_contributor, MetaDataID, (i + 1));

                        #endregion

                        #region 'Series'
                        Step = "Series";
                        dt_RH_Series = Series(fileinfo_1.obj_product_List[i], dt_RH_Series, MetaDataID, (i + 1));
                        #endregion

                        #region 'Status'
                        Step = "Status_b394";
                        dt_RH_Status_b394 = Status_b394(fileinfo_1.obj_product_List[i], dt_RH_Status_b394, MetaDataID, (i + 1));

                        Step = "Status_j141";
                        dt_RH_Status_j141 = Status_j141(fileinfo_1.obj_product_List[i], dt_RH_Status_j141, MetaDataID, (i + 1));


                        #endregion

                        #region 'SalesRights'

                        Step = "SalesRights";
                        dt_RH_SalesRights = SalesRights(fileinfo_1.obj_product_List[i], dt_RH_SalesRights, MetaDataID, (i + 1));

                        //Step = "SalesRights_NotForSale";
                        //dt_RH_SalesRights_NotForSale = SalesRights_NotForSale(fileinfo_1.obj_product_List[i], dt_RH_SalesRights_NotForSale, MetaDataID, (i + 1));

                        #endregion

                        #region 'Page Count'
                        Step = "Page Count";
                        dt_RH_PageCount = PageCount(fileinfo_1.obj_product_List[i], dt_RH_PageCount, MetaDataID, (i + 1));
                        #endregion

                        //#region 'SalesRestriction'
                        //Step = "SalesRestriction";
                        //dt_RH_SalesRestriction = SalesRestriction(fileinfo_1.obj_product_List[i], dt_RH_SalesRestriction, MetaDataID, (i + 1));
                        //#endregion

                        #region 'ReleaseDate'
                        Step = "ReleaseDate";
                        dt_RH_ReleaseDate_b003 = ReleaseDate_b003(fileinfo_1.obj_product_List[i], dt_RH_ReleaseDate_b003, MetaDataID, (i + 1));

                        Step = "Page Count";
                        dt_RH_ReleaseDate_j143 = ReleaseDate_j143(fileinfo_1.obj_product_List[i], dt_RH_ReleaseDate_j143, MetaDataID, (i + 1));
                        #endregion

                        //#region 'b211'

                        //Step = "b211";
                        //dt_RH_b211 = b211(fileinfo_1.obj_product_List[i], dt_RH_b211, (i + 1));

                        //#endregion

                        #region 'EditionNumber_b057'

                        Step = "EditionNumber_b057";
                        dt_RH_EditionNumber_b057 = EditionNumber_b057(fileinfo_1.obj_product_List[i], dt_RH_EditionNumber_b057, MetaDataID, (i + 1));

                        #endregion

                        #region 'ProductFormCode_b012'

                        Step = "ProductFormCode_b012";
                        dt_RH_ProductFormCode_b012 = ProductFormCode_b012(fileinfo_1.obj_product_List[i], dt_RH_ProductFormCode_b012, MetaDataID, (i + 1));

                        #endregion


                        #endregion
                    }

                    lbl_Extraction.BackColor = System.Drawing.Color.Green;
                    lbl_Extraction.Refresh();
                    System.Windows.Forms.Application.DoEvents();



                    lbl_Insert.BackColor = System.Drawing.Color.Yellow;
                    lbl_Insert.Refresh();
                    System.Windows.Forms.Application.DoEvents();


                    #region 'Insert the Data into the SQL Table'

                    int count = 22;  // (1 less than the total jobs)

                    result = InsertRecords(dt_RH_ISBN, "WFH");
                    Insertion_Label(lbl_Insert, count);

                    //result = InsertRecords(dt_RH_b213, "WFH");
                    //Insertion_Label(lbl_Insert, count);

                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Title_Subtitle, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Publisher, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //InsertRecords(dt_RH_Publisher2);

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Imprint, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_UnAbridged, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Language, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Price, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Description, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_RH_Description_d101, "WFH");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_DigitalFormat_b333, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_MainBisacBic, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_BisacBic_b064_b065, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Audience, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_MinAge, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;


                    //if (result)
                    //{
                    //    result = InsertRecords(dt_RH_Bisac2, "WFH");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_contributor, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Series, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Status_b394, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_Status_j141, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_SalesRights, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_RH_SalesRights_NotForSale, "WFH");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_PageCount, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_RH_SalesRestriction, "WFH");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_ReleaseDate_b003, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_ReleaseDate_j143, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_RH_b211, "WFH");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_EditionNumber_b057, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_RH_ProductFormCode_b012, "WFH");
                        Insertion_Label(lbl_Insert, count);
                    }


                    if (result)
                    {

                        lbl_Insert.BackColor = System.Drawing.Color.Green;
                        lbl_Insert.Refresh();
                        System.Windows.Forms.Application.DoEvents();


                    }



                    #endregion
                }
            }
            catch (Exception ex)
            {
                result = false;
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString("WFH"), "Error at " + Step + " : " + ex.ToString());

                //   sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString("WFH"), "Error Cleaning/Deserializing the " + MediaType + " file : " + FileName + " from the publisher - " + PublisherName + ". Exception : " + ex.ToString());

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
        public bool Process_MichaelOMara(string Company, System.Windows.Forms.Label lbl_Processing)
        {
            bool result = false;

            lbl_Processing.BackColor = System.Drawing.Color.Yellow;
            lbl_Processing.Refresh();
            System.Windows.Forms.Application.DoEvents();



            SQLFunction sqlfunction = new SQLFunction();
            result = sqlfunction.ExecuteProc("WFH", ConfigurationSettings.AppSettings["WFH_Process_MichaelOMara_Ebook_UK"].ToString());

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

        //public DataTable b213(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_b213, int MetaDataID, int productCount)
        //{
        //    DataRow dr = dt_RH_b213.NewRow();

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'dt_RH_b213'
        //    int i = 0;
        //    for (int a = 0; a < product.obj_b213_List.Count; a++)
        //    {
        //       ////////b213 -  EpubTypeDescription - [ product, product/relatedproduct, ]

        //        dr["ProductID"] = productCount;
        //        //   dr["RowCnt"] = i;
        //        dr["b213"] = product.obj_b213_List[a].ToString();
        //        dt_RH_b213.Rows.Add(dr);


        //    }
        //    #endregion



        //    return dt_RH_b213;


        //}

        public DataTable ISBN(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_ISBN, int MetaDataID, int productCount)
        {


            DataRow dr = dt_RH_ISBN.NewRow();

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ISBN_b244'
            int i = 0;
            for (int a = 0; a < product.obj_ProductProductIdentifier_List.Count; a++)
            {
                if (product.obj_ProductProductIdentifier_List[a].ProductIDType_ProductProductIdentifier == "15")
                {
                    i++;

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = i;
                    dr["ISBN_b244"] = product.obj_ProductProductIdentifier_List[a].IDValue_ProductProductIdentifier;

                    break;
                }
            }
            #endregion


            dt_RH_ISBN.Rows.Add(dr);

            return dt_RH_ISBN;


        }
        public DataTable TitleSubtitle(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Title_Subtitle, int MetaDataID, int productCount)
        {




            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Title'

            for (int a = 0; a < product.obj_ProductTitle_List.Count; a++)
            {
                if (product.obj_ProductTitle_List[a].TitleType_ProductTitle == "01")
                {
                    DataRow dr = dt_RH_Title_Subtitle.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (a + 1);
                    dr["SubTitle_b029"] = product.obj_ProductTitle_List[a].Subtitle_ProductTitle;
                    dr["TitleType_b202"] = product.obj_ProductTitle_List[a].TitleType_ProductTitle;
                    dr["Title_b203"] = product.obj_ProductTitle_List[a].TitleText_ProductTitle;

                    dt_RH_Title_Subtitle.Rows.Add(dr);
                }
            }
            #endregion



            return dt_RH_Title_Subtitle;


        }
        public DataTable Publisher(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Publisher, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Publisher'
            for (int a = 0; a < product.obj_ProductPublisher_List.Count; a++)
            {
                DataRow dr = dt_RH_Publisher.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Publisher_b081"] = product.obj_ProductPublisher_List[a].PublisherName_ProductPublisher;

                dt_RH_Publisher.Rows.Add(dr);
            }
            #endregion



            return dt_RH_Publisher;


        }
        public DataTable Imprint(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Imprint, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Imprint'
            for (int a = 0; a < product.obj_ProductImprint_List.Count; a++)
            {

                if (!string.IsNullOrEmpty(product.obj_ProductImprint_List[a].NameCodeType_ProductImprint))
                {
                    if (product.obj_ProductImprint_List[a].NameCodeType_ProductImprint == "01")
                    {
                        DataRow dr = dt_RH_Imprint.NewRow();

                        dr["MetaDataID"] = MetaDataID;
                        dr["ProductID"] = productCount;
                        dr["RowCnt"] = a;
                        dr["Imprint_b079"] = product.obj_ProductImprint_List[a].ImprintName_ProductImprint;

                        dt_RH_Imprint.Rows.Add(dr);
                    }
                }

            }
            #endregion



            return dt_RH_Imprint;


        }
        public DataTable UnAbridged(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_UnAbridged, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'UnAbridged'
            for (int a = 0; a < product.obj_EditionTypeCode_List.Count; a++)
            {

                DataRow dr = dt_RH_UnAbridged.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Unabridged_b056"] = product.obj_EditionTypeCode_List[a];

                dt_RH_UnAbridged.Rows.Add(dr);

            }
            #endregion

            return dt_RH_UnAbridged;


        }
        public DataTable Language(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Language, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Language'
            for (int a = 0; a < product.obj_ProductLanguage_List.Count; a++)
            {

                DataRow dr = dt_RH_Language.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Language_b252"] = product.obj_ProductLanguage_List[a].LanguageCode_ProductLanguage;

                dt_RH_Language.Rows.Add(dr);


            }
            #endregion

            return dt_RH_Language;


        }
        public DataTable Price(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Price, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Price'

            for (int a = 0; a < product.obj_ProductSupplyDetail_List.Count; a++)
            {
                for (int b = 0; b < product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List.Count; b++)
                {


                    #region 'GBP'

                    if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice))
                    {
                        if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice.ToLower() == "gbp")
                        {
                            //if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice))
                            //{
                            //    if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice.ToLower() == "06")
                            //    {
                            if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice))
                            {
                                if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice.ToLower() == "01")
                                {

                                    //for (int c = 0; c < product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List.Count; c++)
                                    //{
                                        //if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c].ToString()))
                                        //{
                                        //    if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c].ToString().ToLower() == "gb")
                                        //    {

                                                DataRow dr = dt_RH_Price.NewRow();

                                                dr["MetaDataID"] = MetaDataID;
                                                dr["ProductID"] = productCount;
                                                dr["RowCnt"] = (b + 1);
                                                dr["PriceType_j148"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice;
                                                dr["LibraryPrice_j151"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceAmount_ProductSupplyDetailPrice;
                                                dr["CurrencyCode_j152"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice;
                                                dr["j261"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice;
                                                dr["b251"] = "";// product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c];
                                                dt_RH_Price.Rows.Add(dr);
                                        //    }
                                        //}
                                    //}
                                }
                            }
                            //    }
                            //}
                        }
                    }

                    #endregion

                    #region 'EUR'

                    if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice))
                    {
                        if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice.ToLower() == "eur")
                        {
                            //if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice))
                            //{
                            //    if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice.ToLower() == "06")
                            //    {
                            if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice))
                            {
                                if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice.ToLower() == "01")
                                {
                                    //if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List.Count == 0)
                                    //{
                                    //    DataRow dr = dt_RH_Price.NewRow();

                                    //    dr["MetaDataID"] = MetaDataID;
                                    //    dr["ProductID"] = productCount;
                                    //    dr["RowCnt"] = (b + 1);
                                    //    dr["PriceType_j148"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice;
                                    //    dr["LibraryPrice_j151"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceAmount_ProductSupplyDetailPrice;
                                    //    dr["CurrencyCode_j152"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice;
                                    //    dr["j261"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice;
                                    //    dr["b251"] = "";

                                    //    dt_RH_Price.Rows.Add(dr);

                                    //}
                                    //else
                                    //{
                                    //    for (int c = 0; c < product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List.Count; c++)
                                    //    {
                                    //        //if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c].ToString()))
                                    //        //{
                                    //        //    if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c].ToString().ToLower() == "ie")
                                    //        //    {

                                            DataRow dr = dt_RH_Price.NewRow();

                                            dr["MetaDataID"] = MetaDataID;
                                            dr["ProductID"] = productCount;
                                            dr["RowCnt"] = (b + 1);
                                            dr["PriceType_j148"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice;
                                            dr["LibraryPrice_j151"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceAmount_ProductSupplyDetailPrice;
                                            dr["CurrencyCode_j152"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice;
                                            dr["j261"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice;
                                            dr["b251"] = ""; // product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c];

                                            dt_RH_Price.Rows.Add(dr);
                                            //    }
                                            //}
                                    //    }
                                    //}




                                }
                            }

                            //    }
                            //}
                        }
                    }

                    #endregion

                    #region 'AUD - Commented Out'

                    //if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice))
                    //{
                    //    if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice.ToLower() == "aud")
                    //    {
                    //        //if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice))
                    //        //{
                    //        //    if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice.ToLower() == "06")
                    //        //    {

                    //        if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice))
                    //        {
                    //            if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice.ToLower() == "02")
                    //            {

                    //                for (int c = 0; c < product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List.Count; c++)
                    //                {
                    //                    //if (!string.IsNullOrEmpty(product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c].ToString()))
                    //                    //{
                    //                    //if (product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c].ToString().ToLower() == "au")
                    //                    //{

                    //                    DataRow dr = dt_RH_Price.NewRow();

                    //                    dr["MetaDataID"] = MetaDataID;
                    //                    dr["ProductID"] = productCount;
                    //                    dr["RowCnt"] = (b + 1);
                    //                    dr["PriceType_j148"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceTypeCode_ProductSupplyDetailPrice;
                    //                    dr["LibraryPrice_j151"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceAmount_ProductSupplyDetailPrice;
                    //                    dr["CurrencyCode_j152"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].CurrencyCode_ProductSupplyDetailPrice;
                    //                    dr["j261"] = product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].PriceQualifier_ProductSupplyDetailPrice;
                    //                    dr["b251"] = ""; // product.obj_ProductSupplyDetail_List[a].obj_ProductSupplyDetailPrice_List[b].obj_ProductSupplyDetailPriceCountryCode_List[c];

                    //                    dt_RH_Price.Rows.Add(dr);
                    //                    //}
                    //                    //}
                    //                }
                    //            }
                    //        }
                    //        //    }
                    //        //}
                    //    }
                    //}
                    #endregion

                }
            }

            #endregion

            return dt_RH_Price;


        }

        //public DataTable Description_d101(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Description_d101, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Description'

        //    for (int a = 0; a < product.obj_d101_List.Count; a++)
        //    {


        //        if (!string.IsNullOrEmpty(product.obj_d101_List[a]))
        //        {
        //            DataRow dr = dt_RH_Description_d101.NewRow();

        //            dr["MetaDataID"] = MetaDataID;
        //            dr["ProductID"] = productCount;
        //            dr["RowCnt"] = (a + 1);

        //            if (product.obj_d101_List[a].Length > 3500)
        //            {
        //                //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
        //                dr["Description_d101"] = product.obj_d101_List[a].Substring(0, 3500);
        //            }
        //            else
        //            {
        //                //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
        //                dr["Description_d101"] = product.obj_d101_List[a];
        //            }


        //            dt_RH_Description_d101.Rows.Add(dr);

        //        }
        //        //else
        //        //{
        //        //    dr["Description_d101"] = "";
        //        //}


        //    }
        //    #endregion



        //    return dt_RH_Description_d101;


        //}

        public DataTable Description(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Description, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Description'

            for (int a = 0; a < product.obj_ProductOtherText_List.Count; a++)
            {
                if (product.obj_ProductOtherText_List[a].TextTypeCode_ProductOtherText == "01")

                //product.obj_ProductOtherText_List[a].TextTypeCode_ProductOtherText == "03" ||
                //product.obj_ProductOtherText_List[a].TextTypeCode_ProductOtherText == "01" ||
                //product.obj_ProductOtherText_List[a].TextTypeCode_ProductOtherText == "02" ||
                //product.obj_ProductOtherText_List[a].TextTypeCode_ProductOtherText == "25")
                {
                    DataRow dr = dt_RH_Description.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (a + 1);
                    dr["DescriptionType_d102"] = product.obj_ProductOtherText_List[a].TextTypeCode_ProductOtherText;
                    dr["TextFormat_d103"] = product.obj_ProductOtherText_List[a].TextFormat_ProductOtherText;

                    if (!string.IsNullOrEmpty(product.obj_ProductOtherText_List[a].Text_ProductOtherText))
                    {
                        if (product.obj_ProductOtherText_List[a].Text_ProductOtherText.Length > 3500)
                        {
                            //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                            dr["Description_d104"] = product.obj_ProductOtherText_List[a].Text_ProductOtherText.Substring(0, 3500);
                        }
                        else
                        {
                            //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                            dr["Description_d104"] = product.obj_ProductOtherText_List[a].Text_ProductOtherText;
                        }
                    }
                    else
                    {
                        dr["Description_d104"] = "";
                    }

                    dt_RH_Description.Rows.Add(dr);
                }

            }
            #endregion



            return dt_RH_Description;


        }
        public DataTable Contributor(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_contributor, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Contributor'

            for (int a = 0; a < product.obj_productContributor_List.Count; a++)
            {
                DataRow dr = dt_RH_contributor.NewRow();


                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Contribs_SequenceNumber_b034"] = StringReplace(product.obj_productContributor_List[a].SequenceNumber_productcontributor, "To Be Announced", "");
                dr["Contribs_ContribCode_b035"] = StringReplace(product.obj_productContributor_List[a].ContributorRole_productcontributor, "To Be Announced", "");
                dr["Contribs_FNF_b036"] = StringReplace(product.obj_productContributor_List[a].PersonName_productcontributor, "To Be Announced", "");
                dr["Contribs_LNF_b037"] = StringReplace(product.obj_productContributor_List[a].PersonNameInverted_productcontributor, "To Be Announced", "");
                dr["Contribs_Prefix_b038"] = StringReplace(product.obj_productContributor_List[a].TitlesBeforeNames_productcontributor, "To Be Announced", "");
                dr["Contribs_FirstName_b039"] = StringReplace(product.obj_productContributor_List[a].NamesBeforeKey_productcontributor, "To Be Announced", "");
                dr["Contribs_LastName_b040"] = StringReplace(product.obj_productContributor_List[a].KeyNames_productcontributor, "To Be Announced", "");
                dr["Contribs_CorporateAuthors_b047"] = StringReplace(product.obj_productContributor_List[a].CorporateName_productcontributor, "To Be Announced", "");

                dt_RH_contributor.Rows.Add(dr);

            }

            #endregion



            return dt_RH_contributor;


        }
        public DataTable DigitalFormat_b333(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_DigitalFormat_b333, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'DigitalFormat_b333'

            if (product.obj_ProductFormDetail_List.Count == 0)
            {

                DataRow dr = dt_RH_DigitalFormat_b333.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (1);
                dr["DigitalFormat_b333"] = "Reflowable";
                dt_RH_DigitalFormat_b333.Rows.Add(dr);

            }

            for (int a = 0; a < product.obj_ProductFormDetail_List.Count; a++)
            {

                DataRow dr = dt_RH_DigitalFormat_b333.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                //  dr["DigitalFormat_b333"] = "Reflowable";

                if (!string.IsNullOrEmpty(product.obj_ProductFormDetail_List[a]))
                {

                    //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);

                    if (product.obj_ProductFormDetail_List[a].ToString().ToLower() == "e200")
                    {
                        //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                        // dr["DigitalFormat_b333"] = product.obj_b333_List[a]; 
                        dr["DigitalFormat_b333"] = "Reflowable";
                    }
                    else if (product.obj_ProductFormDetail_List[a].ToString().ToLower() == "e101")
                    {
                        //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                        // dr["DigitalFormat_b333"] = product.obj_b333_List[a]; 
                        dr["DigitalFormat_b333"] = "Reflowable";
                    }
                    else if (product.obj_ProductFormDetail_List[a].ToString().ToLower() == "e201")
                    {
                        //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                        // dr["DigitalFormat_b333"] = product.obj_b333_List[a]; 
                        dr["DigitalFormat_b333"] = "Fixed Layout";
                    }
                    else
                    {
                        if (product.obj_ProductFormDetail_List[a].Trim().Length > 0)
                        {
                            dr["DigitalFormat_b333"] = product.obj_ProductFormDetail_List[a].Trim();
                        }
                        else
                        {
                            dr["DigitalFormat_b333"] = "Reflowable";
                        }
                    }



                }
                else
                {
                    dr["DigitalFormat_b333"] = "Reflowable";
                }

                dt_RH_DigitalFormat_b333.Rows.Add(dr);


            }

            #endregion



            return dt_RH_DigitalFormat_b333;


        }
        public DataTable MainBisacBic(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_MainBisacBic, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Bisac'
            for (int a = 0; a < product.obj_ProductMainSubject_List.Count; a++)
            {
                if (product.obj_ProductMainSubject_List[a].MainSubjectSchemeIdentifier_ProductMainSubject == "10" || product.obj_ProductMainSubject_List[a].MainSubjectSchemeIdentifier_ProductMainSubject == "12")
                {
                    DataRow dr = dt_RH_MainBisacBic.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (a + 1);
                    dr["Bisac_b191"] = product.obj_ProductMainSubject_List[a].MainSubjectSchemeIdentifier_ProductMainSubject;
                    dr["Bisac_b069"] = product.obj_ProductMainSubject_List[a].SubjectCode_ProductMainSubject;

                    dt_RH_MainBisacBic.Rows.Add(dr);
                }
            }
            #endregion

            return dt_RH_MainBisacBic;
        }

        public DataTable BisacBic_b064_b065(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_BisacBic_b064_b065, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'BisacBic_b064_b065'

            string Bisac_Bic = "";
            for (int a = 0; a < product.obj_BASICMainSubject_List.Count; a++)
            {
                if ((product.obj_BASICMainSubject_List[a].ToString().Length > 0) && (Bisac_Bic.Length == 0))
                {
                    Bisac_Bic = product.obj_BASICMainSubject_List[a];
                }
            }
            for (int a = 0; a < product.obj_BICMainSubject_List.Count; a++)
            {
                if ((product.obj_BICMainSubject_List[a].ToString().Length > 0) && (Bisac_Bic.Length == 0))
                {
                    Bisac_Bic = product.obj_BICMainSubject_List[a];
                }
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
        public DataTable Audience(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Audience, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Audience'

            string Audience = "";
            for (int a = 0; a < product.obj_ProductAudience_List.Count; a++)
            {
                if (!string.IsNullOrEmpty(product.obj_ProductAudience_List[a].AudienceCodeType_productAudience.ToString()))
                {
                    if (Convert.ToInt32(product.obj_ProductAudience_List[a].AudienceCodeType_productAudience.ToString()) == 1)
                    {
                        if (!string.IsNullOrEmpty(product.obj_ProductAudience_List[a].AudienceCodeValue_productAudience.ToString()))
                        {

                            if (Convert.ToInt32(product.obj_ProductAudience_List[a].AudienceCodeValue_productAudience.ToString()) == 1)
                            {
                                Audience = "Adult";
                            }
                            else if (Convert.ToInt32(product.obj_ProductAudience_List[a].AudienceCodeValue_productAudience.ToString()) == 2 ||
                                     Convert.ToInt32(product.obj_ProductAudience_List[a].AudienceCodeValue_productAudience.ToString()) == 3 ||
                                     Convert.ToInt32(product.obj_ProductAudience_List[a].AudienceCodeValue_productAudience.ToString()) == 4)
                            {
                                Audience = "Children/YA";
                            }
                            else
                            {
                                Audience = "";
                            }

                            if (Audience.Length > 0)
                            {
                                DataRow dr = dt_RH_Audience.NewRow();

                                dr["MetaDataID"] = MetaDataID;
                                dr["ProductID"] = productCount;
                                dr["RowCnt"] = (a + 1);
                                dr["Audience"] = Audience;

                                dt_RH_Audience.Rows.Add(dr);
                            }

                        }
                    }
                }
            }



            #endregion



            return dt_RH_Audience;


        }
        public DataTable MinAge(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_MinAge, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'MinAge'

            string MinAge = "";
            for (int a = 0; a < product.obj_productaudiencerange_List.Count; a++)
            {
                if (!string.IsNullOrEmpty(product.obj_productaudiencerange_List[a].AudienceRangeQualifier_ProductAudienceRange.ToString()))
                {
                    if (product.obj_productaudiencerange_List[a].AudienceRangeQualifier_ProductAudienceRange.ToString() == "17")
                    {
                        // if b075 = 3 then get b076 value. if b075 = 3 not available then find b075 = 4 . if neither then no value.
                        for (int i = 0; i < product.obj_productaudiencerange_List[a].AudienceRangePrecision_ProductAudienceRange.Count; i++)
                        {

                            if (!string.IsNullOrEmpty(product.obj_productaudiencerange_List[a].AudienceRangePrecision_ProductAudienceRange[i].ToString()))
                            {
                                if (Convert.ToInt32(product.obj_productaudiencerange_List[a].AudienceRangePrecision_ProductAudienceRange[i].ToString()) == 3)
                                {
                                    DataRow dr = dt_RH_MinAge.NewRow();

                                    dr["MetaDataID"] = MetaDataID;
                                    dr["ProductID"] = productCount;
                                    dr["RowCnt"] = (a + 1);
                                    // dr["b074"] = Audience;
                                    dr["b075"] = product.obj_productaudiencerange_List[a].AudienceRangePrecision_ProductAudienceRange[i].ToString();
                                    dr["b076"] = product.obj_productaudiencerange_List[a].AudienceRangeValue_ProductAudienceRange[i].ToString();

                                    dt_RH_MinAge.Rows.Add(dr);

                                    // exit out of loop.
                                    break;
                                }
                                else if (Convert.ToInt32(product.obj_productaudiencerange_List[a].AudienceRangePrecision_ProductAudienceRange[i].ToString()) == 4)
                                {
                                    DataRow dr = dt_RH_MinAge.NewRow();

                                    dr["ProductID"] = productCount;
                                    dr["RowCnt"] = (a + 1);
                                    // dr["b074"] = Audience;
                                    dr["b075"] = product.obj_productaudiencerange_List[a].AudienceRangePrecision_ProductAudienceRange[i].ToString();
                                    dr["b076"] = product.obj_productaudiencerange_List[a].AudienceRangeValue_ProductAudienceRange[i].ToString(); ;

                                    dt_RH_MinAge.Rows.Add(dr);
                                }
                            }

                        }
                    }
                }
            }
            #endregion

            return dt_RH_MinAge;
        }
        public DataTable Series(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Series, int MetaDataID, int productCount)
        {

            //check if your using b203 or not

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Series'

            for (int a = 0; a < product.obj_ProductSeries_List.Count; a++)
            {

                //if (product.obj_product_series_List[a].b018_product_series.Length > 0 || product.obj_product_series_List[a].b019_product_series.Length > 0)
                //if (product.obj_product_series_List[a].b019_product_series.Length > 0)
                //{
                //dr["ProductID"] = productCount;
                //dr["RowCnt"] = (a + 1);
                //dr["SeriesName_b018"] = ""; // product.obj_product_series_List[a].b018_product_series;
                //dr["SeriesNumber_b019"] = product.obj_product_series_List[a].b019_product_series;


                //for (int b = 0; b < product.obj_ProductSeries_List[a].obj_ProductSeriesTitleOfSeries_List.Count; b++)
                //{
                if (!string.IsNullOrEmpty(product.obj_ProductSeries_List[a].TitleOfSeries_ProductSeries))
                {
                    //if (product.obj_ProductSeries_List[a].TitleOfSeries_ProductSeries.Length > 0 )
                    //{
                    DataRow dr = dt_RH_Series.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (a + 1);
                    dr["SeriesName_b018"] = product.obj_ProductSeries_List[a].TitleOfSeries_ProductSeries;
                    dr["SeriesNumber_b019"] = StringReplace(product.obj_ProductSeries_List[a].NumberWithinSeries_ProductSeries, "No.", "");
                    dr["SeriesName_b203"] = ""; //product.obj_ProductSeries_List[a].TitleOfSeries_ProductSeries;

                    dt_RH_Series.Rows.Add(dr);

                }
                //}



                //}

            }
            #endregion



            return dt_RH_Series;


        }
        public DataTable Status_b394(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Status_b394, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Status_b394'

            for (int a = 0; a < product.obj_PublishingStatus_List.Count; a++)
            {

                DataRow dr = dt_RH_Status_b394.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Status_b394"] = product.obj_PublishingStatus_List[a];
                //dr["Status_j141"] = product.obj_product_series_List[a].b019_product_series;

                dt_RH_Status_b394.Rows.Add(dr);

            }

            #endregion



            return dt_RH_Status_b394;


        }
        public DataTable Status_j141(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_Status_j141, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Status_j141'

            for (int a = 0; a < product.obj_ProductSupplyDetail_List.Count; a++)
            {
                DataRow dr = dt_RH_Status_j141.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Status_j141"] = product.obj_ProductSupplyDetail_List[a].AvailabilityCode_ProductSupplyDetail;
                dr["Status_j396"] = product.obj_ProductSupplyDetail_List[a].ProductAvailability_ProductSupplyDetail;


                dt_RH_Status_j141.Rows.Add(dr);

            }

            #endregion


            return dt_RH_Status_j141;


        }
        public DataTable SalesRights(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_SalesRights, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'SalesRights'

            for (int a = 0; a < product.obj_ProductSalesRights_List.Count; a++)
            {
                DataRow dr = dt_RH_SalesRights.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["SalesRightsTypeCode_b089"] = product.obj_ProductSalesRights_List[a].SalesRightsType_ProductSalesRights;
                dr["RightsCountry_b090"] = product.obj_ProductSalesRights_List[a].RightsCountry_ProductSalesRights;
                dr["RightsTerritory_b388"] = product.obj_ProductSalesRights_List[a].RightsTerritory_ProductSalesRights;

                dt_RH_SalesRights.Rows.Add(dr);


            }

            #endregion


            return dt_RH_SalesRights;


        }

        //public DataTable SalesRights_NotForSale(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_SalesRights_NotForSale, int MetaDataID, int productCount)
        //{

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'SalesRights'

        //    for (int a = 0; a < product.obj_notforsale_List.Count; a++)
        //    {
        //        for (int b = 0; b < product.obj_notforsale_List[a].obj_b090_List.Count; b++)
        //        {
        //            DataRow dr = dt_RH_SalesRights_NotForSale.NewRow();

        //            dr["MetaDataID"] = MetaDataID;
        //            dr["ProductID"] = productCount;
        //            dr["RowCnt"] = (b + 1);
        //            dr["NotForSale_b090"] = product.obj_notforsale_List[a].obj_b090_List[b].Replace(" ", "");

        //            dt_RH_SalesRights_NotForSale.Rows.Add(dr);
        //        }

        //    }
        //    #endregion

        //    return dt_RH_SalesRights_NotForSale;


        //}
        //public DataTable SalesRestriction(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_SalesRestriction, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'SalesRestriction'

        //    for (int a = 0; a < product.obj_product_salesrestriction_List.Count; a++)
        //    {
        //        DataRow dr = dt_RH_SalesRestriction.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["SalesRestriction_b383"] = product.obj_product_salesrestriction_List[a].b383_product_salesrestriction;

        //        dt_RH_SalesRestriction.Rows.Add(dr);
        //    }

        //    #endregion


        //    return dt_RH_SalesRestriction;


        //}
        public DataTable PageCount(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_SalesRights, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'PageCount'

            for (int a = 0; a < product.obj_NumberOfPages_List.Count; a++)
            {
                DataRow dr = dt_RH_SalesRights.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["PageCount_b061"] = product.obj_NumberOfPages_List[a];

                dt_RH_SalesRights.Rows.Add(dr);

            }

            #endregion

            return dt_RH_SalesRights;


        }
        public DataTable ReleaseDate_b003(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_ReleaseDate_b003, int MetaDataID, int productCount)
        {



            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ReleaseDate_b003'

            for (int a = 0; a < product.obj_PublicationDate_List.Count; a++)
            {
                DataRow dr = dt_RH_ReleaseDate_b003.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["ReleaseDate_b003"] = product.obj_PublicationDate_List[a];

                dt_RH_ReleaseDate_b003.Rows.Add(dr);
            }

            #endregion


            return dt_RH_ReleaseDate_b003;


        }
        public DataTable ReleaseDate_j143(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_ReleaseDate_j143, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ReleaseDate_j143'

            for (int a = 0; a < product.obj_ProductSupplyDetail_List.Count; a++)
            {
                DataRow dr = dt_RH_ReleaseDate_j143.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["ReleaseDate_j143"] = product.obj_ProductSupplyDetail_List[a].OnSaleDate_ProductSupplyDetail;

                dt_RH_ReleaseDate_j143.Rows.Add(dr);
            }
            #endregion



            return dt_RH_ReleaseDate_j143;


        }
        public DataTable EditionNumber_b057(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_EditionNumber_b057, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'EditionNumber_b057'

            for (int a = 0; a < product.obj_EditionNumber_List.Count; a++)
            {
                DataRow dr = dt_RH_EditionNumber_b057.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["EditionNumber_b057"] = product.obj_EditionNumber_List[a];

                dt_RH_EditionNumber_b057.Rows.Add(dr);

            }

            #endregion


            return dt_RH_EditionNumber_b057;


        }
        public DataTable ProductFormCode_b012(TitleInjestion.Onix_2_Reference_Definiton.Product product, DataTable dt_RH_ProductFormCode_b012, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ProductFormCode_b012'

            for (int a = 0; a < product.obj_ProductForm_List.Count; a++)
            {

                DataRow dr = dt_RH_ProductFormCode_b012.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["ProductFormCode_b012"] = product.obj_ProductForm_List[a];

                dt_RH_ProductFormCode_b012.Rows.Add(dr);
            }

            #endregion

            return dt_RH_ProductFormCode_b012;


        }


        #endregion


        //public DataTable Publisher2(TitleInjestion.Onix_Definition.product product, DataTable dt_RH_Publisher2, int productCount)
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

        //        dt_RH_Publisher2.Rows.Add(dr);
        //    }
        //    #endregion



        //    return dt_RH_Publisher2;


        //}



        //        public DataTable Bisac(TitleInjestion.Onix_Definition.product product, DataTable dt_RH_Bisac, int productCount)
        //        {


        //            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //#region 'Bisac'

        //            for (int a = 0; a < product.obj_product_subject_List.Count; a++)
        //            {
        //                if (product.obj_product_subject_List[a].b067_product_subject == "10")
        //                {
        //                    DataRow dr = dt_RH_Bisac.NewRow();

        //                    dr["ProductID"] = productCount;
        //                    dr["RowCnt"] = (a + 1);
        //                    dr["Bisac_b067"] = product.obj_product_subject_List[a].b067_product_subject;
        //                    dr["Bisac_b069"] = product.obj_product_subject_List[a].b069_product_subject;

        //                    dt_RH_Bisac.Rows.Add(dr);
        //                }
        //            }
        //#endregion



        //            return dt_RH_Bisac;


        //        }                

        //public DataTable Bisac2_b069(TitleInjestion.Onix_Definition.product product, DataTable dt_RH_Bisac2_b069, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Bisac_b064'

        //    for (int a = 0; a < product.ob.Count; a++)
        //    {

        //        DataRow dr = dt_RH_Bisac2_b069.NewRow();

        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["Bisac_b064"] = product.obj_b064_List[a];

        //        dt_RH_Bisac2_b069.Rows.Add(dr);

        //    }
        //    #endregion



        //    return dt_RH_Bisac2_b069;


        //}




        public string StringReplace(string stringToSearch, string find, string replaceWith)
        {
            if (stringToSearch == null) return null;
            if (string.IsNullOrEmpty(find) || replaceWith == null) return stringToSearch;
            return stringToSearch.Replace(find, replaceWith);
        }






        //        public DataTable b211(TitleInjestion.Onix_Definition.product product, DataTable dt_RH_b211, int productCount)
        //        {


        //            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //#region 'ReleaseDate_j143'

        //            for (int a = 0; a < product.obj_b211_List.Count; a++)
        //            {

        //                DataRow dr = dt_RH_b211.NewRow();

        //                dr["ProductID"] = productCount;
        //                dr["RowCnt"] = (a + 1);
        //                dr["b211"] = product.obj_b211_List[a];

        //                dt_RH_b211.Rows.Add(dr);
        //            }
        //#endregion



        //            return dt_RH_b211;


        //        }



    }
}
