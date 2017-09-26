using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
   public class Product_DescriptiveDetail_Collection_TitleDetail
    {

        [XmlElement("TitleElement", IsNullable = true)]
        public List<Product_DescriptiveDetail_Collection_TitleDetail_TitleElement> obj_Product_DescriptiveDetail_Collection_TitleDetail_TitleElement_List = new List<Product_DescriptiveDetail_Collection_TitleDetail_TitleElement>();

        [XmlElement("TitleType", IsNullable = true)]
        public string TitleType { get; set; }


       
    }
}
