using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_DescriptiveDetail_Language
    {


        [XmlElement("LanguageCode", IsNullable = true)]
        public string LanguageCode { get; set; }

        [XmlElement("LanguageRole", IsNullable = true)]
        public string LanguageRole { get; set; }

    }
}
