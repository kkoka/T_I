using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Windows.Forms;


namespace TitleInjestion.CommonFunctions
{
    public class SQLBackup
    {
        private readonly string str_Company;
        private readonly string _backupFolderFullPath;
        private readonly string[] _systemDatabaseNames = { "master", "tempdb", "model", "msdb" };

        public SQLBackup()
        {
        }

        public SQLBackup(string strCompany)
        {
            str_Company = strCompany;      
        }

        public bool BackupDatabase()
        {
            bool result = true;

            try {
                string databaseName = ConfigurationSettings.AppSettings["SQLBackUpDatabase"].ToString();
                string filePath = BuildBackupPathWithFilename(databaseName);

                SQLFunction sqlfunc = new SQLFunction();

                using (var connection = new SqlConnection(sqlfunc.GetConnectionString(str_Company)))
                {
                    string query = String.Format("BACKUP DATABASE [{0}] TO DISK='{1}'", databaseName, filePath);
                    /*
                    BACKUP DATABASE [WFH_OffRamp] TO DISK='G:\\ExtraBackup\\WFH_OffRamp_20170406.bak'
                    BACKUP DATABASE [data] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\Backup\data.bak' WITH NOFORMAT, NOINIT,  NAME = N'data-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
                    GO
                    */
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                result = false;
                result = false;
                SQLFunction sqlfunc = new SQLFunction();
                sqlfunc.Insert_ErrorLog(sqlfunc.GetConnectionString(str_Company), "USERNAME:" + System.Environment.UserName.ToString() +
                    ". -- Error at BackupDatabase. Exception : " + ex.ToString());

                MessageBox.Show("There has been an issue while Backing up the Database. Please contact the Admin.");

            }

            return result;
        }

        public string BuildBackupPathWithFilename(string databaseName)
        {
            string filename = string.Format("{0}.bak", databaseName);

            return Path.Combine(ConfigurationSettings.AppSettings["SQLFTP"].ToString(), filename);
        }


        public bool FTPMove(string SourceDir, string DestinationDir, string Database)
        {
            bool result = true;

            try
            {
                DirectoryInfo src = new DirectoryInfo(SourceDir);
                foreach (FileInfo fi in src.GetFiles())
                {
                    if (fi.Length != 0 && fi.Name.Contains(Database))
                    {
                        string file = fi.Name;

                        //ImpersonateUser iU = new ImpersonateUser();
                        //iU.Undo();


                        File.Move(fi.FullName, DestinationDir + file);

                        //iU.Impersonate();

                    }
                }

            }
            catch (Exception ex)
            {
                result = false;
                SQLFunction sqlfunc = new SQLFunction();
                sqlfunc.Insert_ErrorLog(sqlfunc.GetConnectionString(str_Company), "USERNAME:" + System.Environment.UserName.ToString() + ". -- Error at FTPMove. Exception : " + ex.ToString());

                MessageBox.Show("There has been an issue while Moving the back up files to FTP.");

            }

            return result; ;
        }







        public void BackupAllUserDatabases()
        {
            foreach (string databaseName in GetAllUserDatabases())
            {
                BackupDatabase(databaseName);
            }
        }

        public void BackupDatabase(string databaseName)
        {
            string filePath = BuildBackupPathWithFilename(databaseName);

            SQLFunction sqlfunc = new SQLFunction();

            using (var connection = new SqlConnection(sqlfunc.GetConnectionString(str_Company)))
            {
                var query = String.Format("BACKUP DATABASE [{0}] TO DISK='{1}'", databaseName, filePath);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    

        private IEnumerable<string> GetAllUserDatabases()
        {
            var databases = new List<String>();

            DataTable databasesTable;
            SQLFunction sqlfunc = new SQLFunction();
            using (var connection = new SqlConnection(sqlfunc.GetConnectionString(str_Company)))
            {
                connection.Open();

                databasesTable = connection.GetSchema("Databases");

                connection.Close();
            }

            foreach (DataRow row in databasesTable.Rows)
            {
                string databaseName = row["database_name"].ToString();

                if (_systemDatabaseNames.Contains(databaseName))
                    continue;

                databases.Add(databaseName);
            }

            return databases;
        }

   
    }
}
