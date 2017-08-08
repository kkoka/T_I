using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_publishingdetail_copyrightstatement
    {
        [XmlElement("x512", IsNullable = true)]
        public string x512 { get; set; }
	
        [XmlElement("b087", IsNullable = true)]
        public string b087 { get; set; }

        [XmlElement("copyrightowner", IsNullable = true)]
        public List<product_publishingdetail_copyrightstatement_copyrightowner> obj_productpublishingdetail_copyrightstatement_copyrightowner_List = new List<product_publishingdetail_copyrightstatement_copyrightowner>();

    }
}
