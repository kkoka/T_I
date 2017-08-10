using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_RelatedProduct
    {
        [XmlElement("EpubFormat", IsNullable = true)]
        public string EpubFormat_ProductRelatedProduct { get; set; }

        [XmlElement("EpubType", IsNullable = true)]
        public string EpubType_ProductRelatedProduct { get; set; }

        [XmlElement("EpubTypeDescription", IsNullable = true)]
        public string EpubTypeDescription_ProductRelatedProduct { get; set; }

        [XmlElement("ProductForm", IsNullable = true)]
        public string ProductForm_ProductRelatedProduct { get; set; }

        [XmlElement("ProductFormDetail", IsNullable = true)]
        public string ProductFormDetail_ProductRelatedProduct { get; set; }

        [XmlElement("ProductIdentifier", IsNullable = true)]
        public List<Product_RelatedProduct_ProductIdentifier> obj_ProductRelatedProductProductIdentifier_List = new List<Product_RelatedProduct_ProductIdentifier>();


        [XmlElement("RelationCode", IsNullable = true)]
        public string RelationCode_ProductRelatedProduct { get; set; }

    }
}
