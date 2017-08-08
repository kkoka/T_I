using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_collateraldetail_supportingresource_resourceversion_contentdate
    {      
        [XmlElement("x429", IsNullable = true)]
        public string x429 { get; set; }

        [XmlElement("b306", IsNullable = true)]
        public string b306 { get; set; }

    }
}
