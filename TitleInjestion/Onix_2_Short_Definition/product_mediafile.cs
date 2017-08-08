using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_mediafile
    {
        [XmlElement("f114", IsNullable = true)]
        public string f114_product_mediafile { get; set; }
        
        [XmlElement("f115", IsNullable = true)]
        public string f115_product_mediafile { get; set; }

        [XmlElement("f116", IsNullable = true)]
        public string f116_product_mediafile { get; set; }
 
        [XmlElement("f117", IsNullable = true)]
        public string f117_product_mediafile { get; set; }
 
        [XmlElement("f119", IsNullable = true)]
        public string f119_product_mediafile { get; set; }

        [XmlElement("f120", IsNullable = true)]
        public string f120_product_mediafile { get; set; }
 
        [XmlElement("f373", IsNullable = true)]
        public string f373_product_mediafile { get; set; }
                     

    }
}
