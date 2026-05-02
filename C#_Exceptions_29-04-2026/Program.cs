using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__29_04_2026
{
    internal class Program
    {

        class Base
        {
             public virtual void  show()
            {
                Console.WriteLine("this is base class");
            }
        }

        class Child : Base
        {
            public override void  show()
            {
                base.show();
                Console.WriteLine("this is child class");
            }
        }
        static void Main(string[] args)
        {
            Child c = new Child();
            c.show();
        }
    }
}
