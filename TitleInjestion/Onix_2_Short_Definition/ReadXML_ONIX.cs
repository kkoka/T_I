using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using System.Xml.XPath;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace TitleInjestion.Onix_2_Short_Definition
{
    class ReadXML_ONIX
    {
        public void ReadXML()
        {

            // Create an instance of Camera class.
            ONIXmessage fileInfo_1 = new ONIXmessage();

            // Create an instance of stream writer.
            TextReader txtReader = new StreamReader(@"C:\Users\Kkoka\Desktop\Refactor_TM\Onix_Harlequin_ebook_onix21.xml");

            // Create and instance of XmlSerializer class.
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ONIXmessage));


            // DeSerialize from the StreamReader
            fileInfo_1 = (ONIXmessage)xmlSerializer.Deserialize(txtReader);


            // Close the stream reader
            txtReader.Close();

            Process_Harlequin(fileInfo_1);

        }
        
        public void Process_Harlequin(ONIXmessage fileInfo_1)
        {
            DataTable dt_Harlequin = new DataTable();

            #region 'Columns'

            dt_Harlequin.Columns.Add("FileName", typeof(string));
            dt_Harlequin.Columns.Add("pubId", typeof(string));
            dt_Harlequin.Columns.Add("FileType", typeof(string));

            dt_Harlequin.Columns.Add("b221", typeof(string));
            dt_Harlequin.Columns.Add("ISBN_b244", typeof(string));
           
            dt_Harlequin.Columns.Add("PublisherName_b081", typeof(string));
            dt_Harlequin.Columns.Add("PublisherName_2_b081", typeof(string));

            dt_Harlequin.Columns.Add("EbookVersion_b014", typeof(string));
           
            dt_Harlequin.Columns.Add("TitleType_b202", typeof(string));
            dt_Harlequin.Columns.Add("Title_b203", typeof(string));
            
            dt_Harlequin.Columns.Add("SubTitle_b029", typeof(string));
            
            dt_Harlequin.Columns.Add("UnAbridged_b056", typeof(string));
              
            
            dt_Harlequin.Columns.Add("LanguageCode_b252", typeof(string));
           
            dt_Harlequin.Columns.Add("BISAC_b064", typeof(string));
            dt_Harlequin.Columns.Add("Bisac_Pubspecific_b069", typeof(string));
            dt_Harlequin.Columns.Add("BISAC_b070", typeof(string));
           
           
            dt_Harlequin.Columns.Add("ReleaseDate1_b003", typeof(string));
            dt_Harlequin.Columns.Add("ReleaseDate2_j143", typeof(string));

            
              
            dt_Harlequin.Columns.Add("PriceType_j148", typeof(string));
            dt_Harlequin.Columns.Add("LibraryPrice_j151", typeof(string));
            dt_Harlequin.Columns.Add("j261", typeof(string));
            dt_Harlequin.Columns.Add("CurrencyCode_j152", typeof(string));
           
            dt_Harlequin.Columns.Add("ContributorSequenceNumber_b034", typeof(string));
            dt_Harlequin.Columns.Add("Authors_Narrators_Code_b035", typeof(string));
            dt_Harlequin.Columns.Add("Author_Narrators_Name_b036", typeof(string));
            dt_Harlequin.Columns.Add("CorporateAuthors_b047", typeof(string));
            dt_Harlequin.Columns.Add("LNF_b037", typeof(string));
            dt_Harlequin.Columns.Add("FNF_b036", typeof(string));
            dt_Harlequin.Columns.Add("Author_Narrators_Prefix_b038", typeof(string));
            dt_Harlequin.Columns.Add("Authors_Narrators_FirstName_b039", typeof(string));
            dt_Harlequin.Columns.Add("Authors_Narrators_LastName_b040", typeof(string));


              
            dt_Harlequin.Columns.Add("ProductFormCode_b012", typeof(string));
                
            dt_Harlequin.Columns.Add("DescriptionType_d102", typeof(string));
            dt_Harlequin.Columns.Add("TextFormat_d103", typeof(string));
            dt_Harlequin.Columns.Add("Description_d104", typeof(string));
            dt_Harlequin.Columns.Add("Description_d101", typeof(string));
           
            dt_Harlequin.Columns.Add("Subject_b070", typeof(string));
            dt_Harlequin.Columns.Add("AudibleWma_b333", typeof(string));
           
            dt_Harlequin.Columns.Add("Status_b394", typeof(string));
            dt_Harlequin.Columns.Add("status_j141", typeof(string));
            dt_Harlequin.Columns.Add("Status_j396", typeof(string));
            
           
            dt_Harlequin.Columns.Add("SeriesName_b018", typeof(string));
            dt_Harlequin.Columns.Add("SeriesNumber_b019", typeof(string));
            dt_Harlequin.Columns.Add("SeriesName_b203", typeof(string));
           
            dt_Harlequin.Columns.Add("imprintname_b079", typeof(string));
            
            dt_Harlequin.Columns.Add("SalesRightsTypeCode_b089", typeof(string));
            dt_Harlequin.Columns.Add("RightsCountry_b090", typeof(string));
            dt_Harlequin.Columns.Add("RightsTerritory_b388", typeof(string));
            dt_Harlequin.Columns.Add("PageCount_b061", typeof(string));

            
            dt_Harlequin.Columns.Add("NotForSale", typeof(string));
            dt_Harlequin.Columns.Add("onix_Version", typeof(string));
            dt_Harlequin.Columns.Add("b211", typeof(string));
            dt_Harlequin.Columns.Add("EditionNumber_b057", typeof(string));
            dt_Harlequin.Columns.Add("ClassTrade_j149", typeof(string));
            dt_Harlequin.Columns.Add("CountryCode_b251", typeof(string));
        
            dt_Harlequin.Columns.Add("BISAC_b067", typeof(string));
            dt_Harlequin.Columns.Add("Bisac_pubspecific2_b191", typeof(string));
            dt_Harlequin.Columns.Add("Bisac_pubspecific2_b069", typeof(string));
            dt_Harlequin.Columns.Add("DigitalFormat_b213", typeof(string));
           
            #endregion

            DataRow dr = dt_Harlequin.NewRow();

            
            
            dr["FileName"] =  fileInfo_1.obj_FileInfo_List[0].FileName_FileInfo;
            dr["pubId"] = fileInfo_1.obj_FileInfo_List[0].PubID_FileInfo; 
            dr["FileType"] = fileInfo_1.obj_FileInfo_List[0].FileType_FileInfo;
  
            dt_Harlequin.Rows.Add(dr);








            #region 'Unwanted'
            //dt_Harlequin.Columns.Add("UniquePubIdentifier_a001", typeof(string));
            //dt_Harlequin.Columns.Add("NotificationType_a002", typeof(string));
            //dt_Harlequin.Columns.Add("TitlePrefix_b030", typeof(string));
             //dt_Harlequin.Columns.Add("TitleWithoutPrefix_b031", typeof(string));
             //dt_Harlequin.Columns.Add("UnAbridged_2_b056", typeof(string));
             //dt_Harlequin.Columns.Add("ReleaseDate3_j161", typeof(string));
             //dt_Harlequin.Columns.Add("PriceQualifier", typeof(string));
             //dt_Harlequin.Columns.Add("b064_rank", typeof(string));
             //dt_Harlequin.Columns.Add("b069_rank", typeof(string));
             //dt_Harlequin.Columns.Add("b070_rank", typeof(string));
             //dt_Harlequin.Columns.Add("parent_publishername", typeof(string));
             //dt_Harlequin.Columns.Add("LibraryPrice_j151_CAD", typeof(string));
             //dt_Harlequin.Columns.Add("RetailPrice", typeof(string));
             //dt_Harlequin.Columns.Add("ContributorSequenceWithinRole_b340", typeof(string));
          
            #endregion


            #region 'Commented'
            //dt_Harlequin.Columns.Add("AgeGroup_b073", typeof(string));
            //dt_Harlequin.Columns.Add("Genre", typeof(string));
            //dt_Harlequin.Columns.Add("Fiction", typeof(string));
            //dt_Harlequin.Columns.Add("Children", typeof(string));
            //dt_Harlequin.Columns.Add("PrintBookPubDate", typeof(string));
            //dt_Harlequin.Columns.Add("PersonNameType_b250", typeof(string));
            //dt_Harlequin.Columns.Add("UnknownAnonymous_b249", typeof(string));
            //dt_Harlequin.Columns.Add("n339", typeof(string));
            //dt_Harlequin.Columns.Add("CDCount_b210", typeof(string));
            //dt_Harlequin.Columns.Add("IsExclusive_Flag", typeof(string));
            //dt_Harlequin.Columns.Add("Royalty_Flag", typeof(string));
            //dt_Harlequin.Columns.Add("IsMARC_Flag", typeof(string));

            //dt_Harlequin.Columns.Add("TotalRunTime_Code_b218", typeof(string));
            //dt_Harlequin.Columns.Add("TotalRunTime_b219", typeof(string));
            //dt_Harlequin.Columns.Add("TotalRunTime_Unit_b220", typeof(string));
            //dt_Harlequin.Columns.Add("InsertedOn", typeof(string));

            // dt_Harlequin.Columns.Add("SeriesName_b233", typeof(string));
            //dt_Harlequin.Columns.Add("SeriesPositionNumber", typeof(string));
            //dt_Harlequin.Columns.Add("SeriesTotalNumber", typeof(string));
            //dt_Harlequin.Columns.Add("SeriesID_b273", typeof(string));
            //dt_Harlequin.Columns.Add("DistributionTerritory", typeof(string));
            //dt_Harlequin.Columns.Add("BeginRightsDate", typeof(string));
            //dt_Harlequin.Columns.Add("EndRightsDate", typeof(string));
            //dt_Harlequin.Columns.Add("MetadataType", typeof(string));

            //dt_Harlequin.Columns.Add("ChapterCount", typeof(string));
            //  dt_Harlequin.Columns.Add("Notes", typeof(string));
            //  dt_Harlequin.Columns.Add("LibraryAccountID", typeof(string));
            //  dt_Harlequin.Columns.Add("SKUNumber", typeof(string));
            //  dt_Harlequin.Columns.Add("Awards", typeof(string));
            //  dt_Harlequin.Columns.Add("ReligiousText_Bible", typeof(string));

            //     dt_Harlequin.Columns.Add("AbstractText", typeof(string));
            //dt_Harlequin.Columns.Add("Epilogue", typeof(string));
            //dt_Harlequin.Columns.Add("ContentRating", typeof(string));
            //dt_Harlequin.Columns.Add("Imprints", typeof(string));
            //dt_Harlequin.Columns.Add("OriginalLanguage", typeof(string));
            //dt_Harlequin.Columns.Add("Keywords", typeof(string));
            //dt_Harlequin.Columns.Add("TargetAudience", typeof(string));
            //dt_Harlequin.Columns.Add("MediaFormat", typeof(string));
            //dt_Harlequin.Columns.Add("MediaQuality", typeof(string));
            //dt_Harlequin.Columns.Add("Review", typeof(string));
            //dt_Harlequin.Columns.Add("IsSingleUse", typeof(string));
            //dt_Harlequin.Columns.Add("IsMultiUse", typeof(string));
            //dt_Harlequin.Columns.Add("IsActive", typeof(string));
            //dt_Harlequin.Columns.Add("IsRenewed", typeof(string));
            //dt_Harlequin.Columns.Add("IsDownloadable", typeof(string));
            //dt_Harlequin.Columns.Add("IsTransferableRetail", typeof(string));
            //dt_Harlequin.Columns.Add("ISBurnableRetail", typeof(string));
            //dt_Harlequin.Columns.Add("IsTransferableLibrary", typeof(string));
            //dt_Harlequin.Columns.Add("IsBurnableLibrary", typeof(string));
            //dt_Harlequin.Columns.Add("MarcFileContent", typeof(string));
            //dt_Harlequin.Columns.Add("MarcTagValueText", typeof(string));
            //dt_Harlequin.Columns.Add("Agent", typeof(string));
            //dt_Harlequin.Columns.Add("BookCopyright", typeof(string));
            //dt_Harlequin.Columns.Add("RecordingCopyright", typeof(string));
            //dt_Harlequin.Columns.Add("CreationDate", typeof(string));
            //dt_Harlequin.Columns.Add("CreatedBy", typeof(string));

            //dt_Harlequin.Columns.Add("LastModified", typeof(string));
            //dt_Harlequin.Columns.Add("FilePath", typeof(string));
            //dt_Harlequin.Columns.Add("ReviewComments", typeof(string));
            //dt_Harlequin.Columns.Add("TL_Subject", typeof(string));
            //dt_Harlequin.Columns.Add("TL_DRM_Type", typeof(string));
            //dt_Harlequin.Columns.Add("TL_TitleMain", typeof(string));
            //dt_Harlequin.Columns.Add("TL_TitlePrefix", typeof(string));
            //dt_Harlequin.Columns.Add("TL_MediaType", typeof(string));
            //dt_Harlequin.Columns.Add("Audio_Exist_Flag", typeof(string));
            //dt_Harlequin.Columns.Add("TitleID", typeof(string));
            //dt_Harlequin.Columns.Add("isRuntimeProcessed", typeof(string));
            //dt_Harlequin.Columns.Add("AudioBook_x416", typeof(string));
            //dt_Harlequin.Columns.Add("AudioBook_b385", typeof(string));
            //dt_Harlequin.Columns.Add("EpubType_b211", typeof(string));
            //dt_Harlequin.Columns.Add("DRMFlag_x317", typeof(string));
            //dt_Harlequin.Columns.Add("UsageType_x318", typeof(string));
            //dt_Harlequin.Columns.Add("UsageStatus_x319", typeof(string));
            //dt_Harlequin.Columns.Add("UsageQuantity_x320", typeof(string));
            //dt_Harlequin.Columns.Add("CreatedBy", typeof(string));
            //dt_Harlequin.Columns.Add("UsageUnit_b321", typeof(string));
            //dt_Harlequin.Columns.Add("Series_TitleElementLevel", typeof(string));
            //dt_Harlequin.Columns.Add("Title_TitleElementLevel", typeof(string));
            //dt_Harlequin.Columns.Add("TitleSuffix", typeof(string));
            //dt_Harlequin.Columns.Add("ROWSalesRightsType_referencecode", typeof(string));
            //dt_Harlequin.Columns.Add("SalesRestriction_b383", typeof(string));
          
            #endregion





        }

    }
}
