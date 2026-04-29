using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerException
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
				
				try
				{
					
					int x = int.Parse("abc");
				}
				catch (Exception ex)
				{

					throw new ApplicationException("error while processing data",ex);
				}


			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);

				if (e.InnerException != null)
				{
					Console.WriteLine("inner exception is  " + e.InnerException.Message);
				}
			}
			
        }
    }
}
