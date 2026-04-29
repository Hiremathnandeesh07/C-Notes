using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneSIMCARDLooseCouplingInterface
{
    internal class Jio : ISims
    {
        public void Using()
        {
            Console.WriteLine("phone is using Jio Sim");
        }
    }
}
