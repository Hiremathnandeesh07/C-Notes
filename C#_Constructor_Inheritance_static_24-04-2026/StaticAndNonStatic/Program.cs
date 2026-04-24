using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAndNonStatic
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // creating object of PEOPLE class 
            People p = new People();
            p.name = "nandeesh";
            //p.age = 45;  THIS IS NOT ALLOWED
        }
    }
}
