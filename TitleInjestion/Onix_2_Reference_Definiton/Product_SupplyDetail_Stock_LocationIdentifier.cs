using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_SupplyDetail_Stock_LocationIdentifier
    {
        [XmlElement("IDTypeName", IsNullable = true)]
        public string IDTypeName_ProductSupplyDetailStockLocationIdentifier { get; set; }

        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue_ProductSupplyDetail_StockLocationIdentifier { get; set; }

        [XmlElement("LocationIDType", IsNullable = true)]
        public string LocationIDType_ProductSupplyDetailStockLocationIdentifier { get; set; }

    }
}
