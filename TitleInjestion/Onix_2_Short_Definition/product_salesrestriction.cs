using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_salesrestriction
    {
        [XmlElement("b381", IsNullable = true)]
        public string b381_product_salesrestriction { get; set; }

        [XmlElement("b383", IsNullable = true)]
        public string b383_product_salesrestriction { get; set; }

        [XmlElement("salesoutlet", IsNullable = true)]
        public List<product_salesrestriction_salesoutlet> obj_product_salesrestriction_salesoutlet_List = new List<product_salesrestriction_salesoutlet>();
	  
    }
}
