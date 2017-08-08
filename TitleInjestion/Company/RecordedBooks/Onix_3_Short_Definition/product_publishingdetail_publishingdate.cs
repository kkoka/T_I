using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
   public class product_publishingdetail_publishingdate
    {
        [XmlElement("x448", IsNullable = true)]
        public string x448 { get; set; }
	
        [XmlElement("b306", IsNullable = true)]
        public string b306 { get; set; }

    }
}
