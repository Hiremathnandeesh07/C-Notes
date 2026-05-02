using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SuperMarketBillingSystem_01_05_2026
{
    internal class CustomerModel
    {
        public CustomerModel(int customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }

        public int CustomerId { get; set; }
     public string Name { get; set; }
    }
}
