using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_AudienceRange
    {

        [XmlElement("AudienceRangePrecision", IsNullable = true)]
        public List<string> AudienceRangePrecision_ProductAudienceRange = new List<string>();

        [XmlElement("AudienceRangeQualifier", IsNullable = true)]
        public string AudienceRangeQualifier_ProductAudienceRange { get; set; }

        [XmlElement("AudienceRangeValue", IsNullable = true)]
        public List<string> AudienceRangeValue_ProductAudienceRange = new List<string>();

    }
}
