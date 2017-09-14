using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization; 


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
  public  class Product_PublishingDetail_SalesRights
    {

        [XmlElement("SalesRightsType", IsNullable = true)]
        public string SalesRightsType { get; set; }

        [XmlElement("Territory", IsNullable = true)]
        public List<Product_PublishingDetail_Territory> obj_Product_PublishingDetail_Territory_List = new List<Product_PublishingDetail_Territory>();



    }
}
