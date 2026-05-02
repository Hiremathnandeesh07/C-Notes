using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class Program
    {


		class RandomException : Exception
		{
			 public RandomException(string message): base(message)
			{

			}

		}
        static void Main(string[] args)
        {
			try
			{
				throw new RandomException("this is exception");
			}
			catch (RandomException e)
			{
                Console.WriteLine(e.Message);
				
			}
        }
    }
}
