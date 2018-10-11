using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
   public class Product_Series_Title
    {
        [XmlElement("TitleType", IsNullable = true)]
        public string TitleType_Product_Series_Title { get; set; }

        [XmlElement("TitleText", IsNullable = true)]
        public string TitleText_Product_Series_Title { get; set; }

        [XmlElement("TitlePrefix", IsNullable = true)]
        public string TitlePrefix_Product_Series_Title { get; set; }

        [XmlElement("TitleWithoutPrefix", IsNullable = true)]
        public string TitleWithoutPrefix_Product_Series_Title { get; set; }

        [XmlElement("Subtitle", IsNullable = true)]
        public string Subtitle_Product_Series_Title { get; set; }


    }
}
