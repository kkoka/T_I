using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;



namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_titledetail_titleelement
    {
       [XmlElement("b034", IsNullable = true)]
        public string b034 { get; set; }

	    [XmlElement("x409", IsNullable = true)]
        public string x409 { get; set; }

	     [XmlElement("b203", IsNullable = true)]
        public string b203 { get; set; }

	   [XmlElement("b029", IsNullable = true)]
        public string b029 { get; set; }

        [XmlElement("b030", IsNullable = true)]
        public string b030 { get; set; }

        [XmlElement("b031", IsNullable = true)]
        public string b031 { get; set; }

    }
}
