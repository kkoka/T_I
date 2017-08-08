using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_audience
    {
        [XmlElement("b204", IsNullable = true)]
        public string b204 { get; set; }

        [XmlElement("b205", IsNullable = true)]
        public string b205 { get; set; }

        [XmlElement("b206", IsNullable = true)]
        public List<string> obj_b206_productdescriptivedetail_audience_List = new List<string>();

    }
}
