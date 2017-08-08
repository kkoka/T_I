using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition
{
    public class product_publishingdetail
    {
        [XmlElement("imprint", IsNullable = true)]
        public List<product_publishingdetail_imprint> obj_productpublishingdetail_imprint_List = new List<product_publishingdetail_imprint>();

        [XmlElement("publisher", IsNullable = true)]
        public List<product_publishingdetail_publisher> obj_productpublishingdetail_publisher_List = new List<product_publishingdetail_publisher>();
        
        [XmlElement("b394", IsNullable = true)]
        public List<string> obj_b394_List = new List<string>();


        [XmlElement("publishingdate", IsNullable = true)]
        public List<product_publishingdetail_publishingdate> obj_productpublishingdetail_publishingdate_List = new List<product_publishingdetail_publishingdate>();

        [XmlElement("copyrightstatement", IsNullable = true)]
        public List<product_publishingdetail_copyrightstatement> obj_productpublishingdetail_copyrightstatement_List = new List<product_publishingdetail_copyrightstatement>();
       
        [XmlElement("salesrights", IsNullable = true)]
        public List<product_publishingdetail_salesrights> obj_productpublishingdetail_salesrights_List = new List<product_publishingdetail_salesrights>();
        
        [XmlElement("x456", IsNullable = true)]
        public string x456 { get; set; }

    }
}
