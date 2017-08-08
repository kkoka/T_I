using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_subject
    {
        [XmlElement("x425", IsNullable = true)]
        public string x425 { get; set; }
		 
        [XmlElement("b067", IsNullable = true)]
        public string b067 { get; set; }
	
        [XmlElement("b069", IsNullable = true)]
        public string b069 { get; set; }

    }
}
