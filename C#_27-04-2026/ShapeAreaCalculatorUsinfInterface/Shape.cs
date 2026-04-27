using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculatorUsinfInterface
{
    
        public interface Shape
        {
             int CalculateArea();
        }
        public class Circle : Shape
        {
            public int Radius { set; get; }
            public  int CalculateArea()
            {
                return Radius;
            }

        }
        public class Rectangle : Shape
        {
            public int Length { get; set; }

            public int Breadth { set; get; }

            public  int CalculateArea()
            {
                return Length * Breadth;
            }
        }
    
}
