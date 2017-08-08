using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_relatedproduct
    {
        [XmlElement("b012", IsNullable = true)]
        public string b012_product_relatedproduct { get; set; }
     
        [XmlElement("b211", IsNullable = true)]
        public string b211_product_relatedproduct { get; set; }
    
        [XmlElement("b333", IsNullable = true)]
        public string b333_product_relatedproduct { get; set; }
    
        [XmlElement("h208", IsNullable = true)]
        public string h208_product_relatedproduct { get; set; }

        [XmlElement("productidentifier", IsNullable = true)]
        public List<product_relatedproduct_productidentifier> obj_product_relatedproduct_productidentifier_List = new List<product_relatedproduct_productidentifier>();
       
        [XmlElement("publisher", IsNullable = true)]
        public List<product_relatedproduct_publisher> obj_product_relatedproduct_publisher_List = new List<product_relatedproduct_publisher>();
	  
     
    }
}
