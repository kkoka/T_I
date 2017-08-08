using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_salesrestriction_salesoutlet
    {
        [XmlElement("b382", IsNullable = true)]
        public string b382_product_salesrestriction_salesoutlet { get; set; }


        [XmlElement("salesoutletidentifier", IsNullable = true)]
        public List<product_salesrestriction_salesoutlet_salesoutletidentifier> obj_product_salesrestriction_salesoutlet_List = new List<product_salesrestriction_salesoutlet_salesoutletidentifier>();
	
        		
       
    }
}
