using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail
    {
        [XmlElement("x314", IsNullable = true)]
        public string x314_product_descriptivedetail { get; set; }

        [XmlElement("b012", IsNullable = true)]
       public List<string> obj_b012_product_descriptivedetail_List = new List<string>();


        [XmlElement("b384", IsNullable = true)]
        public string b384_product_descriptivedetail { get; set; }

        [XmlElement("x317", IsNullable = true)]
        public List<string> obj_x317_product_descriptivedetail_List = new List<string>();

        [XmlElement("epubusageconstraint", IsNullable = true)]
        public List<product_descriptivedetail_epubusageconstraint> obj_productdescriptivedetail_epubusageconstraint_List = new List<product_descriptivedetail_epubusageconstraint>();

        [XmlElement("collection", IsNullable = true)]
        public List<product_descriptivedetail_collection> obj_productdescriptivedetail_collection_List = new List<product_descriptivedetail_collection>();
        
        [XmlElement("titledetail", IsNullable = true)]
        public List<product_descriptivedetail_titledetail> obj_product_descriptivedetail_titledetail_List = new List<product_descriptivedetail_titledetail>();

        [XmlElement("contributor", IsNullable = true)]
        public List<product_descriptivedetail_contributor> obj_product_descriptivedetail_contributor_List = new List<product_descriptivedetail_contributor>();

        [XmlElement("x419", IsNullable = true)]
        public List<string> obj_x419_product_descriptivedetail_List = new List<string>();

        [XmlElement("language", IsNullable = true)]
        public List<product_descriptivedetail_language> obj_product_descriptivedetail_language_List = new List<product_descriptivedetail_language>();

        [XmlElement("extent", IsNullable = true)]
        public List<product_descriptivedetail_extent> obj_product_descriptivedetail_extent_List = new List<product_descriptivedetail_extent>();

        [XmlElement("subject", IsNullable = true)]
        public List<product_descriptivedetail_subject> obj_product_descriptivedetail_subject_List = new List<product_descriptivedetail_subject>();
            
        [XmlElement("b073", IsNullable = true)]
        public string b073_product_descriptivedetail { get; set; }

        [XmlElement("audience", IsNullable = true)]
        public List<product_descriptivedetail_audience> obj_product_descriptivedetail_audience_List = new List<product_descriptivedetail_audience>();

        [XmlElement("audiencerange", IsNullable = true)]
        public List<product_descriptivedetail_audiencerange> obj_product_descriptivedetail_audiencerange_list = new List<product_descriptivedetail_audiencerange>();
        
    }
}
