using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Audience
    {
        [XmlElement("AudienceCodeType", IsNullable = true)]
        public string AudienceCodeType_productaudience { get; set; }
   

        [XmlElement("AudienceCodeValue", IsNullable = true)]
        public List<string> obj_product_audience_AudienceCodeValue_List = new List<string>();

    }
}
