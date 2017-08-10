using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_salesrestriction_salesoutlet_salesoutletidentifier
    {
        [XmlElement("b244", IsNullable = true)]
        public string b244_product_salesrestriction_salesoutlet_salesoutletidentifier { get; set; }

        [XmlElement("b393", IsNullable = true)]
        public string b393_product_salesrestriction_salesoutlet_salesoutletidentifier { get; set; }

    }
}
