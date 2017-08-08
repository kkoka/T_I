using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_SupplyDetail_Stock_LocationIdentifier
    {
        [XmlElement("IDTypeName", IsNullable = true)]
        public string IDTypeName_ProductSupplyDetail_Stock_LocationIdentifier { get; set; }
   
        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue_ProductSupplyDetail_Stock_LocationIdentifier { get; set; }

        [XmlElement("ImprintName", IsNullable = true)]
        public string LocationIDType_ProductSupplyDetail_Stock_LocationIdentifier { get; set; }
                               
    }
}
