//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace C__preparation_10_05_2026
//{
//    internal class test1
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World");
//            int[][] arr = new int[3][];

//            for (int i = 0; i < arr.Length; i++)
//            {
//                Console.WriteLine("enter the lenght of " + (i + 1) + " th row");
//                int cols = Convert.ToInt32(Console.ReadLine());
//                arr[i] = new int[cols];
//                for (int j = 0; j < cols; j++)
//                {
//                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
//                }
//            }


//            for (int i = 0; i < arr.Length; i++)
//            {

//                for (int j = 0; j < arr[i].Length; j++)
//                {
//                    Console.Write(arr[i][j] + "\t");
//                }
//                Console.WriteLine();
//            }



//        }
//    }
//}