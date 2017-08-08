using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_collateraldetail_supportingresource_resourceversion
    {
        [XmlElement("x441", IsNullable = true)]
        public string x441 { get; set; }

        [XmlElement("resourceversionfeature", IsNullable = true)]
        public List<product_collateraldetail_supportingresource_resourceversion_resourceversionfeature> obj_productcollateraldetail_supportingresource_resourceversion_resourceversionfeature_List = new List<product_collateraldetail_supportingresource_resourceversion_resourceversionfeature>();
        
        [XmlElement("x435", IsNullable = true)]
        public string x435 { get; set; }
        
        [XmlElement("contentdate", IsNullable = true)]
        public List<product_collateraldetail_supportingresource_resourceversion_contentdate> obj_productcollateraldetail_supportingresource_resourceversion_contentdate_List = new List<product_collateraldetail_supportingresource_resourceversion_contentdate>();

    }
}
