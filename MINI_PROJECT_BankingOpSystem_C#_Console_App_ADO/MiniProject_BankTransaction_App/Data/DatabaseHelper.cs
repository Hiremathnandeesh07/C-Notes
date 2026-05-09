using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniProject_BankTransaction_App.Data
{
    internal class DatabaseHelper
    {
        
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            _connectionString = ConfigurationManager
                                .ConnectionStrings["DefaultConnection"]
                                .ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
