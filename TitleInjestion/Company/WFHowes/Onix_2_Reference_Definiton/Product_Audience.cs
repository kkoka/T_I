using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_Audience
    {
        [XmlElement("AudienceCodeType", IsNullable = true)]
        public string AudienceCodeType_productAudience { get; set; }
        //   public List<product_audience> obj_productaudience_b204 = new List<product_audience>();

        [XmlElement("AudienceCodeValue", IsNullable = true)]
        public string AudienceCodeValue_productAudience { get; set; }
    }
}
