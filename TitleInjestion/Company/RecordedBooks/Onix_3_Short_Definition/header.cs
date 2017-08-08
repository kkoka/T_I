using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class header
    {
        [XmlElement("sender", IsNullable = true)]
        public List<sender> obj_header_List = new List<sender>();

        [XmlElement("x307", IsNullable = true)]
        public string x307_header { get; set; }

    }
}
