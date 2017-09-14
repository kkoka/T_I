using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml;
using System.Xml.Serialization;



namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_ProductSupply
    {
       
        [XmlElement("MarketPublishingDetail", IsNullable = true)]
        public List<Product_PublishingDetail_MarketPublishingDetail> obj_Product_PublishingDetail_MarketPublishingDetail_List = new List<Product_PublishingDetail_MarketPublishingDetail>();

        [XmlElement("SupplyDetail", IsNullable = true)]
        public List<Product_PublishingDetail_SupplyDetail> obj_Product_PublishingDetail_SupplyDetail_List = new List<Product_PublishingDetail_SupplyDetail>();


    }
}
