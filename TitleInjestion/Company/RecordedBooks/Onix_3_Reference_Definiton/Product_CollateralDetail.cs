using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_CollateralDetail
    {
        [XmlElement("TextContent", IsNullable = true)]
        public List<Product_CollateralDetail_TextContent> obj_Product_CollateralDetail_TextContent_List = new List<Product_CollateralDetail_TextContent>();

    }
}
