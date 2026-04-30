using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace AchievingOptionalParametersUsingOPTIONAL
{
    internal class Program
    {
    static void ShowData(int x, [Optional] int y)
        {
            Console.WriteLine($"value of x is {x} and y is {y}");
        }

        static void Main(string[] args)
        {

            ShowData(34, 23);
            ShowData(23);

        }
    }
}
