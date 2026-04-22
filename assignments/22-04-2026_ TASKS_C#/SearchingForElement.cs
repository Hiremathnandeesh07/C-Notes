using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _22_04_2026__TASKS_C_
{
    internal class SearchingForElement
    {
        static void Main(string[] args)
        {
            // Ask the user for the array size
            Console.WriteLine("Enter size of array:");
            int len = Convert.ToInt32(Console.ReadLine());

            // Create array of given size
            int[] arr = new int[len];

            // Variables to store sum and maximum value
            int sum = 0;
            int max = int.MinValue;

            // Accept array elements from user
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("Enter the " + (i + 1) + "th element:");
                arr[i] = Convert.ToInt32(Console.ReadLine());

                // Calculate sum of elements
                sum += arr[i];

                // Find maximum element
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            // Ask user for the element to search
            Console.WriteLine("Enter element to search:");
            int key = Convert.ToInt32(Console.ReadLine());

            // Search for the element in the array
            for (int i = 0; i < len; i++)
            {
                if (key == arr[i])
                {
                    // If element is found, display its position (1-based index)
                    Console.WriteLine(key + " found at position " + (i + 1));
                    return; // Exit the program after finding the element
                }
            }

            // If element is not found
            Console.WriteLine("Sorry, key not found.");
        }
    }
}