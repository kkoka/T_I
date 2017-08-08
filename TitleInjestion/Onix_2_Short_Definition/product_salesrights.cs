using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product_salesrights
    {
        [XmlElement("b089", IsNullable = true)]
        public string b089_product_salesrights { get; set; }

        [XmlElement("b090", IsNullable = true)]
        public string b090_product_salesrights { get; set; }

        [XmlElement("b388", IsNullable = true)]
        public string b388_product_salesrights { get; set; }


    
    }
}
