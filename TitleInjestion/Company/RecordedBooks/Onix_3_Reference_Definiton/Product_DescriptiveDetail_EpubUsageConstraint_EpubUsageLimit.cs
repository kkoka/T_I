using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_DescriptiveDetail_EpubUsageConstraint_EpubUsageLimit
    {
        [XmlElement("Quantity", IsNullable = true)]
        public string Quantity { get; set; }

        [XmlElement("EpubUsageUnit", IsNullable = true)]
        public string EpubUsageUnit { get; set; }
        
    }
}
