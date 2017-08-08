using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_RelatedProduct_ProductIdentifier
    {

        [XmlElement("IDValue", IsNullable = true)]
        public string IDValue_ProductRelatedProduct_ProductIdentifier { get; set; }


        [XmlElement("ProductIDType", IsNullable = true)]
        public string ProductIDType_ProductRelatedProduct_ProductIdentifier { get; set; }
            
    }
}
