using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Short_Definition
{
    public class product_supplydetail_price_discountcoded
    {
        [XmlElement("j363", IsNullable = true)]
        public string j363_product_supplydetail_price_discountcoded { get; set; }

        [XmlElement("j364", IsNullable = true)]
        public string j364_product_supplydetail_price_discountcoded { get; set; }

        [XmlElement("j378", IsNullable = true)]
        public string j378_product_supplydetail_price_discountcoded { get; set; }
    }
}
