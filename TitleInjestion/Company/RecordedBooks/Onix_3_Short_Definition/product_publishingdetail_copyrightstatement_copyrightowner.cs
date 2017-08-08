using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_publishingdetail_copyrightstatement_copyrightowner
    {
        
     [XmlElement("b047", IsNullable = true)]
        public string b047 { get; set; }

    }
}
