using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_extent
    {
        [XmlElement("b218", IsNullable = true)]
        public string b218_product_extent { get; set; }

          [XmlElement("b219", IsNullable = true)]
        public string b219_product_extent { get; set; }

          [XmlElement("b220", IsNullable = true)]
        public string b220_product_extent { get; set; }

      

     

    }
}
