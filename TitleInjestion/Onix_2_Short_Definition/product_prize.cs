using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_prize
    {
        [XmlElement("g126", IsNullable = true)]
        public string g126_product_prize { get; set; }

        [XmlElement("g127", IsNullable = true)]
        public string g127_product_prize { get; set; }

        [XmlElement("g128", IsNullable = true)]
        public string g128_product_prize { get; set; }

        [XmlElement("g129", IsNullable = true)]
        public string g129_product_prize { get; set; }
     
    }
}
