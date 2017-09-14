using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail_Subject
    {
        [XmlElement("MainSubject", IsNullable = true)]
        public string MainSubject { get; set; }

        [XmlElement("SubjectCode", IsNullable = true)]
        public string SubjectCode { get; set; }

        [XmlElement("SubjectHeadingText", IsNullable = true)]
        public string SubjectHeadingText { get; set; }

        [XmlElement("SubjectSchemeIdentifier", IsNullable = true)]
        public string SubjectSchemeIdentifier { get; set; }
  
             
    }
}
