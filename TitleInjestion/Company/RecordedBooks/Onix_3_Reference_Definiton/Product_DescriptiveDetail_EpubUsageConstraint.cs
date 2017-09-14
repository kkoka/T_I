using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail_EpubUsageConstraint
    {
        [XmlElement("EpubUsageType", IsNullable = true)]
        public string EpubUsageType { get; set; }

        [XmlElement("EpubUsageStatus", IsNullable = true)]
        public string EpubUsageStatus { get; set; }

        [XmlElement("EpubUsageLimit", IsNullable = true)]
        public List<Product_DescriptiveDetail_EpubUsageConstraint_EpubUsageLimit> obj_EpubUsageLimit_List = new List<Product_DescriptiveDetail_EpubUsageConstraint_EpubUsageLimit>();

 



    }
}
