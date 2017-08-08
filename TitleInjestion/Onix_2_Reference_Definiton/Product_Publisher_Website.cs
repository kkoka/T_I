using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_Publisher_Website
    {
        [XmlElement("WebsiteLink", IsNullable = true)]
        public string WebsiteLink_ProductPublisherWebsite { get; set; }
        

        [XmlElement("WebsiteRole", IsNullable = true)]
        public string WebsiteRole_ProductPublisherWebsite { get; set; }
     
                          

    }
}
