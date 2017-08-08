using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitleInjestion.MetaData
{
    public class MetaDataFileAvailability
    {
        public string ID { get; set; }
        public string PubID { get; set; }
        public string PublisherName { get; set; }
        public string MediaType { get; set; }
        public string FileType { get; set; }        
        public string PublisherFilelocation { get; set; }
        public string FileName { get; set; }
        public string OnixVersion { get; set; }
        public string TagType { get; set; }
        public int FileCount { get; set; }
        public string TotalFileSize { get; set; }
        //public List<string> publisherfilename = new List<string>();
        public string XML_Encoding { get; set; }
      
       

    }
}
