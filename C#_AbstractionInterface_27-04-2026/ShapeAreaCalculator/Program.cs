using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape c = new Circle()
            {
                Radius = 34
            };
            Console.WriteLine(c.CalculateArea());
            Shape c2 = new Rectangle()
            {
                Length = 34,
                Breadth = 23
            };
            Console.WriteLine(c2.CalculateArea());
        }
    }
}

