using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_PublishingDetail_Imprint
    {
        
        [XmlElement("ImprintName", IsNullable = true)]
        public string ImprintName { get; set; }

        [XmlElement("ImprintIdentifier", IsNullable = true)]
        public List<Product_PublishingDetail_Imprint_ImprintIdentifier> obj_Product_DescriptiveDetail_PublishingDetail_Imprint_ImprintIdentifier_List = new List<Product_PublishingDetail_Imprint_ImprintIdentifier>();


    }
}
