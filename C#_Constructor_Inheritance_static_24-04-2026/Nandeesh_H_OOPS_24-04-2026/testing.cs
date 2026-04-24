using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nandeesh_H_OOPS_24_04_2026
{
    internal class testing
    {
        static void Main(string[] args)
        {
            DateTime joinDate;
            bool isValid = DateTime.TryParse(Console.ReadLine(), out joinDate);

            if (isValid)
            {
                Console.WriteLine(joinDate);
            }
            else
            {
                Console.WriteLine("Invalid date format");
            }







            //Console.WriteLine(now);
            //Console.WriteLine(now.Date);
            //Console.WriteLine(now.Year);
            //Console.WriteLine(now.Month);
            //Console.WriteLine(now.Day);
            //Console.WriteLine(now.DayOfYear);
            //Console.WriteLine(now.TimeOfDay);
            //Console.WriteLine(now.ToString("dddd"));


        }
    }
}
