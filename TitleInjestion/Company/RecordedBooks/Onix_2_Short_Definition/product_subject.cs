using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_subject
    {
        [XmlElement("b067", IsNullable = true)]
        public string b067_product_subject { get; set; }

        [XmlElement("b068", IsNullable = true)]
        public string b068_product_subject { get; set; }
       
        [XmlElement("b069", IsNullable = true)]
        public string b069_product_subject { get; set; }

        [XmlElement("b070", IsNullable = true)]
        public string b070_product_subject { get; set; }

        [XmlElement("b171", IsNullable = true)]
        public string b171_product_subject { get; set; }

    }
}
