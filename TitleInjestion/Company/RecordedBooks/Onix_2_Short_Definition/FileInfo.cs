using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class FileInfo
    {
        [XmlElement("FileName")]
        public string FileName_FileInfo { get; set; }

        [XmlElement("Pub_ID")]
        public string PubID_FileInfo { get; set; }

        [XmlElement("FileType")]
        public string FileType_FileInfo { get; set; }

    }
}
