using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_MarketRepresentation
    {
        [XmlElement("AgentName", IsNullable = true)]
        public string AgentName_ProductMarketRepresentation { get; set; }

        [XmlElement("AgentRole", IsNullable = true)]
        public string AgentRole_ProductMarketRepresentation { get; set; }
       

        [XmlElement("MarketCountry", IsNullable = true)]
        public string MarketCountry_ProductMarketRepresentation { get; set; }

        [XmlElement("MarketDate", IsNullable = true)]
        public List<Product_MarketRepresentation_MarketDate> obj_ProductMarketRepresentationMarketDate_List = new List<Product_MarketRepresentation_MarketDate>();
 
        [XmlElement("MarketPublishingStatus", IsNullable = true)]
        public string MarketPublishingStatus_ProductMarketRepresentation { get; set; }
       


      

    }
}
