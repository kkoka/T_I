using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;



namespace TitleInjestion.Onix_2_Reference_Definiton
{
    public class Product_Set
    {
        [XmlElement("ItemNumberWithinSet", IsNullable = true)]
        public string ItemNumberWithinSet_ProductSet { get; set; }


        [XmlElement("TitleOfSet", IsNullable = true)]
        public string TitleOfSet_ProductSet { get; set; }


    }
}
