using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_series_seriesidentifier
    {
        [XmlElement("b233", IsNullable = true)]
        public string b233_product_series_seriesidentifier { get; set; }

        [XmlElement("b244", IsNullable = true)]
        public string b244_product_series_seriesidentifier { get; set; }

        [XmlElement("b273", IsNullable = true)]
        public string b273_product_series_seriesidentifier { get; set; }

    }
}
