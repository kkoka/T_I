using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_PublishingDetail_PublishingDate
    {
        [XmlElement("Date", IsNullable = true)]
        public string Date { get; set; }


        [XmlElement("DateFormat", IsNullable = true)]
        public string DateFormat { get; set; }


        [XmlElement("PublishingDateRole", IsNullable = true)]
        public string PublishingDateRole { get; set; }

 
    }
}
