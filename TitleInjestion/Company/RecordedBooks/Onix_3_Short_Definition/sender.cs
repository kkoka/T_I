using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class sender
    {
        [XmlElement("x298", IsNullable = true)]
        public string x298_header { get; set; }

        [XmlElement("x299", IsNullable = true)]
        public string x299_header { get; set; }

        [XmlElement("j272", IsNullable = true)]
        public string j272_header { get; set; }

      
    }
}
