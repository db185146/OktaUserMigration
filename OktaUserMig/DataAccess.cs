using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OktaUserMig
{
    class DataAccess
    {
        internal static DataRow LoadUserInfo(string uniqueUserId)
        {
            return ExecuteSqlCommand($"select * from RDF_Users where UniqueID={uniqueUserId}");
        }

        internal static DataRow GetHighestUniqueUserId()
        {
            return ExecuteSqlCommand("select MAX(UniqueID) from RDF_Users");
        }

        private static DataRow ExecuteSqlCommand(string cmdText)
        {
            DataRow returnValue = null;

            using (var command = new SqlCommand(cmdText))
            {
                var dataTable = GetDataTable(command);

                if (dataTable.Rows.Count > 0)
                {
                    returnValue = dataTable.Rows[0];
                }
            }

            return returnValue;
        }

        public static DataTable GetDataTable(SqlCommand command)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(GetConnectionString()))
            {
                command.CommandType = CommandType.Text;

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command.Connection = connection;

                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        private static Configuration configuration;

        public static string GetConnectionString(string database = "rdf", string connectionStringName = "rdf")
        {
            //todo: get connection string from CmcServer.Common.dll.config
            // return string.Format(configuration.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString, database);
            return "Data Source=153.87.46.112;Initial Catalog=rdf;User Id=sa;Password=password100!;";
        }

        private static void OpenConfigFile()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string exePath = Uri.UnescapeDataString(uri.Path);
            configuration = ConfigurationManager.OpenExeConfiguration(exePath);
        }

    }
}
