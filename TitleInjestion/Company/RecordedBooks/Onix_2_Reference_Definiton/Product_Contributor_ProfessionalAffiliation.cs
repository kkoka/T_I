using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Contributor_ProfessionalAffiliation
    {
        [XmlElement("Affiliation", IsNullable = true)]
        public string Affiliation_ProductContributor_ProfessionalAffiliation { get; set; }       
    }
}
