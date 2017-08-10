using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_audience
    {
        [XmlElement("b204", IsNullable = true)]
        public string b204_product { get; set; }
        //   public List<product_audience> obj_productaudience_b204 = new List<product_audience>();

        [XmlElement("b206", IsNullable = true)]
        public string b206_product { get; set; }
        //   public List<product_audience> obj_productaudience_b206 = new List<product_audience>();
    }
}
