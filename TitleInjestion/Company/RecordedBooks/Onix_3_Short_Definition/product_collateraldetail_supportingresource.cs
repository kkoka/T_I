using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_collateraldetail_supportingresource
    {
        [XmlElement("x436", IsNullable = true)]
        public string x436 { get; set; }

      	[XmlElement("x427", IsNullable = true)]
        public string x427 { get; set; }

      	[XmlElement("x437", IsNullable = true)]
        public string x437 { get; set; }
        
        [XmlElement("resourceversion", IsNullable = true)]
        public List<product_collateraldetail_supportingresource_resourceversion> obj_productcollateraldetail_supportingresource_resourceversion_List = new List<product_collateraldetail_supportingresource_resourceversion>();

    }
}
