using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using TitleInjestion.CommonFunctions;
using System.IO;

namespace TitleInjestion.MetaData
{
    class MetaData_Info
    {
        List<MetaDataFileAvailability> MFA = new List<MetaDataFileAvailability>();
        public DataTable dt_MetaDataPubInfo(string Company, string[] MediaType, string[] PublisherName, System.Windows.Forms.Label lbl_Message)
        {
            DataTable dt = new DataTable();

            SQLFunction sqlfunc_Calls = new SQLFunction();
            dt = sqlfunc_Calls.Get_MetaData_Publisher_Info(Company, MediaType, PublisherName, lbl_Message);
          
            return dt;


       }

        public List<MetaDataFileAvailability> MetaDataPubInfo(string Company, string[] MediaType, string[] PublisherName, System.Windows.Forms.Label lbl_Message)
        {
            DataTable dt = new DataTable();

            SQLFunction sqlfunc_Calls = new SQLFunction();
            dt = sqlfunc_Calls.Get_MetaData_Publisher_Info(Company,  MediaType, PublisherName, lbl_Message);

            List<MetaDataFileAvailability> mfa_1 = new List<MetaDataFileAvailability>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int FileCount = 0;
                string[] fileArray = null;

                if (dt.Rows[i]["FileType"].ToString().ToLower() =="onix")
                {
                    FileCount = Directory.GetFiles(dt.Rows[i]["PublisherFilelocation"].ToString(), "*.xml", SearchOption.TopDirectoryOnly).Length;
                    fileArray = Directory.GetFiles(dt.Rows[i]["PublisherFilelocation"].ToString(), "*.xml", SearchOption.TopDirectoryOnly);
                }

                if (dt.Rows[i]["FileType"].ToString().ToLower() == "excel")
                {
                    FileCount = Directory.GetFiles(dt.Rows[i]["PublisherFilelocation"].ToString(), "*.xls", SearchOption.TopDirectoryOnly).Length;
                    fileArray = Directory.GetFiles(dt.Rows[i]["PublisherFilelocation"].ToString(), "*.xls", SearchOption.TopDirectoryOnly);
                }
               


                for (int j = 0; j < FileCount ; j++)
                {
                    System.IO.FileInfo file_1 = new System.IO.FileInfo(fileArray[j].ToString());


                    MetaDataFileAvailability mfa_2 = new MetaDataFileAvailability();

                    mfa_2.ID = dt.Rows[i]["ID"].ToString();
                    mfa_2.PubID = dt.Rows[i]["PubID"].ToString();
                    mfa_2.PublisherName = dt.Rows[i]["PublisherName"].ToString();
                    mfa_2.MediaType = dt.Rows[i]["MediaType"].ToString();
                    mfa_2.FileType = dt.Rows[i]["FileType"].ToString();
                    mfa_2.PublisherFilelocation = dt.Rows[i]["PublisherFilelocation"].ToString();
                    mfa_2.FileName = file_1.Name;
                    mfa_2.OnixVersion = dt.Rows[i]["OnixVersion"].ToString();
                    mfa_2.TagType = dt.Rows[i]["TagType"].ToString();
                    mfa_2.FileCount = FileCount;
                    mfa_2.TotalFileSize = Convert.ToString(file_1.Length/ 1024); //GetDirectorySize(dt.Rows[i]["PublisherFilelocation"].ToString());
                    mfa_2.XML_Encoding = dt.Rows[i]["XML_Encoding"].ToString();

                    mfa_1.Add(mfa_2);
                }
                
            }

            //  MFA = Add_MetaDataFileNames(mfa_1);

            return mfa_1;


        }

        public List<MetaDataFileAvailability> Add_MetaDataFileNames (List<MetaDataFileAvailability> mfa)
        {
            
            for(int i= 0; i< mfa.Count; i++)
            {
                MetaDataFileAvailability mfa_2 = new MetaDataFileAvailability();

                
                mfa_2.PubID = mfa[i].PubID;
                mfa_2.PublisherName = mfa[i].PublisherName.ToString();
                mfa_2.MediaType = mfa[i].MediaType.ToString();
                mfa_2.PublisherFilelocation = mfa[i].PublisherFilelocation.ToString();
                mfa_2.FileCount = Directory.GetFiles(mfa[i].PublisherFilelocation.ToString(), "*.xml", SearchOption.TopDirectoryOnly).Length;
                mfa_2.TotalFileSize = GetDirectorySize(mfa[i].PublisherFilelocation.ToString());


                MFA.Add(mfa_2);

            }

         

            return MFA;
        }


        public string GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.xml", SearchOption.TopDirectoryOnly);

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return Convert.ToString(b);
        }

    }
}
