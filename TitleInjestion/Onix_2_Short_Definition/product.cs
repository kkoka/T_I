using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace TitleInjestion.Onix_2_Short_Definition
{
    public class product
    {
        [XmlElement("a001", IsNullable = true)]
        public string a001 { get; set; }     
       
        [XmlElement("a002", IsNullable = true)]
        public string a002 { get; set; }     
       
        [XmlElement("a194", IsNullable = true)]
        public string a194 { get; set; }     
        
        [XmlElement("a197", IsNullable = true)]
        public string a197 { get; set; }

        [XmlElement("audience", IsNullable = true)]
        public List<product_audience> obj_productaudience_List = new List<product_audience>();

        [XmlElement("audiencerange", IsNullable = true)]
        public List<product_audiencerange> obj_productaudiencerange_List = new List<product_audiencerange>();

        [XmlElement("b003", IsNullable = true)]
        public List<string> obj_b003_List = new List<string>();
      
        [XmlElement("b012", IsNullable = true)]
        public List<string> obj_b012_List = new List<string>();
      
        [XmlElement("b014", IsNullable = true)]
        public List<string> obj_b014_List = new List<string>();

        [XmlElement("b049", IsNullable = true)]
        public string b049 { get; set; }

        [XmlElement("b056", IsNullable = true)]
        public List<string> obj_b056_List = new List<string>();

        [XmlElement("b057", IsNullable = true)]
        public List<string> obj_b057_List = new List<string>();
    
        [XmlElement("b058", IsNullable = true)]
        public string b058 { get; set; }

        [XmlElement("b061", IsNullable = true)]
        public List<string> obj_b061_List = new List<string>();
      
        [XmlElement("b062", IsNullable = true)]
        public string b062 { get; set; }

        [XmlElement("b063", IsNullable = true)]
        public string b063 { get; set; }

        [XmlElement("b064", IsNullable = true)]
        public List<string> obj_b064_List = new List<string>();


        [XmlElement("b065", IsNullable = true)]
        public List<string> obj_b065_List = new List<string>();

        [XmlElement("b066", IsNullable = true)]
        public string b066 { get; set; }

        [XmlElement("b072", IsNullable = true)]
        public List<string> obj_b072_List = new List<string>();

        [XmlElement("b073", IsNullable = true)]
        public List<string> obj_b073_List = new List<string>();

        [XmlElement("b081", IsNullable = true)]
        public List<string> obj_b081_List = new List<string>();


        [XmlElement("b083", IsNullable = true)]
        public string b083 { get; set; }

        [XmlElement("b086", IsNullable = true)]
        public string b086 { get; set; }

        [XmlElement("b087", IsNullable = true)]
        public string b087 { get; set; }

        [XmlElement("b088", IsNullable = true)]
        public string b088 { get; set; }

        [XmlElement("b125", IsNullable = true)]
        public string b125 { get; set; }

        [XmlElement("b189", IsNullable = true)]
        public string b189 { get; set; }

        [XmlElement("b190", IsNullable = true)]
        public string b190 { get; set; }

        [XmlElement("b200", IsNullable = true)]
        public string b200 { get; set; }

        [XmlElement("b207", IsNullable = true)]
        public string b207 { get; set; }

        [XmlElement("b209", IsNullable = true)]
        public string b209 { get; set; }

        [XmlElement("b210", IsNullable = true)]
        public string b210 { get; set; }

        [XmlElement("b211", IsNullable = true)]
        public List<string> obj_b211_List = new List<string>();
        
        [XmlElement("b212", IsNullable = true)]
        public string b212 { get; set; }

        [XmlElement("b213", IsNullable = true)]
        public List<string> obj_b213_List = new List<string>();

        [XmlElement("b214", IsNullable = true)]
        public string b214 { get; set; }

        [XmlElement("b216", IsNullable = true)]
        public string b216 { get; set; }

        [XmlElement("b225", IsNullable = true)]
        public string b225 { get; set; }

        [XmlElement("b246", IsNullable = true)]
        public List<string> obj_b246_List = new List<string>();

        [XmlElement("b277", IsNullable = true)]
        public string b277 { get; set; }

        [XmlElement("b333", IsNullable = true)]
        public List<string> obj_b333_List = new List<string>();

        [XmlElement("b362", IsNullable = true)]
        public string b362 { get; set; }

        [XmlElement("b384", IsNullable = true)]
        public string b384 { get; set; }

        [XmlElement("b385", IsNullable = true)]
        public List<string> obj_b385_List = new List<string>();

        [XmlElement("b394", IsNullable = true)]
        public List<string> obj_b394_List = new List<string>();
       
        [XmlElement("b395", IsNullable = true)]
        public string b395 { get; set; }

        [XmlElement("complexity", IsNullable = true)]
        public List<product_complexity> obj_complexity_List = new List<product_complexity>();

        [XmlElement("containeditem", IsNullable = true)]
        public List<product_containeditem> obj_product_containeditem_List = new List<product_containeditem>();

        [XmlElement("contributor", IsNullable = true)]
        public List<product_contributor> obj_contributor_List = new List<product_contributor>();

        [XmlElement("copyrightstatement", IsNullable = true)]
        public List<product_copyrightstatement> obj_copyrightstatement_List = new List<product_copyrightstatement>();


        [XmlElement("d100", IsNullable = true)]
        public string d100 { get; set; }

        [XmlElement("d101", IsNullable = true)]
        public List<string> obj_d101_List = new List<string>();

        [XmlElement("extent", IsNullable = true)]
        public List<product_extent> obj_extent_List = new List<product_extent>();

        [XmlElement("h134", IsNullable = true)]
        public string h134 { get; set; }

        [XmlElement("illustrations", IsNullable = true)]
        public List<product_illustrations> obj_illustrations_List = new List<product_illustrations>();

        [XmlElement("imprint", IsNullable = true)]
        public List<product_imprint> obj_imprint_List = new List<product_imprint>();

        [XmlElement("k167", IsNullable = true)]
        public string k167 { get; set; }

        [XmlElement("language", IsNullable = true)]
        public List<product_language> obj_product_language_List = new List<product_language>();

        [XmlElement("mainsubject", IsNullable = true)]
        public List<product_mainsubject> obj_product_mainsubject_List = new List<product_mainsubject>();

        [XmlElement("marketrepresentation", IsNullable = true)]
        public List<product_marketrepresentation> obj_marketrepresentation_List = new List<product_marketrepresentation>();

        [XmlElement("measure", IsNullable = true)]
        public List<product_measure> obj_measure_List = new List<product_measure>();

        [XmlElement("mediafile", IsNullable = true)]
        public List<product_mediafile> obj_mediafile_List = new List<product_mediafile>();


        [XmlElement("n338", IsNullable = true)]
        public List<string> obj_n338_List = new List<string>();
       
        [XmlElement("n339", IsNullable = true)]
        public string n339 { get; set; }

        [XmlElement("n386", IsNullable = true)]
        public string n386 { get; set; }



        [XmlElement("notforsale", IsNullable = true)]
        public List<product_notforsale> obj_notforsale_List = new List<product_notforsale>();

        [XmlElement("othertext", IsNullable = true)]
        public List<product_othertext> obj_product_othertext_List = new List<product_othertext>();

        [XmlElement("prize", IsNullable = true)]
        public List<product_prize> obj_product_prize_List = new List<product_prize>();

        [XmlElement("productclassification", IsNullable = true)]
        public List<product_productclassification> obj_product_productclassification_List = new List<product_productclassification>();

        [XmlElement("productformfeature", IsNullable = true)]
        public List<product_productformfeature> obj_product_productformfeature_List = new List<product_productformfeature>();

        [XmlElement("personassubject", IsNullable = true)]
        public List<product_personassubject> obj_product_personassubject_List = new List<product_personassubject>();

        [XmlElement("productidentifier", IsNullable = true)]
        public List<product_productidentifier> obj_product_productidentifier_List = new List<product_productidentifier>();


        [XmlElement("productwebsite", IsNullable = true)]
        public List<product_productwebsite> obj_product_productwebsite_List = new List<product_productwebsite>();

        [XmlElement("publisher", IsNullable = true)]
        public List<product_publisher> obj_product_publisher_List = new List<product_publisher>();

        [XmlElement("relatedproduct", IsNullable = true)]
        public List<product_relatedproduct> obj_product_relatedproduct_List = new List<product_relatedproduct>();

        [XmlElement("religioustext", IsNullable = true)]
        public List<product_religioustext> obj_product_religioustext_List = new List<product_religioustext>();

        [XmlElement("salesrestriction", IsNullable = true)]
        public List<product_salesrestriction> obj_product_salesrestriction_List = new List<product_salesrestriction>();

        [XmlElement("salesrights", IsNullable = true)]
        public List<product_salesrights> obj_product_salesrights_List = new List<product_salesrights>();

        [XmlElement("series", IsNullable = true)]
        public List<product_series> obj_product_series_List = new List<product_series>();

        [XmlElement("subject", IsNullable = true)]
        public List<product_subject> obj_product_subject_List = new List<product_subject>();

        [XmlElement("supplydetail", IsNullable = true)]
        public List<product_supplydetail> obj_product_supplydetail_List = new List<product_supplydetail>();

        [XmlElement("title", IsNullable = true)]
        public List<product_title> obj_product_title_List = new List<product_title>();

        [XmlElement("website", IsNullable = true)]
        public List<product_website> obj_product_website_List = new List<product_website>();

        [XmlElement("workidentifier", IsNullable = true)]
        public List<product_workidentifier> obj_product_workidentifier_List = new List<product_workidentifier>();
	  
          
       
         

    }
}
