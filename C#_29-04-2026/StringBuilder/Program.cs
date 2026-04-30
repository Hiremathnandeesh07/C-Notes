using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "nandeesh ";
            Console.WriteLine(name.GetHashCode());
            name += "hello boy";
            Console.WriteLine(name.GetHashCode());
            name += "he he he";
            Console.WriteLine(name.GetHashCode());
            Console.WriteLine(name);



            StringBuilder sb = new StringBuilder("welcome");
            Console.WriteLine(sb.GetHashCode());
            sb.Append("nandeesh");
            Console.WriteLine(sb.GetHashCode());

        }
    }
}
