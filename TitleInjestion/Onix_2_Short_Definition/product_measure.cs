using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Short_Definition
{
   public class product_measure
    {
       [XmlElement("c093", IsNullable = true)]
       public string c093_product { get; set; }
     
       [XmlElement("c094", IsNullable = true)]
       public string c094_product { get; set; }
      
       [XmlElement("c095", IsNullable = true)]
       public string c095_product { get; set; }
     
       


    }
}
