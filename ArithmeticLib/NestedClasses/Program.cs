using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedClasses
{

    class OuterClass
    {
        public class InnerClass
        {
            public void Message()
            {
                Console.WriteLine("message from inner class");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            OuterClass.InnerClass inClass = new OuterClass.InnerClass();
            inClass.Message();

        }
    }
}
