using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiding
{
   
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Parent p = new Child();
            p.Show();
        }
    }
}
