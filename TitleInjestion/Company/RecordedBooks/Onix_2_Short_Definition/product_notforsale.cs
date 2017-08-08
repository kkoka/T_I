using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_notforsale
    {
        [XmlElement("b090", IsNullable = true)]
        public List<string> obj_b090_List = new List<string>();
     
        [XmlElement("b388", IsNullable = true)]
        public string b388_product { get; set; }


        [XmlElement("productidentifier", IsNullable = true)]
        public List<product_notforsale_productidentifier> obj_product_notforsale_productidentifier_List = new List<product_notforsale_productidentifier>();
	  	      

     
    }
}
