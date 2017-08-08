using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_religioustext
    {

        [XmlElement("bible", IsNullable = true)]
        public List<product_religioustext_bible> obj_product_othertext_List = new List<product_religioustext_bible>();
	  
          
     
      
    }
}
