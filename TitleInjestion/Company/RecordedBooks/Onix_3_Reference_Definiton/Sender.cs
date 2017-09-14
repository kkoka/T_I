using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Sender
    {
        [XmlElement("SenderName", IsNullable = true)]
        public string SenderName_Sender { get; set; }

        [XmlElement("ContactName", IsNullable = true)]
        public string ContactName_Sender { get; set; }

        [XmlElement("EmailAddress", IsNullable = true)]
        public string EmailAddress_Sender { get; set; }

 
    }
}
