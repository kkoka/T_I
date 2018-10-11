using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Extent
    {
        [XmlElement("ExtentType", IsNullable = true)]
        public string ExtentType_Product_Extent { get; set; }

        [XmlElement("ExtentValue", IsNullable = true)]
        public string ExtentValue_Product_Extent { get; set; }

        [XmlElement("ExtentUnit", IsNullable = true)]
        public string ExtentUnit_Product_Extent { get; set; }
    }
}
