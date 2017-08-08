using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_audiencerange
    {
        [XmlElement("b074", IsNullable = true)]
        public string b074_product { get; set; }       

        [XmlElement("b075", IsNullable = true)]
        public List<string> b075_product = new List<string>();

        [XmlElement("b076", IsNullable = true)]
        public List<string> b076_product = new List<string>();
      
   
    }
}
