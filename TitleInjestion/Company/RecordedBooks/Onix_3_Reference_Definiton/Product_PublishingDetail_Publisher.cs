using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_PublishingDetail_Publisher
    {

        [XmlElement("PublisherName", IsNullable = true)]
        public string PublisherName { get; set; }

        [XmlElement("PublishingRole", IsNullable = true)]
        public string PublishingRole { get; set; }

      


    }
}
