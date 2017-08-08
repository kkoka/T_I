using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton
{
    public class Product_MediaFile
    {
        [XmlElement("MediaFileDate", IsNullable = true)]
        public string MediaFileDate_ProductMediaFile { get; set; }
    
        [XmlElement("MediaFileFormatCode", IsNullable = true)]
        public string MediaFileFormatCode_ProductMediaFile { get; set; }
  
         
        [XmlElement("MediaFileLink", IsNullable = true)]
        public string MediaFileLink_ProductMediaFile { get; set; }
  
         
        [XmlElement("MediaFileLinkTypeCode", IsNullable = true)]
        public string MediaFileLinkTypeCode_ProductMediaFile { get; set; }
 
          
        [XmlElement("MediaFileTypeCode", IsNullable = true)]
        public string MediaFileTypeCode_ProductMediaFile { get; set; }
             

    }
}
