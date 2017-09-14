using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_DescriptiveDetail_Extent
    {
        [XmlElement("ExtentType", IsNullable = true)]
        public string ExtentType { get; set; }


        [XmlElement("ExtentUnit", IsNullable = true)]
        public string ExtentUnit { get; set; }

        [XmlElement("ExtentValue", IsNullable = true)]
        public string ExtentValue { get; set; }

    }
}
