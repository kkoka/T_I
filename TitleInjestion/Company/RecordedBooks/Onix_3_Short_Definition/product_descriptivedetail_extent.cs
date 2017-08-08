using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;



namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_extent
    {
       [XmlElement("b218", IsNullable = true)]
        public string b218 { get; set; }

        [XmlElement("b219", IsNullable = true)]
        public string b219 { get; set; }

        [XmlElement("b220", IsNullable = true)]
        public string b220 { get; set; }


    }
}
