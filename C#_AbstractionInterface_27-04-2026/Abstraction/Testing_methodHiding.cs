using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    abstract class Dog
    {
        public virtual void speek()
        {
            Console.WriteLine("dog is speeking");
        }
        
        
    }

    class Cat :Dog
    {
        public new void speek()
        {
            Console.WriteLine("cat is speeking");
        }
    }
    internal class Testing_methodHiding 

    {

        static void Main(string[] args)
        {
            Dog d1 = new Cat();
            d1.speek();
        }
    }
}
