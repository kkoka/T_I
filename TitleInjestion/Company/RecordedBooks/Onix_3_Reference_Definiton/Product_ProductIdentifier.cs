using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_ProductIdentifier
    {
        [XmlElement("ProductIDType", IsNullable = true)]
        public string ProductIDType { get; set; }

        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue { get; set; }

     

    }
}
