using System;

namespace _22_04_2026__TASKS_C_
{
    internal class ProductOfMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows:");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of columns:");
            int cols = Convert.ToInt32(Console.ReadLine());

            int[,] matrix1 = new int[rows, cols];
            int[,] matrix2 = new int[rows, cols];
            int[,] productMatrix = new int[rows, cols];

            // Input Matrix 1
            Console.WriteLine("\nEnter elements for Matrix 1:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Matrix1[{i},{j}] = ");
                    matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Input Matrix 2
            Console.WriteLine("\nEnter elements for Matrix 2:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Matrix2[{i},{j}] = ");
                    matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Matrix Multiplication
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    productMatrix[i, j] = sum;
                }
            }

            // Display Result Matrix
            Console.WriteLine("\nProduct Matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(productMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}