using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_title
    {
        [XmlElement("b027", IsNullable = true)]
        public string b027_product_title { get; set; }

        [XmlElement("b029", IsNullable = true)]
        public string b029_product_title { get; set; }

        [XmlElement("b030", IsNullable = true)]
        public string b030_product_title { get; set; }

        [XmlElement("b031", IsNullable = true)]
        public string b031_product_title { get; set; }

        [XmlElement("b202", IsNullable = true)]
        public string b202_product_title { get; set; }

        [XmlElement("b203", IsNullable = true)]
        public string b203_product_title { get; set; }

        [XmlElement("b276", IsNullable = true)]
        public string b276_product_title { get; set; }

    }
}
