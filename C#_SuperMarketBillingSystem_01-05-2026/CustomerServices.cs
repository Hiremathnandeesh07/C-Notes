using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SuperMarketBillingSystem_01_05_2026
{
    internal class CustomerServices
    {
        // array to store customer objects
        private static CustomerModel[] customers = new CustomerModel[100];
        // maintaining the index
        static int customerIndex = -1;

      
     
        // adding customer
        public static bool AddCustomer(string name)
        {
            // validating the indexoutofbound
            if (customerIndex >= 99)
            {
                return false;
            }
            else
            {
                int TempProductId = ProductServices.GenerateUnique5DigitNumber();
                CustomerModel customer = new CustomerModel(TempProductId, name);
                customers[++customerIndex] = customer;
            }
            return true;

        }

        // viewing customer
        public static bool ViewCustomer()
        {
            if (customerIndex < 0)
                return false;


            for (int i = 0; i <= customerIndex; i++)
            {
                var item = customers[i];
                Console.WriteLine($"{item.CustomerId}\t {item.Name}\t ");
            }

            return true;
        }



        // updating customer name
        public static bool UpdateCustomer(int customerId,string name)
        {
            for (int i = 0; i <= customerIndex; i++)
            {

                var item = customers[i];
                if (item.CustomerId == customerId)
                {
                    Console.WriteLine($"old customer details  : {customerId}");
                    Console.WriteLine($"{item.CustomerId}\t {item.Name}\t ");
                    item.Name = name;

                    Console.WriteLine($"New customer details  : {customerId}");
                    Console.WriteLine($"{item.CustomerId}\t {item.Name}\t ");
                    return true;
                }

            }
            return false;
        }

        // deleting customer

        public static void DeleteCustomer(int code)
        {
            for (int i = 0; i <= customerIndex; i++)
            {
                var item = customers[i];
                if (item.CustomerId == code)
                {
                    ShiftArrayElementsCustomer(i);
                    break;
                }
            }
        }


        // method to  slide all the objects to left afeter deletion
        public static bool ShiftArrayElementsCustomer(int deletingIndex)
        {

            if (deletingIndex < 0 || deletingIndex > customerIndex)
                return false;

            // shift references to the left
            for (int i = deletingIndex; i < customerIndex; i++)
            {
                customers[i] = customers[i + 1];
            }

            // clear last slot
            customers[customerIndex] = null;
            customerIndex--;

            return true;
        }







    }
}
