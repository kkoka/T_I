using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_Contributor_ProfessionalAffiliation
    {
        [XmlElement("Affiliation", IsNullable = true)]
        public string Affiliation_productcontributor_ProfessionalAffiliation { get; set; }


    }
}
