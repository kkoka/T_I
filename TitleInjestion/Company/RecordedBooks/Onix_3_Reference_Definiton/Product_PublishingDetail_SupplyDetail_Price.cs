using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public  class Product_PublishingDetail_SupplyDetail_Price
    {
        [XmlElement("CurrencyCode", IsNullable = true)]
        public string CurrencyCode { get; set; }


        [XmlElement("PriceAmount", IsNullable = true)]
        public string PriceAmount { get; set; }


        [XmlElement("PriceType", IsNullable = true)]
        public string PriceType { get; set; }


    }
}
