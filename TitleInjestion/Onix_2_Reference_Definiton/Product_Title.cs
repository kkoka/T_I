using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_Title
    {
        [XmlElement("Subtitle", IsNullable = true)]
        public string Subtitle_ProductTitle { get; set; }
        
         
        [XmlElement("TitlePrefix", IsNullable = true)]
        public string TitlePrefix_ProductTitle { get; set; }
     
            
        [XmlElement("TitleText", IsNullable = true)]
        public string TitleText_ProductTitle { get; set; }
          
        [XmlElement("TitleType", IsNullable = true)]
        public string TitleType_ProductTitle { get; set; }
    
              
        [XmlElement("TitleWithoutPrefix", IsNullable = true)]
        public string TitleWithoutPrefix_ProductTitle { get; set; }
             

    }
}
