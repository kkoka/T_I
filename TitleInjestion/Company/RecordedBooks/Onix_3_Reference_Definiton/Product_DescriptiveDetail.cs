using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail
    {

        [XmlElement("ProductComposition", IsNullable = true)]
        public string ProductComposition { get; set; }

        [XmlElement("ProductForm", IsNullable = true)]
        public string ProductForm { get; set; }

        [XmlElement("ProductFormDetail", IsNullable = true)]
        public string ProductFormDetail { get; set; }

        [XmlElement("ProductContentType", IsNullable = true)]
        public string ProductContentType { get; set; }

        [XmlElement("EpubTechnicalProtection", IsNullable = true)]
        public string EpubTechnicalProtection { get; set; }
        public List<string> obj_EpubTechnicalProtection_Product_DescriptiveDetail_List = new List<string>();

        [XmlElement("EpubUsageConstraint", IsNullable = true)]
        public List<Product_DescriptiveDetail_EpubUsageConstraint> obj_Product_DescriptiveDetail_EpubUsageConstraint_List = new List<Product_DescriptiveDetail_EpubUsageConstraint>();

        [XmlElement("Collection", IsNullable = true)]
        public List<Product_DescriptiveDetail_Collection> obj_Product_DescriptiveDetail_Collection_List = new List<Product_DescriptiveDetail_Collection>();


        [XmlElement("NoCollection", IsNullable = true)]
        public string NoCollection { get; set; }

        [XmlElement("NoEdition", IsNullable = true)]
        public string NoEdition { get; set; }

        [XmlElement("EditionType", IsNullable = true)]
        public List<string> obj_EditionType_Product_DescriptiveDetail_List = new List<string>();

        [XmlElement("TitleDetail", IsNullable = true)]
        public List<Product_DescriptiveDetail_TitleDetail> obj_Product_DescriptiveDetail_TitleDetail_List = new List<Product_DescriptiveDetail_TitleDetail>();

        [XmlElement("Contributor", IsNullable = true)]
        public List<Product_DescriptiveDetail_Contributor> obj_Product_DescriptiveDetail_Contributor_List = new List<Product_DescriptiveDetail_Contributor>();


        [XmlElement("Language", IsNullable = true)]
        public List<Product_DescriptiveDetail_Language> obj_Product_DescriptiveDetail_Language_List = new List<Product_DescriptiveDetail_Language>();

        [XmlElement("Extent", IsNullable = true)]
        public List<Product_DescriptiveDetail_Extent> obj_Product_DescriptiveDetail_Extent_List = new List<Product_DescriptiveDetail_Extent>();

        [XmlElement("Subject", IsNullable = true)]
        public List<Product_DescriptiveDetail_Subject> obj_Product_DescriptiveDetail_Subject_List = new List<Product_DescriptiveDetail_Subject>();

        [XmlElement("AudienceCode", IsNullable = true)]
        public List<string> obj_Product_DescriptiveDetail_AudienceCode_List = new List<string>();



        [XmlElement("AudienceRange", IsNullable = true)]
        public List<Product_DescriptiveDetail_AudienceRange> obj_Product_DescriptiveDetail_AudienceRange_List = new List<Product_DescriptiveDetail_AudienceRange>();

        [XmlElement("ReligiousText", IsNullable = true)]
        public List<Product_DescriptiveDetail_ReligiousText> obj_Product_DescriptiveDetail_ReligiousText_List = new List<Product_DescriptiveDetail_ReligiousText>();

      

        



    }
}
