using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _22_04_2026__TASKS_C_
{
    internal class SumOfArrayEle
    {
        static void Main(string[] args)
        {
            //Accept n array elements and print sum of an array elements
            int rows = 0;
            int cols = 0;
            int sum = 0;
            
            Console.WriteLine("enter no of rows : ");
            rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter no of columns");
            cols = Convert.ToInt32(Console.ReadLine());
            int[,] matrix1 = new int[rows, cols];
            int[,] matrix2 = new int[rows, cols];
            int[,] matrix3 = new int[rows, cols];


            // receiving the matrix1 elements
            Console.WriteLine("enter elements for matrix1 : ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine("Enter number for " + i + "th row and " + j + "th column");
                    matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                    
                    
                }

            }

            // receiving the matrix2 elements
            Console.WriteLine("enter elements for matrix2 : ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine("Enter number for " + i + "th row and " + j + "th column");
                    matrix2[i, j] = Convert.ToInt32(Console.ReadLine());


                }

            }

            //elements in matrix1 
            Console.WriteLine("Elements in Matrix1 are : ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    
                    Console.Write(matrix1[i, j] + "\t");

                }
                Console.WriteLine();

            }

            //elements in matrix2
            Console.WriteLine("Elements in Matrix2 are : ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    
                    Console.Write(matrix2[i, j] + "\t");

                }
                Console.WriteLine();

            }



            // printing result matrix
            Console.WriteLine("Elements in Matrix3 are : ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                    Console.Write(matrix3[i,j] + "\t");

                }
                Console.WriteLine();

            }

            
            
            
        }
    }
}
