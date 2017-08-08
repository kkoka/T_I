using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_supplydetail_supplieridentifier
    {
        [XmlElement("b233", IsNullable = true)]
        public string b233_product_supplydetail_supplieridentifier { get; set; }

        [XmlElement("b244", IsNullable = true)]
        public string b244_product_supplydetail_supplieridentifier { get; set; }

        [XmlElement("j345", IsNullable = true)]
        public string j345_product_supplydetail_supplieridentifier { get; set; }

    }
}
