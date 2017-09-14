using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail_ReligiousText_Bible
    {

        [XmlElement("BibleContents", IsNullable = true)]
        public string BibleContents { get; set; }


        [XmlElement("BiblePurpose", IsNullable = true)]
        public string BiblePurpose { get; set; }


        [XmlElement("BibleTextOrganization", IsNullable = true)]
        public string BibleTextOrganization { get; set; }


        [XmlElement("BibleVersion", IsNullable = true)]
        public string BibleVersion { get; set; }


        [XmlElement("StudyBibleType", IsNullable = true)]
        public string StudyBibleType { get; set; }
         
    }
}
