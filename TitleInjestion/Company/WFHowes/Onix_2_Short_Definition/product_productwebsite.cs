using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_productwebsite
    {
        [XmlElement("b367", IsNullable = true)]
        public string b367_product_productwebsite { get; set; }

        [XmlElement("f123", IsNullable = true)]
        public string f123_product_productwebsite { get; set; }

    }
}
