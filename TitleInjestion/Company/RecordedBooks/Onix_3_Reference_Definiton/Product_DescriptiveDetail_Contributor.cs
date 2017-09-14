using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail_Contributor
    {

        [XmlElement("ContributorRole", IsNullable = true)]
        public string ContributorRole { get; set; }

        [XmlElement("CorporateName", IsNullable = true)]
        public string CorporateName { get; set; }

        [XmlElement("KeyNames", IsNullable = true)]
        public string KeyNames { get; set; }

        [XmlElement("NamesBeforeKey", IsNullable = true)]
        public string NamesBeforeKey { get; set; }

        [XmlElement("PersonName", IsNullable = true)]
        public string PersonName { get; set; }

        [XmlElement("PersonNameInverted", IsNullable = true)]
        public string PersonNameInverted { get; set; }

        [XmlElement("SequenceNumber", IsNullable = true)]
        public string SequenceNumber { get; set; }

        [XmlElement("TitlesBeforeNames", IsNullable = true)]
        public string TitlesBeforeNames { get; set; }
 
    }
}
