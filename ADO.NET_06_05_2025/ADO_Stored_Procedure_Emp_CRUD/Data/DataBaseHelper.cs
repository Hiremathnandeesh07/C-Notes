using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;  // sqlcommand, sqlconnection, sqldatareader
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADO_Stored_Procedure_Emp_CRUD.Data
{
    public class DataBaseHelper
    {
        // readonly - once set in constructor -> cannot be changed
        private readonly string _connectionString;

        // Make the constructor public so callers (like EmployeeRespository) can instantiate this type.
        public DataBaseHelper()
        {

            _connectionString = ConfigurationManager
                                .ConnectionStrings["DefaultConnection"]
                                .ConnectionString;
            // “Go to App.config → find connection named ‘DefaultConnection’ → get its actual connection string → store it in _connectionString”
        }



        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
