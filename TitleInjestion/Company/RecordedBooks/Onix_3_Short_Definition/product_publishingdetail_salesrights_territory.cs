﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_publishingdetail_salesrights_territory
    {
        [XmlElement("x449", IsNullable = true)]
        public List<string> obj_x449_List = new List<string>();

    }
}
