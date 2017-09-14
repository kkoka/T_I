using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
  public class Product_PublishingDetail_SupplyDetail_Supplier
    {

        [XmlElement("SupplierName", IsNullable = true)]
        public string SupplierName { get; set; }


        [XmlElement("SupplierRole", IsNullable = true)]
        public string SupplierRole { get; set; }


        [XmlElement("Website", IsNullable = true)]
        public List<Product_PublishingDetail_SupplyDetail_Supplier_Website> obj_Product_PublishingDetail_SupplyDetail_Website_List = new List<Product_PublishingDetail_SupplyDetail_Supplier_Website>();


    }
}
