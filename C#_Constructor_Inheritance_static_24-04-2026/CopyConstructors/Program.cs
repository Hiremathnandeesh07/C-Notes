using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyConstructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassForCopyConstructors c1 = new ClassForCopyConstructors("nandeesh",34);
            ClassForCopyConstructors c2 = new ClassForCopyConstructors(c1);
            Console.WriteLine(c2.name);
            Console.WriteLine(c2.age);
        }
    }
}
