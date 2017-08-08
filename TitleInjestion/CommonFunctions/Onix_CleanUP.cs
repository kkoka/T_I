using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.IO.MemoryMappedFiles;
using System.Configuration;



namespace TitleInjestion.CommonFunctions
{
    class Onix_CleanUP
    {
        XElement rootNode;
      //  string cleanedupFilePath1 = @"\\rbencode02\incoming\TitleManagement\TitleIngestionFiles\";
        string cleanedupFilePath = ConfigurationSettings.AppSettings["WFH_cleanedupFilePath"].ToString();

        public string ReferenceTags_ShortTags_Translation(string xmlText)
        {
            xmlText = xmlText.Replace("<!DOCTYPE ONIXmessage SYSTEM \"http://www.editeur.org/onix/2.1/short/onix-international.dtd\" >", "");
            xmlText = xmlText.Replace("<!DOCTYPE ONIXMessage SYSTEM \"http://www.editeur.org/onix/2.1/reference/onix-international.dtd\" >", "");

            xmlText = xmlText.Replace("<!DOCTYPE ONIXmessage SYSTEM \"http://www.editeur.org/onix/2.1/short/onix-international.dtd\">", "");
            xmlText = xmlText.Replace("<!DOCTYPE ONIXMessage SYSTEM \"http://www.editeur.org/onix/2.1/reference/onix-international.dtd\">", "");


            xmlText = xmlText.Replace("<RecordReference>", "<a001>").Replace("<NotificationType>", "<a002>").Replace("<Text>", "<Text><![CDATA[").Replace("<Text textformat=\"02\">", "<Text textformat=\"02\"><![CDATA[").Replace("</Text>", "]]></Text>");
            xmlText = xmlText.Replace("</RecordReference>", "</a001>").Replace("</NotificationType>", "</a002>");
            xmlText = xmlText.Replace("<Text textformat=\"04\">", "<Text textformat=\"04\"><![CDATA[");
            xmlText = xmlText.Replace("<Text textformat=\"05\">", "<Text textformat=\"05\"><![CDATA[");
            xmlText = xmlText.Replace("<Text textformat=\"06\">", "<Text textformat=\"06\"><![CDATA[").Replace("<Text textformat=\"06\"><![CDATA[<![CDATA[", "<Text textformat=\"06\"><![CDATA[");
            xmlText = xmlText.Replace("<Text><![CDATA[<![CDATA[", "<Text><![CDATA[").Replace("<Text textformat=\"02\"><![CDATA[<![CDATA[", "<Text textformat=\"02\"><![CDATA[").Replace("<Text textformat=\"04\"><![CDATA[<![CDATA[", "<Text textformat=\"04\"><![CDATA[").Replace("]]>]]></Text>", "]]></Text>");
            xmlText = xmlText.Replace("<b044>", "<b044><![CDATA[").Replace("</b044>", "]]></b044>").Replace("]]>]]></b044>", "]]></b044>").Replace("<b044 textformat=\"05\">", "<b044 textformat=\"05\"><![CDATA[").Replace("<b044 textformat=\"05\"><![CDATA[<![CDATA[", "<b044 textformat=\"05\"><![CDATA[");
            xmlText = xmlText.Replace("<b044  textformat=\"02\">", "<b044 textformat=\"02\"><![CDATA[").Replace("<b044 textformat=\"02\">", "<b044 textformat=\"02\"><![CDATA[").Replace("<b044 textformat=\"02\"><![CDATA[<![CDATA[", "<b044 textformat=\"02\"><![CDATA[");
            xmlText = xmlText.Replace("<d104 language=\"eng\">", "<d104  language=\"eng\"><![CDATA[").Replace("<d104 language=\"eng\"><![CDATA[<![CDATA[", "<d104 language=\"eng\"><![CDATA[");
            xmlText = xmlText.Replace("<d104 textformat=\"05\">", "<d104 textformat=\"05\"><![CDATA[").Replace("<d104 textformat=\"05\"><![CDATA[<![CDATA[", "<d104 textformat=\"05\"><![CDATA[").Replace("</d104>", "]]></d104>").Replace("]]>]]></d104>", "]]></d104>");
            xmlText = xmlText.Replace("<d104  textformat=\"02\">", "<d104 textformat=\"02\"><![CDATA[").Replace("<d104 textformat=\"02\">", "<d104 textformat=\"02\"><![CDATA[").Replace("<d104 textformat=\"02\"><![CDATA[<![CDATA[", "<d104 textformat=\"02\"><![CDATA[");
            xmlText = xmlText.Replace("<d104 textformat=\"02\" refname=\"Text\" >", "<d104 textformat=\"02\" refname=\"Text\" ><![CDATA[").Replace("<d104 textformat=\"02\">", "<d104 textformat=\"02\"><![CDATA[").Replace("<d104 textformat=\"02\"><![CDATA[<![CDATA[", "<d104 textformat=\"02\"><![CDATA[");
            xmlText = xmlText.Replace("<d104  textformat=\"04\">", "<d104 textformat=\"04\"><![CDATA[").Replace("<d104 textformat=\"04\">", "<d104 textformat=\"04\"><![CDATA[").Replace("<d104 textformat=\"02\" refname=\"Text\" ><![CDATA[<![CDATA[", "<d104 textformat=\"02\" refname=\"Text\" ><![CDATA[");
            xmlText = xmlText.Replace("<b070>", "<b070><![CDATA[").Replace("<b070><![CDATA[<![CDATA[", "<b070><![CDATA[").Replace("</b070>", "]]></b070>").Replace("]]>]]></b070>", "]]></b070>");
            xmlText = xmlText.Replace("]]>\n]]>", "\n]]>").Replace("]]>\r\n]]>", "\r\n]]>");
            xmlText = xmlText.Replace("<d104>", "<d104><![CDATA[").Replace("<d104><![CDATA[<![CDATA[", "<d104><![CDATA[");

            return xmlText;
        }


        public string CleanUP_LargeXMLFiles(FileInfo file, string Company) //, string fullfilepath_Sortfile)
        {
            try
            {
                if (file.Exists)
                {

                           

                  
                        #region 'case 2'

                        int filesize = (int)file.Length;
                        //50000000
                        //if (filesize > 10)
                        //if (filesize > 100000000)
                        //{
                            #region ''
                            string xmltext = "";


                            using (StreamWriter sw1 = new StreamWriter(cleanedupFilePath + file.Name))
                            {

                                using (StreamReader sr = new StreamReader(file.FullName))
                                {
                                    while (sr.Peek() >= 0)
                                    {
                                        //Console.WriteLine(sr.ReadLine());
                                        sw1.WriteLine(ReferenceTags_ShortTags_Translation(SanitizeXmlString(sr.ReadLine())));
                                    }
                                }
                            }

                            #endregion

                            #region 'Sort - commented'

                            //rootNode = XElement.Load(cleanedupFilePath + file.Name);
                            //rootNode.Save(cleanedupFilePath + file.Name);

                            #endregion

                        //}
                        //else
                        //{
                        //    #region ''
                        //        using (StreamReader Reader = new StreamReader(file.FullName))
                        //        {
                        //            StringBuilder Sb1 = new StringBuilder();
                        //            StringBuilder Sb2 = new StringBuilder();

                        //            string line = "";

                        //            Sb1.Append(Reader.ReadToEnd());


                        //            Sb1.Replace("xmlns=\"http://www.editeur.org/onix/2.1/reference\"", "");
                        //            Sb1.Replace("xmlns=\"http://www.editeur.org/onix/2.1/short\"", "");




                        //            rootNode = XElement.Parse(ReferenceTags_ShortTags_Translation(SanitizeXmlString(Sb1.ToString())));


                        //            //SortFile(onix_tagtype);
                        //            rootNode.Save(cleanedupFilePath + file.Name);
                        //            //declaration = @"<?xml version=""1.0"" encoding=""" + xml_Declaration + @"""?>";

                        //        }
                        //    #endregion
                        //}
                        //   SortFile();

                        #endregion


                 


                }
                else
                {
                    throw new FileNotFoundException(file.FullName);

                }
            }
            catch (Exception ex)
            {
                SQLFunction sqlfunction = new SQLFunction();
                sqlfunction.Insert_ErrorLog(sqlfunction.GetConnectionString(Company), ex.ToString());
                //Console.WriteLine(ex.Message.ToString());
                //Console.WriteLine(ex.GetBaseException().ToString());
                //// Console.ReadLine();
                ////CommonFunctions ForEmail = new CommonFunctions();
                ////ForEmail.SendExceptionsInMail("Move Files And Add FileNames Validation - Exception", "<b>Error at Sort_OnixElements</b> " + file.FullName + "<br/>" + ex.Message, "kkoka@recordedbooks.com", "", "");


            }

            return cleanedupFilePath + file.Name;
        }

        public string CleanUP_OnixElements(FileInfo file, string Company) //, string fullfilepath_Sortfile)
        {
            try
            {
                if (file.Exists)
                {

                    using (StreamReader Reader = new StreamReader(file.FullName))
                    {
                        StringBuilder Sb1 = new StringBuilder();
                        StringBuilder Sb2 = new StringBuilder();

                        string line = "";

                        #region 'case 2'

                        int filesize = (int)file.Length;
                        string declaration = "";
                        string xml_Declaration = "";
                        //50000000
                        //if (filesize > 10)
                        if (filesize > 50000000)
                        {
                            #region ''


                            using (StreamReader sr = new StreamReader(file.FullName))
                            {
                                var xDoc = XDocument.Parse(sr.ReadToEnd()); // loading source xml

                                xml_Declaration = xDoc.Declaration.ToString();

                                //string asdf 
                                string rootName = xDoc.Root.Name.ToString();

                                string firstnode = xDoc.FirstNode.ToString();
                                //Console.WriteLine("First Node: " + firstnode);
                                //Console.WriteLine("Root Node: " + rootName);


                                //string asdf = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>";

                                var xmls = xDoc.Root.Elements().ToArray(); // split into elements
                          

                                #region 'Merge'
                                //  harlequin_xml20749 -- xmls.Length

                                string xmltext = "";


                                using (StreamWriter sw1 = new StreamWriter(cleanedupFilePath + file.Name))
                                {

                                    sw1.WriteLine(declaration);

                                    if (rootName.Contains("ONIXMessage"))
                                    {
                                        sw1.WriteLine("<ONIXMessage>");
                                    }
                                    else
                                    {
                                        sw1.WriteLine("<ONIXmessage>");
                                    }

                                    for (int i = 0; i < xmls.Length; i++)
                                    {

                                        xmltext = ReferenceTags_ShortTags_Translation(SanitizeXmlString(xmls[i].ToString()));


                                        sw1.WriteLine(xmltext);
                                    }

                                    //  sw1.WriteLine("</ONIXmessage>");
                                    if (rootName.Contains("ONIXMessage"))
                                    {
                                        sw1.WriteLine("</ONIXMessage>");
                                    }
                                    else
                                    {
                                        sw1.WriteLine("</ONIXmessage>");
                                    }
                                }


                                #endregion

                                #region 'Sort'

                                //rootNode = XElement.Load(cleanedupFilePath + file.Name);
                                //rootNode.Save(cleanedupFilePath + file.Name);
                        

                                #endregion

                                
                            }

                            #endregion
                        }
                        else
                        {
                            #region ''

                            Sb1.Append(Reader.ReadToEnd());


                            Sb1.Replace("xmlns=\"http://www.editeur.org/onix/2.1/reference\"", "");
                            Sb1.Replace("xmlns=\"http://www.editeur.org/onix/2.1/short\"", "");


                          
                            
                                rootNode = XElement.Parse(ReferenceTags_ShortTags_Translation(SanitizeXmlString(Sb1.ToString())));
                     

                            //SortFile(onix_tagtype);
                            rootNode.Save(cleanedupFilePath + file.Name);
                            //declaration = @"<?xml version=""1.0"" encoding=""" + xml_Declaration + @"""?>";

                       
                            #endregion
                        }
                        //   SortFile();

                        #endregion


                    }


                }
                else
                {
                    throw new FileNotFoundException(file.FullName);
                   
                }
            }
            catch (Exception ex)
            {
                SQLFunction sqlfunction = new SQLFunction();
                sqlfunction.Insert_ErrorLog(sqlfunction.GetConnectionString(Company), ex.ToString());
                //Console.WriteLine(ex.Message.ToString());
                //Console.WriteLine(ex.GetBaseException().ToString());
                //// Console.ReadLine();
                ////CommonFunctions ForEmail = new CommonFunctions();
                ////ForEmail.SendExceptionsInMail("Move Files And Add FileNames Validation - Exception", "<b>Error at Sort_OnixElements</b> " + file.FullName + "<br/>" + ex.Message, "kkoka@recordedbooks.com", "", "");


            }

            return cleanedupFilePath + file.Name;
        }


        /// <summary>
        /// Remove illegal XML characters from a string.
        /// </summary>
        public string SanitizeXmlString(string xml)
        {
            if (xml == null)
            {
                throw new ArgumentNullException("xml");
            }

            StringBuilder buffer = new StringBuilder(xml.Length);
            // StringBuilder buffer = new StringBuilder();

            foreach (char c in xml)
            {
                if (IsLegalXmlChar(c))
                {
                    buffer.Append(c);
                }
            }
          //  buffer.Replace("&lt;", "<");
         
            buffer.Replace("<!DOCTYPE ONIXmessage SYSTEM \"http://www.editeur.org/onix/2.1/short/onix-international.dtd\">", "");
            buffer.Replace("<!DOCTYPE ONIXmessage SYSTEM \"http://www.editeur.org/onix/2.1/short/onix-international.dtd\">", "");
            buffer.Replace("<!DOCTYPE ONIXMessage SYSTEM \"http://www.editeur.org/onix/2.1/02/short/onix-international.dtd\">", "");

            return buffer.ToString();
        }

        /// <summary>
        /// Whether a given character is allowed by XML 1.0.
        /// </summary>
        public bool IsLegalXmlChar(int character)
        {
            return
            (
                 character == 0x9 /* == '\t' == 9   */          ||
                 character == 0xA /* == '\n' == 10  */          ||
                 character == 0xD /* == '\r' == 13  */          ||
                (character >= 0x20 && character <= 0xD7FF) ||
                (character >= 0xE000 && character <= 0xFFFD) ||
                (character >= 0x10000 && character <= 0x10FFFF && character != 0X2014)

            );
        }



    }
}
