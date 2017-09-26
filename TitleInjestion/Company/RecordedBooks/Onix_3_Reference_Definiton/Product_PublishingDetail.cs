using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_PublishingDetail
    {


        [XmlElement("CityOfPublication", IsNullable = true)]
        public string CityOfPublication { get; set; }


        [XmlElement("CountryOfPublication", IsNullable = true)]
        public string CountryOfPublication { get; set; }


        [XmlElement("Imprint", IsNullable = true)]
        public List<Product_PublishingDetail_Imprint> obj_Product_PublishingDetail_Imprint_List = new List<Product_PublishingDetail_Imprint>();

        [XmlElement("PublishingStatus", IsNullable = true)]
        public List<string> obj_PublishingStatus_List = new List<string>();

        [XmlElement("ROWSalesRightsType", IsNullable = true)]
        public string ROWSalesRightsType { get; set; }


        [XmlElement("Publisher", IsNullable = true)]
        public List<Product_PublishingDetail_Publisher> obj_Product_PublishingDetail_Publisher_List = new List<Product_PublishingDetail_Publisher>();


        [XmlElement("PublishingDate", IsNullable = true)]
        public List<Product_PublishingDetail_PublishingDate> obj_Product_PublishingDetail_PublishingDate_List = new List<Product_PublishingDetail_PublishingDate>();


        [XmlElement("SalesRestriction", IsNullable = true)]
        public List<Product_PublishingDetail_SalesRestriction> obj_Product_PublishingDetail_SalesRestriction_List = new List<Product_PublishingDetail_SalesRestriction>();

        [XmlElement("SalesRights", IsNullable = true)]
        public List<Product_PublishingDetail_SalesRights> obj_Product_PublishingDetail_SalesRights_List = new List<Product_PublishingDetail_SalesRights>();


    }
}
