using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_DescriptiveDetail_ReligiousText
    {

        [XmlElement("Bible", IsNullable = true)]
        public List<Product_DescriptiveDetail_ReligiousText_Bible> obj_Product_DescriptiveDetail_ReligiousText_Bible_List = new List<Product_DescriptiveDetail_ReligiousText_Bible>();


    }
}
