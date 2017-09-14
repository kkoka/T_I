using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_PublishingDetail_Imprint_ImprintIdentifier
    {
        [XmlElement("IDTypeName", IsNullable = true)]
        public string IDTypeName { get; set; }


        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue { get; set; }

        [XmlElement("ImprintIDType", IsNullable = true)]
        public string ImprintIDType { get; set; }

    }
}
