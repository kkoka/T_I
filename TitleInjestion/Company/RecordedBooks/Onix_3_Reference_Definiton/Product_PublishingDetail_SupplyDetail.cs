using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_PublishingDetail_SupplyDetail
    {
        
        [XmlElement("Price", IsNullable = true)]
        public List<Product_PublishingDetail_SupplyDetail_Price> obj_Product_PublishingDetail_SupplyDetail_Price_List = new List<Product_PublishingDetail_SupplyDetail_Price>();

        [XmlElement("ProductAvailability", IsNullable = true)]
        public List<string> obj_ProductAvailability_List = new List<string>();



        [XmlElement("Supplier", IsNullable = true)]
        public List<Product_PublishingDetail_SupplyDetail_Supplier> obj_Product_PublishingDetail_SupplyDetail_Supplier_List = new List<Product_PublishingDetail_SupplyDetail_Supplier>();


        [XmlElement("UnpricedItemType", IsNullable = true)]
        public string UnpricedItemType { get; set; }



    }
}
