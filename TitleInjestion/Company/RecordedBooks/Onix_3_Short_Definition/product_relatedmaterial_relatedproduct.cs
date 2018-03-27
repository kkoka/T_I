using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
   public class product_relatedmaterial_relatedproduct
    {

        [XmlElement("x455", IsNullable = true)]
        public string x455 { get; set; }


        
        [XmlElement("productidentifier", IsNullable = true)]
        public List<product_relatedmaterial_relatedproduct_productidentifier> obj_product_relatedmaterial_relatedproduct_productidentifier = new List<product_relatedmaterial_relatedproduct_productidentifier>();



        [XmlElement("b012", IsNullable = true)]
        public string b012 { get; set; }


    }
}
