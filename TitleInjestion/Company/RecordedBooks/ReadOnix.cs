
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition;
using TitleInjestion.Company.RecordedBooks.Onix_2_Reference_Definiton;
using TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition;

namespace TitleInjestion.Company.RecordedBooks
{
    class ReadOnix
    {
        public TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.ONIXmessage Work_With_Onix2shortTags(string filelocation, System.Windows.Forms.Label lbl_Message, System.Windows.Forms.Label lbl_CleanUp, string Company, string MediaType, string FileName, string PublisherName, string OnixVersion, string TagType, string XML_Encoding)
        {

            lbl_CleanUp.BackColor = System.Drawing.Color.Yellow;
            lbl_CleanUp.Refresh();
            System.Windows.Forms.Application.DoEvents();


            #region 'CleanUp ONIX elements'
            TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.ONIXmessage fileInfo_2short = new TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.ONIXmessage();



            //System.IO.FileInfo file_1 = new System.IO.FileInfo(@"C:\Users\kkoka\Desktop\wfh\harpercollins\HCUK_ONIX_full_20141107.xml");

            System.IO.FileInfo file_1 = new System.IO.FileInfo(filelocation);
            string CleanedFile_WithName = "";

            try
            {
                #region ''
                //   System.IO.FileInfo file_1 = new System.IO.FileInfo(file);
                Onix_CleanUP cleanup_xml = new Onix_CleanUP(); //(info, sort_filepath, onix_TagType , xml_encoding);

                CleanedFile_WithName = cleanup_xml.CleanUP_LargeXMLFiles(file_1, Company, MediaType, PublisherName);

                //string CleanedFile_WithName = cleanup_xml.CleanUP_OnixElements(file_1, Company);


                //sing(StreamReader reader = new StreamReader("my.xml", Encoding.UTF8, true)) {
                //    XmlSerializer serializer = new XmlSerializer(typeof(SomeType));

                //    object result = serializer.Deserialize(reader);
                //}

                // Create an instance of stream writer.

                //     TextReader txtReader = new StreamReader(filelocation);
                TextReader txtReader = new StreamReader(CleanedFile_WithName, Encoding.GetEncoding(XML_Encoding));


                // Create and instance of XmlSerializer class.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.ONIXmessage));

                // DeSerialize from the StreamReader
                fileInfo_2short = (TitleInjestion.Company.RecordedBooks.Onix_2_Short_Definition.ONIXmessage)xmlSerializer.Deserialize(txtReader);

                // Close the stream reader
                txtReader.Close();

                lbl_CleanUp.BackColor = System.Drawing.Color.Green;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();

                #endregion
            }
            catch (Exception ex)
            {
                lbl_Message.Text = "There has been some problem cleaning up the file.";
                lbl_Message.Refresh();
                System.Windows.Forms.Application.DoEvents();

                lbl_CleanUp.BackColor = System.Drawing.Color.Red;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();

                CommonFunctions.SQLFunction sqlfnction = new CommonFunctions.SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(Company), "Error Cleaning/Deserializing the " + MediaType + " file : " + FileName + " from the publisher - " + PublisherName + ". Exception : " + ex.ToString());

            }
            finally
            {
                File.Delete(CleanedFile_WithName);
            }

            return fileInfo_2short;

            #endregion


        }
        public ONIXMessage Work_With_Onix2referenceTags(string filelocation, System.Windows.Forms.Label lbl_Message, System.Windows.Forms.Label lbl_CleanUp, string Company, string MediaType, string FileName, string PublisherName, string OnixVersion, string TagType, string XML_Encoding)
        {

            lbl_CleanUp.BackColor = System.Drawing.Color.Yellow;
            lbl_CleanUp.Refresh();
            System.Windows.Forms.Application.DoEvents();


            #region 'CleanUp ONIX elements'

            ONIXMessage fileInfo_2reference = new ONIXMessage();


            //System.IO.FileInfo file_1 = new System.IO.FileInfo(@"C:\Users\kkoka\Desktop\wfh\harpercollins\HCUK_ONIX_full_20141107.xml");

            System.IO.FileInfo file_1 = new System.IO.FileInfo(filelocation);
            string CleanedFile_WithName = "";

            try
            {
                //   System.IO.FileInfo file_1 = new System.IO.FileInfo(file);
                Onix_CleanUP cleanup_xml = new Onix_CleanUP(); //(info, sort_filepath, onix_TagType , xml_encoding);

                CleanedFile_WithName = cleanup_xml.CleanUP_LargeXMLFiles(file_1, Company);

                //string CleanedFile_WithName = cleanup_xml.CleanUP_OnixElements(file_1, Company);




                // Create an instance of stream writer.

                //     TextReader txtReader = new StreamReader(filelocation);
                TextReader txtReader = new StreamReader(CleanedFile_WithName, Encoding.GetEncoding(XML_Encoding));
               
                // Create and instance of XmlSerializer class.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ONIXMessage));

                // DeSerialize from the StreamReader
                fileInfo_2reference = (ONIXMessage)xmlSerializer.Deserialize(txtReader);

                // Close the stream reader
                txtReader.Close();

                lbl_CleanUp.BackColor = System.Drawing.Color.Green;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();


            }
            catch (Exception ex)
            {
                lbl_Message.Text = "There has been some problem cleaning up the file.";
                lbl_Message.Refresh();
                System.Windows.Forms.Application.DoEvents();

                lbl_CleanUp.BackColor = System.Drawing.Color.Red;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();

                CommonFunctions.SQLFunction sqlfnction = new CommonFunctions.SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(Company), "Error Cleaning/Deserializing the " + MediaType + " file : " + FileName + " from the publisher - " + PublisherName + ". Exception : " + ex.ToString());

            }
            finally
            {
                File.Delete(CleanedFile_WithName);
            }

            return fileInfo_2reference;

            #endregion


        }
        public TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition.ONIXmessage Work_With_Onix3shortTags(string filelocation, System.Windows.Forms.Label lbl_Message, System.Windows.Forms.Label lbl_CleanUp, string Company, string MediaType, string FileName, string PublisherName, string OnixVersion, string TagType, string XML_Encoding)
        {

            lbl_CleanUp.BackColor = System.Drawing.Color.Yellow;
            lbl_CleanUp.Refresh();
            System.Windows.Forms.Application.DoEvents();


            #region 'CleanUp ONIX elements'

            TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition.ONIXmessage fileInfo_3short = new TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition.ONIXmessage();


            //System.IO.FileInfo file_1 = new System.IO.FileInfo(@"C:\Users\kkoka\Desktop\wfh\harpercollins\HCUK_ONIX_full_20141107.xml");

            System.IO.FileInfo file_1 = new System.IO.FileInfo(filelocation);
            string CleanedFile_WithName = "";

            try
            {
                //   System.IO.FileInfo file_1 = new System.IO.FileInfo(file);
                Onix_CleanUP cleanup_xml = new Onix_CleanUP(); //(info, sort_filepath, onix_TagType , xml_encoding);

                CleanedFile_WithName = cleanup_xml.CleanUP_LargeXMLFiles(file_1, Company, MediaType, PublisherName);

                //string CleanedFile_WithName = cleanup_xml.CleanUP_OnixElements(file_1, Company);


                //sing(StreamReader reader = new StreamReader("my.xml", Encoding.UTF8, true)) {
                //    XmlSerializer serializer = new XmlSerializer(typeof(SomeType));

                //    object result = serializer.Deserialize(reader);
                //}

                // Create an instance of stream writer.

                //     TextReader txtReader = new StreamReader(filelocation);
                TextReader txtReader = new StreamReader(CleanedFile_WithName, Encoding.GetEncoding(XML_Encoding));


                // Create and instance of XmlSerializer class.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Onix_3_Short_Definition.ONIXmessage));

                // DeSerialize from the StreamReader
                fileInfo_3short = (TitleInjestion.Company.RecordedBooks.Onix_3_Short_Definition.ONIXmessage)xmlSerializer.Deserialize(txtReader);

                // Close the stream reader
                txtReader.Close();

                lbl_CleanUp.BackColor = System.Drawing.Color.Green;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();


            }
            catch (Exception ex)
            {
                lbl_Message.Text = "There has been some problem cleaning up the file.";
                lbl_Message.Refresh();
                System.Windows.Forms.Application.DoEvents();

                lbl_CleanUp.BackColor = System.Drawing.Color.Red;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();

                CommonFunctions.SQLFunction sqlfnction = new CommonFunctions.SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(Company), "Error Cleaning/Deserializing the " + MediaType + " file : " + FileName + " from the publisher - " + PublisherName + ". Exception : " + ex.ToString());

            }
            finally
            {
                File.Delete(CleanedFile_WithName);
            }

            return fileInfo_3short;

            #endregion


        }
        public TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton.ONIXMessage Work_With_Onix3ReferenceTags(string filelocation, System.Windows.Forms.Label lbl_Message, System.Windows.Forms.Label lbl_CleanUp, string Company, string MediaType, string FileName, string PublisherName, string OnixVersion, string TagType, string XML_Encoding)
        {

            lbl_CleanUp.BackColor = System.Drawing.Color.Yellow;
            lbl_CleanUp.Refresh();
            System.Windows.Forms.Application.DoEvents();


            #region 'CleanUp ONIX elements'

            TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton.ONIXMessage fileInfo_3reference = new TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton.ONIXMessage();


            //System.IO.FileInfo file_1 = new System.IO.FileInfo(@"C:\Users\kkoka\Desktop\wfh\harpercollins\HCUK_ONIX_full_20141107.xml");

            System.IO.FileInfo file_1 = new System.IO.FileInfo(filelocation);
            string CleanedFile_WithName = "";

            try
            {
                //   System.IO.FileInfo file_1 = new System.IO.FileInfo(file);
                Onix_CleanUP cleanup_xml = new Onix_CleanUP(); //(info, sort_filepath, onix_TagType , xml_encoding);

                CleanedFile_WithName = cleanup_xml.CleanUP_LargeXMLFiles(file_1, Company, MediaType, PublisherName);

                //string CleanedFile_WithName = cleanup_xml.CleanUP_OnixElements(file_1, Company);


                //sing(StreamReader reader = new StreamReader("my.xml", Encoding.UTF8, true)) {
                //    XmlSerializer serializer = new XmlSerializer(typeof(SomeType));

                //    object result = serializer.Deserialize(reader);
                //}

                // Create an instance of stream writer.

                //     TextReader txtReader = new StreamReader(filelocation);
                TextReader txtReader = new StreamReader(CleanedFile_WithName, Encoding.GetEncoding(XML_Encoding));


                // Create and instance of XmlSerializer class.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Onix_3_Reference_Definiton.ONIXMessage));

                // DeSerialize from the StreamReader
                fileInfo_3reference = (TitleInjestion.Company.RecordedBooks.Onix_3_Reference_Definiton.ONIXMessage)xmlSerializer.Deserialize(txtReader);

                // Close the stream reader
                txtReader.Close();

                lbl_CleanUp.BackColor = System.Drawing.Color.Green;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();


            }
            catch (Exception ex)
            {
                lbl_Message.Text = "There has been some problem cleaning up the file.";
                lbl_Message.Refresh();
                System.Windows.Forms.Application.DoEvents();

                lbl_CleanUp.BackColor = System.Drawing.Color.Red;
                lbl_CleanUp.Refresh();
                System.Windows.Forms.Application.DoEvents();

                CommonFunctions.SQLFunction sqlfnction = new CommonFunctions.SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(Company), "Error Cleaning/Deserializing the " + MediaType + " file : " + FileName + " from the publisher - " + PublisherName + ". Exception : " + ex.ToString());

            }
            finally
            {
                File.Delete(CleanedFile_WithName);
            }

            return fileInfo_3reference;

            #endregion


        }

    }
}
