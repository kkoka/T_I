using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_religioustext_bible
    {
        [XmlElement("b352", IsNullable = true)]
        public string b352_product_religioustext_bible { get; set; }

        [XmlElement("b353", IsNullable = true)]
        public string b353_product_religioustext_bible { get; set; }

        [XmlElement("b354", IsNullable = true)]
        public string b354_product_religioustext_bible { get; set; }

        [XmlElement("b355", IsNullable = true)]
        public string b355_product_religioustext_bible { get; set; }

    }
}
