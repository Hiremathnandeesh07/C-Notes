using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO02_crud
{
    internal class CrudOperarions
    {
        // inserting new record
        public void StudentInsertOperation(SqlConnection cn,string tname, string tcourse)
        {
            

            // creating query
            string query = $"insert into Student (name,course) values ('{tname}','{tcourse}')";


            // creating command object
            SqlCommand cmd = new SqlCommand(query, cn);


            // running query via command object
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine($"record inserted successfully..... + {result}");
        }


        // checking the student Existance
        public bool IsExist(SqlConnection cn, int tid)
        {
            // query to get existance or not
            string query = $"select count(*) from student where id={tid} ";

            // creating command object
            SqlCommand cmd = new SqlCommand(query, cn);

            // storing reponse form query
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            if(result == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        // method for displaying Student records

        public void StudentDisplayOperation(SqlConnection cn)
        {
            // creating query
            string query = $"select * from Student";

            // creating command object
            SqlCommand cmd = new SqlCommand(query, cn);

            // running query
            SqlDataReader reader = cmd.ExecuteReader();


            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{"ID",-5} {"NAME",-20} {"COURSE",-15}");
            Console.WriteLine("-----------------------------------------");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["id"],-5} {reader["name"],-20} {reader["course"],-15}"
                );
            }
            reader.Close();
            
        }

        // updating the course of student
        public void StudentCourseUpdateOperation(SqlConnection cn, int tid,string tcourse)
        {
            string query = $"update Student set course = '{tcourse}' where id = {tid}";

            // creating command object
            SqlCommand cmd = new SqlCommand(query, cn);

            // running query
            
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine($"record updated successfully..... + {result}");
        }


        // deleting student record
        public void StudentDeleteOperation(SqlConnection cn, int tid)
        {
            // creating sql query
            string query = $"Delete from Student where id = {tid}";

            // creating command object
            SqlCommand cmd = new SqlCommand(query, cn);

            // running query
            cmd.ExecuteNonQuery();
        }



    }
}
