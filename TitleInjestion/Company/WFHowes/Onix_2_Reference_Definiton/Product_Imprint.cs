using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_Imprint
    {

        [XmlElement("ImprintName", IsNullable = true)]
        public string ImprintName_ProductImprint { get; set; }

        [XmlElement("NameCodeType", IsNullable = true)]
        public string NameCodeType_ProductImprint { get; set; }

        [XmlElement("NameCodeTypeName", IsNullable = true)]
        public string NameCodeTypeName_ProductImprint { get; set; }

        [XmlElement("NameCodeValue", IsNullable = true)]
        public string NameCodeValue_ProductImprint { get; set; }

    }
}
