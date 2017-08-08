using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_OtherText
    {
        [XmlElement("Text", IsNullable = true)]
        public string Text_ProductOtherText { get; set; }
                 
        [XmlElement("TextFormat", IsNullable = true)]
        public string TextFormat_ProductOtherText { get; set; }


        [XmlElement("TextLink", IsNullable = true)]
        public string TextLink_ProductOtherText { get; set; }


        [XmlElement("TextLinkType", IsNullable = true)]
        public string TextLinkType_ProductOtherText { get; set; }


        [XmlElement("TextSourceTitle", IsNullable = true)]
        public string TextSourceTitle_ProductOtherText { get; set; }
 
        [XmlElement("TextTypeCode", IsNullable = true)]
        public string TextTypeCode_ProductOtherText { get; set; }
 
        



    }
}
