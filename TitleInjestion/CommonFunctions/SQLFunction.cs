using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Data.OleDb;
using System.Windows.Forms;

namespace TitleInjestion.CommonFunctions
{
    class SQLFunction
    {

        public string GetConnectionString(string Company)
        {

            string connectionString = ConfigurationSettings.AppSettings[Company +"_connString"].ToString();

            return connectionString;
        }
        public void SQLConnections(string Company)
        {
            string connectionstring = GetConnectionString(Company);
        }
        public bool SQLInsert(DataTable dt, string Company)
        {
            bool result = SQLBulkInsert(dt, GetConnectionString(Company));
            return result;
        }

        public int InsertMetaData_Info(int pubid, string FileName, string FileType, string Company)
        {
            //Read the connection string from Web.Config file

            int ID = 0;
              
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand("InsertMetaDataInfo", con);
                    cmd.CommandTimeout = 0;

                    //Specify that the SqlCommand is a stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd.Parameters.AddWithValue("@Pub_ID", pubid);
                    cmd.Parameters.AddWithValue("@FileName", FileName);
                    cmd.Parameters.AddWithValue("@FileType", FileType);

                    //Open the connection and execute the query
                    con.Open();
                    ID = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
               Insert_ErrorLog(GetConnectionString(Company), ex.ToString());
            }

            return ID;
        }


        public bool SQLBulkInsert(DataTable dt, string connectionstring)
        {
            bool result = true;
            try
            { 
                // Copy the DataTable to SQL Server
                using (SqlConnection dbConnection = new SqlConnection(connectionstring))
                {
                    dbConnection.Open();
                    using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                    {
                        s.BulkCopyTimeout = 0;
                        s.DestinationTableName = dt.TableName;
                        foreach (var column in dt.Columns)
                            s.ColumnMappings.Add(column.ToString(), column.ToString());

                        s.WriteToServer(dt);
                    }


                }
            }
            catch (Exception ex)
            {
                result = false;
                Insert_ErrorLog(connectionstring, "Table : "+dt.TableName + ". " +ex.ToString());
            }

            finally
            {

            }
            return result;

        }
        public bool ExecuteProc(string Company, string ProcName)
        {
            bool result = true;
            try
            {

                //Read the connection string from Web.Config file

                using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand(ProcName, con);
                    cmd.CommandTimeout = 0;

                    //Specify that the SqlCommand is a stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
                    //Open the connection and execute the query
                    con.Open();
                    cmd.ExecuteNonQuery();

                 }
            }
            catch (Exception ex)
            {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "Error at Execute Process : "+  ProcName + ". Exception : "+ ex.ToString());

            }

            finally
            {

            }
            return result;

        }
        public bool Execute_DeleteTitleID_Proc(string Company, string Param1)
        {
            bool result;
            //Read the connection string from Web.Config file

            try
            {

                using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand("TI_DeleteProcessedTitlesID", con);
                    cmd.CommandTimeout = 0;

                    //Specify that the SqlCommand is a stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd.Parameters.AddWithValue("@ID", Param1);
                 
                    //Open the connection and execute the query
                    con.Open();
                    cmd.ExecuteNonQuery();

                    //Retrieve the value of the output parameter
                    //  string EmployeeId = outPutParameter.Value.ToString();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "Error at Execute_DeleteTitleID_Proc:" + ex.ToString());

            }

            return result;
        }
        public bool Execute_DeleteContributorID_Proc(string Company, string Param1)
        {
            bool result;
            //Read the connection string from Web.Config file

            try
            {

                using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand("TI_DeleteContributorID", con);
                    cmd.CommandTimeout = 0;

                    //Specify that the SqlCommand is a stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd.Parameters.AddWithValue("@ID", Param1);


                    ////Add the output parameter to the command object
                    //SqlParameter outPutParameter = new SqlParameter();
                    //outPutParameter.ParameterName = "@EmployeeId";
                    //outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    //outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    //cmd.Parameters.Add(outPutParameter);

                    //Open the connection and execute the query
                    con.Open();
                    cmd.ExecuteNonQuery();

                    //Retrieve the value of the output parameter
                    //  string EmployeeId = outPutParameter.Value.ToString();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "Error at Execute_DeleteContributorID_Proc:" + ex.ToString());

            }

            return result;
        }

        public bool Execute_ValidationProc(string Company,string Param1)
        {
            bool result;
            //Read the connection string from Web.Config file

            try
            {

                using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand("TI_MetaDataFieldValidation", con);
                    cmd.CommandTimeout = 0;

                    //Specify that the SqlCommand is a stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd.Parameters.AddWithValue("@Validation_Level", Param1);


                    ////Add the output parameter to the command object
                    //SqlParameter outPutParameter = new SqlParameter();
                    //outPutParameter.ParameterName = "@EmployeeId";
                    //outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    //outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    //cmd.Parameters.Add(outPutParameter);

                    //Open the connection and execute the query
                    con.Open();
                    cmd.ExecuteNonQuery();

                    //Retrieve the value of the output parameter
                    //  string EmployeeId = outPutParameter.Value.ToString();

                    result = true;
                }
            }
            catch(Exception ex)
            {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "Error at Execute_ValidationProc:" + ex.ToString());

            }

            return result;
        }
        //public void Insert_Log(string connectionString, string ErrorStatus, string ErrorMessage)
        //{
        //    //Read the connection string from Web.Config file


        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        //Create the SqlCommand object
        //        SqlCommand cmd = new SqlCommand("Insert_Log", con);

        //        //Specify that the SqlCommand is a stored procedure
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        //Add the input parameters to the command object
        //        cmd.Parameters.AddWithValue("@ErrorStatus", ErrorStatus);
        //        cmd.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);



        //        //Open the connection and execute the query
        //        con.Open();
        //        cmd.ExecuteNonQuery();



        //    }


        //}

       public void Insert_ErrorLog(string connectionString, string ErrorMessage)
        {
            //Read the connection string from Web.Config file


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand("Insert_ErrorLog", con);
                    cmd.CommandTimeout = 0;

                    //Specify that the SqlCommand is a stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);

                    //Open the connection and execute the query
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
            }


        }
  
 
        public bool GetErrorLogCount(string Company, System.Windows.Forms.Button btn_ErrorLog)
        {
            bool result = true;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) From ErrorLog ";

                    Int32 count = (Int32)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                      //  btn_ErrorLog.Text = "Error Log : "  + Convert.ToString(count);
                        btn_ErrorLog.BackColor = System.Drawing.Color.DodgerBlue;
                        btn_ErrorLog.Enabled = true;
                        btn_ErrorLog.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                    }
                    if (count==0)
                    {
                        btn_ErrorLog.Text = "Error Log";
                        btn_ErrorLog.Enabled = false;
                        btn_ErrorLog.BackColor = System.Drawing.Color.DimGray;
                        btn_ErrorLog.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                    }

                }
                catch (Exception ex)
                {
                    result = false;                
                   
                    Insert_ErrorLog(GetConnectionString(Company), "Error at GetErrorLogCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return result;
            
        }
        public bool Delete_ErrorLogs(string Company, string ID)
        {
            bool result = true;
            SqlCommand cmd = null;
            using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                {
                try
                    {
               
                    //Create the SqlCommand object
                    cmd = new SqlCommand("Delete from ErrorLog where id in (" + ID + ")", con);
                    cmd.CommandTimeout = 0;

                    //Specify that the SqlCommand is a stored procedure
                    cmd.CommandType = System.Data.CommandType.Text;


                    //Open the connection and execute the query
                    con.Open();
                    cmd.ExecuteNonQuery();
                 }
            
                catch (Exception ex)
                {
                   result = false;                
                   Insert_ErrorLog(GetConnectionString(Company), "Error at Delete_ErrorLogs:" + ex.ToString());
                }
                finally
                {
                   cmd.Dispose();
                   cmd = null;
                   con.Close();
                }

            }
            return result;
          
        }

        public DataTable GetErrorLogDetails(string Company, System.Windows.Forms.Label lbl_Message, System.Windows.Forms.DataGridView GridView)
        {
            bool result = true;

            DataTable dt = new DataTable();
           
            // Copy the DataTable to SQL Server
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();
               
                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandText = "select Id, Error_Message, LogDateTime From ErrorLog order by id desc ";

                    SqlDataAdapter da = null;

                    using (da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    lbl_Message.Text = "There has been a problem with the request. Please the Error Logs.";
                    lbl_Message.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    result = false;
                    Insert_ErrorLog(GetConnectionString(Company), "Error at Get_MetaData_Publisher_Info:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return dt;
            
        }


        public DataTable Get_MetaData_Publisher_Info(string Company, string[] MediaType, string[] PublisherName, System.Windows.Forms.Label lbl_Message)
        {
            bool result = true;

            string query_MediaType = "";
            
                    for (int i = 0; i < MediaType.Length; i++)
                    {
                        if (i == 0)
                        {
                            query_MediaType = "MediaType in ( '" + MediaType[i].ToString() + "' ";
                        }
                        else
                        {
                            query_MediaType += ", '" + MediaType[i].ToString() + "'";
                        }
                    }

                    if(query_MediaType.Length  > 0)
                    {
                        query_MediaType += ")"; 
                    }



                    string query_PublisherName = "";

                    for (int i = 0; i < PublisherName.Length; i++)
                    {
                        string str_PublisherName = PublisherName[i].ToString();
                        int index = str_PublisherName.IndexOf(':');
                        str_PublisherName = str_PublisherName.Substring(index + 1).Trim();


                        if (i == 0)
                        {
                            query_PublisherName = "publishername  in ( '" + str_PublisherName + "' ";
                        }
                        else
                        {
                            query_PublisherName += ", '" + str_PublisherName + "'";
                        }
                    }



                    if (query_PublisherName.Length > 0)
                    {
                        query_PublisherName += ")";
                    }

                     //  select Id, *From metadata_publisher
                     //  where xml_encoding in ('UTF-8','iso-8859-1') 
	                 //  and publisher_name in ('Oasis',	'RandomHouse',	'Naxos Audiobooks')



                    string query = "";

                    if (query_MediaType.Length>0)
                    {
                        query = query + "where " + query_MediaType ;
                    }

                    if (query_MediaType.Length == 0 && query_PublisherName.Length > 0)
                    {
                        query = query + "where " + query_PublisherName;
                    }

                    if (query_MediaType.Length > 0 && query_PublisherName.Length > 0)
                    {
                        query = query + " and " + query_PublisherName;
                    }


                    DataTable dt = new DataTable();

                    // Copy the DataTable to SQL Server
                    using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
                    {
                        SqlCommand cmd = null;
                        try
                        {
                            dbConnection.Open();
              
                            cmd = dbConnection.CreateCommand();
                            cmd.CommandTimeout = 0;

                            cmd.CommandText = "select Id, PubID, PublisherName, MediaType, FileType, PublisherFilelocation, OnixVersion, XML_Encoding, TagType From metadata_publisher " +  query + " order by PublisherName, MediaType";
                            SqlDataAdapter da = null;

                            using (da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                        catch ( Exception ex)
                        {
                            lbl_Message.Text = "There has been a problem with the request. Please the Error Logs.";
                            lbl_Message.Refresh();
                            System.Windows.Forms.Application.DoEvents();

                            result = false;
                            Insert_ErrorLog(GetConnectionString(Company), "Error at Get_MetaData_Publisher_Info:" + ex.ToString());
                        }
                        finally
                        {
                            cmd.Dispose();
                            cmd = null;
                            dbConnection.Close();
                        }

                    }

                    return dt;
        }

        public bool PopulateMediaType(string Company, System.Windows.Forms.ListBox lstbox)
        {
            bool result = true;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                SqlDataReader sdr = null;
                try
                {
                    dbConnection.Open();
               
                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandText = "select distinct MediaType From metadata_publisher order by MediaType";
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        lstbox.Items.Add(sdr[0]);
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    Insert_ErrorLog(GetConnectionString(Company), "Error at PopulateMediaType:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    sdr = null;
                    dbConnection.Close();
                }

            }
            return result;
 
        }
        
        public bool PopulatePublishers(string Company, string[] MediaType, System.Windows.Forms.ListBox lstbox)
        {
            bool result = true;
            string query = "";

            for(int i = 0; i < MediaType.Length; i++ )
            {
                if(i==0)
                { 
                query = " where MediaType = '" + MediaType[i].ToString() + "' ";
                }
                else
                {
                    query += "or MediaType = '" + MediaType[i].ToString() + "'";
                }
            }

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                SqlDataReader sdr = null;
                try
                {
                    dbConnection.Open();
                
                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandText = "select distinct MediaType + ': ' + PublisherName From metadata_publisher "+ query + " order by 1";
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        lstbox.Items.Add(sdr[0]);
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    Insert_ErrorLog(GetConnectionString(Company), "Error at PopulatePublishers:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    sdr = null;
                    dbConnection.Close();
                }

            }
            return result;
        }

        public bool DisplayTitleCount(string Company, System.Windows.Forms.Button btn_Control)
        {
            bool result = true;
            string query = "select count(*) From Processed_Titles";

            if (Company == "RB")
            {
                query += " where isdonotload = '0'";
            }
            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    Int32 count = (Int32)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        btn_Control.BackColor = System.Drawing.Color.DodgerBlue;
                        btn_Control.Enabled = true;
                        btn_Control.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                    }

                }
                catch (Exception ex)
                {
                    result = false;

                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayTitleCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return result;

        }
        public bool DisplayTitleCount(string Company, System.Windows.Forms.Label label1, System.Windows.Forms.Label lbl_Message)
        {
            bool result = true;

            string query = "select count(*) From Processed_Titles";

            if (Company =="RB")
            {
                query += " where isdonotload = '0'";
            }

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    label1.Text = Convert.ToString(count);

                }
                catch (Exception ex)
                {
                    result = false;

                    label1.Text = "--";
                    label1.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    lbl_Message.Text = "Unfortunately we encountered an error, please try again later.";
                    lbl_Message.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayTitleCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return result; 

        }
        public Int32 DisplayTitleCount_Val1(string Company)
        {
            Int32 count = 0;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                     cmd.CommandText = "select count(*) From Processed_Titles where IsValidated1 = 0 ";

                    count = (Int32)cmd.ExecuteScalar();

                   

                }
                catch (Exception ex)
                {                
                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayTitleCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return count;

        }
        public bool DisplayTitleCount_Val1(string Company, System.Windows.Forms.Label label1, System.Windows.Forms.Label lbl_Message)
        {

            bool result = true;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) From Processed_Titles where IsValidated1 = 0 ";

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    label1.Text = Convert.ToString(count);

                }
                catch (Exception ex)
                {
                    result = false;

                    label1.Text = "--";
                    label1.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    lbl_Message.Text = "Unfortunately we encountered an error, please try again later.";
                    lbl_Message.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayTitleCount_Val1:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return result;

        }
        public bool DisplayTitleCount_Val2(string Company, System.Windows.Forms.Label label1, System.Windows.Forms.Label lbl_Message)
        {

            bool result = true;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) From Processed_Titles where isValidated1 = 1 and isApproved = 1 and isValidated2 = 0 ";

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    label1.Text = Convert.ToString(count);

                }
                catch (Exception ex)
                {
                    result = false;

                    label1.Text = "--";
                    label1.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    lbl_Message.Text = "Unfortunately we encountered an error, please try again later.";
                    lbl_Message.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayTitleCount_Val2:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return result;

        }
        public Int32 DisplayApprovedTitleCount(string Company)
        {
            Int32 count = 0;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) From Processed_Titles where isApproved = 1 and isValidated1=1 ";

                    count = (Int32)cmd.ExecuteScalar();
                   

                }
                catch (Exception ex)
                {
                   
                    System.Windows.Forms.Application.DoEvents();

                  
                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayApprovedTitleCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return count;

        }
        public bool DisplayApprovedTitleCount(string Company, System.Windows.Forms.Label label1, System.Windows.Forms.Label lbl_Message)
        {

            bool result = true;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) From Processed_Titles where isApproved = 1 and isValidated1=1 ";

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    label1.Text = Convert.ToString(count);

                }
                catch (Exception ex)
                {
                    result = false;

                    label1.Text = "--";
                    label1.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    lbl_Message.Text = "Unfortunately we encountered an error, please try again later.";
                    lbl_Message.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayApprovedTitleCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return result;

        }        
        public bool DisplayContributorCount(string Company, System.Windows.Forms.Label label1, System.Windows.Forms.Label lbl_Message)
        {

            bool result = true;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) From PublisherContributorData ";

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    label1.Text = Convert.ToString(count);

                }
                catch (Exception ex)
                {
                    result = false;

                    label1.Text = "--";
                    label1.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    lbl_Message.Text = "Unfortunately we encountered an error, please try again later.";
                    lbl_Message.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayContributorCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return result;

        }

        public Int32 DisplayOfframpTitleCount(string Company)
        {
            Int32 count = 0;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) From Pub_offramp ";

                    count = (Int32)cmd.ExecuteScalar();


                }
                catch (Exception ex)
                {

                    System.Windows.Forms.Application.DoEvents();


                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayOfframpTitleCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return count;

        }
        public bool DisplayOfframpTitleCount(string Company, System.Windows.Forms.Label label1, System.Windows.Forms.Label lbl_Message)
        {
            bool result = true;

            using (SqlConnection dbConnection = new SqlConnection(GetConnectionString(Company)))
            {
                SqlCommand cmd = null;
                try
                {
                    dbConnection.Open();

                    cmd = dbConnection.CreateCommand();
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) From Pub_offramp ";

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    label1.Text = Convert.ToString(count);

                }
                catch (Exception ex)
                {
                    result = false;

                    label1.Text = "--";
                    label1.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    lbl_Message.Text = "Unfortunately we encountered an error, please try again later.";
                    lbl_Message.Refresh();
                    System.Windows.Forms.Application.DoEvents();

                    Insert_ErrorLog(GetConnectionString(Company), "Error at DisplayOfframpTitleCount:" + ex.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    dbConnection.Close();
                }

            }

            return result;


        }

        public DataTable ReadExcel(string filePath, DataTable dt_Excel)
        {


         
            //    string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"", filePath);
            DataTable table = new DataTable();
            DataTable dtSchema = new DataTable();


            //  ArrayList SheetName = new ArrayList();

            string strConn = "";

            if (filePath.ToLower().EndsWith("xls"))
            {
                strConn = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34 + "';";
            }
            else if (filePath.ToLower().EndsWith("xlsx"))
            {
                //     strConn_working = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=YES" + (char)34;
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34;
                //      strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel14.0;HDR=YES;IMEX=1;" + (char)34; 
            }

            using (OleDbConnection dbConnection = new OleDbConnection(strConn))
            {
                dbConnection.Open();

                dtSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


                //      string filep = "\\\\rbencode02\\incoming\\titlemanagement\\metadata\\highbridge\\Library_HighBridge_091912.xls"

                string[] worksheet_names = new string[dtSchema.Rows.Count];
                string SheetName = "";

                string[] SheetName_1 = filePath.Split('\\');
                //if (SheetName_1[5].ToString().ToLower() == "highbridgeaudio")
                //{
                //    SheetName = "Metadata$";
                //}
                //else if(SheetName_1[6].ToString().ToLower() == "audiogo" && SheetName_1[7].ToLower().EndsWith(".xlsx"))
                //{                         
                //    for (int i = 0; i < dtSchema.Rows.Count; i++)
                //    {
                //        worksheet_names[i] = dtSchema.Rows[i]["TABLE_NAME"].ToString();
                //    }
                //}
                //else
                //{
                    SheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                    for (int ii = 0; ii < dtSchema.Rows.Count; ii++)
                    {
                        string sheeetname = dtSchema.Rows[ii]["TABLE_NAME"].ToString();
                        if (sheeetname != "_xlnm#_FilterDatabase")
                        {
                            SheetName = sheeetname;
                            break;
                        }
                    }
                //}

                #region 'Load Excel Data in Result Dataset'

                #region 'comment'
                //if (SheetName_1[6].ToString().ToLower() == "audiogo" && SheetName_1[7].ToLower().EndsWith(".xlsx"))
                //{
                //    for (int i = 0; i < dtSchema.Rows.Count; i++)
                //    {
                //        using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [" + worksheet_names[i] + "]", dbConnection)) //rename sheet if required!

                //        dbAdapter.Fill(result,worksheet_names[i].ToString());
                //        //result.Tables.Add(table);
                //        //int rows = table.Rows.Count;
                //    }
                //}
                #endregion

                using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [" + SheetName + "]", dbConnection)) //rename sheet if required!

                    dbAdapter.Fill(table);
                table = table.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();

                //for( int r=0; r< table.Rows.Count; r++)
                //{
                //    for( int i=0; i< table.Columns.Count; i++)
                //    {
                //        Console.WriteLine(i + ": " + table.Rows[r][i].ToString());
                //    }
                //     Console.WriteLine(r + " New row ----------------------------- "); 


                //}
               
                #endregion

                dbConnection.Close();
            }

            return table;
        }

        public DataTable ReadExcel(string Company, string filePath, string TableName = "" )
        {
            ImpersonateUser iU = new ImpersonateUser();

            if (Company =="WFH")
            {
            iU.Undo();
            }

            //    string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"", filePath);
            DataTable table = new DataTable();
            DataTable dtSchema = new DataTable();
            string step = "";
            try
            {
                int i1 = 0;


                //  ArrayList SheetName = new ArrayList();

                string strConn = "";

                if (filePath.ToLower().EndsWith("xls"))
                {
                    strConn = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34 + "';";
                }
                else if (filePath.ToLower().EndsWith("xlsx"))
                {
                    //     strConn_working = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=YES" + (char)34;
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34;
                    //      strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel14.0;HDR=YES;IMEX=1;" + (char)34; 
                }

                using (OleDbConnection dbConnection = new OleDbConnection(strConn))
                {
                    dbConnection.Open();
                    dtSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    //      string filep = "\\\\rbencode02\\incoming\\titlemanagement\\metadata\\highbridge\\Library_HighBridge_091912.xls"

                    //   string[] worksheet_names = new string[dtSchema.Rows.Count];

                    string SheetName = "";

                    //string[] SheetName_1 = filePath.Split('\\');

                    //if (SheetName_1[5].ToString().ToLower() == "highbridgeaudio")
                    //{
                    //    SheetName = "Metadata$";
                    //}
                    //else if(SheetName_1[6].ToString().ToLower() == "audiogo" && SheetName_1[7].ToLower().EndsWith(".xlsx"))
                    //{                         
                    //    for (int i = 0; i < dtSchema.Rows.Count; i++)
                    //    {
                    //        worksheet_names[i] = dtSchema.Rows[i]["TABLE_NAME"].ToString();
                    //    }
                    //}
                    //else
                    //{
                    if (TableName.Length == 0)
                    {
                        SheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                        for (int ii = 0; ii < dtSchema.Rows.Count; ii++)
                        {
                            string sheeetname = dtSchema.Rows[ii]["TABLE_NAME"].ToString();
                            if (sheeetname != "_xlnm#_FilterDatabase")
                            {
                                SheetName = sheeetname;
                                break;
                            }
                        }
                    }
                    else
                    {
                        SheetName = TableName;
                    }
                    
                    //}
                   
                    #region 'Load Excel Data in Result Dataset'

                    #region 'comment'
                    //if (SheetName_1[6].ToString().ToLower() == "audiogo" && SheetName_1[7].ToLower().EndsWith(".xlsx"))
                    //{
                    //    for (int i = 0; i < dtSchema.Rows.Count; i++)
                    //    {
                    //        using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [" + worksheet_names[i] + "]", dbConnection)) //rename sheet if required!

                    //        dbAdapter.Fill(result,worksheet_names[i].ToString());
                    //        //result.Tables.Add(table);
                    //        //int rows = table.Rows.Count;
                    //    }
                    //}
                    #endregion


                    using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [" + SheetName + "]", dbConnection)) //rename sheet if required!
                        dbAdapter.Fill(table);


                    table = table.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();


                    //for( int r=0; r< table.Rows.Count; r++)
                    //{
                    //    for( int i=0; i< table.Columns.Count; i++)
                    //    {
                    //        Console.WriteLine(i + ": " + table.Rows[r][i].ToString());
                    //    }
                    //     Console.WriteLine(r + " New row ----------------------------- "); 


                    //}
                    //result.Tables.Add(table);
                    int rows = table.Rows.Count;

                    #endregion

                    dbConnection.Close();
                }

            }

            catch (Exception ex)
            {
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(Company), "Error at ReadExcel : " + ex.ToString());
            }
            finally
            {
                if (Company == "WFH")
                {
                    iU.Impersonate();
                }
            }


            return table;
        }

        public DataTable ReadExcel_1(string Company, string filePath)
        {
            ImpersonateUser iU = new ImpersonateUser();

            if (Company == "WFH")
            {
                iU.Undo();
            }

            //    string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"", filePath);
            DataTable table = new DataTable();
            DataTable dtSchema = new DataTable();
            string step = "";
            try
            {
                int i1 = 0;


                //  ArrayList SheetName = new ArrayList();

                string strConn = "";

                if (filePath.ToLower().EndsWith("xls"))
                {
                    strConn = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34 + "';";
                }
                else if (filePath.ToLower().EndsWith("xlsx"))
                {
                    //     strConn_working = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=YES" + (char)34;
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34;
                    //      strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=" + (char)34 + "Excel14.0;HDR=YES;IMEX=1;" + (char)34; 
                }

                using (OleDbConnection dbConnection = new OleDbConnection(strConn))
                {
                    dbConnection.Open();
                    dtSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    //      string filep = "\\\\rbencode02\\incoming\\titlemanagement\\metadata\\highbridge\\Library_HighBridge_091912.xls"

                    string[] worksheet_names = new string[dtSchema.Rows.Count];
                    string SheetName = "";

                    string[] SheetName_1 = filePath.Split('\\');

                    //if (SheetName_1[5].ToString().ToLower() == "highbridgeaudio")
                    //{
                    //    SheetName = "Metadata$";
                    //}
                    //else if(SheetName_1[6].ToString().ToLower() == "audiogo" && SheetName_1[7].ToLower().EndsWith(".xlsx"))
                    //{                         
                    //    for (int i = 0; i < dtSchema.Rows.Count; i++)
                    //    {
                    //        worksheet_names[i] = dtSchema.Rows[i]["TABLE_NAME"].ToString();
                    //    }
                    //}
                    //else
                    //{

                    SheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                    for (int ii = 0; ii < dtSchema.Rows.Count; ii++)
                    {
                        string sheeetname = dtSchema.Rows[ii]["TABLE_NAME"].ToString();
                        if (sheeetname != "_xlnm#_FilterDatabase")
                        {
                            SheetName = sheeetname;
                            break;
                        }
                    }
                    //}

                    #region 'Load Excel Data in Result Dataset'

                    #region 'comment'
                    //if (SheetName_1[6].ToString().ToLower() == "audiogo" && SheetName_1[7].ToLower().EndsWith(".xlsx"))
                    //{
                    //    for (int i = 0; i < dtSchema.Rows.Count; i++)
                    //    {
                    //        using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [" + worksheet_names[i] + "]", dbConnection)) //rename sheet if required!

                    //        dbAdapter.Fill(result,worksheet_names[i].ToString());
                    //        //result.Tables.Add(table);
                    //        //int rows = table.Rows.Count;
                    //    }
                    //}
                    #endregion


                    using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [" + SheetName + "]", dbConnection)) //rename sheet if required!
                        dbAdapter.Fill(table);


                    table = table.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();


                    //for( int r=0; r< table.Rows.Count; r++)
                    //{
                    //    for( int i=0; i< table.Columns.Count; i++)
                    //    {
                    //        Console.WriteLine(i + ": " + table.Rows[r][i].ToString());
                    //    }
                    //     Console.WriteLine(r + " New row ----------------------------- "); 


                    //}
                    //result.Tables.Add(table);
                    int rows = table.Rows.Count;

                    #endregion

                    dbConnection.Close();
                }

            }

            catch (Exception ex)
            {
                SQLFunction sqlfnction = new SQLFunction();
                sqlfnction.Insert_ErrorLog(sqlfnction.GetConnectionString(Company), "Error at ReadExcel : " + ex.ToString());
            }
            finally
            {
                if (Company == "WFH")
                {
                    iU.Impersonate();
                }
            }


            return table;
        }


        public bool UploadFile_RBMetaData(string Company, string FilePathName)
        {
            bool result = true;

            #region ''
            try
            {
                //Upload and save the file

               
                 string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                //                string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePathName + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34;
             //    string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text'";

                //   string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34;
                //conString = string.Format(conString, FilePathName);

                conString = string.Format(conString, FilePathName);


                string username1 = System.Environment.UserName.ToString();

                //ImpersonateUser iU = new ImpersonateUser();
                //iU.Undo();

                string username = System.Environment.UserName.ToString();

                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();

                    #region 'read excel file'



                    dtExcelData.Columns.AddRange(new DataColumn[50] {

                        new DataColumn("File Type", typeof(string)),
                        new DataColumn("Errors", typeof(string)),
                        new DataColumn("Publisher Name", typeof(string)),
                        new DataColumn("ISBN", typeof(string)),
                        new DataColumn("Title", typeof(string)),
                        new DataColumn("Original Title", typeof(string)),
                        new DataColumn("Sub Title", typeof(string)),
                        new DataColumn("Original SubTitle", typeof(string)),
                        new DataColumn("EditionNumber", typeof(string)),
                        new DataColumn("DigitalFormat", typeof(string)),
                        new DataColumn("Authors", typeof(string)),
                        new DataColumn("Narrators", typeof(string)),
                        new DataColumn("Illustrator", typeof(string)),
                        new DataColumn("Editor", typeof(string)),
                        new DataColumn("Reader", typeof(string)),
                        new DataColumn("Corporate Authors", typeof(string)),
                        new DataColumn("Translator", typeof(string)),
                        new DataColumn("Photographer", typeof(string)),
                        new DataColumn("Unabridged", typeof(string)),
                        new DataColumn("Edition Type Code", typeof(string)),
                        new DataColumn("BISAC", typeof(string)),
                        new DataColumn("Min Age", typeof(string)),
                        new DataColumn("AgeGroup", typeof(string)),
                        new DataColumn("Publish Date", typeof(string)),
                        new DataColumn("Release Date", typeof(string)),
                        new DataColumn("Total Run Time",typeof(string)),
                        new DataColumn("Language", typeof(string)),
                        new DataColumn("Fiction", typeof(string)),
                        new DataColumn("DRM Flag",typeof(string)),
                        new DataColumn("Media Type",typeof(string)),
                        new DataColumn("Library Price",typeof(string)),
                        new DataColumn("Library Price CAD",typeof(string)),
                        new DataColumn("Description",typeof(string)),
                        new DataColumn("Series Name", typeof(string)),
                        new DataColumn("Original Series Name", typeof(string)),
                        new DataColumn("Series Position Number", typeof(string)),
                        new DataColumn("Status", typeof(string)),
                        new DataColumn("Trilogy Status", typeof(string)),
                        new DataColumn("PageCount", typeof(string)),
                        new DataColumn("RightsCountry", typeof(string)),
                        new DataColumn("Not_For_Sale_In_US", typeof(string)),
                        new DataColumn("Manual_Correction_For_RightsCountry", typeof(string)),
                        new DataColumn("Add To DoNot Load", typeof(string)),
                        new DataColumn("Reason Code", typeof(string)),
                        new DataColumn("ID", typeof(string)),
                        new DataColumn("PubID", typeof(string)),
                        new DataColumn("Delta/ New", typeof(string)),
                        new DataColumn("filename", typeof(string)),
                        new DataColumn("parent_publishername", typeof(string)),
                        new DataColumn("imprint_publisher_accountno", typeof(string)) });
                                  

                    #endregion


                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }
                    excel_con.Close();

                    string asdf = "";
                    for(int i = 0; i<dtExcelData.Rows.Count;i++)
                    {
                        for (int j = 0; j < dtExcelData.Columns.Count; j++)
                        {
                            asdf += dtExcelData.Rows[i][j].ToString() + "<->";
                        }
                        
                    }


                    //iU.Impersonate();
                    //username = System.Environment.UserName.ToString();

                    #region 'SQLBULKCOPY'
                    using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.[Approved_Titles]";
                            sqlBulkCopy.BulkCopyTimeout = 0;

                            //[OPTIONAL]: Map the Excel columns with that of the database table


                                sqlBulkCopy.ColumnMappings.Add("File Type", "FileType");
                              //  sqlBulkCopy.ColumnMappings.Add("Errors", "ErrorMessage");
                                sqlBulkCopy.ColumnMappings.Add("Publisher Name", "PublisherName");
                                sqlBulkCopy.ColumnMappings.Add("ISBN", "ISBN");
                                sqlBulkCopy.ColumnMappings.Add("Title", "Title");
                                sqlBulkCopy.ColumnMappings.Add("Original Title", "Original_Title");
                                sqlBulkCopy.ColumnMappings.Add("Sub Title", "SubTitle");
                                sqlBulkCopy.ColumnMappings.Add("Original SubTitle", "Original_SubTitle");
                                sqlBulkCopy.ColumnMappings.Add("EditionNumber", "EditionNumber");
                                sqlBulkCopy.ColumnMappings.Add("DigitalFormat", "DigitalFormat");
                                sqlBulkCopy.ColumnMappings.Add("Authors", "Authors");
                                sqlBulkCopy.ColumnMappings.Add("Narrators", "Narrators");
                                sqlBulkCopy.ColumnMappings.Add("Illustrator", "Illustrator");
                                sqlBulkCopy.ColumnMappings.Add("Editor", "Editor");
                                sqlBulkCopy.ColumnMappings.Add("Reader", "Reader");
                                sqlBulkCopy.ColumnMappings.Add("Corporate Authors", "CorporateAuthors");
                                sqlBulkCopy.ColumnMappings.Add("Translator", "Translator");
                                sqlBulkCopy.ColumnMappings.Add("Photographer", "Photographer");
                                sqlBulkCopy.ColumnMappings.Add("Unabridged", "Unabridged");
                                sqlBulkCopy.ColumnMappings.Add("Edition Type Code", "EditionTypeCode");
                                sqlBulkCopy.ColumnMappings.Add("BISAC", "BISAC");
                                sqlBulkCopy.ColumnMappings.Add("Min Age", "MinAge");
                                sqlBulkCopy.ColumnMappings.Add("AgeGroup", "AgeGroup");
                                sqlBulkCopy.ColumnMappings.Add("Publish Date", "PublishDate");
                                sqlBulkCopy.ColumnMappings.Add("Release Date", "ReleaseDate");
                                sqlBulkCopy.ColumnMappings.Add("Total Run Time", "TotalRunTime");
                                sqlBulkCopy.ColumnMappings.Add("Language", "Language");
                                sqlBulkCopy.ColumnMappings.Add("Fiction", "Fiction");
                                sqlBulkCopy.ColumnMappings.Add("DRM Flag", "DRM_Flag");
                                sqlBulkCopy.ColumnMappings.Add("Media Type", "MediaType");
                                sqlBulkCopy.ColumnMappings.Add("Library Price", "LibraryPrice_USD");
                                sqlBulkCopy.ColumnMappings.Add("Library Price CAD", "LibraryPrice_CAD");
                                sqlBulkCopy.ColumnMappings.Add("Description", "Description");
                                sqlBulkCopy.ColumnMappings.Add("Series Name", "SeriesName");
                                sqlBulkCopy.ColumnMappings.Add("Original Series Name", "Original_SeriesName");
                                sqlBulkCopy.ColumnMappings.Add("Series Position Number", "SeriesPositionNumber");
                                sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                                sqlBulkCopy.ColumnMappings.Add("Trilogy Status", "Trilogy_Status");
                                sqlBulkCopy.ColumnMappings.Add("PageCount", "PageCount");
                                sqlBulkCopy.ColumnMappings.Add("RightsCountry", "RightsCountry");
                         //   sqlBulkCopy.ColumnMappings.Add("Not_For_Sale_In_US", "");
                                sqlBulkCopy.ColumnMappings.Add("Manual_Correction_For_RightsCountry", "Manual_Correction_For_RightsCountry");
                                sqlBulkCopy.ColumnMappings.Add("Add To DoNot Load", "AddToDoNotLoad");
                                sqlBulkCopy.ColumnMappings.Add("Reason Code", "ReasonCode");
                                sqlBulkCopy.ColumnMappings.Add("ID", "ID");
                                sqlBulkCopy.ColumnMappings.Add("PubID", "PubID");
                         //   sqlBulkCopy.ColumnMappings.Add("Delta/ New", "");
                                sqlBulkCopy.ColumnMappings.Add("filename", "FileName");
                                sqlBulkCopy.ColumnMappings.Add("parent_publishername", "Parent_PublisherName");
                                sqlBulkCopy.ColumnMappings.Add("imprint_publisher_accountno", "Imprint_Publisher_AccountNo");
                            

                            con.Open();


                            sqlBulkCopy.WriteToServer(dtExcelData);

                            con.Close();
                        }
                    }

                    #endregion

                }
            }
            catch (Exception ex)
             {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "USERNAME:" + System.Environment.UserName.ToString() + ". -- Error at UploadFile Process : File: " + FilePathName + ". Exception : " + ex.ToString());

                MessageBox.Show("There has been some issue during Contributor Generation.");
            }

            finally
            {

            }

            #endregion

            return result;

        }
        public bool UploadFile_RBMetaData2(string Company, string FilePathName)
        {
            bool result = true;

#region ''
            try
            {
                //Upload and save the file

              
                // string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePathName + ";Extended Properties=" + (char)34 + "Excel 12.0 XML;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text" + (char)34;

                //conString = string.Format(conString, FilePathName);

                ImpersonateUser iU = new ImpersonateUser();
                iU.Undo();

                string username = System.Environment.UserName.ToString();

                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();

#region 'read excel file'



                    dtExcelData.Columns.AddRange(new DataColumn[49] {
                        new DataColumn("File Type", typeof(string)),
                        new DataColumn("Errors", typeof(string)),
                        new DataColumn("parent_publishername", typeof(string)),
                        new DataColumn("imprint_publisher_accountno", typeof(string)),
                        new DataColumn("Publisher Name", typeof(string)),
                        new DataColumn("ISBN", typeof(string)),
                        new DataColumn("Title", typeof(string)),
                        new DataColumn("Original Title", typeof(string)),
                        new DataColumn("Sub Title", typeof(string)),
                        new DataColumn("Original SubTitle", typeof(string)),
                        new DataColumn("EditionNumber", typeof(string)),
                        new DataColumn("Authors", typeof(string)),
                        new DataColumn("Narrators", typeof(string)),
                        new DataColumn("Illustrator", typeof(string)),
                        new DataColumn("Editor", typeof(string)),
                        new DataColumn("Reader", typeof(string)),
                        new DataColumn("Corporate Authors", typeof(string)),
                        new DataColumn("Translator", typeof(string)),
                        new DataColumn("Photographer", typeof(string)),
                        new DataColumn("Total Run Time", typeof(string)),
                        new DataColumn("Unabridged", typeof(string)),
                        new DataColumn("Language", typeof(string)),
                        new DataColumn("BISAC", typeof(string)),
                        new DataColumn("Min Age", typeof(string)),
                        new DataColumn("Publish Date",typeof(string)),
                        new DataColumn("Release Date", typeof(string)),
                        new DataColumn("Library Price", typeof(string)),
                        new DataColumn("Library Price CAD",typeof(string)),
                        new DataColumn("Fiction",typeof(string)),
                        new DataColumn("DRM Flag",typeof(string)),
                        new DataColumn("Media Type",typeof(string)),
                        new DataColumn("Description",typeof(string)),
                        new DataColumn("Series Name", typeof(string)),
                        new DataColumn("Original Series Name", typeof(string)),
                        new DataColumn("Series Position Number", typeof(string)),
                        new DataColumn("Status", typeof(string)),
                        new DataColumn("Add To DoNot Load", typeof(string)),
                        new DataColumn("Reason Code", typeof(string)),
                        new DataColumn("Delta / New", typeof(string)),
                        new DataColumn("ID", typeof(string)),
                        new DataColumn("PubID", typeof(string)),
                        new DataColumn("filename", typeof(string)),
                        new DataColumn("PageCount", typeof(string)),
                        new DataColumn("RightsCountry", typeof(string)),
                        new DataColumn("Manual_Correction_For_RightsCountry", typeof(string)),
                        new DataColumn("Not_For_Sale_In_US", typeof(string)),
                        new DataColumn("Trilogy Status", typeof(string)),
                        new DataColumn("Edition Type Code", typeof(string)),
                        new DataColumn("DigitalFormat", typeof(string)) });

#endregion


                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }
                    excel_con.Close();

                    iU.Impersonate();
                    username = System.Environment.UserName.ToString();

#region 'SQLBULKCOPY'
                    using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.[Approved_Titles]";
                            sqlBulkCopy.BulkCopyTimeout = 0;

                            //[OPTIONAL]: Map the Excel columns with that of the database table


                            sqlBulkCopy.ColumnMappings.Add("File Type", "FileType");
                            sqlBulkCopy.ColumnMappings.Add("Errors", "ErrorMessage");
                            sqlBulkCopy.ColumnMappings.Add("Agent Parent PublisherName", "Agent_ParentPublisherName");
                            sqlBulkCopy.ColumnMappings.Add("Agent PartnerID", "Agent_PartnerID");
                            sqlBulkCopy.ColumnMappings.Add("Agent AccountID", "Agent_AccountID");
                            sqlBulkCopy.ColumnMappings.Add("Publisher Name", "PublisherName");
                            sqlBulkCopy.ColumnMappings.Add("Publisher PartnerID", "Publisher_PartnerID");
                            sqlBulkCopy.ColumnMappings.Add("Imprint Name", "ImprintName");
                            sqlBulkCopy.ColumnMappings.Add("Imprint PartnerID", "Imprint_PartnerID");
                            sqlBulkCopy.ColumnMappings.Add("ISBN", "ISBN");
                            sqlBulkCopy.ColumnMappings.Add("Title", "Title");
                            sqlBulkCopy.ColumnMappings.Add("Original Title", "OriginalTitle");
                            sqlBulkCopy.ColumnMappings.Add("Sub Title", "SubTitle");
                            sqlBulkCopy.ColumnMappings.Add("Original SubTitle", "OriginalSubTitle");
                            sqlBulkCopy.ColumnMappings.Add("Authors", "Authors");
                            sqlBulkCopy.ColumnMappings.Add("Corporate Authors", "CorporateAuthors");
                            sqlBulkCopy.ColumnMappings.Add("Editor", "Editor");
                            sqlBulkCopy.ColumnMappings.Add("Narrators", "Narrators");
                            sqlBulkCopy.ColumnMappings.Add("Reader", "Reader");
                            sqlBulkCopy.ColumnMappings.Add("Illustrator", "Illustrator");
                            sqlBulkCopy.ColumnMappings.Add("Photographer", "Photographer");
                            sqlBulkCopy.ColumnMappings.Add("Translator", "Translator");
                            sqlBulkCopy.ColumnMappings.Add("RightsCountry", "RightsCountry");
                            sqlBulkCopy.ColumnMappings.Add("Manual_Correction_For_RightsCountry", "Manual_Correction_For_RightsCountry");
                            sqlBulkCopy.ColumnMappings.Add("EditionNumber", "EditionNumber");
                            sqlBulkCopy.ColumnMappings.Add("Unabridged", "Unabridged");
                            sqlBulkCopy.ColumnMappings.Add("Edition Type Code", "EditionTypeCode");
                            sqlBulkCopy.ColumnMappings.Add("BISAC", "BISAC");
                            sqlBulkCopy.ColumnMappings.Add("Genre1", "Genre1");
                            sqlBulkCopy.ColumnMappings.Add("Genre2", "Genre2");
                            sqlBulkCopy.ColumnMappings.Add("Category", "Category");
                            sqlBulkCopy.ColumnMappings.Add("SubCategory", "SubCategory");
                            sqlBulkCopy.ColumnMappings.Add("Min Age", "MinAge");
                            sqlBulkCopy.ColumnMappings.Add("Publish Date", "PublishDate");
                            sqlBulkCopy.ColumnMappings.Add("Release Date", "ReleaseDate");
                            sqlBulkCopy.ColumnMappings.Add("Total Run Time", "TotalRunTime");
                            sqlBulkCopy.ColumnMappings.Add("Language", "Language");
                            sqlBulkCopy.ColumnMappings.Add("Fiction", "Fiction");
                            sqlBulkCopy.ColumnMappings.Add("DRM Flag", "DRM_Flag");
                            sqlBulkCopy.ColumnMappings.Add("Media Type", "MediaType");
                            sqlBulkCopy.ColumnMappings.Add("Library Price USD", "LibraryPrice_USD");
                            sqlBulkCopy.ColumnMappings.Add("Library Price GBP", "LibraryPrice_GBP");
                            sqlBulkCopy.ColumnMappings.Add("Library Price EUR", "LibraryPrice_EUR");
                            sqlBulkCopy.ColumnMappings.Add("Library Price AUD", "LibraryPrice_AUD");
                            sqlBulkCopy.ColumnMappings.Add("Description", "Description");
                            sqlBulkCopy.ColumnMappings.Add("Series Name", "SeriesName");
                            sqlBulkCopy.ColumnMappings.Add("Original Series Name", "OriginalSeriesName");
                            sqlBulkCopy.ColumnMappings.Add("Series Position Number", "SeriesPositionNumber");
                            sqlBulkCopy.ColumnMappings.Add("DigitalFormat", "DigitalFormat");
                            sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                            sqlBulkCopy.ColumnMappings.Add("SAP_Status", "SAP_Status");
                            sqlBulkCopy.ColumnMappings.Add("PageCount", "PageCount");
                            sqlBulkCopy.ColumnMappings.Add("Delta/New", "Delta_New");
                            sqlBulkCopy.ColumnMappings.Add("PubID", "PubID");
                            sqlBulkCopy.ColumnMappings.Add("AddToDoNotLoad", "AddToDoNotLoad");
                            sqlBulkCopy.ColumnMappings.Add("ReasonCode", "ReasonCode");
                            sqlBulkCopy.ColumnMappings.Add("TobeDeleted", "Tobedeleted");
                            sqlBulkCopy.ColumnMappings.Add("ID", "id");
                            sqlBulkCopy.ColumnMappings.Add("filename", "filename");


                            con.Open();


                            sqlBulkCopy.WriteToServer(dtExcelData);

                            con.Close();
                        }
                    }

#endregion

                }
            }
            catch (Exception ex)
            {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "USERNAME:" + System.Environment.UserName.ToString() + ". -- Error at UploadFile Process : File: " + FilePathName + ". Exception : " + ex.ToString());

                MessageBox.Show("There has been some issue during Contributor Generation.");
            }

            finally
            {

            }

#endregion

            return result;

        }
        public bool UploadFile_MetaData(string Company, string FilePathName)
        {
            bool result = true;
        
#region ''
            try
            {
                //Upload and save the file

               
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";

                conString = string.Format(conString, FilePathName);

                ImpersonateUser iU = new ImpersonateUser();
                iU.Undo();

                string username = System.Environment.UserName.ToString();
            
                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();

#region 'read excel file'

                    dtExcelData.Columns.AddRange(new DataColumn[59] {
                        new DataColumn("File Type", typeof(string)),
                        new DataColumn("Errors", typeof(string)),
                        new DataColumn("Agent Parent PublisherName", typeof(string)),
                        new DataColumn("Agent PartnerID", typeof(string)),
                        new DataColumn("Agent AccountID", typeof(string)),
                        new DataColumn("Publisher Name", typeof(string)),
                        new DataColumn("Publisher PartnerID", typeof(string)),
                        new DataColumn("Imprint Name", typeof(string)),
                        new DataColumn("Imprint PartnerID", typeof(string)),
                        new DataColumn("ISBN", typeof(string)),
                        new DataColumn("Title", typeof(string)),
                        new DataColumn("Original Title", typeof(string)),
                        new DataColumn("Sub Title", typeof(string)),
                        new DataColumn("Original SubTitle", typeof(string)),
                        new DataColumn("Authors", typeof(string)),
                        new DataColumn("Corporate Authors", typeof(string)),
                        new DataColumn("Editor", typeof(string)),
                        new DataColumn("Narrators", typeof(string)),
                        new DataColumn("Reader", typeof(string)),
                        new DataColumn("Illustrator", typeof(string)),
                        new DataColumn("Photographer", typeof(string)),
                        new DataColumn("Translator", typeof(string)),
                        new DataColumn("RightsCountry", typeof(string)),
                        new DataColumn("Manual_Correction_For_RightsCountry", typeof(string)),
                        new DataColumn("EditionNumber",typeof(string)),
                        new DataColumn("Unabridged", typeof(string)),
                        new DataColumn("Edition Type Code", typeof(string)),
                        new DataColumn("BISAC",typeof(string)),
                        new DataColumn("Genre1",typeof(string)),
                        new DataColumn("Genre2",typeof(string)),
                        new DataColumn("Category",typeof(string)),
                        new DataColumn("SubCategory",typeof(string)),
                        new DataColumn("Min Age", typeof(string)),
                        new DataColumn("Publish Date", typeof(string)),
                        new DataColumn("Release Date", typeof(string)),
                        new DataColumn("Total Run Time", typeof(string)),
                        new DataColumn("Language", typeof(string)),
                        new DataColumn("Fiction", typeof(string)),
                        new DataColumn("DRM Flag", typeof(string)),
                        new DataColumn("Media Type", typeof(string)),
                        new DataColumn("Library Price USD", typeof(string)),
                        new DataColumn("Library Price GBP", typeof(string)),
                        new DataColumn("Library Price EUR", typeof(string)),
                        new DataColumn("Library Price AUD", typeof(string)),
                        new DataColumn("Description", typeof(string)),
                        new DataColumn("Series Name", typeof(string)),
                        new DataColumn("Original Series Name", typeof(string)),
                        new DataColumn("Series Position Number", typeof(string)),
                        new DataColumn("DigitalFormat", typeof(string)),
                        new DataColumn("Status", typeof(string)),
                        new DataColumn("SAP_Status", typeof(string)),
                        new DataColumn("PageCount", typeof(string)),
                        new DataColumn("Delta/New", typeof(string)),
                        new DataColumn("PubID", typeof(string)),
                        new DataColumn("AddToDoNotLoad", typeof(string)),
                        new DataColumn("ReasonCode", typeof(string)),
                        new DataColumn("TobeDeleted", typeof(string)),
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("filename", typeof(string)) });
                   
#endregion


                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }
                    excel_con.Close();

                    iU.Impersonate();
                    username = System.Environment.UserName.ToString();
                    
#region 'SQLBULKCOPY'
                    using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.[Approved_Titles]";
                            sqlBulkCopy.BulkCopyTimeout = 0;

                            //[OPTIONAL]: Map the Excel columns with that of the database table


                            sqlBulkCopy.ColumnMappings.Add("File Type", "FileType");
                            sqlBulkCopy.ColumnMappings.Add("Errors", "ErrorMessage");
                            sqlBulkCopy.ColumnMappings.Add("Agent Parent PublisherName", "Agent_ParentPublisherName");
                            sqlBulkCopy.ColumnMappings.Add("Agent PartnerID", "Agent_PartnerID");
                            sqlBulkCopy.ColumnMappings.Add("Agent AccountID", "Agent_AccountID");
                            sqlBulkCopy.ColumnMappings.Add("Publisher Name", "PublisherName");
                            sqlBulkCopy.ColumnMappings.Add("Publisher PartnerID", "Publisher_PartnerID");
                            sqlBulkCopy.ColumnMappings.Add("Imprint Name", "ImprintName");
                            sqlBulkCopy.ColumnMappings.Add("Imprint PartnerID", "Imprint_PartnerID");
                            sqlBulkCopy.ColumnMappings.Add("ISBN", "ISBN");
                            sqlBulkCopy.ColumnMappings.Add("Title", "Title");
                            sqlBulkCopy.ColumnMappings.Add("Original Title", "OriginalTitle");
                            sqlBulkCopy.ColumnMappings.Add("Sub Title", "SubTitle");
                            sqlBulkCopy.ColumnMappings.Add("Original SubTitle", "OriginalSubTitle");
                            sqlBulkCopy.ColumnMappings.Add("Authors", "Authors");
                            sqlBulkCopy.ColumnMappings.Add("Corporate Authors", "CorporateAuthors");
                            sqlBulkCopy.ColumnMappings.Add("Editor", "Editor");
                            sqlBulkCopy.ColumnMappings.Add("Narrators", "Narrators");
                            sqlBulkCopy.ColumnMappings.Add("Reader", "Reader");
                            sqlBulkCopy.ColumnMappings.Add("Illustrator", "Illustrator");
                            sqlBulkCopy.ColumnMappings.Add("Photographer", "Photographer");
                            sqlBulkCopy.ColumnMappings.Add("Translator", "Translator");
                            sqlBulkCopy.ColumnMappings.Add("RightsCountry", "RightsCountry");
                            sqlBulkCopy.ColumnMappings.Add("Manual_Correction_For_RightsCountry", "Manual_Correction_For_RightsCountry");
                            sqlBulkCopy.ColumnMappings.Add("EditionNumber", "EditionNumber");
                            sqlBulkCopy.ColumnMappings.Add("Unabridged", "Unabridged");
                            sqlBulkCopy.ColumnMappings.Add("Edition Type Code", "EditionTypeCode");
                            sqlBulkCopy.ColumnMappings.Add("BISAC", "BISAC");
                            sqlBulkCopy.ColumnMappings.Add("Genre1", "Genre1");
                            sqlBulkCopy.ColumnMappings.Add("Genre2", "Genre2");
                            sqlBulkCopy.ColumnMappings.Add("Category", "Category");
                            sqlBulkCopy.ColumnMappings.Add("SubCategory", "SubCategory");
                            sqlBulkCopy.ColumnMappings.Add("Min Age", "MinAge");
                            sqlBulkCopy.ColumnMappings.Add("Publish Date", "PublishDate");
                            sqlBulkCopy.ColumnMappings.Add("Release Date", "ReleaseDate");
                            sqlBulkCopy.ColumnMappings.Add("Total Run Time", "TotalRunTime");
                            sqlBulkCopy.ColumnMappings.Add("Language", "Language");
                            sqlBulkCopy.ColumnMappings.Add("Fiction", "Fiction");
                            sqlBulkCopy.ColumnMappings.Add("DRM Flag", "DRM_Flag");
                            sqlBulkCopy.ColumnMappings.Add("Media Type", "MediaType");
                            sqlBulkCopy.ColumnMappings.Add("Library Price USD", "LibraryPrice_USD");
                            sqlBulkCopy.ColumnMappings.Add("Library Price GBP", "LibraryPrice_GBP");
                            sqlBulkCopy.ColumnMappings.Add("Library Price EUR", "LibraryPrice_EUR");
                            sqlBulkCopy.ColumnMappings.Add("Library Price AUD", "LibraryPrice_AUD");
                            sqlBulkCopy.ColumnMappings.Add("Description", "Description");
                            sqlBulkCopy.ColumnMappings.Add("Series Name", "SeriesName");
                            sqlBulkCopy.ColumnMappings.Add("Original Series Name", "OriginalSeriesName");
                            sqlBulkCopy.ColumnMappings.Add("Series Position Number", "SeriesPositionNumber");
                            sqlBulkCopy.ColumnMappings.Add("DigitalFormat", "DigitalFormat");
                            sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                            sqlBulkCopy.ColumnMappings.Add("SAP_Status", "SAP_Status");
                            sqlBulkCopy.ColumnMappings.Add("PageCount", "PageCount");
                            sqlBulkCopy.ColumnMappings.Add("Delta/New", "Delta_New");
                            sqlBulkCopy.ColumnMappings.Add("PubID", "PubID");
                            sqlBulkCopy.ColumnMappings.Add("AddToDoNotLoad", "AddToDoNotLoad");
                            sqlBulkCopy.ColumnMappings.Add("ReasonCode", "ReasonCode");
                            sqlBulkCopy.ColumnMappings.Add("TobeDeleted", "Tobedeleted");
                            sqlBulkCopy.ColumnMappings.Add("ID", "id");
                            sqlBulkCopy.ColumnMappings.Add("filename", "filename");


                            con.Open();


                            sqlBulkCopy.WriteToServer(dtExcelData);

                            con.Close();
                        }
                    }

#endregion

                }
            }
            catch (Exception ex)
            {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "USERNAME:" + System.Environment.UserName.ToString()+ ". -- Error at UploadFile Process : File: " + FilePathName + ". Exception : " + ex.ToString());

                MessageBox.Show("There has been some issue during Contributor Generation.");
            }

            finally
            {

            }

#endregion

            return result;

        }
        public bool UploadFile_RBContribs(string Company, string FilePathName)
        {
            bool result = true;

            #region ''
            try
            {
                //Upload and save the file

               
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";

                conString = string.Format(conString, FilePathName);


                //ImpersonateUser iU = new ImpersonateUser();
                //iU.Undo();

                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();

                    #region 'Read Excel file'
                                      


                    //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                    dtExcelData.Columns.AddRange(new DataColumn[12] {
                        new DataColumn("Pub_code", typeof(string)),
                        new DataColumn("Isbn", typeof(string)),
                        new DataColumn("ForeName", typeof(string)),
                        new DataColumn("SurName", typeof(string)),
                        new DataColumn("FNF", typeof(string)),
                        new DataColumn("LNF", typeof(string)),
                        new DataColumn("ContType", typeof(string)),
                        new DataColumn("Lead", typeof(string)),
                        new DataColumn("Rank", typeof(string)),
                        new DataColumn("ID", typeof(string)),
                        new DataColumn("status", typeof(string)),
                        new DataColumn("FileType", typeof(string))  });

                    #endregion


                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }
                    excel_con.Close();

                    //iU.Impersonate();

                    using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.[Approved_ContributorData]";
                            sqlBulkCopy.BulkCopyTimeout = 0;

                            //[OPTIONAL]: Map the Excel columns with that of the database table

                            #region 'SQLBULKCOPY'

                         //   sqlBulkCopy.ColumnMappings.Add("Pub_code", "");
                         //   sqlBulkCopy.ColumnMappings.Add("Isbn", "ISBN");
                            sqlBulkCopy.ColumnMappings.Add("ForeName", "ForeName");
                            sqlBulkCopy.ColumnMappings.Add("SurName", "SurName");
                            sqlBulkCopy.ColumnMappings.Add("FNF", "FNF");
                            sqlBulkCopy.ColumnMappings.Add("LNF", "LNF");
                            sqlBulkCopy.ColumnMappings.Add("ContType", "ContType");
                            sqlBulkCopy.ColumnMappings.Add("Lead", "lead");
                            sqlBulkCopy.ColumnMappings.Add("Rank", "Rank");
                            sqlBulkCopy.ColumnMappings.Add("ID", "ID");
                      //    sqlBulkCopy.ColumnMappings.Add("status", "");
                      //      sqlBulkCopy.ColumnMappings.Add("FileType", "");

                            #endregion


                            con.Open();


                            sqlBulkCopy.WriteToServer(dtExcelData);

                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "Error at UploadFile Process : File: " + FilePathName + ". Exception : " + ex.ToString());
            }

            finally
            {

            }

            #endregion

            return result;

        }
        public bool UploadFile_Contribs(string Company, string FilePathName)
        {
            bool result = true;
          
#region ''
            try
            {
                //Upload and save the file

              
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";

                conString = string.Format(conString, FilePathName);


                ImpersonateUser iU = new ImpersonateUser();
                iU.Undo();

                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();

#region 'Read Excel file'

                    //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                    dtExcelData.Columns.AddRange(new DataColumn[12] {
                        new DataColumn("FileName", typeof(string)),
                        new DataColumn("ErrorMessage", typeof(string)),
                        new DataColumn("Isbn", typeof(string)),
                        new DataColumn("ForeName", typeof(string)),
                        new DataColumn("SurName", typeof(string)),
                        new DataColumn("FNF", typeof(string)),
                        new DataColumn("LNF", typeof(string)),
                        new DataColumn("ContType", typeof(string)),
                        new DataColumn("Rank", typeof(string)),
                        new DataColumn("PartnerID", typeof(string)),
                        new DataColumn("ToBeDeleted", typeof(string)),
                        new DataColumn("ID", typeof(string))  });

#endregion


                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }
                    excel_con.Close();

                    iU.Impersonate();
                  
                    using (SqlConnection con = new SqlConnection(GetConnectionString(Company)))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.[Approved_ContributorData]";
                            sqlBulkCopy.BulkCopyTimeout = 0;

                            //[OPTIONAL]: Map the Excel columns with that of the database table

#region 'SQLBULKCOPY'

                            sqlBulkCopy.ColumnMappings.Add("FileName", "FileName");
                            sqlBulkCopy.ColumnMappings.Add("ErrorMessage", "ErrorMessage");
                            sqlBulkCopy.ColumnMappings.Add("Isbn", "ISBN");
                            sqlBulkCopy.ColumnMappings.Add("ForeName", "ForeName");
                            sqlBulkCopy.ColumnMappings.Add("SurName", "SurName");
                            sqlBulkCopy.ColumnMappings.Add("FNF", "FNF");
                            sqlBulkCopy.ColumnMappings.Add("LNF", "LNF");
                            sqlBulkCopy.ColumnMappings.Add("ContType", "ContType");
                            sqlBulkCopy.ColumnMappings.Add("Rank", "Rank");
                            sqlBulkCopy.ColumnMappings.Add("PartnerID", "PartnerID");
                            sqlBulkCopy.ColumnMappings.Add("ToBeDeleted", "ToBeDeleted");
                            sqlBulkCopy.ColumnMappings.Add("ID", "ID");

#endregion
                            
                                                    
                            con.Open();


                            sqlBulkCopy.WriteToServer(dtExcelData);

                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                Insert_ErrorLog(GetConnectionString(Company), "Error at UploadFile Process : File: " + FilePathName + ". Exception : " + ex.ToString());
            }

            finally
            {

            }

#endregion

            return result;

        }

        //Read XSL Data
   

      


    }
}
