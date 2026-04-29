using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemLooseCouplingInterface
{
    class CreditCardPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("paid using CreditCard");
        }
    }

}
