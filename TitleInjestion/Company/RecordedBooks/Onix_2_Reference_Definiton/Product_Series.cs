using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_Series
    {
                   
        [XmlElement("NumberWithinSeries", IsNullable = true)]
        public string NumberWithinSeries_Product_Series { get; set; }

        [XmlElement("SeriesIdentifier", IsNullable = true)]
        public List<Product_Series_SeriesIdentifier> obj_productSeries_SeriesIdentifier_List = new List<Product_Series_SeriesIdentifier>();
        
        [XmlElement("TitleOfSeries", IsNullable = true)]
        public string TitleOfSeries_Product_Series { get; set; }

    }
}
