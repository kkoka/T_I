using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_personassubject
    {
        [XmlElement("b037", IsNullable = true)]
        public string b037_product_personassubject { get; set; }

    }
}
