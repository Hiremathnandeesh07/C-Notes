using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetterSetterDemo
{

    class DemoClass
    {
        private string name;
        //public string Name { set; get; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DemoClass dc = new DemoClass();
            dc.Name = "nandeesh";
            Console.WriteLine(dc.Name);
        }
    }
}
