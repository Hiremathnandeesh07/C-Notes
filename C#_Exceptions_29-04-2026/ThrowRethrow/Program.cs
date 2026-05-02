using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowRethrow
{
  
class Program
        {
            static void MethodA()
            {
                // Actual error happens here
                try
            {
                int x = int.Parse("abc");
            }
          
            catch(Exception ex)
            {
                Console.WriteLine("inside method A catch");
               
                throw ex;
            }
                
            }

            static void MethodB()
            {
                try
                {
                    MethodA();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Inside MethodB catch");

                    // CHANGE THIS LINE LATER
                    throw ;
                    // throw ex;
                }
            }

            static void Main()
            {
                try
                {
                    MethodB();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFinal Catch:");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nStackTrace:");
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
