﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_RelatedProduct_ProductIdentifier
    {
        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue_ProductRelatedProductProductIdentifier { get; set; }


        [XmlElement("ProductIDType", IsNullable = true)]
        public string ProductIDType_ProductRelatedProductProductIdentifier { get; set; }

    }
}
