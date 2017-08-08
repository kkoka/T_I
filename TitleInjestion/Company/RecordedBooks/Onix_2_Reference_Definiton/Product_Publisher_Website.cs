using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Publisher_Website
    {
        [XmlElement("WebsiteLink", IsNullable = true)]
        public string WebsiteLink_ProductPublisher_Website { get; set; }
     
              
        [XmlElement("WebsiteRole", IsNullable = true)]
        public string WebsiteRole_ProductPublisher_Website { get; set; }
    
                          
    }
}
