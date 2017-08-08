using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_ProductClassification
    {
        [XmlElement("ProductClassificationCode", IsNullable = true)]
        public string ProductClassificationCode_ProductClassification { get; set; }
        	
        [XmlElement("ProductClassificationType", IsNullable = true)]
        public string ProductClassificationType_ProductClassification { get; set; }
       		

    }
}
