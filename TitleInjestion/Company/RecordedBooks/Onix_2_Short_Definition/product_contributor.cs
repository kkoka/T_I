using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_contributor
    {
        [XmlElement("b034", IsNullable = true)]
        public string b034_productcontributor { get; set; }
        
        [XmlElement("b035", IsNullable = true)]
        public string b035_productcontributor { get; set; }
        
        [XmlElement("b036", IsNullable = true)]
        public string b036_productcontributor { get; set; }
       
        [XmlElement("b037", IsNullable = true)]
        public string b037_productcontributor { get; set; }
       
        [XmlElement("b038", IsNullable = true)]
        public string b038_productcontributor { get; set; }
       
        [XmlElement("b039", IsNullable = true)]
        public string b039_productcontributor { get; set; }
       
        [XmlElement("b040", IsNullable = true)]
        public string b040_productcontributor { get; set; }
       
        [XmlElement("b041", IsNullable = true)]
        public string b041_productcontributor { get; set; }
       
        [XmlElement("b042", IsNullable = true)]
        public string b042_productcontributor { get; set; }
     
        [XmlElement("b043", IsNullable = true)]
        public string b043_productcontributor { get; set; }

        [XmlElement("b044", IsNullable = true)]
        public string b044_productcontributor { get; set; }
    
        [XmlElement("b045", IsNullable = true)]
        public string b045_productcontributor { get; set; }
    
        [XmlElement("b046", IsNullable = true)]
        public string b046_productcontributor { get; set; }

        [XmlElement("b047", IsNullable = true)]
        public string b047_productcontributor { get; set; }

        [XmlElement("b247", IsNullable = true)]
        public string b247_productcontributor { get; set; }

        [XmlElement("b248", IsNullable = true)]
        public string b248_productcontributor { get; set; }
    
        [XmlElement("b251", IsNullable = true)]
        public string b251_productcontributor { get; set; }
    
        [XmlElement("b340", IsNullable = true)]
        public string b340_productcontributor { get; set; }
       
        [XmlElement("b398", IsNullable = true)]
        public string b398_productcontributor { get; set; }

        [XmlElement("personnameidentifier", IsNullable = true)]
        public List<product_contributor_personnameidentifier> obj_contributor_personnameidentifier_List = new List<product_contributor_personnameidentifier>();

        [XmlElement("professionalaffiliation", IsNullable = true)]
        public List<product_contributor_professionalaffiliation> obj_contributor_professionalaffiliation_List = new List<product_contributor_professionalaffiliation>();

        [XmlElement("website", IsNullable = true)]
        public List<product_contributor_website> obj_contributor_website_List = new List<product_contributor_website>();
      
      
						
				

    }
}
