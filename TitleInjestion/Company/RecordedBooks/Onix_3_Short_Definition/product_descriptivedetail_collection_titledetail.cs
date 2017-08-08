using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_descriptivedetail_collection_titledetail
    {
       [XmlElement("b202", IsNullable = true)]
       public string b202 { get; set; }
        
       [XmlElement("titleelement", IsNullable = true)]
       public List<product_descriptivedetail_collection_titledetail_titleelement> obj_product_descriptivedetail_collection_titledetail_titleelement_List = new List<product_descriptivedetail_collection_titledetail_titleelement>();

    }
}
