﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_relatedproduct_publisher_website
    {
        [XmlElement("b295", IsNullable = true)]
        public string b295_product_relatedproduct_publisher_website { get; set; }

        [XmlElement("b367", IsNullable = true)]
        public string b367_product_relatedproduct_publisher_website { get; set; }

    }
}
