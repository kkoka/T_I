using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_collateraldetail
    {
        
        [XmlElement("textcontent", IsNullable = true)]
        public List<product_collateraldetail_textcontent> obj_productcollateraldetail_textcontent_List = new List<product_collateraldetail_textcontent>();
        
        [XmlElement("supportingresource", IsNullable = true)]
        public List<product_collateraldetail_supportingresource> obj_productcollateraldetail_supportingresource_List = new List<product_collateraldetail_supportingresource>();

    }
}
