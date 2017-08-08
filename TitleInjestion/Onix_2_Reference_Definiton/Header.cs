using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Header
    {

        [XmlElement("FromCompany")]
        public string FromCompany_header { get; set; }

        [XmlElement("FromPerson")]
        public string FromPerson_header { get; set; }

        [XmlElement("ToPerson")]
        public string ToPerson_header { get; set; }

        [XmlElement("FromEmail")]
        public string FromEmail_header { get; set; }

        [XmlElement("ToCompany")]
        public string ToCompany_header { get; set; }

        [XmlElement("SentDate")]
        public string SentDate_header { get; set; }

        [XmlElement("FromSAN")]
        public string FromSAN_header { get; set; }

        [XmlElement("DefaultCurrencyCode")]
        public string DefaultCurrencyCode_header { get; set; }

        [XmlElement("DefaultClassOfTrade")]
        public string DefaultClassOfTrade_header { get; set; }

        [XmlElement("DefaultLanguageOfText")]
        public string DefaultLanguageOfText_header { get; set; }        

    }
}
