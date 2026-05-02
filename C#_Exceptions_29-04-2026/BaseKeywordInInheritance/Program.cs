using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseKeywordInInheritance
{
    internal class Program
    {

        

        static void Main(string[] args)
        {
            int a = 34, b = 45;
            try
            {
                int c = a / 0;

            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                Console.WriteLine("this is always ran");
            }

        }
    }
}
