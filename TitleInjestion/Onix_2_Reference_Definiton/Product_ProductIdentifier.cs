using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_ProductIdentifier
    {
        [XmlElement("IDTypeName", IsNullable = true)]
        public string IDTypeName_ProductProductIdentifier { get; set; }
                         
        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue_ProductProductIdentifier { get; set; }

        [XmlElement("ProductIDType", IsNullable = true)]
        public string ProductIDType_ProductProductIdentifier { get; set; }

    }
}
