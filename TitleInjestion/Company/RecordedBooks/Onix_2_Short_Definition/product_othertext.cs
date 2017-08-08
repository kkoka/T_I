using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition
{
    public class product_othertext
    {

        [XmlElement("b374", IsNullable = true)]
        public string b374_product_othertext { get; set; }
     
        [XmlElement("d102", IsNullable = true)]
        public string d102_product_othertext { get; set; }
      
        [XmlElement("d103", IsNullable = true)]
        public string d103_product_othertext { get; set; }

        [XmlElement("d104", IsNullable = true)]
        /* 
           <xs:element name="d104">
                        <xs:complexType>
                          <xs:simpleContent>
                            <xs:extension base="xs:string">
                              <xs:attribute  name="textformat" type="xs:unsignedByte"  />
                            </xs:extension>
                          </xs:simpleContent>
                        </xs:complexType>
                      </xs:element>
         */
        public string d104_product_othertext { get; set; }
              

        [XmlElement("d107", IsNullable = true)]
        public string d107_product_othertext { get; set; }
      
         [XmlElement("d108", IsNullable = true)]
        public string d108_product_othertext { get; set; }
      
         [XmlElement("d109", IsNullable = true)]
        public string d109_product_othertext { get; set; }
      
         
    }
}
