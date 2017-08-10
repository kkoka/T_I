using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_Contributor
    {



        [XmlElement("BiographicalNote", IsNullable = true)]
        public string BiographicalNote_productcontributor { get; set; }

        [XmlElement("ContributorRole", IsNullable = true)]
        public string ContributorRole_productcontributor { get; set; }

        [XmlElement("CorporateName", IsNullable = true)]
        public string CorporateName_productcontributor { get; set; }

        [XmlElement("CountryCode", IsNullable = true)]
        public string CountryCode_productcontributor { get; set; }

        [XmlElement("KeyNames", IsNullable = true)]
        public string KeyNames_productcontributor { get; set; }

        [XmlElement("NamesBeforeKey", IsNullable = true)]
        public string NamesBeforeKey_productcontributor { get; set; }

        [XmlElement("PersonName", IsNullable = true)]
        public string PersonName_productcontributor { get; set; }

        [XmlElement("PersonNameInverted", IsNullable = true)]
        public string PersonNameInverted_productcontributor { get; set; }

        [XmlElement("ProfessionalAffiliation", IsNullable = true)]
        public List<Product_Contributor_ProfessionalAffiliation> obj_contributor_ProfessionalAffiliation_List = new List<Product_Contributor_ProfessionalAffiliation>();

        [XmlElement("SequenceNumber", IsNullable = true)]
        public string SequenceNumber_productcontributor { get; set; }

        [XmlElement("SuffixToKey", IsNullable = true)]
        public string SuffixToKey_productcontributor { get; set; }

        [XmlElement("TitlesBeforeNames", IsNullable = true)]
        public string TitlesBeforeNames_productcontributor { get; set; }


    }
}
