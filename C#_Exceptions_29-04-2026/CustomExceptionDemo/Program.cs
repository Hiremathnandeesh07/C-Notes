using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptionDemo
{
    internal class Program
    {

        //static void CheckAge(int age)
        //{
        //    if (age < 18)
        //    {
        //        throw new AgeNotValidException("Age must be 18 or above");
        //    }
        //}
        //class AgeNotValidException : Exception
        //{
        //    public AgeNotValidException(string message) : base(message)
        //    {

        //    }
        //}
            static void Main()
            {
            //try
            //{
            //CheckAge(15);
            //{
            //    throw new AgeNotValidException("age is less than 35");
            //}
            //}
            //catch (AgeNotValidException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            try
            {
                int b = 0;
                int c = 34 / b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
        
    }
}
