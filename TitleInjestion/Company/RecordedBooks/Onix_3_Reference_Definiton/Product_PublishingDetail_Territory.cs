using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_PublishingDetail_Territory
    {

        [XmlElement("CountriesIncluded", IsNullable = true)]
        public List<string> obj_Product_PublishingDetail_Territory_CountriesIncluded_List = new List<string>();

        [XmlElement("CountriesExcluded", IsNullable = true)]
        public string CountriesExcluded { get; set; }

        [XmlElement("RegionsIncluded", IsNullable = true)]
        public List<string> obj_Product_PublishingDetail_Territory_RegionsIncluded_List = new List<string>();
      
    }
}
