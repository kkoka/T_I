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
        public string CountriesIncluded { get; set; }

        [XmlElement("CountriesExcluded", IsNullable = true)]
        public string CountriesExcluded { get; set; }

        [XmlElement("RegionsIncluded", IsNullable = true)]
        public string RegionsIncluded { get; set; }
         
    }
}
