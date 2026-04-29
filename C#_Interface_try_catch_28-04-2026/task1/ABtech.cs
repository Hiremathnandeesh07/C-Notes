using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    /*
     * Create an abstract class called “btech” in which 
     * we have abstract method called “CoreSubjects” and 
     * non-abstract method “Duration” and inherit the class into 
     * child classes like :CSE ECE Civil
     */
    abstract class ABtech
    {
        public abstract void CoreSubjects();

        public void Duration()
        {
            Console.WriteLine("this is duaration 4 years");
        }

    }
}
