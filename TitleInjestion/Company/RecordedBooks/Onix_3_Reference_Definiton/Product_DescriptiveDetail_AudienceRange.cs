using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail_AudienceRange
    {

        [XmlElement("AudienceRangePrecision", IsNullable = true)]
        public string AudienceRangePrecision { get; set; }


        [XmlElement("AudienceRangePrecision_AudienceAge", IsNullable = true)]
        public string AudienceRangePrecision_AudienceAge { get; set; }


        [XmlElement("AudienceRangeQualifier", IsNullable = true)]
        public string AudienceRangeQualifier { get; set; }


        [XmlElement("AudienceRangeQualifier_AudienceAge", IsNullable = true)]
        public string AudienceRangeQualifier_AudienceAge { get; set; }


        [XmlElement("AudienceRangeValue", IsNullable = true)]
        public string AudienceRangeValue { get; set; }


        [XmlElement("AudienceRangeValue_AudienceAge", IsNullable = true)]
        public string AudienceRangeValue_AudienceAge { get; set; }

     
         
              


    }
}
