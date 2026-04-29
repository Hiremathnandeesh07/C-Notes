using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            ABtech ece = new DEce();
            ece.CoreSubjects();
            ece.Duration();
            Console.WriteLine();
            DCivil civil = new DCivil();
            civil.CoreSubjects();
            civil.Duration();
            Console.WriteLine();
            DCse cse = new DCse();
            cse.CoreSubjects();
            cse.Duration();
        }
    }
}
