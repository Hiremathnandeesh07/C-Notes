using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    internal class OptionalParameters
    {
        static void Greetings(string name = "Guest")
        {
            Console.WriteLine("Welcome " + name);
        }
        static void Main(string[] args)
        {
            Greetings("nandeesh");
            Greetings();

        }
    }
}
