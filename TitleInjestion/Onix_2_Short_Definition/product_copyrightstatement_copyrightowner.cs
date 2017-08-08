using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_copyrightstatement_copyrightowner
    {
        [XmlElement("b036", IsNullable = true)]
        public string b036_product_copyrightstatement_copyrightowner { get; set; }
 
    }
}
