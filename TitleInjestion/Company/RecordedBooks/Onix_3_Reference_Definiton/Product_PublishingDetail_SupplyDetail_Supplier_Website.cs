using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_PublishingDetail_SupplyDetail_Supplier_Website
    {

        [XmlElement("WebsiteLink", IsNullable = true)]
        public string WebsiteLink { get; set; }


        [XmlElement("WebsiteRole", IsNullable = true)]
        public string WebsiteRole { get; set; }

    }
}
