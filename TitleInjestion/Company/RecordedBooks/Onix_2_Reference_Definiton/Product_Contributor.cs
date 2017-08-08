using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Contributor
    {

        [XmlElement("BiographicalNote", IsNullable = true)]
        public string BiographicalNote_ProductContributor { get; set; }
    
        [XmlElement("ContributorRole", IsNullable = true)]
        public string ContributorRole_ProductContributor { get; set; }
     
        [XmlElement("CorporateName", IsNullable = true)]
        public string CorporateName_ProductContributor { get; set; }
     
        [XmlElement("CountryCode", IsNullable = true)]
        public string CountryCode_ProductContributor { get; set; }
  	
        [XmlElement("KeyNames", IsNullable = true)]
        public string KeyNames_ProductContributor { get; set; }
     
        [XmlElement("NamesBeforeKey", IsNullable = true)]
        public string NamesBeforeKey_ProductContributor { get; set; }
      
        [XmlElement("PersonName", IsNullable = true)]
        public string PersonName_ProductContributor { get; set; }
     
        [XmlElement("PersonNameInverted", IsNullable = true)]
        public string PersonNameInverted_ProductContributor { get; set; }

        [XmlElement("ProfessionalAffiliation", IsNullable = true)]
        public List<Product_Contributor_ProfessionalAffiliation> obj_productContributor_ProfessionalAffiliation_List = new List<Product_Contributor_ProfessionalAffiliation>();
       
           
        [XmlElement("SequenceNumber", IsNullable = true)]
        public string SequenceNumber_ProductContributor { get; set; }
  
         
        [XmlElement("SuffixToKey", IsNullable = true)]
        public string SuffixToKey_ProductContributor { get; set; }
  
	
        [XmlElement("TitlesBeforeNames", IsNullable = true)]
        public string TitlesBeforeNames_ProductContributor { get; set; }
 
                       
    }
}
