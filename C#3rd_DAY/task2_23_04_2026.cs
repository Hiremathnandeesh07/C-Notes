using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    /*
     * accept the first name,middle name and last name into
     * method and return full name and display it in main method
     */
    internal class task2_23_04_2026
    {
        static string FullName(string first,string middle,string last)
        {
            return first + " " + middle + " " + last;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter first middle and lastname");
            Console.WriteLine(FullName(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
            
        }
    }
}
