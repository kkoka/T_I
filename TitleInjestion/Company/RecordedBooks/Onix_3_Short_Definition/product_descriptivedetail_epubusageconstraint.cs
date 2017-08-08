using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_epubusageconstraint
    {
        [XmlElement("x318", IsNullable = true)]
        public string x318_product_descriptivedetail_epubusageconstraint { get; set; }

        [XmlElement("x319", IsNullable = true)]
        public string x319_product_descriptivedetail_epubusageconstraint { get; set; }
        
        [XmlElement("epubusagelimit", IsNullable = true)]
        public List<product_descriptivedetail_epubusageconstraint_epubusagelimit> obj_extent_List = new List<product_descriptivedetail_epubusageconstraint_epubusagelimit>();


    }
}
