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
        static void MarksCard(int marks,string name = null)
        {
            Console.WriteLine($"name is {name}");
            Console.WriteLine($"marks is {marks}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter the name of the person : ");
            string name = Console.ReadLine();
            Console.WriteLine("enter total marks");
            int marks = Convert.ToInt32(Console.ReadLine());
            MarksCard(marks,name);
        }
    }
}
