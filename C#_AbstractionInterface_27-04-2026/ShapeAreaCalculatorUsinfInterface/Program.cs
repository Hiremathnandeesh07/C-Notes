using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculatorUsinfInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape shape1 = new Rectangle()
            {
                Length = 34,
                Breadth=22
            };
            Console.WriteLine(shape1.CalculateArea());
        }
    }
}
