using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
  
    internal class NamedParameters
    {
        static void Greetings(string name, int age, string gender)
        {
            Console.WriteLine($"hi {name}, you are {age} old and you are {gender}");
        }
        static void Main(string[] args)
        {
            Greetings(age: 45, gender: "female", name: "hitler");
        }
    }
}
