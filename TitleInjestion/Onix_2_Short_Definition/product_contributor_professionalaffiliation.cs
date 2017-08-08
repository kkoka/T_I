using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_contributor_professionalaffiliation
    {
        [XmlElement("b049", IsNullable = true)]
        public string b049_product_contributor_professionalaffiliation { get; set; }

    }
}
