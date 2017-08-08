using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TitleInjestion.CommonFunctions
{
    class SQLData
    {
        public string GetConnectionString(string Company)
        {
            string connectionString = ConfigurationSettings.AppSettings[Company + "_connString"].ToString();

            return connectionString;
        }

        public void SQLConnections(string Company)
        {
            string connectionstring = GetConnectionString(Company);
        }

        public DataTable GetMediaType()
        {
            DataTable dt_MediaType = new DataTable();
            

            return dt_MediaType;

        }
    }
}
