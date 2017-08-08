using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_collection
    {
        [XmlElement("x329", IsNullable = true)]
        public string x329_product_descriptivedetail_collection { get; set; }

        [XmlElement("collectionsequence", IsNullable = true)]
        public List<product_descriptivedetail_collection_collectionsequence> obj_product_descriptivedetail_collection_collectionsequence_List = new List<product_descriptivedetail_collection_collectionsequence>();
        
        [XmlElement("titledetail", IsNullable = true)]
        public List<product_descriptivedetail_collection_titledetail> obj_product_descriptivedetail_collection_titledetail_List = new List<product_descriptivedetail_collection_titledetail>();

      

    }
}
