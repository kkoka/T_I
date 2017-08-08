using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Prize
    {
        [XmlElement("PrizeCode", IsNullable = true)]
        public string PrizeCode_ProductPrize { get; set; }
                       
        [XmlElement("PrizeCountry", IsNullable = true)]
        public string PrizeCountry_ProductPrize { get; set; }
                              
        [XmlElement("PrizeJury", IsNullable = true)]
        public string PrizeJury_ProductPrize { get; set; }
                      
        [XmlElement("PrizeName", IsNullable = true)]
        public string PrizeName_ProductPrize { get; set; }
                      
        [XmlElement("PrizeYear", IsNullable = true)]
        public string PrizeYear_ProductPrize { get; set; }
  
                       


    }
}
