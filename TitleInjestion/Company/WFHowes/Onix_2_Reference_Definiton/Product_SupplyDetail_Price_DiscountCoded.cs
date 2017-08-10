﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_SupplyDetail_Price_DiscountCoded
    {
        [XmlElement("DiscountCode", IsNullable = true)]
        public string DiscountCode_ProductSupplyDetailPriceDiscountCoded { get; set; }



        [XmlElement("DiscountCodeType", IsNullable = true)]
        public string DiscountCodeType_ProductSupplyDetailPriceDiscountCoded { get; set; }


    }
}
