using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    //Accept name of person and marks.then you need to display name and total marks,
    //If name is given by user then display name and “total marks not given”
    internal class task10_23_04_2026
    {

        static void MarksCard(string name = null, int? marks = null)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Console.WriteLine($"Name is {name}");

                if (marks.HasValue)
                {
                    Console.WriteLine($"Marks is {marks}");
                }
                else
                {
                    Console.WriteLine("Marks not given");
                }
            }
            else
            {
                Console.WriteLine("Name not given");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the person (press Enter to skip):");
            string name = Console.ReadLine();

            Console.WriteLine("Enter total marks (press Enter to skip):");
            string marksInput = Console.ReadLine();

            if (string.IsNullOrEmpty(marksInput))
            {
                // marks not given
                MarksCard(name);
            }
            else
            {
                int marks = Convert.ToInt32(marksInput);
                MarksCard(name, marks);
            }
        }

    }
    
}