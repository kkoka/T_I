using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Website
    {
        [XmlElement("WebsiteLink", IsNullable = true)]
        public string WebsiteLink_ProductWebsite { get; set; }
   
        	 				
    }
}
