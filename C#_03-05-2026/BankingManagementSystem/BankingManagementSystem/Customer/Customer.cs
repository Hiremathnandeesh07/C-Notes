using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Customers
{
    public  class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public static int TotalCustomers = 0;

        public Customer(int id, string name, string city)
        {
            CustomerId = id;
            Name = name;
            City = city;
            TotalCustomers++;
        }

        public void DisplayCustomer()
        {
            Console.WriteLine($"{CustomerId} - {Name} - {City}");
        }

    }

}
