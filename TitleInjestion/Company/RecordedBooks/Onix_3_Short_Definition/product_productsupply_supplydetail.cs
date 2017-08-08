using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_productsupply_supplydetail
    {
        
        [XmlElement("supplier", IsNullable = true)]
        public List<product_productsupply_supplydetail_supplier> obj_productproductsupply_supplydetail_supplier_List = new List<product_productsupply_supplydetail_supplier>();
        
        [XmlElement("j396", IsNullable = true)]
        public string j396 { get; set; }
        
        [XmlElement("supplydate", IsNullable = true)]
        public List<product_productsupply_supplydetail_supplydate> obj_productproductsupply_supplydetail_supplydate_List = new List<product_productsupply_supplydetail_supplydate>();

        [XmlElement("price", IsNullable = true)]
        public List<product_productsupply_supplydetail_price> obj_productproductsupply_supplydetail_price_List = new List<product_productsupply_supplydetail_price>();

        
    }
}
