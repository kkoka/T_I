using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product
    {
        [XmlElement("a001", IsNullable = true)]
        public string a001 { get; set; }

        [XmlElement("a002", IsNullable = true)]
        public string a002 { get; set; }

        [XmlElement("Audience", IsNullable = true)]
        public List<Product_Audience> obj_ProductAudience_List = new List<Product_Audience>();

        [XmlElement("AudienceCode", IsNullable = true)]
        public string AudienceCode { get; set; }

        [XmlElement("AudienceRange", IsNullable = true)]
        public List<Product_AudienceRange> obj_productaudiencerange_List = new List<Product_AudienceRange>();

        [XmlElement("Barcode", IsNullable = true)]
        public string Barcode { get; set; }

        [XmlElement("BASICMainSubject", IsNullable = true)]
        public List<string> obj_BASICMainSubject_List = new List<string>();

        [XmlElement("BASICVersion", IsNullable = true)]
        public string BASICVersion { get; set; }

        [XmlElement("BICMainSubject", IsNullable = true)]
        public List<string> obj_BICMainSubject_List = new List<string>();

        [XmlElement("BICVersion", IsNullable = true)]
        public string BICVersion { get; set; }

        [XmlElement("CityOfPublication", IsNullable = true)]
        public string CityOfPublication { get; set; }

        [XmlElement("Contributor", IsNullable = true)]
        public List<Product_Contributor> obj_productContributor_List = new List<Product_Contributor>();



        [XmlElement("ContributorStatement", IsNullable = true)]
        public string ContributorStatement { get; set; }


        [XmlElement("CopyrightYear", IsNullable = true)]
        public string CopyrightYear { get; set; }


        [XmlElement("CountryOfPublication", IsNullable = true)]
        public string CountryOfPublication { get; set; }


        [XmlElement("EditionNumber", IsNullable = true)]
        public List<string> obj_EditionNumber_List = new List<string>();


        [XmlElement("EditionTypeCode", IsNullable = true)]
        public List<string> obj_EditionTypeCode_List = new List<string>();



        [XmlElement("EditionStatement", IsNullable = true)]
        public string EditionStatement { get; set; }


        [XmlElement("EpubFormat", IsNullable = true)]
        public string EpubFormat { get; set; }


        [XmlElement("EpubType", IsNullable = true)]
        public string EpubType { get; set; }


        [XmlElement("EpubTypeDescription", IsNullable = true)]
        public string EpubTypeDescription { get; set; }


        [XmlElement("EpubTypeNote", IsNullable = true)]
        public string EpubTypeNote { get; set; }


        [XmlElement("IllustrationsNote", IsNullable = true)]
        public string IllustrationsNote { get; set; }

        [XmlElement("Illustrations", IsNullable = true)]
        public List<Product_Illustrations> obj_ProductIllustrations_List = new List<Product_Illustrations>();

        [XmlElement("Imprint", IsNullable = true)]
        public List<Product_Imprint> obj_ProductImprint_List = new List<Product_Imprint>();

        [XmlElement("InterestAge", IsNullable = true)]
        public string InterestAge { get; set; }

        [XmlElement("Language", IsNullable = true)]
        public List<Product_Language> obj_ProductLanguage_List = new List<Product_Language>();

        [XmlElement("MainSubject", IsNullable = true)]
        public List<Product_MainSubject> obj_ProductMainSubject_List = new List<Product_MainSubject>();

        [XmlElement("MarketRepresentation", IsNullable = true)]
        public List<Product_MarketRepresentation> obj_ProductMarketRepresentation_List = new List<Product_MarketRepresentation>();

        [XmlElement("Measure", IsNullable = true)]
        public List<Product_Measure> obj_ProductMeasure_List = new List<Product_Measure>();

        [XmlElement("MediaFile", IsNullable = true)]
        public List<Product_MediaFile> obj_ProductMediaFile_List = new List<Product_MediaFile>();

        [XmlElement("NoEdition", IsNullable = true)]
        public string NoEdition { get; set; }

        [XmlElement("NoSeries", IsNullable = true)]
        public string NoSeries { get; set; }

        [XmlElement("NumberOfPages", IsNullable = true)]
        public List<string> obj_NumberOfPages_List = new List<string>();

        [XmlElement("NumberOfPieces", IsNullable = true)]
        public string NumberOfPieces { get; set; }

        [XmlElement("OtherText", IsNullable = true)]
        public List<Product_OtherText> obj_ProductOtherText_List = new List<Product_OtherText>();

        [XmlElement("OutOfPrintDate", IsNullable = true)]
        public string OutOfPrintDate { get; set; }

        [XmlElement("Prize", IsNullable = true)]
        public List<Product_Prize> obj_ProductPrize_List = new List<Product_Prize>();

        [XmlElement("ProductClassification", IsNullable = true)]
        public List<Product_ProductClassification> obj_ProductProductClassification_List = new List<Product_ProductClassification>();

        [XmlElement("ProductContentType", IsNullable = true)]
        public List<string> obj_ProductContentType_List = new List<string>();


        [XmlElement("ProductForm", IsNullable = true)]
        public List<string> obj_ProductForm_List = new List<string>();


        [XmlElement("ProductFormDetail", IsNullable = true)]
        public List<string> obj_ProductFormDetail_List = new List<string>();

        [XmlElement("ProductIdentifier", IsNullable = true)]
        public List<Product_ProductIdentifier> obj_ProductProductIdentifier_List = new List<Product_ProductIdentifier>();

        [XmlElement("ProductWebsite", IsNullable = true)]
        public List<Product_ProductWebsite> obj_ProductProductWebsite_List = new List<Product_ProductWebsite>();

        [XmlElement("PublicationDate", IsNullable = true)]
        public List<string> obj_PublicationDate_List = new List<string>();


        [XmlElement("Publisher", IsNullable = true)]
        public List<Product_Publisher> obj_ProductPublisher_List = new List<Product_Publisher>();


        [XmlElement("PublishingStatus", IsNullable = true)]
        public List<string> obj_PublishingStatus_List = new List<string>();


        [XmlElement("PublishingStatusNote", IsNullable = true)]
        public string PublishingStatusNote { get; set; }


        [XmlElement("RelatedProduct", IsNullable = true)]
        public List<Product_RelatedProduct> obj_ProductRelatedProduct_List = new List<Product_RelatedProduct>();

        [XmlElement("SalesRestriction", IsNullable = true)]
        public List<Product_SalesRestriction> obj_ProductSalesRestriction_List = new List<Product_SalesRestriction>();

        [XmlElement("SalesRights", IsNullable = true)]
        public List<Product_SalesRights> obj_ProductSalesRights_List = new List<Product_SalesRights>();

        [XmlElement("Series", IsNullable = true)]
        public List<Product_Series> obj_ProductSeries_List = new List<Product_Series>();

        [XmlElement("Set", IsNullable = true)]
        public List<Product_Set> obj_ProductSet_List = new List<Product_Set>();

        [XmlElement("Subject", IsNullable = true)]
        public List<Product_Subject> obj_ProductSubject_List = new List<Product_Subject>();

        [XmlElement("SupplyDetail", IsNullable = true)]
        public List<Product_SupplyDetail> obj_ProductSupplyDetail_List = new List<Product_SupplyDetail>();

        [XmlElement("Title", IsNullable = true)]
        public List<Product_Title> obj_ProductTitle_List = new List<Product_Title>();


        [XmlElement("USSchoolGrade", IsNullable = true)]
        public string USSchoolGrade { get; set; }

        [XmlElement("Website", IsNullable = true)]
        public List<Product_Website> obj_ProductWebsite_List = new List<Product_Website>();

        [XmlElement("WorkIdentifier", IsNullable = true)]
        public List<Product_WorkIdentifier> obj_ProductWorkIdentifier_List = new List<Product_WorkIdentifier>();

        [XmlElement("YearFirstPublished", IsNullable = true)]
        public string YearFirstPublished { get; set; }

    }
}
