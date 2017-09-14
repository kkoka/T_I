using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml;
using System.Xml.Serialization;



namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_RelatedMaterial_RelatedProduct
    {



        [XmlElement("ProductIdentifier", IsNullable = true)]
        public List<Product_RelatedMaterial_RelatedProduct_ProductIdentifier> obj_Product_PublishingDetail_RelatedProduct_ProductIdentifier_List = new List<Product_RelatedMaterial_RelatedProduct_ProductIdentifier>();



        [XmlElement("ProductRelationCode", IsNullable = true)]
        public string ProductRelationCode { get; set; }

                             

    }
}
