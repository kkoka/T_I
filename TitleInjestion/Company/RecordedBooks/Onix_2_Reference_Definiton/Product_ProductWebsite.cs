using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_ProductWebsite
    {
        [XmlElement("ProductWebsiteLink", IsNullable = true)]
        public string ProductWebsiteLink_ProductProductWebsite { get; set; }
       
        [XmlElement("WebsiteRole", IsNullable = true)]
        public string WebsiteRole_ProductProductWebsite { get; set; }
      
               

    }
}
