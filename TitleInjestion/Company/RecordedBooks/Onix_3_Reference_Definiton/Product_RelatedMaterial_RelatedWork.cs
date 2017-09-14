using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton
{
    public class Product_RelatedMaterial_RelatedWork
    {
        

        [XmlElement("WorkIdentifier", IsNullable = true)]
        public List<Product_RelatedMaterial_RelatedWork_WorkIdentifier> obj_Product_RelatedMaterial_RelatedWork_WorkIdentifier_List = new List<Product_RelatedMaterial_RelatedWork_WorkIdentifier>();




        [XmlElement("WorkRelationCode", IsNullable = true)]
        public string WorkRelationCode { get; set; }


        
    }
}
