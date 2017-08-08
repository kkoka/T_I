using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_WorkIdentifier
    {
        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue_ProductWorkIdentifier { get; set; }

        [XmlElement("WorkIDType", IsNullable = true)]
        public string WorkIDType_ProductWorkIdentifier { get; set; }
                 
    }
}
