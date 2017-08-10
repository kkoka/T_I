using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_complexity
    {
        [XmlElement("b077", IsNullable = true)]
        public string b077_productcomplexity { get; set; }

        [XmlElement("b078", IsNullable = true)]
        public string b078_productcomplexity { get; set; }

    }
}
