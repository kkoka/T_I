using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_supplydetail
    {
        [XmlElement("j135", IsNullable = true)]
        public string j135_product_supplydetail { get; set; }
       
        [XmlElement("j136", IsNullable = true)]
        public string j136_product_supplydetail { get; set; }

        [XmlElement("j137", IsNullable = true)]
        public string j137_product_supplydetail { get; set; }
        
        //check test


        [XmlElement("j138", IsNullable = true)]
        public string j138_product_supplydetail { get; set; }

        [XmlElement("j140", IsNullable = true)]
        public string j140_product_supplydetail { get; set; }
        
        [XmlElement("j141", IsNullable = true)]
        public string j141_product_supplydetail { get; set; }
  
        [XmlElement("j142", IsNullable = true)]
        public string j142_product_supplydetail { get; set; }
 
        [XmlElement("j143", IsNullable = true)]
        public string j143_product_supplydetail { get; set; }
 

        [XmlElement("j144", IsNullable = true)]
        public string j144_product_supplydetail { get; set; }
  
        [XmlElement("j145", IsNullable = true)]
        public string j145_product_supplydetail { get; set; }

        [XmlElement("j146", IsNullable = true)]
        public string j146_product_supplydetail { get; set; }

        [XmlElement("j147", IsNullable = true)]
        public string j147_product_supplydetail { get; set; }



        [XmlElement("j192", IsNullable = true)]
        public string j192_product_supplydetail { get; set; }
  
        [XmlElement("j260", IsNullable = true)]
        public string j260_product_supplydetail { get; set; }
 
        [XmlElement("j268", IsNullable = true)]
        public string j268_product_supplydetail { get; set; }
  
        [XmlElement("j269", IsNullable = true)]
        public string j269_product_supplydetail { get; set; }
 
        [XmlElement("j270", IsNullable = true)]
        public string j270_product_supplydetail { get; set; }
  
        [XmlElement("j271", IsNullable = true)]
        public string j271_product_supplydetail { get; set; }

        [XmlElement("j272", IsNullable = true)]
        public string j272_product_supplydetail { get; set; }
  
        [XmlElement("j292", IsNullable = true)]
        public string j292_product_supplydetail { get; set; }
  
        [XmlElement("j387", IsNullable = true)]
        public string j387_product_supplydetail { get; set; }
  
        [XmlElement("j396", IsNullable = true)]
        public string j396_product_supplydetail { get; set; }
     
        [XmlElement("j397", IsNullable = true)]
        public string j397_product_supplydetail { get; set; }
    
        [XmlElement("j399", IsNullable = true)]
        public string j399_product_supplydetail { get; set; }


        [XmlElement("price", IsNullable = true)]
        public List<product_supplydetail_price> obj_supplydetail_price_List = new List<product_supplydetail_price>();
      
        [XmlElement("supplieridentifier", IsNullable = true)]
        public List<product_supplydetail_supplieridentifier> obj_supplydetail_supplieridentifier_List = new List<product_supplydetail_supplieridentifier>();
       
        [XmlElement("website", IsNullable = true)]
        public List<product_supplydetail_website> obj_supplydetail_website_List = new List<product_supplydetail_website>();
        


    }
}
