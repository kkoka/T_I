using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_workidentifier
    {
        [XmlElement("b201", IsNullable = true)]
        public string b201_product_title { get; set; }

        [XmlElement("b233", IsNullable = true)]
        public string b233_product_title { get; set; }

        [XmlElement("b244", IsNullable = true)]
        public string b244_product_title { get; set; }


    }
}
