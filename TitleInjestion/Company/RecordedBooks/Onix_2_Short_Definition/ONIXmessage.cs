using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class ONIXmessage
    {
        [XmlElement("FileInfo")]
        public List<FileInfo> obj_FileInfo_List = new List<FileInfo>();

        [XmlElement("header")]
        public List<header> obj_header_List = new List<header>();

        [XmlElement("product")]
        public List<product> obj_product_List = new List<product>();


    }
}
