using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_collection_collectionsequence
    {
      
        [XmlElement("x479", IsNullable = true)]
        public string x479 { get; set; }

        [XmlElement("x480", IsNullable = true)]
        public string x480 { get; set; }

        [XmlElement("x481", IsNullable = true)]
        public string x481 { get; set; }
        

    }
}
