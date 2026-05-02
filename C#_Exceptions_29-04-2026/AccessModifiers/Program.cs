using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class DemoClass
    {
        private void PrivateMethod()
        {
            Console.WriteLine("this si private method");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("this is protected method");
        }

        public void PublicMethod()
        {
            Console.WriteLine("this is public method");
        }
    }


    internal class Program : DemoClass 
    {

        
        Program() : base()
        {
        
            }
     
        static void Main(string[] args)
        {
            Program dc = new Program();
            dc.PublicMethod();
            dc.ProtectedMethod();
            //dc.PrivateMethod();  NOT ACCESSABLE
            
            
            
        }
    }
}
