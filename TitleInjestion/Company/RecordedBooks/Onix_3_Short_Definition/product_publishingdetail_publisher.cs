using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_publishingdetail_publisher
    {
        [XmlElement("b291", IsNullable = true)]
        public string b291 { get; set; }

       	[XmlElement("b081", IsNullable = true)]
        public string b081 { get; set; }


    }
}
