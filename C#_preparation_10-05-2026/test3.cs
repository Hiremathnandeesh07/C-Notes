using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C__preparation_10_05_2026
{
    internal class test3
    {
        static public void Method2()
        {
            try
            {
                int b = 0;
                int c = 34 / b;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static public void Method1()
        {
            try
            {
                Method2();
            }
            catch(Exception )
            {
                throw  ;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Method1();
                Console.WriteLine("enter name before exception");
                string name = Console.ReadLine();
                Console.WriteLine(name);

            }
            catch(Exception e )
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

            }
            finally
            {
                Console.WriteLine("this is finally block");
            }
            Console.WriteLine("enter name after exception");
            string name2 = Console.ReadLine();
            Console.WriteLine(name2);
            


        }
        }
    
}
