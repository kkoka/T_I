using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_collateraldetail_textcontent
    {
        [XmlElement("x426", IsNullable = true)]
        public string x426 { get; set; }

        [XmlElement("x427", IsNullable = true)]
        public string x427 { get; set; }

        [XmlElement("d104", IsNullable = true)]
        public string d104 { get; set; }


    }
}
