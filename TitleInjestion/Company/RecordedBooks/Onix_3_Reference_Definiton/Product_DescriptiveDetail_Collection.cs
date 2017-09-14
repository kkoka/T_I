using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail_Collection
    {
        [XmlElement("CollectionType", IsNullable = true)]
        public string CollectionType { get; set; }

      
        [XmlElement("TitleDetail", IsNullable = true)]
        public List<Product_DescriptiveDetail_Collection_TitleDetail> obj_Product_DescriptiveDetail_Collection_TitleDetail_List = new List<Product_DescriptiveDetail_Collection_TitleDetail>();


    }
}
