using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Header
    {
        [XmlElement("Sender", IsNullable = true)]
        public List<Sender> obj_Header_List = new List<Sender>();

        [XmlElement("SentDateTime", IsNullable = true)]
        public string SentDateTime_Header { get; set; }

        [XmlElement("DefaultCurrencyCode", IsNullable = true)]
        public string DefaultCurrencyCode_Header { get; set; }
        
          
    }
}
