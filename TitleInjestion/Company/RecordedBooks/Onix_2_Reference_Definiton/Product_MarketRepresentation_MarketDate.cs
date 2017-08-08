using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_MarketRepresentation_MarketDate
    {
        [XmlElement("Date", IsNullable = true)]
        public string Date_ProductMarketRepresentationMarketDate { get; set; }

        [XmlElement("MarketDateRole", IsNullable = true)]
        public string MarketDateRole_ProductMarketRepresentationMarketDate { get; set; }

				
    }
}
