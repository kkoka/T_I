using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_publisher
    {
        [XmlElement("b081", IsNullable = true)]
        public string b081_product_publisher { get; set; }

        [XmlElement("b241", IsNullable = true)]
        public string b241_product_publisher { get; set; }

        [XmlElement("b242", IsNullable = true)]
        public string b242_product_publisher { get; set; }

        [XmlElement("b243", IsNullable = true)]
        public string b243_product_publisher { get; set; }

        [XmlElement("b291", IsNullable = true)]
        public string b291_product_publisher { get; set; }

        [XmlElement("website", IsNullable = true)]
        public List<product_publisher_website> obj_product_othertext_List = new List<product_publisher_website>();
	  

    }
}
