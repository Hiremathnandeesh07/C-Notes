using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    /* define 4 static methods like sum,
     product,difference,divide 
    should have two arguments and switch case to  implement 
    */
   
    internal class task1_23_04_2026
    {
        static int Sum(int a, int b)
        {
            return a + b;
        }
        static int Product(int a, int b)
        {
            return a * b;
        }
        static int Difference(int a, int b)
        {
            return a - b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the two numbers a and b :");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            

            while (true)
            {
                Console.WriteLine("Now choose one from Sum, Product, Difference, Divide and exit if you want to close");
                string userOperation = Console.ReadLine();
                if (userOperation.ToLower() == "exit")
                {
                    Console.WriteLine("exiting......");
                    break;
                }
                else
                {
                    switch (userOperation)
                    {
                        case "Sum":
                            Console.WriteLine("Sum is :" + Sum(a, b));
                            break;
                        case "Product":
                            Console.WriteLine("Product is : " + Product(a, b));
                            break;
                        case "Difference":
                            Console.WriteLine("Difference is  : " + Difference(a, b));
                            break;
                        case "Divide":
                            Console.WriteLine("Division is : " + Divide(a, b));
                            break;
                        default:
                            Console.WriteLine("you entered invalid input");
                            break;
                    }
                }
            }
        }
    }
}
