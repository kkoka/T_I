using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_audiencerange
    {
        [XmlElement("b074", IsNullable = true)]
        public string b074 { get; set; }

        [XmlElement("b075", IsNullable = true)]
        public List<string> b075 = new List<string>();

        [XmlElement("b076", IsNullable = true)]
        public List<string> b076 = new List<string>();



    }
}
