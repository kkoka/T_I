using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_SupplyDetail
    {
        [XmlElement("AvailabilityCode", IsNullable = true)]
        public string AvailabilityCode_ProductSupplyDetail { get; set; }
       
        [XmlElement("EmailAddress", IsNullable = true)]
        public string EmailAddress_ProductSupplyDetail { get; set; }
  

        [XmlElement("ExpectedShipDate", IsNullable = true)]
        public string ExpectedShipDate_ProductSupplyDetail { get; set; }
  
                          
   
        [XmlElement("FaxNumber", IsNullable = true)]
        public string FaxNumber_ProductSupplyDetail { get; set; }
  
         
        [XmlElement("LastDateForReturns", IsNullable = true)]
        public string LastDateForReturns_ProductSupplyDetail { get; set; }
  
         
        [XmlElement("OnSaleDate", IsNullable = true)]
        public string OnSaleDate_ProductSupplyDetail { get; set; }
  

        [XmlElement("PackQuantity", IsNullable = true)]
        public string PackQuantity_ProductSupplyDetail { get; set; }

        [XmlElement("Price", IsNullable = true)]
        public List<Product_SupplyDetail_Price> obj_product_SupplyDetail_Price_List = new List<Product_SupplyDetail_Price>();


        [XmlElement("ProductAvailability", IsNullable = true)]
        public string ProductAvailability_ProductSupplyDetail { get; set; }
   
               
        [XmlElement("ReturnsCode", IsNullable = true)]
        public string ReturnsCode_ProductSupplyDetail { get; set; }

         
        [XmlElement("ReturnsCodeType", IsNullable = true)]
        public string ReturnsCodeType_ProductSupplyDetail { get; set; }

        
        [XmlElement("Stock", IsNullable = true)]
        public List<Product_SupplyDetail_Stock> obj_productSupplyDetail_Stock_List = new List<Product_SupplyDetail_Stock>();

        [XmlElement("SupplierName", IsNullable = true)]
        public string SupplierName_ProductSupplyDetail { get; set; }
      
        [XmlElement("SupplierRole", IsNullable = true)]
        public string SupplierRole_ProductSupplyDetail { get; set; }
     
        [XmlElement("SupplierSAN", IsNullable = true)]
        public string SupplierSAN_ProductSupplyDetail { get; set; }
    
        [XmlElement("SupplyToCountry", IsNullable = true)]
        public string SupplyToCountry_ProductSupplyDetail { get; set; }

        [XmlElement("SupplyToTerritory", IsNullable = true)]
        public string SupplyToTerritory_ProductSupplyDetail { get; set; }

        [XmlElement("TelephoneNumber", IsNullable = true)]
        public string TelephoneNumber_ProductSupplyDetail { get; set; }
                  

    }
}
