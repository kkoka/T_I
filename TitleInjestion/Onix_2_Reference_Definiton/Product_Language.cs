using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_Language
    {

        [XmlElement("LanguageCode", IsNullable = true)]
        public string LanguageCode_ProductLanguage { get; set; }

                
        [XmlElement("LanguageRole", IsNullable = true)]
        public string LanguageRole_ProductLanguage { get; set; }


    }
}
