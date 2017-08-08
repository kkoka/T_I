using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_language
    {
        [XmlElement("b253", IsNullable = true)]
        public string b253 { get; set; }

      	[XmlElement("b252", IsNullable = true)]
        public List<string> obj_b252_product_descriptivedetail_List = new List<string>();


    }
}
