using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_relatedproduct_publisher
    {
        [XmlElement("b081", IsNullable = true)]
        public string b081_product_relatedproduct_publisher { get; set; }

        [XmlElement("b291", IsNullable = true)]
        public string b291_product_relatedproduct_publisher { get; set; }

        [XmlElement("website", IsNullable = true)]
        public List<product_relatedproduct_publisher_website> obj_product_othertext_List = new List<product_relatedproduct_publisher_website>();

    }
}
