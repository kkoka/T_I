﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_productsupply_supplydetail_supplydate
    {
       [XmlElement("x461", IsNullable = true)]
        public string x461 { get; set; }
		
        [XmlElement("b306", IsNullable = true)]
        public string b306 { get; set; }

    }
}
