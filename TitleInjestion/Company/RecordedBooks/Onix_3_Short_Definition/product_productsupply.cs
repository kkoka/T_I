using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_productsupply
    {
        [XmlElement("supplydetail", IsNullable = true)]
        public List<product_productsupply_supplydetail> obj_productproductsupply_supplydetail_List = new List<product_productsupply_supplydetail>();

    }
}
