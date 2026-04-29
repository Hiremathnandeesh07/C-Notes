using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneSIMCARDLooseCouplingInterface
{
    internal class PhoneService
    {
        ISims _sims;
        public PhoneService(ISims sims)
        {
            _sims = sims;
        }

        public void Network()
        {
            _sims.Using();
            Console.WriteLine("Network changes.......");
        }
    }
}
