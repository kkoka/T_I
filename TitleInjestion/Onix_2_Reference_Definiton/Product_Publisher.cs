using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_Publisher
    {
        [XmlElement("NameCodeType", IsNullable = true)]
        public string NameCodeType_ProductPublisher { get; set; }

        [XmlElement("NameCodeTypeName", IsNullable = true)]
        public string NameCodeTypeName_ProductPublisher { get; set; }
        
        [XmlElement("NameCodeValue", IsNullable = true)]
        public string NameCodeValue_ProductPublisher { get; set; }
          
		[XmlElement("PublisherName", IsNullable = true)]
        public string PublisherName_ProductPublisher { get; set; }
     	  
        [XmlElement("PublishingRole", IsNullable = true)]
        public string PublishingRole_ProductPublisher { get; set; }


        [XmlElement("Website", IsNullable = true)]
        public List<Product_Publisher_Website> obj_ProductPublisherWebsite_List = new List<Product_Publisher_Website>();





    }
}
