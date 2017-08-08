using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_notforsale_productidentifier
    {
        [XmlElement("b221", IsNullable = true)]
        public string b221_product_notforsale_productidentifier { get; set; }
     
        [XmlElement("b244", IsNullable = true)]
        public string b244_product_notforsale_productidentifier { get; set; }
             
    }
}
