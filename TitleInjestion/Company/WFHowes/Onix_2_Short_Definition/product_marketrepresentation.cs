using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_marketrepresentation
    {
        [XmlElement("j401", IsNullable = true)]
        public string j401_product_marketrepresentation { get; set; }

        [XmlElement("j402", IsNullable = true)]
        public string j402_product_marketrepresentation { get; set; }

        [XmlElement("j403", IsNullable = true)]
        public string j403_product_marketrepresentation { get; set; }

    }
}
