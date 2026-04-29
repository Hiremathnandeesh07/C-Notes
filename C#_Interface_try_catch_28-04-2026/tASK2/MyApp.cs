using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tASK2
{
    internal class MyApp : IMouse,IKeyboard
    {
        public void MoveMouse()
        {
            Console.WriteLine("move the mouse");
        }
        public void PressKeys()
        {
            Console.WriteLine("press the keys");
        }
    }
}
