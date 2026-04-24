using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        // code for applying inheritance
        static void Main(string[] args)
        {
            Teacher t1 = new Teacher();
            t1.name = "nandeesh";
            t1.teacherId = 2345;
            Console.WriteLine($"teacher name is {t1.name} and id is {t1.teacherId}");
        }
    }
}
