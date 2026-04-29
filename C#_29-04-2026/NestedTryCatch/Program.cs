using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedTryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    int x = int.Parse("abc"); // low-level error
                }
                catch (Exception)
                {
                    Console.WriteLine("Logging error in inner");
                    //throw new Exception("this is the inner exception", ex);
                    throw;
                }
            }
            catch (Exception )
            {
                Console.WriteLine("this is outer exception");
                //if (ex.InnerException != null)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                Console.WriteLine(ex.Message);
            }
        }
    }
}
