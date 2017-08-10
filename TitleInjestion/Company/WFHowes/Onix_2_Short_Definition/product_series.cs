using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_series
    {
        [XmlElement("b018", IsNullable = true)]
        public string b018_product_series { get; set; }

        [XmlElement("b019", IsNullable = true)]
        public string b019_product_series { get; set; }

        [XmlElement("seriesidentifier", IsNullable = true)]
        public List<product_series_seriesidentifier> obj_product_series_seriesidentifier_List = new List<product_series_seriesidentifier>();


        [XmlElement("title", IsNullable = true)]
        public List<product_series_title> obj_product_series_title_List = new List<product_series_title>();

    }
}
