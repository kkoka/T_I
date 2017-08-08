using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_Illustrations
    {
        [XmlElement("IllustrationType", IsNullable = true)]
        public string IllustrationType_ProductIllustrations { get; set; }
          
        [XmlElement("IllustrationTypeDescription", IsNullable = true)]
        public string IllustrationTypeDescription_ProductIllustrations { get; set; }
    
        [XmlElement("Number", IsNullable = true)]
        public string Number_ProductIllustrations { get; set; }
                



    }
}
