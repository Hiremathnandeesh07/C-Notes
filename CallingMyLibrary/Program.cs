using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArithmeticLib;   //THIS IS MY OWN CREATED LIBRARY

namespace CallingMyLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator obj = new Calculator();
            Console.WriteLine(obj.Add(23,56));
        }
    }
}
