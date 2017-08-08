using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_MarketRepresentation
    {

        [XmlElement("Measurement", IsNullable = true)]
        public string Measurement_ProductMarketRepresentation { get; set; }
          
            
        [XmlElement("MeasureTypeCode", IsNullable = true)]
        public string MeasureTypeCode_ProductMarketRepresentation { get; set; }
 
            
        [XmlElement("MeasureUnitCode", IsNullable = true)]
        public string MeasureUnitCode_ProductMarketRepresentation { get; set; }
              

    }
}
