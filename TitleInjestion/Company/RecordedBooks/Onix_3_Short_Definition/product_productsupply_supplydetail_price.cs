using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;



namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_productsupply_supplydetail_price
    {
       [XmlElement("x462", IsNullable = true)]
        public string x462 { get; set; }
	
	   [XmlElement("j261", IsNullable = true)]
        public string j261 { get; set; }
		
       [XmlElement("j151", IsNullable = true)]
        public string j151 { get; set; }
	
        [XmlElement("j152", IsNullable = true)]
        public string j152 { get; set; }

        [XmlElement("territory", IsNullable = true)]
        public List<product_productsupply_supplydetail_price_territory> obj_productaudience_List = new List<product_productsupply_supplydetail_price_territory>();

      		 
    }
}
