using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemLooseCouplingInterface
{
   
    internal class Program
    {
        static void Main(string[] args)
        {

            IPayment pay = new CreditCardPayment();
            PaymentService ps = new PaymentService(pay);
            ps.Process();
            
        }
    }
}
