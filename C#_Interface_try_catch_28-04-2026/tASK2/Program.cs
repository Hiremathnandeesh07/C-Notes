using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tASK2
{
    internal class Program
    {
        /*
         * Create My app class which us implenting Mouse and IKeyboard unterfaces.
         * Mouse has a method called ‘MoveMouse’ and 
         * Ikeyboard has a method called ‘PressKeys’
         * 
         */


        // calling the interface methods with MYCLASS reference type because 
        // i had implimented MULTIPLE INHERITANCE

        static void Main(string[] args)
        {
            MyApp mouse = new MyApp();
            mouse.MoveMouse();
            mouse.PressKeys();
        }
    }
}
