using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_relatedmaterial
    {
        [XmlElement("relatedproduct", IsNullable = true)]
        public List<product_relatedmaterial_relatedproduct> obj_productrelatedmaterial_relatedproduct_List = new List<product_relatedmaterial_relatedproduct>();

        
    }
}
