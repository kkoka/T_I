using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_productsupply_supplydetail_supplier
    {
        [XmlElement("j292", IsNullable = true)]
        public string j292 { get; set; }

     	[XmlElement("j137", IsNullable = true)]
        public string j137 { get; set; }




    }
}
