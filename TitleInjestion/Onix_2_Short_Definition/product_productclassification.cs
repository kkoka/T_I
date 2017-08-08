using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_productclassification
    {
        [XmlElement("b274", IsNullable = true)]
        public string b274_product_productclassification { get; set; }
       
        [XmlElement("b275", IsNullable = true)]
        public string b275_product_productclassification { get; set; }
         
    }
}
