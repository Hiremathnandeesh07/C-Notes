using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_2nd_day
{
    internal class yearsCalculations
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the DOB \n");
            
            DateTime dob=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("enter male or female");
            string gender = Console.ReadLine();

            DateTime today = DateTime.Now;
            int age = today.Year - dob.Year;
            if(today<dob.AddYears(age))
            {
                age--;
            }
            Console.WriteLine(age);
            if(age > 18)
            {
                Console.WriteLine("eleigible to vote");
            }
            else
            {
                Console.WriteLine("not eligible to vote");
            }
            if(age > 21 && gender == "male")
            {
                Console.WriteLine("can marry");
            }

            else if (age > 22 && gender == "female")
            {
                Console.WriteLine("can marry");
            }
            else
            {
                Console.WriteLine("cannot marry now");
            }

          
        }
    }
}
