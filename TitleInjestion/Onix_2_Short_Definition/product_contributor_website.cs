using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_contributor_website
    {

        [XmlElement("b294", IsNullable = true)]
        public string b294_productcontributor_website { get; set; }

        [XmlElement("b295", IsNullable = true)]
        public string b295_productcontributor_website { get; set; }

        [XmlElement("b367", IsNullable = true)]
        public string b367_productcontributor_website { get; set; }

        	
  
    }
}
