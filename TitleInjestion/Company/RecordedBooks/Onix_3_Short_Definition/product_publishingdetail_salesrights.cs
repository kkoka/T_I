using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_publishingdetail_salesrights
    {
        
        [XmlElement("b089", IsNullable = true)]
        public string b089 { get; set; }
        
 [XmlElement("territory", IsNullable = true)]
        public List<product_publishingdetail_salesrights_territory> obj_productpublishingdetail_salesrights_territory_List = new List<product_publishingdetail_salesrights_territory>();


    }
}
