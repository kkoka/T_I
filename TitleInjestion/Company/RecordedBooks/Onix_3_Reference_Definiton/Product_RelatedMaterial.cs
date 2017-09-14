using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_RelatedMaterial
    {
        


        [XmlElement("RelatedProduct", IsNullable = true)]
        public List<Product_RelatedMaterial_RelatedProduct> obj_Product_PublishingDetail_RelatedProduct_List = new List<Product_RelatedMaterial_RelatedProduct>();



        [XmlElement("RelatedWork", IsNullable = true)]
        public List<Product_RelatedMaterial_RelatedWork> obj_Product_RelatedMaterial_RelatedWork_List = new List<Product_RelatedMaterial_RelatedWork>();




    }
}
