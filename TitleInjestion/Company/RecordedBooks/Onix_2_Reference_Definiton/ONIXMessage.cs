using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class ONIXMessage
    {
        [XmlElement("FileInfo")]
        public List<FileInfo> obj_FileInfo_List = new List<FileInfo>();

        [XmlElement("Header")]
        public List<Header> obj_header_List = new List<Header>();

        [XmlElement("Product")]
        public List<Product> obj_product_List = new List<Product>();

    }
}
