using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_contributor
    {
        [XmlElement("b034", IsNullable = true)]
        public string b034 { get; set; }

        [XmlElement("b035", IsNullable = true)]
        public string b035 { get; set; }
    
		[XmlElement("b036", IsNullable = true)]
        public string b036 { get; set; }

     
		[XmlElement("b037", IsNullable = true)]
        public string b037 { get; set; }

        [XmlElement("b038", IsNullable = true)]
        public string b038 { get; set; }


        [XmlElement("b039", IsNullable = true)]
        public string b039 { get; set; }

     
		[XmlElement("b040", IsNullable = true)]
        public string b040 { get; set; }

     
		[XmlElement("b044", IsNullable = true)]
        public string b044 { get; set; }

        [XmlElement("b047", IsNullable = true)]
        public string b047 { get; set; }


        
    }
}
