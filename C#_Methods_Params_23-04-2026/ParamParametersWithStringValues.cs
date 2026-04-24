using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
   
    internal class ParamParametersWithStringValues
    {
        static void PrintNames(params string[] names)
        {
            foreach (string s in names)
            {
                Console.WriteLine(s +"\t");
                
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            PrintNames("bob", "loby", "seresa");
            PrintNames("application", "robert", "system", "computer");
        }
    }
}
