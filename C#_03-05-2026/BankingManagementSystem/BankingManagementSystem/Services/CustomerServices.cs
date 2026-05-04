using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Services
{
    public class CustomerServices
    {
        public static void AddCustomer()
        {
            Console.WriteLine("Enter the following details to register as a customer");
            Console.Write("Id: ");
            int id = Int32.Parse(Console.ReadLine().Trim());
            Console.Write("Name: " );
            string name = Console.ReadLine().Trim();
            Console.Write("City :");
            string city = Console.ReadLine();
            Program.customers.Add(new Customers.Customer(id, name, city));
            Console.WriteLine("Customer Registered Successfully\n");
        }


        public static void ViewCustomer()
        {
            Console.WriteLine("----------Showing Customer Details------------\n");

            foreach (var customer in Program.customers)
            {
                customer.DisplayCustomer();
            }
            Console.WriteLine("----------------------------------------------\n");
        }

        public static void CountTotalCustomer()
        {
            Console.WriteLine("The total number of customers are : " + Customers.Customer.TotalCustomers);
        }


    }
}
