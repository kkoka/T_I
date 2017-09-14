using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_CollateralDetail_TextContent
    {
        [XmlElement("ContentAudience", IsNullable = true)]
        public string ContentAudience { get; set; }

        [XmlElement("Text", IsNullable = true)]
        public string Text { get; set; }

        [XmlElement("TextAuthor", IsNullable = true)]
        public string TextAuthor { get; set; }

        [XmlElement("TextType", IsNullable = true)]
        public string TextType { get; set; }

      
                   

    }
}
