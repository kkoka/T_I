using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_SupplyDetail_Price
    {
        [XmlElement("ClassOfTrade", IsNullable = true)]
        public string ClassOfTrade_ProductSupplyDetailPrice { get; set; }

        [XmlElement("CountryCode", IsNullable = true)]
        public List<string> obj_ProductSupplyDetailPriceCountryCode_List = new List<string>();

        [XmlElement("CurrencyCode", IsNullable = true)]
        public string CurrencyCode_ProductSupplyDetailPrice { get; set; }

        [XmlElement("DiscountCoded", IsNullable = true)]
        public List<Product_SupplyDetail_Price_DiscountCoded> obj_ProductSupplyDetailPriceDiscountCoded_List = new List<Product_SupplyDetail_Price_DiscountCoded>();

        [XmlElement("PriceAmount", IsNullable = true)]
        public string PriceAmount_ProductSupplyDetailPrice { get; set; }

        [XmlElement("PriceEffectiveFrom", IsNullable = true)]
        public string PriceEffectiveFrom_ProductSupplyDetailPrice { get; set; }

        [XmlElement("PriceQualifier", IsNullable = true)]
        public string PriceQualifier_ProductSupplyDetailPrice { get; set; }

        [XmlElement("PriceStatus", IsNullable = true)]
        public string PriceStatus_ProductSupplyDetailPrice { get; set; }


        [XmlElement("PriceTypeCode", IsNullable = true)]
        public string PriceTypeCode_ProductSupplyDetailPrice { get; set; }

        [XmlElement("PriceTypeDescription", IsNullable = true)]
        public string PriceTypeDescription_ProductSupplyDetailPrice { get; set; }


        [XmlElement("TaxAmount1", IsNullable = true)]
        public string TaxAmount1_ProductSupplyDetailPrice { get; set; }

        [XmlElement("TaxableAmount1", IsNullable = true)]
        public string TaxableAmount1_ProductSupplyDetailPrice { get; set; }

        [XmlElement("TaxRateCode1", IsNullable = true)]
        public string TaxRateCode1_ProductSupplyDetailPrice { get; set; }

        [XmlElement("Territory", IsNullable = true)]
        public string Territory_ProductSupplyDetailPrice { get; set; }


    }
}
