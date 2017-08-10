using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_contributor_personnameidentifier
    {
        [XmlElement("b233", IsNullable = true)]
        public string b233_productcontributor { get; set; }

        [XmlElement("b244", IsNullable = true)]
        public string b244_productcontributor { get; set; }

        [XmlElement("b390", IsNullable = true)]
        public string b390_productcontributor { get; set; }


    }
}
