﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Series_SeriesIdentifier
    {

        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue_ProductSeries_SeriesIdentifier { get; set; }

        [XmlElement("SeriesIDType", IsNullable = true)]
        public string SeriesIDType_ProductSeries_SeriesIdentifier { get; set; }


    }
}
