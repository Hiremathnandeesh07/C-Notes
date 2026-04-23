using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    /*
     * accept marks into 5 subjects into an array
     * and apss it into a method to find total marks
     */
    internal class task5_23_04_2026
    {
        static int SumOfMarks(int[] marks)
        {
            int total = 0;
            foreach(int x in marks)
            {
                total += x;
            }
            return total;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter marks of subjects : ");
            int[] arr = new int[5];
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"enter marks for subject {i+1}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("total sum of marks is : " + SumOfMarks(arr));
        }
    }
}
