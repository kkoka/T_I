using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_illustrations
    {
        [XmlElement("b256", IsNullable = true)]
        public string b256_product_illustrations { get; set; }

        [XmlElement("b257", IsNullable = true)]
        public string b257_product_illustrations { get; set; }

        [XmlElement("b361", IsNullable = true)]
        public string b361_product_illustrations { get; set; }



    }
}
