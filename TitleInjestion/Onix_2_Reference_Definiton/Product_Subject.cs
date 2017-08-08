using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_Subject
    {

        [XmlElement("SubjectCode", IsNullable = true)]
        public string SubjectCode_ProductSubject { get; set; }
                      
        [XmlElement("SubjectHeadingText", IsNullable = true)]
        public string SubjectHeadingText_ProductSubject { get; set; }
                   
        [XmlElement("SubjectSchemeIdentifier", IsNullable = true)]
        public string SubjectSchemeIdentifier_ProductSubject { get; set; }
                   
        [XmlElement("SubjectSchemeVersion", IsNullable = true)]
        public string SubjectSchemeVersion_ProductSubject { get; set; }

              

    }
}
