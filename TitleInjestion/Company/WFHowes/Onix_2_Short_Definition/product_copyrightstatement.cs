using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_copyrightstatement
    {
        [XmlElement("b087", IsNullable = true)]
        public string b087_product_copyrightstatement { get; set; }

        [XmlElement("copyrightowner", IsNullable = true)]
        public List<product_copyrightstatement_copyrightowner> obj_complexity_List = new List<product_copyrightstatement_copyrightowner>();



    }
}
