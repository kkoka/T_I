using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
   public class product_containeditem
    {

        [XmlElement("b012", IsNullable = true)]
        public string b012_productcontaineditem { get; set; }
       
        [XmlElement("b210", IsNullable = true)]
        public string b210_productcontaineditem { get; set; }

        [XmlElement("productidentifier", IsNullable = true)]
        public List<product_containeditem_productidentifier> obj_productidentifier_List = new List<product_containeditem_productidentifier>();
              	
					
						
					
					
					
					
			   
   	 	    		  
        

    }
}
