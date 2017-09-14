using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product
    {
        [XmlElement("RecordReference", IsNullable = true)]
        public string RecordReference { get; set; }

        [XmlElement("NotificationType", IsNullable = true)]
        public string NotificationType { get; set; }

        [XmlElement("RecordSourceType", IsNullable = true)]
        public string RecordSourceType { get; set; }

        [XmlElement("ProductIdentifier", IsNullable = true)]
        public List<Product_ProductIdentifier> obj_Product_ProductIdentifier_List = new List<Product_ProductIdentifier>();

        [XmlElement("DescriptiveDetail", IsNullable = true)]
        public List<Product_DescriptiveDetail> obj_Product_DescriptiveDetail_List = new List<Product_DescriptiveDetail>();

        [XmlElement("CollateralDetail", IsNullable = true)]
        public List<Product_CollateralDetail> obj_Product_CollateralDetail_List = new List<Product_CollateralDetail>();

        [XmlElement("PublishingDetail", IsNullable = true)]
        public List<Product_PublishingDetail> obj_Product_PublishingDetail_List = new List<Product_PublishingDetail>();

        [XmlElement("ProductSupply", IsNullable = true)]
        public List<Product_ProductSupply> obj_Product_ProductSupply_List = new List<Product_ProductSupply>();

        [XmlElement("RelatedMaterial", IsNullable = true)]
        public List<Product_RelatedMaterial> obj_Product_RelatedMaterial_List = new List<Product_RelatedMaterial>();

    }
}
