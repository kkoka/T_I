using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail_TitleDetail_TitleElement
    {


        [XmlElement("Subtitle", IsNullable = true)]
        public string Subtitle { get; set; }

        [XmlElement("TitleElementLevel", IsNullable = true)]
        public string TitleElementLevel { get; set; }

        [XmlElement("TitlePrefix", IsNullable = true)]
        public string TitlePrefix { get; set; }

        [XmlElement("TitleText", IsNullable = true)]
        public string TitleText { get; set; }

        [XmlElement("TitleWithoutPrefix", IsNullable = true)]
        public string TitleWithoutPrefix { get; set; }
         
                       


    }
}
