using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetterSetterDemo
{

    class DemoClass
    {
        // declaration
        private string name;


        // initialized without explicitly writting getter and setter
        public int age { get; set; }
        public string model { get; set; }

        //property
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
