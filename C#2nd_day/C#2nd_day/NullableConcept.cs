using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2nd_day
{
    internal class NullableConcept
    {
        static void Main(string[] args)
        {
            int? age = null;
            //int string  = null;

            Console.WriteLine(age.GetValueOrDefault());


            //if (age.HasValue)
            //{
            //    Console.WriteLine(age.Value);
            //    Console.WriteLine(age);
            //}
            //else
            //{
            //    Console.WriteLine("null is there");
            //}

        }
    }
}
