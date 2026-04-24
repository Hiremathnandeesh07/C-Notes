using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiding
{
     class Parent
    {
        public void Show()
        {
            Console.WriteLine("this is parent");
        }
    }
    class Child : Parent
    {
        public void Show()
        {
            Console.WriteLine("this is child");
        }
    }
}
