using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_MainSubject
    {
        [XmlElement("MainSubjectSchemeIdentifier", IsNullable = true)]
        public string MainSubjectSchemeIdentifier_ProductMainSubject { get; set; }


        [XmlElement("SubjectCode", IsNullable = true)]
        public string SubjectCode_ProductMainSubject { get; set; }


        [XmlElement("SubjectHeadingText", IsNullable = true)]
        public string SubjectHeadingText_ProductMainSubject { get; set; }


        [XmlElement("SubjectSchemeVersion", IsNullable = true)]
        public string SubjectSchemeVersion_ProductMainSubject { get; set; }
    }
}
