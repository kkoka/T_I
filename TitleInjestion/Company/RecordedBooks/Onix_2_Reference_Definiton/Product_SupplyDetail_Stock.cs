using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_SupplyDetail_Stock
    {

        
        [XmlElement("LocationIdentifier", IsNullable = true)]
        public List<Product_SupplyDetail_Stock_LocationIdentifier> obj_productSupplyDetailStock_LocationIdentifier_List = new List<Product_SupplyDetail_Stock_LocationIdentifier>();


        [XmlElement("LocationName", IsNullable = true)]
        public string LocationName_ProductImprint { get; set; }
  
        [XmlElement("OnHand", IsNullable = true)]
        public string OnHand_ProductImprint { get; set; }
   
    }
}
