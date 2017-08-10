using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_language
    {
        [XmlElement("b251", IsNullable = true)]
        public string b251_product_language { get; set; }

        [XmlElement("b252", IsNullable = true)]
        public string b252_product_language { get; set; }

        [XmlElement("b253", IsNullable = true)]
        public string b253_product_language { get; set; }

    }
}
