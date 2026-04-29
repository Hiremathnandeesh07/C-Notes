using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemLooseCouplingInterface
{
    class PaymentService
    {
        private IPayment _payment;
        public PaymentService(IPayment payment)
        {
            _payment = payment;
        }

        public void Process()
        {
            _payment.Pay();
            Console.WriteLine("payment done....");
        }

    }
}
