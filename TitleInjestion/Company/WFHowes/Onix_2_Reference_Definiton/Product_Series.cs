using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.WFHowes.Onix_2_Reference_Definiton
{
    public class Product_Series
    {
        [XmlElement("NumberWithinSeries", IsNullable = true)]
        public string NumberWithinSeries_ProductSeries { get; set; }


        [XmlElement("SeriesIdentifier", IsNullable = true)]
        public List<Product_Series_SeriesIdentifier> obj_ProductSeriesSeriesIdentifier_List = new List<Product_Series_SeriesIdentifier>();

        [XmlElement("TitleOfSeries", IsNullable = true)]
        public string TitleOfSeries_ProductSeries { get; set; }


    }
}
