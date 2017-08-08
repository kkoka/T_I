using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product
    {
        [XmlElement("a001", IsNullable = true)]
        public string a001 { get; set; }

        [XmlElement("a002", IsNullable = true)]
        public string a002 { get; set; }

        [XmlElement("productidentifier", IsNullable = true)]
        public List<product_productidentifier> obj_productproductidentifier_List = new List<product_productidentifier>();

        [XmlElement("descriptivedetail", IsNullable = true)]
        public List<product_descriptivedetail> obj_productdescriptivedetail_List = new List<product_descriptivedetail>();


        [XmlElement("collateraldetail", IsNullable = true)]
        public List<product_collateraldetail> obj_productcollateraldetail_List = new List<product_collateraldetail>();

        
        [XmlElement("publishingdetail", IsNullable = true)]
        public List<product_publishingdetail> obj_productpublishingdetail_List = new List<product_publishingdetail>();

        [XmlElement("productsupply", IsNullable = true)]
        public List<product_productsupply> obj_productproductsupply_List = new List<product_productsupply>();


    }
}
