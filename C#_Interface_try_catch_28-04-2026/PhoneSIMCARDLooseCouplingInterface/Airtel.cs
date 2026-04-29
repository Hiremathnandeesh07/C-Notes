using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneSIMCARDLooseCouplingInterface
{
    internal class Airtel : ISims
    {
        public void Using()
        {
            Console.WriteLine("this is using Airtel Sim");
        }
    }
}
