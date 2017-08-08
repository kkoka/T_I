using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_epubusageconstraint_epubusagelimit
    {

        [XmlElement("x320", IsNullable = true)]
        public string x320_product_descriptivedetail_epubusageconstraint_epubusagelimit { get; set; }


        [XmlElement("x321", IsNullable = true)]
        public string x321_product_descriptivedetail_epubusageconstraint_epubusagelimit { get; set; }

    }
}
