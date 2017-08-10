using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_imprint
    {
        [XmlElement("b079", IsNullable = true)]
        public string b079_product_imprint { get; set; }

        [XmlElement("b241", IsNullable = true)]
        public string b241_product_imprint { get; set; }

        [XmlElement("b242", IsNullable = true)]
        public string b242_product_imprint { get; set; }

        [XmlElement("b243", IsNullable = true)]
        public string b243_product_imprint { get; set; }


    }
}
