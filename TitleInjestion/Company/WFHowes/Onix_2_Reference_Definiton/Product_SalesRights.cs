using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_SalesRights
    {
        [XmlElement("RightsCountry", IsNullable = true)]
        public string RightsCountry_ProductSalesRights { get; set; }

        [XmlElement("RightsTerritory", IsNullable = true)]
        public string RightsTerritory_ProductSalesRights { get; set; }

        [XmlElement("SalesRightsType", IsNullable = true)]
        public string SalesRightsType_ProductSalesRights { get; set; }

    }
}
