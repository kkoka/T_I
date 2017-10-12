using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

using TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition;

using TitleInjestion.CommonFunctions;


namespace TitleInjestion.Company.RecordedBooks.Publisher.EAudio.Lerner
{
    class Lerner_Extraction
    {
        public List<string> d101_productID = new List<string>();

        public bool RB_Lerner_Extraction(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.ONIXmessage fileinfo_1, int pubid, string FileName, string MediaType,
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


                //DataTable dt_MetaDataInfo = new DataTable("MetaDataInfo");
                //#region 'Columns Declaration'

                //dt_MetaDataInfo.Columns.Add("Pub_ID", typeof(int));
                //dt_MetaDataInfo.Columns.Add("FileName", typeof(string));
                //dt_MetaDataInfo.Columns.Add("FileType", typeof(string));

                //#endregion

                DataTable dt_ISBN = new DataTable("ISBN");
                #region 'Columns Declaration'

                dt_ISBN.Columns.Add("MetaDataID", typeof(int));
                dt_ISBN.Columns.Add("ProductID", typeof(int));
                dt_ISBN.Columns.Add("RowCnt", typeof(int));
                //  dt_ISBN.Columns.Add("b221", typeof(string));
                dt_ISBN.Columns.Add("ISBN_b244", typeof(string));

                #endregion

                //DataTable dt_b213 = new DataTable("b213");
                //#region 'Columns Declaration'

                //dt_b213.Columns.Add("MetaDataID", typeof(int));
                //dt_b213.Columns.Add("ProductID", typeof(int));
                //dt_b213.Columns.Add("RowCnt", typeof(int));
                //dt_b213.Columns.Add("b213", typeof(string));

                //#endregion

                DataTable dt_Title_Subtitle = new DataTable("Title_Subtitle");
                #region 'Columns Declaration'

                dt_Title_Subtitle.Columns.Add("MetaDataID", typeof(int));
                dt_Title_Subtitle.Columns.Add("ProductID", typeof(int));
                dt_Title_Subtitle.Columns.Add("RowCnt", typeof(int));
                dt_Title_Subtitle.Columns.Add("SubTitle_b029", typeof(string));
                dt_Title_Subtitle.Columns.Add("TitlePrefix_b030", typeof(string));
                dt_Title_Subtitle.Columns.Add("TitleWithoutPrefix_b031", typeof(string));
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

                //DataTable dt_Publisher2 = new DataTable("Publisher2");
                //#region 'Columns Declaration'

                //dt_Publisher2.Columns.Add("ProductID", typeof(int));
                //dt_Publisher2.Columns.Add("RowCnt", typeof(int));
                //dt_Publisher2.Columns.Add("Publisher_b081", typeof(string));

                //#endregion

                //DataTable dt_Imprint = new DataTable("Imprint");
                //#region 'Columns Declaration'

                //dt_Imprint.Columns.Add("MetaDataID", typeof(int));
                //dt_Imprint.Columns.Add("ProductID", typeof(int));
                //dt_Imprint.Columns.Add("RowCnt", typeof(int));
                //dt_Imprint.Columns.Add("Imprint_b079", typeof(string));

                //#endregion

                //DataTable dt_DigitalFormat_b333 = new DataTable("DigitalFormat");
                //#region 'Columns Declaration'

                //dt_DigitalFormat_b333.Columns.Add("MetaDataID", typeof(int));
                //dt_DigitalFormat_b333.Columns.Add("ProductID", typeof(int));
                //dt_DigitalFormat_b333.Columns.Add("RowCnt", typeof(int));
                //dt_DigitalFormat_b333.Columns.Add("DigitalFormat_b333", typeof(string));

                //#endregion;

                DataTable dt_UnAbridged = new DataTable("UnAbridged");
                #region 'Columns Declaration'

                dt_UnAbridged.Columns.Add("MetaDataID", typeof(int));
                dt_UnAbridged.Columns.Add("ProductID", typeof(int));
                dt_UnAbridged.Columns.Add("RowCnt", typeof(int));
                dt_UnAbridged.Columns.Add("Unabridged_b056", typeof(string));

                #endregion;

                //////DataTable dt_UnAbridged2 = new DataTable("UnAbridged2");
                //////#region 'Columns Declaration'

                //////dt_UnAbridged2.Columns.Add("MetaDataID", typeof(int));
                //////dt_UnAbridged2.Columns.Add("ProductID", typeof(int));
                //////dt_UnAbridged2.Columns.Add("RowCnt", typeof(int));
                //////dt_UnAbridged2.Columns.Add("UnAbridged_b058", typeof(string));

                //////#endregion;


                DataTable dt_CDCount = new DataTable("CDCount");
                #region 'Columns Declaration'

                dt_CDCount.Columns.Add("MetaDataID", typeof(int));
                dt_CDCount.Columns.Add("ProductID", typeof(int));
                dt_CDCount.Columns.Add("RowCnt", typeof(int));
                dt_CDCount.Columns.Add("CDCount_b210", typeof(string));

                #endregion;



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
                //   dt_Price.Columns.Add("ClassOfTrade_j149", typeof(string));
                dt_Price.Columns.Add("LibraryPrice_j151", typeof(string));
                dt_Price.Columns.Add("CurrencyCode_j152", typeof(string));
                dt_Price.Columns.Add("j261", typeof(string));

                #endregion


                DataTable dt_Description = new DataTable("Description");
                #region 'Columns Declaration'

                dt_Description.Columns.Add("MetaDataID", typeof(int));
                dt_Description.Columns.Add("ProductID", typeof(int));
                dt_Description.Columns.Add("RowCnt", typeof(int));
                dt_Description.Columns.Add("DescriptionType_d102", typeof(string));
                dt_Description.Columns.Add("TextFormat_d103", typeof(string));
                dt_Description.Columns.Add("Description_d104", typeof(string));

                #endregion

                //DataTable dt_Description_d101 = new DataTable("Description_d101");
                //#region 'Columns Declaration'

                //dt_Description_d101.Columns.Add("MetaDataID", typeof(int));
                //dt_Description_d101.Columns.Add("ProductID", typeof(int));
                //dt_Description_d101.Columns.Add("RowCnt", typeof(int));
                //dt_Description_d101.Columns.Add("Description_d101", typeof(string));

                //#endregion

                DataTable dt_Bisac = new DataTable("Bisac");
                #region 'Columns Declaration'

                dt_Bisac.Columns.Add("MetaDataID", typeof(int));
                dt_Bisac.Columns.Add("ProductID", typeof(int));
                dt_Bisac.Columns.Add("RowCnt", typeof(int));
                dt_Bisac.Columns.Add("Bisac_b067", typeof(string));
                dt_Bisac.Columns.Add("Bisac_b069", typeof(string));

                #endregion

                //DataTable dt_MainBisacBic = new DataTable("MainBisacBic");
                //#region 'Columns Declaration'

                //dt_MainBisacBic.Columns.Add("MetaDataID", typeof(int));
                //dt_MainBisacBic.Columns.Add("ProductID", typeof(int));
                //dt_MainBisacBic.Columns.Add("RowCnt", typeof(int));
                //dt_MainBisacBic.Columns.Add("Bisac_b191", typeof(string));
                //dt_MainBisacBic.Columns.Add("Bisac_b069", typeof(string));

                //#endregion

                DataTable dt_Bisac_b064 = new DataTable("Bisac_b064");
                #region 'Columns Declaration'

                dt_Bisac_b064.Columns.Add("MetaDataID", typeof(int));
                dt_Bisac_b064.Columns.Add("ProductID", typeof(int));
                dt_Bisac_b064.Columns.Add("RowCnt", typeof(int));
                dt_Bisac_b064.Columns.Add("Bisac_b064", typeof(string));

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

                DataTable dt_TotalRunTime = new DataTable("TotalRunTime");
                #region 'Columns Declaration'

                dt_TotalRunTime.Columns.Add("MetaDataID", typeof(int));
                dt_TotalRunTime.Columns.Add("ProductID", typeof(int));
                dt_TotalRunTime.Columns.Add("RowCnt", typeof(int));
                dt_TotalRunTime.Columns.Add("TotalRunTimeCode_b218", typeof(string));
                dt_TotalRunTime.Columns.Add("TotalRunTime_b219", typeof(string));
                dt_TotalRunTime.Columns.Add("TotalRunTimeUnit_b220", typeof(string));

                #endregion

                DataTable dt_AudienceCode_b073 = new DataTable("AudienceCode_b073");
                #region 'Columns Declaration'

                dt_AudienceCode_b073.Columns.Add("MetaDataID", typeof(int));
                dt_AudienceCode_b073.Columns.Add("ProductID", typeof(int));
                dt_AudienceCode_b073.Columns.Add("RowCnt", typeof(int));
                dt_AudienceCode_b073.Columns.Add("AudienceCode_b073", typeof(string));

                #endregion


                DataTable dt_AudienceCode_b206 = new DataTable("AudienceCode_b206");
                #region 'Columns Declaration'

                dt_AudienceCode_b206.Columns.Add("MetaDataID", typeof(int));
                dt_AudienceCode_b206.Columns.Add("ProductID", typeof(int));
                dt_AudienceCode_b206.Columns.Add("RowCnt", typeof(int));
                dt_AudienceCode_b206.Columns.Add("AudienceCode_b206", typeof(string));

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

                DataTable dt_Series = new DataTable("Series");
                #region 'Columns Declaration'

                dt_Series.Columns.Add("MetaDataID", typeof(int));
                dt_Series.Columns.Add("ProductID", typeof(int));
                dt_Series.Columns.Add("RowCnt", typeof(int));
                dt_Series.Columns.Add("SeriesName_b018", typeof(string));
                dt_Series.Columns.Add("SeriesNumber_b019", typeof(string));
                dt_Series.Columns.Add("SeriesName_b203", typeof(string));

                #endregion

                DataTable dt_Status_b394 = new DataTable("Status_b394");
                #region 'Columns Declaration'

                dt_Status_b394.Columns.Add("MetaDataID", typeof(int));
                dt_Status_b394.Columns.Add("ProductID", typeof(int));
                dt_Status_b394.Columns.Add("RowCnt", typeof(int));
                dt_Status_b394.Columns.Add("Status_b394", typeof(string));

                #endregion

                DataTable dt_Status_j141 = new DataTable("Status_j141");
                #region 'Columns Declaration'

                dt_Status_j141.Columns.Add("MetaDataID", typeof(int));
                dt_Status_j141.Columns.Add("ProductID", typeof(int));
                dt_Status_j141.Columns.Add("RowCnt", typeof(int));
                dt_Status_j141.Columns.Add("Status_j141", typeof(string));
                dt_Status_j141.Columns.Add("Status_j396", typeof(string));

                #endregion


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

                DataTable dt_SalesRights_NotForSale = new DataTable("SalesRights_NotForSale");
                #region 'Columns Declaration'

                dt_SalesRights_NotForSale.Columns.Add("MetaDataID", typeof(int));
                dt_SalesRights_NotForSale.Columns.Add("ProductID", typeof(int));
                dt_SalesRights_NotForSale.Columns.Add("RowCnt", typeof(int));
                dt_SalesRights_NotForSale.Columns.Add("NotForSale_b090", typeof(string));

                #endregion

                //DataTable dt_PageCount = new DataTable("PageCount");
                //#region 'Columns Declaration'

                //dt_PageCount.Columns.Add("MetaDataID", typeof(int));
                //dt_PageCount.Columns.Add("ProductID", typeof(int));
                //dt_PageCount.Columns.Add("RowCnt", typeof(int));
                //dt_PageCount.Columns.Add("PageCount_b061", typeof(string));

                //#endregion

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

                DataTable dt_ReleaseDate_j143 = new DataTable("ReleaseDate_j143");
                #region 'Columns Declaration'

                dt_ReleaseDate_j143.Columns.Add("MetaDataID", typeof(int));
                dt_ReleaseDate_j143.Columns.Add("ProductID", typeof(int));
                dt_ReleaseDate_j143.Columns.Add("RowCnt", typeof(int));
                dt_ReleaseDate_j143.Columns.Add("ReleaseDate_j143", typeof(string));

                #endregion


                DataTable dt_MinAge = new DataTable("MinAge");
                #region 'Columns Declaration'

                dt_MinAge.Columns.Add("MetaDataID", typeof(int));
                dt_MinAge.Columns.Add("ProductID", typeof(int));
                dt_MinAge.Columns.Add("RowCnt", typeof(int));
                dt_MinAge.Columns.Add("b075", typeof(string));
                dt_MinAge.Columns.Add("b076", typeof(string));

                #endregion

                //DataTable dt_b211 = new DataTable("b211");
                //#region 'Columns Declaration'

                //dt_b211.Columns.Add("MetaDataID", typeof(int));
                //dt_b211.Columns.Add("ProductID", typeof(int));
                //dt_b211.Columns.Add("RowCnt", typeof(int));
                //dt_b211.Columns.Add("b211", typeof(string));

                //#endregion

                DataTable dt_EditionNumber_b057 = new DataTable("EditionNumber_b057");
                #region 'Columns Declaration'

                dt_EditionNumber_b057.Columns.Add("MetaDataID", typeof(int));
                dt_EditionNumber_b057.Columns.Add("ProductID", typeof(int));
                dt_EditionNumber_b057.Columns.Add("RowCnt", typeof(int));
                dt_EditionNumber_b057.Columns.Add("EditionNumber_b057", typeof(string));

                #endregion

                DataTable dt_ProductFormCode_b012 = new DataTable("ProductFormCode_b012");
                #region 'Columns Declaration'

                dt_ProductFormCode_b012.Columns.Add("MetaDataID", typeof(int));
                dt_ProductFormCode_b012.Columns.Add("ProductID", typeof(int));
                dt_ProductFormCode_b012.Columns.Add("RowCnt", typeof(int));
                dt_ProductFormCode_b012.Columns.Add("ProductFormCode_b012", typeof(string));

                #endregion

                #endregion

                int MetaDataID = InsertMetaData_Info(pubid, FileName, MediaType, "RB");

                if (MetaDataID > 0)
                {
                    for (int i = 0; i < fileinfo_1.obj_product_List.Count; i++)
                    {

                        #region 'Populate DataTable'




                        // for each product
                        #region 'ISBN'
                        Step = "ISBN";
                        dt_ISBN = ISBN(fileinfo_1.obj_product_List[i], dt_ISBN, MetaDataID, (i + 1));
                        #endregion



                        // for each product
                        #region 'b213'
                        //Step = "b213";
                        //dt_b213 = b213(fileinfo_1.obj_product_List[i], dt_b213, MetaDataID, (i + 1));
                        #endregion





                        #region 'Title_Subtitle'
                        Step = "Title_Subtitle";
                        dt_Title_Subtitle = TitleSubtitle(fileinfo_1.obj_product_List[i], dt_Title_Subtitle, MetaDataID, (i + 1));
                        #endregion

                        #region 'Publisher'
                        Step = "Publisher";
                        dt_Publisher = Publisher(fileinfo_1.obj_product_List[i], dt_Publisher, MetaDataID, (i + 1));
                        #endregion

                        //#region 'Publisher2'
                        //dt_Publisher2 = Publisher2(fileinfo_1.obj_product_List[i], dt_Publisher2, MetaDataID, (i + 1));
                        //#endregion

                        //#region 'Imprint'
                        //Step = "Imprint";
                        //dt_Imprint = Imprint(fileinfo_1.obj_product_List[i], dt_Imprint, MetaDataID, (i + 1));
                        //#endregion

                        #region 'UnAbridged'
                        Step = "UnAbridged";
                        dt_UnAbridged = UnAbridged(fileinfo_1.obj_product_List[i], dt_UnAbridged, MetaDataID, (i + 1));
                        #endregion


                        ////#region 'UnAbridged_b058'
                        ////Step = "UnAbridged_b058";
                        ////dt_UnAbridged2 = UnAbridged2(fileinfo_1.obj_product_List[i], dt_UnAbridged2, MetaDataID, (i + 1));
                        ////#endregion



                        #region 'CDCount_b210'
                        Step = "CDCount_b210";
                        dt_CDCount = CDCount(fileinfo_1.obj_product_List[i], dt_CDCount, MetaDataID, (i + 1));
                        #endregion

                        #region 'Language'
                        Step = "Language";
                        dt_Language = Language(fileinfo_1.obj_product_List[i], dt_Language, MetaDataID, (i + 1));
                        #endregion

                        #region 'Price'
                        Step = "Price";
                        dt_Price = Price(fileinfo_1.obj_product_List[i], dt_Price, MetaDataID, (i + 1));
                        #endregion

                        #region 'Description'
                        //Step = "Description1";
                        //dt_Description_d101 = Description_d101(fileinfo_1.obj_product_List[i], dt_Description_d101, MetaDataID, (i + 1));

                        Step = "Description2";
                        dt_Description = Description(fileinfo_1.obj_product_List[i], dt_Description, MetaDataID, (i + 1));

                        #endregion

                        #region 'DigitalFormat_AudibleWma_b333'

                        //Step = "DigitalFormat_b333";
                        //dt_DigitalFormat_b333 = DigitalFormat_b333(fileinfo_1.obj_product_List[i], dt_DigitalFormat_b333, MetaDataID, (i + 1));

                        #endregion

                        #region 'Bisac'
                        Step = "dt_Bisac";
                        dt_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_Bisac, MetaDataID, (i + 1));





                        //Step = "dt_MainBisacBic";
                        //dt_MainBisacBic = MainBisacBic(fileinfo_1.obj_product_List[i], dt_MainBisacBic, MetaDataID, (i + 1));

                        Step = "dt_Bisac_b064";
                        dt_Bisac_b064 = Bisac_b064(fileinfo_1.obj_product_List[i], dt_Bisac_b064, MetaDataID, (i + 1));

                        //Step = "dt_Bic_b065";
                        //dt_Bic_b065 = Bic_b065(fileinfo_1.obj_product_List[i], dt_Bic_b065, (i + 1));


                        #endregion



                        #region 'TotalRunTime'

                        Step = "TotalRunTime";
                        dt_TotalRunTime = TotalRunTime(fileinfo_1.obj_product_List[i], dt_TotalRunTime, MetaDataID, (i + 1));

                        #endregion





                        #region 'Audience'
                        //Step = "dt_Bisac";
                        //dt_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_Bisac, (i + 1));

                        //Step = "dt_Audience";
                        //dt_Audience = Audience(fileinfo_1.obj_product_List[i], dt_Audience, MetaDataID, (i + 1));
                        //Step = "dt_Audience";

                        Step = "dt_AudienceCode_b073";
                        dt_AudienceCode_b073 = AudienceCode_b073(fileinfo_1.obj_product_List[i], dt_AudienceCode_b073, MetaDataID, (i + 1));
                        Step = "dt_AudienceCode_b073";

                        Step = "dt_AudienceCode_b206";
                        dt_AudienceCode_b206 = AudienceCode_b206(fileinfo_1.obj_product_List[i], dt_AudienceCode_b206, MetaDataID, (i + 1));
                        Step = "dt_AudienceCode_b206";




                        #endregion

                        #region 'MinAge'
                        //Step = "dt_Bisac";
                        //dt_Bisac = Bisac(fileinfo_1.obj_product_List[i], dt_Bisac, (i + 1));

                        Step = "dt_MinAge";
                        dt_MinAge = MinAge(fileinfo_1.obj_product_List[i], dt_MinAge, MetaDataID, (i + 1));
                        Step = "dt_MinAge";



                        #endregion

                        #region 'Contributors'
                        Step = "Contributors";
                        dt_contributor = Contributor(fileinfo_1.obj_product_List[i], dt_contributor, MetaDataID, (i + 1));

                        #endregion

                        #region 'Series'
                        Step = "Series";
                        dt_Series = Series(fileinfo_1.obj_product_List[i], dt_Series, MetaDataID, (i + 1));
                        #endregion

                        #region 'Status'
                        Step = "Status_b394";
                        dt_Status_b394 = Status_b394(fileinfo_1.obj_product_List[i], dt_Status_b394, MetaDataID, (i + 1));

                        Step = "Status_j141";
                        dt_Status_j141 = Status_j141(fileinfo_1.obj_product_List[i], dt_Status_j141, MetaDataID, (i + 1));


                        #endregion

                        #region 'SalesRights'

                        Step = "SalesRights";
                        dt_SalesRights = SalesRights(fileinfo_1.obj_product_List[i], dt_SalesRights, MetaDataID, (i + 1));

                        Step = "SalesRights_NotForSale";
                        dt_SalesRights_NotForSale = SalesRights_NotForSale(fileinfo_1.obj_product_List[i], dt_SalesRights_NotForSale, MetaDataID, (i + 1));

                        #endregion

                        //#region 'Page Count'
                        //Step = "Page Count";
                        //dt_PageCount = PageCount(fileinfo_1.obj_product_List[i], dt_PageCount, MetaDataID, (i + 1));
                        //#endregion

                        //#region 'SalesRestriction'
                        //Step = "SalesRestriction";
                        //dt_SalesRestriction = SalesRestriction(fileinfo_1.obj_product_List[i], dt_SalesRestriction, MetaDataID, (i + 1));
                        //#endregion

                        #region 'ReleaseDate'
                        Step = "dt_ReleaseDate_b003";
                        dt_ReleaseDate_b003 = ReleaseDate_b003(fileinfo_1.obj_product_List[i], dt_ReleaseDate_b003, MetaDataID, (i + 1));

                        Step = "dt_ReleaseDate_j143 Count";
                        dt_ReleaseDate_j143 = ReleaseDate_j143(fileinfo_1.obj_product_List[i], dt_ReleaseDate_j143, MetaDataID, (i + 1));
                        #endregion

                        //#region 'b211'

                        //Step = "b211";
                        //dt_b211 = b211(fileinfo_1.obj_product_List[i], dt_b211, (i + 1));

                        //#endregion

                        #region 'EditionNumber_b057'

                        Step = "EditionNumber_b057";
                        dt_EditionNumber_b057 = EditionNumber_b057(fileinfo_1.obj_product_List[i], dt_EditionNumber_b057, MetaDataID, (i + 1));

                        #endregion

                        #region 'ProductFormCode_b012'

                        Step = "ProductFormCode_b012";
                        dt_ProductFormCode_b012 = ProductFormCode_b012(fileinfo_1.obj_product_List[i], dt_ProductFormCode_b012, MetaDataID, (i + 1));

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

                    int count = 23;

                    result = InsertRecords(dt_ISBN, "RB");
                    Insertion_Label(lbl_Insert, count);

                    //result = InsertRecords(dt_b213, "RB");
                    //Insertion_Label(lbl_Insert, count);

                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Title_Subtitle, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Publisher, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //InsertRecords(dt_Publisher2);

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_Imprint, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_UnAbridged, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    ////if (result)
                    ////{
                    ////    result = InsertRecords(dt_UnAbridged2, "RB");
                    ////    Insertion_Label(lbl_Insert, count);
                    ////}
                    ////count--;

                    if (result)
                    {
                        result = InsertRecords(dt_CDCount, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;



                    if (result)
                    {
                        result = InsertRecords(dt_Language, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Price, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Description, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_Description_d101, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_DigitalFormat_b333, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Bisac, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_MainBisacBic, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Bisac_b064, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_Audience, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;


                    if (result)
                    {
                        result = InsertRecords(dt_TotalRunTime, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_AudienceCode_b073, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_AudienceCode_b206, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_MinAge, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;


                    //if (result)
                    //{
                    //    result = InsertRecords(dt_Bisac2, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_contributor, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Series, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Status_b394, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_Status_j141, "RB");
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
                        result = InsertRecords(dt_SalesRights_NotForSale, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_PageCount, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_SalesRestriction, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_ReleaseDate_b003, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_ReleaseDate_j143, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    //if (result)
                    //{
                    //    result = InsertRecords(dt_b211, "RB");
                    //    Insertion_Label(lbl_Insert, count);
                    //}
                    //count--;

                    if (result)
                    {
                        result = InsertRecords(dt_EditionNumber_b057, "RB");
                        Insertion_Label(lbl_Insert, count);
                    }
                    count--;

                    if (result)
                    {
                        result = InsertRecords(dt_ProductFormCode_b012, "RB");
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
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString("RB"), "Error at " + Step + " : " + ex.ToString());
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
        public bool Process_Lerner_EAudio(string Company, System.Windows.Forms.Label lbl_Processing)
        {
            bool result = false;

            lbl_Processing.BackColor = System.Drawing.Color.Yellow;
            lbl_Processing.Refresh();
            System.Windows.Forms.Application.DoEvents();




            SQLFunction sqlfunction = new SQLFunction();
            result = sqlfunction.ExecuteProc("RB", ConfigurationSettings.AppSettings["RB_Process_Lerner_EAudio"].ToString());

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

        //public DataTable b213(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_b213, int MetaDataID, int productCount)
        //{
        //    DataRow dr = dt_b213.NewRow();

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'dt_b213'
        //    int i = 0;
        //    for (int a = 0; a < product.obj_b213_List.Count; a++)
        //    {

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = i;
        //        dr["b213"] = product.obj_b213_List[a].ToString();

        //        dt_b213.Rows.Add(dr);

        //    }
        //    #endregion



        //    return dt_b213;


        //}


        public DataTable ISBN(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_ISBN, int MetaDataID, int productCount)
        {


            DataRow dr = dt_ISBN.NewRow();

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ISBN_b244'
            int i = 0;
            for (int a = 0; a < product.obj_product_productidentifier_List.Count; a++)
            {
                if (product.obj_product_productidentifier_List[a].b221_product_productidentifier == "15")
                {
                    i++;

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = i;
                    dr["ISBN_b244"] = product.obj_product_productidentifier_List[a].b244_product_productidentifier;

                    break;
                }
            }
            #endregion


            dt_ISBN.Rows.Add(dr);

            return dt_ISBN;


        }
        public DataTable TitleSubtitle(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Title_Subtitle, int MetaDataID, int productCount)
        {




            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Title'

            for (int a = 0; a < product.obj_product_title_List.Count; a++)
            {
                if (product.obj_product_title_List[a].b202_product_title == "01")
                {
                    DataRow dr = dt_Title_Subtitle.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (a + 1);
                    dr["SubTitle_b029"] = product.obj_product_title_List[a].b029_product_title;
                    dr["TitlePrefix_b030"] = product.obj_product_title_List[a].b030_product_title;
                    dr["TitleWithoutPrefix_b031"] = product.obj_product_title_List[a].b031_product_title;
                    dr["TitleType_b202"] = product.obj_product_title_List[a].b202_product_title;
                    dr["Title_b203"] = product.obj_product_title_List[a].b203_product_title;

                    dt_Title_Subtitle.Rows.Add(dr);
                }
            }
            #endregion



            return dt_Title_Subtitle;


        }
        public DataTable Publisher(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Publisher, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Publisher'
            for (int a = 0; a < product.obj_product_publisher_List.Count; a++)
            {
                DataRow dr = dt_Publisher.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Publisher_b081"] = "Lerner Publishing Group"; //product.obj_product_publisher_List[a].b081_product_publisher;

                dt_Publisher.Rows.Add(dr);
            }
            #endregion



            return dt_Publisher;


        }

        //public DataTable Publisher2(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Publisher2, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Publisher'
        //    for (int a = 0; a < product.obj_b081_List.Count; a++)
        //    {
        //        DataRow dr = dt_Publisher2.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["Publisher_b081"] = product.obj_b081_List[a].ToString();

        //        dt_Publisher2.Rows.Add(dr);
        //    }
        //    #endregion



        //    return dt_Publisher2;


        //}    

        public DataTable Imprint(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Imprint, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Imprint'
            for (int a = 0; a < product.obj_imprint_List.Count; a++)
            {

                DataRow dr = dt_Imprint.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = a;
                dr["Imprint_b079"] = product.obj_imprint_List[a].b079_product_imprint;

                dt_Imprint.Rows.Add(dr);

            }
            #endregion



            return dt_Imprint;


        }
        public DataTable UnAbridged(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_UnAbridged, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'UnAbridged'
            for (int a = 0; a < product.obj_b056_List.Count; a++)
            {

                DataRow dr = dt_UnAbridged.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Unabridged_b056"] = product.obj_b056_List[a];

                dt_UnAbridged.Rows.Add(dr);

            }
            #endregion

            return dt_UnAbridged;


        }
        ////public DataTable UnAbridged2(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_UnAbridged2, int MetaDataID, int productCount)
        ////{


        ////    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        ////    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        ////    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        ////    #region 'dt_UnAbridged2'
        ////    for (int a = 0; a < product.obj_b058_List.Count; a++)
        ////    {

        ////        DataRow dr = dt_UnAbridged2.NewRow();

        ////        dr["MetaDataID"] = MetaDataID;
        ////        dr["ProductID"] = productCount;
        ////        dr["RowCnt"] = (a + 1);
        ////        dr["UnAbridged_b058"] = product.obj_b058_List[a];

        ////        dt_UnAbridged2.Rows.Add(dr);

        ////    }
        ////    #endregion

        ////    return dt_UnAbridged2;


        ////}

        public DataTable CDCount(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_CDCount, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'dt_CDCount'
            for (int a = 0; a < product.obj_b210_List.Count; a++)
            {

                DataRow dr = dt_CDCount.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["CDCount_b210"] = product.obj_b210_List[a].ToString();

                dt_CDCount.Rows.Add(dr);

            }
            #endregion

            return dt_CDCount;

        }

        public DataTable Language(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Language, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Language'
            for (int a = 0; a < product.obj_product_language_List.Count; a++)
            {
                if (!string.IsNullOrEmpty(product.obj_product_language_List[a].b252_product_language))
                {

                    if ((product.obj_product_language_List[a].b252_product_language.ToLower() == "eng") ||
                        (product.obj_product_language_List[a].b252_product_language.ToLower() == "spa") ||
                        (product.obj_product_language_List[a].b252_product_language.ToLower() == "fre") ||
                        (product.obj_product_language_List[a].b252_product_language.ToLower() == "ger"))
                    {

                        DataRow dr = dt_Language.NewRow();

                        dr["MetaDataID"] = MetaDataID;
                        dr["ProductID"] = productCount;
                        dr["RowCnt"] = (a + 1);
                        dr["Language_b252"] = product.obj_product_language_List[a].b252_product_language;

                        dt_Language.Rows.Add(dr);
                    }
                }

            }
            #endregion

            return dt_Language;


        }
        public DataTable Price(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Price, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Price'

            for (int a = 0; a < product.obj_product_supplydetail_List.Count; a++)
            {
                for (int b = 0; b < product.obj_product_supplydetail_List[a].obj_supplydetail_price_List.Count; b++)
                {


                    #region 'USD'

                    if (product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j152_product_supplydetail_price.ToLower() == "usd")
                    {
                        //if (!string.IsNullOrEmpty(product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j261_product_supplydetail_price))
                        //{
                        //    if (product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j261_product_supplydetail_price.ToLower() == "06")
                        //    {
                        if (!string.IsNullOrEmpty(product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j148_product_supplydetail_price))
                        {
                            if (product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j148_product_supplydetail_price.ToLower() == "01")
                            {

                                //for (int c = 0; c < product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].obj_b251_List.Count; c++)
                                //{
                                //    if (product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].obj_b251_List[c].ToString().ToLower() == "gb")
                                //    {

                                DataRow dr = dt_Price.NewRow();

                                dr["MetaDataID"] = MetaDataID;
                                dr["ProductID"] = productCount;
                                dr["RowCnt"] = (b + 1);
                                dr["PriceType_j148"] = product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j148_product_supplydetail_price;
                                //     dr["ClassOfTrade_j149"] = ""; //  product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j149_product_supplydetail_price;
                                dr["LibraryPrice_j151"] = product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j151_product_supplydetail_price;
                                dr["CurrencyCode_j152"] = product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j152_product_supplydetail_price;
                                dr["j261"] = product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j261_product_supplydetail_price;

                                dt_Price.Rows.Add(dr);

                                //    }
                                //}
                            }
                        }
                        //    }
                        //}
                    }

                    #endregion

                    #region 'CAD'

                    if (product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j152_product_supplydetail_price.ToLower() == "cad")
                    {
                        //if (!string.IsNullOrEmpty(product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j261_product_supplydetail_price))
                        //{
                        //    if (product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j261_product_supplydetail_price.ToLower() == "06")
                        //    {
                        if (!string.IsNullOrEmpty(product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j148_product_supplydetail_price))
                        {
                            if (product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j148_product_supplydetail_price.ToLower() == "01")
                            {

                                //for (int c = 0; c < product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].obj_b251_List.Count; c++)
                                //{
                                //    if (product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].obj_b251_List[c].ToString().ToLower() == "ie")
                                //    {

                                DataRow dr = dt_Price.NewRow();

                                dr["MetaDataID"] = MetaDataID;
                                dr["ProductID"] = productCount;
                                dr["RowCnt"] = (b + 1);
                                dr["PriceType_j148"] = product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j148_product_supplydetail_price;
                                //    dr["ClassOfTrade_j149"] = ""; //  product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j149_product_supplydetail_price;
                                dr["LibraryPrice_j151"] = product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j151_product_supplydetail_price;
                                dr["CurrencyCode_j152"] = product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j152_product_supplydetail_price;
                                dr["j261"] = product.obj_product_supplydetail_List[a].obj_supplydetail_price_List[b].j261_product_supplydetail_price;

                                dt_Price.Rows.Add(dr);
                                //    }
                                //}
                            }
                        }

                        //    }
                        //}
                    }

                    #endregion


                }
            }

            #endregion

            return dt_Price;


        }
        //public DataTable Description_d101(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Description_d101, int MetaDataID, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Description'

        //    for (int a = 0; a < product.obj_d101_List.Count; a++)
        //    {


        //        if (!string.IsNullOrEmpty(product.obj_d101_List[a]))
        //        {
        //            DataRow dr = dt_Description_d101.NewRow();

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


        //            dt_Description_d101.Rows.Add(dr);

        //        }
        //        //else
        //        //{
        //        //    dr["Description_d101"] = "";
        //        //}


        //    }
        //    #endregion



        //    return dt_Description_d101;


        //}
        public DataTable Description(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Description, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Description'

            for (int a = 0; a < product.obj_product_othertext_List.Count; a++)
            {
                if (product.obj_product_othertext_List[a].d102_product_othertext == "03" ||
                    product.obj_product_othertext_List[a].d102_product_othertext == "01" ||
                    product.obj_product_othertext_List[a].d102_product_othertext == "02" ||
                    product.obj_product_othertext_List[a].d102_product_othertext == "25")
                {
                    DataRow dr = dt_Description.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (a + 1);
                    dr["DescriptionType_d102"] = product.obj_product_othertext_List[a].d102_product_othertext;
                    dr["TextFormat_d103"] = product.obj_product_othertext_List[a].d103_product_othertext;

                    if (!string.IsNullOrEmpty(product.obj_product_othertext_List[a].d104_product_othertext))
                    {
                        if (product.obj_product_othertext_List[a].d104_product_othertext.Length > 3500)
                        {
                            //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                            dr["Description_d104"] = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                        }
                        else
                        {
                            //string asdf = product.obj_product_othertext_List[a].d104_product_othertext.Substring(0, 3500);
                            dr["Description_d104"] = product.obj_product_othertext_List[a].d104_product_othertext;
                        }
                    }
                    else
                    {
                        dr["Description_d104"] = "";
                    }

                    dt_Description.Rows.Add(dr);
                }

            }
            #endregion



            return dt_Description;


        }
        public DataTable Contributor(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_contributor, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Contributor'

            for (int a = 0; a < product.obj_contributor_List.Count; a++)
            {
                DataRow dr = dt_contributor.NewRow();


                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Contribs_SequenceNumber_b034"] = StringReplace(product.obj_contributor_List[a].b034_productcontributor, "To Be Announced", "");
                dr["Contribs_ContribCode_b035"] = StringReplace(product.obj_contributor_List[a].b035_productcontributor, "To Be Announced", "");
                dr["Contribs_FNF_b036"] = StringReplace(StringReplace(product.obj_contributor_List[a].b036_productcontributor, "To Be Announced", ""), "tbd", "");
                dr["Contribs_LNF_b037"] = StringReplace(StringReplace(product.obj_contributor_List[a].b037_productcontributor, "To Be Announced", ""), "tbd", "");
                dr["Contribs_Prefix_b038"] = StringReplace(product.obj_contributor_List[a].b038_productcontributor, "To Be Announced", "");
                dr["Contribs_FirstName_b039"] = StringReplace(product.obj_contributor_List[a].b039_productcontributor, "To Be Announced", "");
                dr["Contribs_LastName_b040"] = StringReplace(product.obj_contributor_List[a].b040_productcontributor, "To Be Announced", "");
                dr["Contribs_CorporateAuthors_b047"] = StringReplace(StringReplace(product.obj_contributor_List[a].b047_productcontributor, "To Be Announced", ""), "tbd", "");

                dt_contributor.Rows.Add(dr);

            }

            #endregion



            return dt_contributor;


        }

        //public DataTable DigitalFormat_b333(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_DigitalFormat_b333, int MetaDataID, int productCount)
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


        public DataTable Bisac(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Bisac, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Bisac'

            for (int a = 0; a < product.obj_product_subject_List.Count; a++)
            {
                if (product.obj_product_subject_List[a].b067_product_subject == "10")
                {
                    DataRow dr = dt_Bisac.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (a + 1);
                    dr["Bisac_b067"] = product.obj_product_subject_List[a].b067_product_subject;
                    dr["Bisac_b069"] = product.obj_product_subject_List[a].b069_product_subject;

                    dt_Bisac.Rows.Add(dr);
                }
            }

            #endregion



            return dt_Bisac;


        }


        ////////public DataTable MainBisacBic(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_MainBisacBic, int MetaDataID, int productCount)
        ////////{
        ////////            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        ////////            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        ////////            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        ////////            #region 'Bisac'

        ////////            for (int a = 0; a < product.obj_product_mainsubject_List.Count; a++)
        ////////            {
        ////////                if (!string.IsNullOrEmpty(product.obj_product_mainsubject_List[a].b191_product_mainsubject.ToString()))
        ////////                {
        ////////                    if (product.obj_product_mainsubject_List[a].b191_product_mainsubject == "10")
        ////////                    {
        ////////                        DataRow dr = dt_MainBisacBic.NewRow();

        ////////                        dr["MetaDataID"] = MetaDataID;
        ////////                        dr["ProductID"] = productCount;
        ////////                        dr["RowCnt"] = (a + 1);
        ////////                        dr["Bisac_b191"] = product.obj_product_mainsubject_List[a].b191_product_mainsubject;
        ////////                        dr["Bisac_b069"] = product.obj_product_mainsubject_List[a].b070_product_mainsubject;

        ////////                        dt_MainBisacBic.Rows.Add(dr);
        ////////                    }
        ////////                }
        ////////            }

        ////////    #endregion



        ////////    return dt_MainBisacBic;


        ////////}
        public DataTable Bisac_b064(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Bisac_b064, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Bisac_b064'

            string Bisac = "";
            for (int a = 0; a < product.obj_b064_List.Count; a++)
            {


                if (product.obj_b064_List[a].ToString().Trim().Length > 0)
                {
                    DataRow dr = dt_Bisac_b064.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = 1;
                    dr["Bisac_b064"] = product.obj_b064_List[a].Trim();

                    dt_Bisac_b064.Rows.Add(dr);
                }
            }



            #endregion



            return dt_Bisac_b064;


        }
        //public DataTable Audience(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Audience, int MetaDataID, int productCount)
        //{
        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Audience'

        //    string Audience = "";
        //    for (int a = 0; a < product.obj_productaudience_List.Count; a++)
        //    {
        //        if (!string.IsNullOrEmpty(product.obj_productaudience_List[a].b204_product.ToString()))
        //        {
        //            if (Convert.ToInt32(product.obj_productaudience_List[a].b204_product.ToString()) == 1)
        //            {
        //                if (!string.IsNullOrEmpty(product.obj_productaudience_List[a].b206_product.ToString()))
        //                {

        //                    if (Convert.ToInt32(product.obj_productaudience_List[a].b206_product.ToString()) == 1)
        //                    {
        //                        Audience = "Adult";
        //                    }
        //                    else if (Convert.ToInt32(product.obj_productaudience_List[a].b206_product.ToString()) == 2 ||
        //                             Convert.ToInt32(product.obj_productaudience_List[a].b206_product.ToString()) == 3 ||
        //                             Convert.ToInt32(product.obj_productaudience_List[a].b206_product.ToString()) == 4)
        //                    {
        //                        Audience = "Children/YA";
        //                    }
        //                    else
        //                    {
        //                        Audience = "";
        //                    }

        //                    if (Audience.Length > 0)
        //                    {
        //                        DataRow dr = dt_Audience.NewRow();

        //                        dr["MetaDataID"] = MetaDataID;
        //                        dr["ProductID"] = productCount;
        //                        dr["RowCnt"] = (a + 1);
        //                        dr["Audience"] = Audience;

        //                        dt_Audience.Rows.Add(dr);
        //                    }

        //                }
        //            }
        //        }
        //    }



        //    #endregion



        //    return dt_Audience;


        //}




        public DataTable TotalRunTime(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_TotalRunTime, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'TotalRunTime'

            for (int a = 0; a < product.obj_extent_List.Count; a++)
            {

                if (!string.IsNullOrEmpty(product.obj_extent_List[a].b218_product_extent))
                {
                    if (product.obj_extent_List[a].b218_product_extent.Trim() == "09")
                    {

                        if (!string.IsNullOrEmpty(product.obj_extent_List[a].b219_product_extent))
                        {
                            DataRow dr = dt_TotalRunTime.NewRow();

                            dr["MetaDataID"] = MetaDataID;
                            dr["ProductID"] = productCount;
                            dr["RowCnt"] = (a + 1);
                            dr["TotalRunTimeCode_b218"] = product.obj_extent_List[a].b218_product_extent.ToString();
                            dr["TotalRunTime_b219"] = product.obj_extent_List[a].b219_product_extent.ToString();
                            dr["TotalRunTimeUnit_b220"] = product.obj_extent_List[a].b220_product_extent.ToString();

                            dt_TotalRunTime.Rows.Add(dr);

                        }

                    }
                }


            }

            #endregion

            return dt_TotalRunTime;


        }



        public DataTable AudienceCode_b073(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_AudienceCode_b073, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'AudienceCode_b073'

            for (int a = 0; a < product.obj_b073_List.Count; a++)
            {
                if (!string.IsNullOrEmpty(product.obj_b073_List[a]))
                {
                    if (product.obj_b073_List[a].Trim().Length > 0)
                    {
                        DataRow dr = dt_AudienceCode_b073.NewRow();

                        dr["MetaDataID"] = MetaDataID;
                        dr["ProductID"] = productCount;
                        dr["RowCnt"] = (a + 1);

                        string b073 = product.obj_b073_List[a];

                        if (b073 == "01" || b073 == "05" || b073 == "06" || b073 == "07" || b073 == "08" || b073 == "09")
                        {
                            dr["AudienceCode_b073"] = "Adult";
                        }
                        else if (b073 == "02")
                        {
                            dr["AudienceCode_b073"] = "Childrens";
                        }
                        else if (b073 == "03")
                        {
                            dr["AudienceCode_b073"] = "Young Adult";
                        }
                        else
                        {
                            dr["AudienceCode_b073"] = b073;
                        }

                        dt_AudienceCode_b073.Rows.Add(dr);



                        break;
                    }
                }
            }

            #endregion

            return dt_AudienceCode_b073;


        }

        public DataTable AudienceCode_b206(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_AudienceCode_b206, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'AudienceCode_b206'
            string audiencecode = "";

            for (int a = 0; a < product.obj_productaudience_List.Count; a++)
            {
                if (audiencecode.Length == 0)
                {
                    for (int b = 0; b < product.obj_productaudience_List[a].obj_b206_List.Count; b++)
                    {

                        if (product.obj_productaudience_List[a].obj_b206_List[b].Trim().Length > 0)
                        {
                            DataRow dr = dt_AudienceCode_b206.NewRow();

                            dr["MetaDataID"] = MetaDataID;
                            dr["ProductID"] = productCount;
                            dr["RowCnt"] = (a + 1);


                            string b206 = product.obj_productaudience_List[a].obj_b206_List[b].ToString();

                            if (b206 == "01" || b206 == "05" || b206 == "06" || b206 == "07" || b206 == "08" || b206 == "09")
                            {
                                dr["AudienceCode_b206"] = "Adult";
                            }
                            else if (b206 == "02")
                            {
                                dr["AudienceCode_b206"] = "Childrens";
                            }
                            else if (b206 == "03")
                            {
                                dr["AudienceCode_b206"] = "Young Adult";
                            }
                            else
                            {
                                dr["AudienceCode_b206"] = b206;
                            }


                            audiencecode = "value";


                            dt_AudienceCode_b206.Rows.Add(dr);

                            a = product.obj_productaudience_List.Count;

                            break;

                        }

                    }
                }
            }

            #endregion

            return dt_AudienceCode_b206;


        }

        public DataTable MinAge(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_MinAge, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'MinAge'

            string MinAge = "";
            for (int a = 0; a < product.obj_productaudiencerange_List.Count; a++)
            {
                if (!string.IsNullOrEmpty(product.obj_productaudiencerange_List[a].b074_product.ToString()))
                {
                    if (product.obj_productaudiencerange_List[a].b074_product.ToString() == "17")
                    {
                        // if b075 = 3 then get b076 value. if b075 = 3 not available then find b075 = 4 . if neither then no value.
                        for (int i = 0; i < product.obj_productaudiencerange_List[a].b075_product.Count; i++)
                        {
                            if (Convert.ToInt32(product.obj_productaudiencerange_List[a].b075_product[i].ToString()) == 3)
                            {
                                DataRow dr = dt_MinAge.NewRow();

                                dr["MetaDataID"] = MetaDataID;
                                dr["ProductID"] = productCount;
                                dr["RowCnt"] = (a + 1);
                                // dr["b074"] = Audience;
                                dr["b075"] = product.obj_productaudiencerange_List[a].b075_product[i].ToString();
                                dr["b076"] = product.obj_productaudiencerange_List[a].b076_product[i].ToString();

                                dt_MinAge.Rows.Add(dr);

                                // exit out of loop.
                                break;
                            }
                            //else if (Convert.ToInt32(product.obj_productaudiencerange_List[a].b075_product[i].ToString()) == 4)
                            //{
                            //    DataRow dr = dt_MinAge.NewRow();

                            //    dr["ProductID"] = productCount;
                            //    dr["RowCnt"] = (a + 1);
                            //    // dr["b074"] = Audience;
                            //    dr["b075"] = product.obj_productaudiencerange_List[a].b075_product[i].ToString();
                            //    dr["b076"] = product.obj_productaudiencerange_List[a].b076_product[i].ToString();

                            //    dt_MinAge.Rows.Add(dr);
                            //}


                        }
                    }
                }
            }
            #endregion

            return dt_MinAge;
        }


        public DataTable Series(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Series, int MetaDataID, int productCount)
        {

            //check if your using b203 or not

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Series'

            for (int a = 0; a < product.obj_product_series_List.Count; a++)
            {

                //if (product.obj_product_series_List[a].b018_product_series.Length > 0 || product.obj_product_series_List[a].b019_product_series.Length > 0)
                //if (product.obj_product_series_List[a].b019_product_series.Length > 0)
                //{
                //dr["ProductID"] = productCount;
                //dr["RowCnt"] = (a + 1);
                //dr["SeriesName_b018"] = ""; // product.obj_product_series_List[a].b018_product_series;
                //dr["SeriesNumber_b019"] = product.obj_product_series_List[a].b019_product_series;


                //for (int b = 0; b < product.obj_product_series_List[a].obj_product_series_title_List.Count; b++)
                //{


                if ((!string.IsNullOrEmpty(product.obj_product_series_List[a].b018_product_series))
                       // || (!string.IsNullOrEmpty(product.obj_product_series_List[a].obj_product_series_title_List[b].b203_product_series_title))
                       || (!string.IsNullOrEmpty(product.obj_product_series_List[a].b019_product_series))
                       )
                {


                    //if (product.obj_product_series_List[a].b018_product_series.Length > 0 ||
                    // //   product.obj_product_series_List[a].obj_product_series_title_List[b].b203_product_series_title.Length > 0 || 
                    //    (product.obj_product_series_List[a].b019_product_series.Length > 0))
                    //{
                    DataRow dr = dt_Series.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (a + 1);
                    dr["SeriesName_b018"] = product.obj_product_series_List[a].b018_product_series;
                    dr["SeriesNumber_b019"] = StringReplace(product.obj_product_series_List[a].b019_product_series, "No.", "");
                    dr["SeriesName_b203"] = ""; //product.obj_product_series_List[a].obj_product_series_title_List[b].b203_product_series_title;

                    dt_Series.Rows.Add(dr);

                }
                //}



                //}

            }
            #endregion



            return dt_Series;


        }
        public DataTable Status_b394(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Status_b394, int MetaDataID, int productCount)
        {


            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Status_b394'

            for (int a = 0; a < product.obj_b394_List.Count; a++)
            {

                DataRow dr = dt_Status_b394.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Status_b394"] = product.obj_b394_List[a];

                dt_Status_b394.Rows.Add(dr);

            }

            #endregion



            return dt_Status_b394;


        }
        public DataTable Status_j141(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_Status_j141, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'Status_j141'

            for (int a = 0; a < product.obj_product_supplydetail_List.Count; a++)
            {
                DataRow dr = dt_Status_j141.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["Status_j141"] = product.obj_product_supplydetail_List[a].j141_product_supplydetail;
                dr["Status_j396"] = product.obj_product_supplydetail_List[a].j396_product_supplydetail;


                dt_Status_j141.Rows.Add(dr);

            }

            #endregion


            return dt_Status_j141;


        }
        public DataTable SalesRights(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_SalesRights, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'SalesRights'

            for (int a = 0; a < product.obj_product_salesrights_List.Count; a++)
            {
                DataRow dr = dt_SalesRights.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["SalesRightsTypeCode_b089"] = product.obj_product_salesrights_List[a].b089_product_salesrights;
                dr["RightsCountry_b090"] = product.obj_product_salesrights_List[a].b090_product_salesrights;
                dr["RightsTerritory_b388"] = product.obj_product_salesrights_List[a].b388_product_salesrights;

                dt_SalesRights.Rows.Add(dr);


            }

            #endregion


            return dt_SalesRights;


        }
        public DataTable SalesRights_NotForSale(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_SalesRights_NotForSale, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'SalesRights'

            for (int a = 0; a < product.obj_notforsale_List.Count; a++)
            {
                for (int b = 0; b < product.obj_notforsale_List[a].obj_b090_List.Count; b++)
                {
                    DataRow dr = dt_SalesRights_NotForSale.NewRow();

                    dr["MetaDataID"] = MetaDataID;
                    dr["ProductID"] = productCount;
                    dr["RowCnt"] = (b + 1);
                    dr["NotForSale_b090"] = product.obj_notforsale_List[a].obj_b090_List[b].Replace(" ", "");

                    dt_SalesRights_NotForSale.Rows.Add(dr);
                }

            }
            #endregion

            return dt_SalesRights_NotForSale;


        }
        //public DataTable PageCount(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_SalesRights, int MetaDataID, int productCount)
        //{

        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'PageCount'

        //    for (int a = 0; a < product.obj_b061_List.Count; a++)
        //    {
        //        DataRow dr = dt_SalesRights.NewRow();

        //        dr["MetaDataID"] = MetaDataID;
        //        dr["ProductID"] = productCount;
        //        dr["RowCnt"] = (a + 1);
        //        dr["PageCount_b061"] = product.obj_b061_List[a];

        //        dt_SalesRights.Rows.Add(dr);

        //    }

        //    #endregion

        //    return dt_SalesRights;


        //}
        //public DataTable SalesRestriction(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_SalesRestriction, int MetaDataID, int productCount)
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
        public DataTable ReleaseDate_b003(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_ReleaseDate_b003, int MetaDataID, int productCount)
        {



            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ReleaseDate_b003'

            for (int a = 0; a < product.obj_b003_List.Count; a++)
            {
                DataRow dr = dt_ReleaseDate_b003.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["ReleaseDate_b003"] = product.obj_b003_List[a];

                dt_ReleaseDate_b003.Rows.Add(dr);
            }

            #endregion


            return dt_ReleaseDate_b003;


        }
        public DataTable ReleaseDate_j143(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_ReleaseDate_j143, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ReleaseDate_j143'

            for (int a = 0; a < product.obj_product_supplydetail_List.Count; a++)
            {
                DataRow dr = dt_ReleaseDate_j143.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["ReleaseDate_j143"] = product.obj_product_supplydetail_List[a].j143_product_supplydetail;

                dt_ReleaseDate_j143.Rows.Add(dr);
            }
            #endregion



            return dt_ReleaseDate_j143;


        }

        public DataTable EditionNumber_b057(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_EditionNumber_b057, int MetaDataID, int productCount)
        {
            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'EditionNumber_b057'

            for (int a = 0; a < product.obj_b057_List.Count; a++)
            {
                DataRow dr = dt_EditionNumber_b057.NewRow();

                dr["MetaDataID"] = MetaDataID;
                dr["ProductID"] = productCount;
                dr["RowCnt"] = (a + 1);
                dr["EditionNumber_b057"] = product.obj_b057_List[a];

                dt_EditionNumber_b057.Rows.Add(dr);

            }

            #endregion


            return dt_EditionNumber_b057;


        }
        public DataTable ProductFormCode_b012(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.product product, DataTable dt_ProductFormCode_b012, int MetaDataID, int productCount)
        {

            //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
            //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

            #region 'ProductFormCode_b012'

            for (int a = 0; a < product.obj_b012_List.Count; a++)
            {
                if (!string.IsNullOrEmpty(product.obj_b012_List[a]))
                {


                    string b012 = product.obj_b012_List[a];
                    if (b012 == "AJ")
                    {
                        DataRow dr = dt_ProductFormCode_b012.NewRow();

                        dr["MetaDataID"] = MetaDataID;
                        dr["ProductID"] = productCount;
                        dr["RowCnt"] = (a + 1);
                        dr["ProductFormCode_b012"] = "DownloadbleAudio";

                        dt_ProductFormCode_b012.Rows.Add(dr);

                    }
                    //else if (b012 == "AA")
                    //{
                    //    b012 = "Physical Audio CD"; 
                    //}
                    //else if (b012 == "AC")
                    //{
                    //    b012 = "Physical Audio CD";
                    //}
                    //else if (b012 == "AZ")
                    //{
                    //    b012 = "Physical Audio CD";
                    //}
                    //else if (b012 == "AK")
                    //{
                    //    b012 = "Playaway";
                    //}
                    //else 
                    //{

                    //}







                }
            }

            #endregion

            return dt_ProductFormCode_b012;


        }


        #endregion


        //public DataTable Publisher2(TitleInjestion.Onix_Definition.product product, DataTable dt_Publisher2, int productCount)
        //{


        //    //dr["FileName"] = fileinfo_1.obj_FileInfo_List[0].FileName_FileInfo;
        //    //dr["pubId"] = fileinfo_1.obj_FileInfo_List[0].PubID_FileInfo;
        //    //dr["FileType"] = fileinfo_1.obj_FileInfo_List[0].FileType_FileInfo;

        //    #region 'Publisher'
        //    for (int a = 0; a < product.obj_b081_List.Count; a++)
        //    {
        //        DataRow dr = dt_Publisher2.NewRow();

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






        //        public DataTable b211(TitleInjestion.Onix_Definition.product product, DataTable dt_b211, int productCount)
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
