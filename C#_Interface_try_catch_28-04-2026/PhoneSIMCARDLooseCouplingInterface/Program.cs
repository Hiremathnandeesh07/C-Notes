using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneSIMCARDLooseCouplingInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISims sims = new Airtel();
            PhoneService ps = new PhoneService(sims);
            ps.Network();


            sims = new Jio();
            PhoneService ps1 = new PhoneService(sims);
            ps1.Network();

        }
    }
}
