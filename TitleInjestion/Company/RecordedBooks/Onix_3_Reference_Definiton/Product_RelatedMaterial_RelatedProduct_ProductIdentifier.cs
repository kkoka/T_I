using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_RelatedMaterial_RelatedProduct_ProductIdentifier
    {


        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue { get; set; }


        [XmlElement("ProductIDType", IsNullable = true)]
        public string ProductIDType { get; set; }


       
           
    }
}
