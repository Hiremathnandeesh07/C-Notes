using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__SuperMarketBillingSystem_01_05_2026
{
    internal class ProductServices
    {

        // array to store product objects
        public  static ProductModel[] products = new ProductModel[100];
        // maintaining the index
        public static int productsIndex = -1;
        
        // generating rand object
        static Random rand = new Random();


        // method to generate uniquenumber
        public static int GenerateUnique5DigitNumber()
        {
            while (true)
            {
                int num = rand.Next(10000, 100000);
                if (num.ToString().Distinct().Count() == 5)
                    return num;
            }
        }




        // adding the product
        public static bool AddProduct(string name, decimal price,int quantity)
        {
            // validating the indexoutofbound
            if (productsIndex >= 99)
            {
                return false;
            }
            else
            {
                int TempProductId = GenerateUnique5DigitNumber();
                ProductModel product = new ProductModel(TempProductId,name,price,quantity);
                products[++productsIndex] = product;
                
                return true;


            }

        }


        // displaying products
        public static bool ViewProducts()
        {

            if (productsIndex < 0)
                return false;


            for (int i = 0; i <= productsIndex; i++)
            {
                var item = products[i];
                Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
            }

            return true;

        }


        // updating product price with product code
        public static bool ProductPriceUpdate(int code,decimal price)
        {
            for (int i = 0; i <= productsIndex; i++)
            {

                var item = products[i];
                if (item.ProductCode == code)
                {
                    Console.WriteLine($"old product details of productCode : {code}");
                    Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
                    item.Price = price;

                    Console.WriteLine($"New product details of productCode : {code}");
                    Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
                    return true;
                }
                
            }
            return false;

        }


        // product quantity update with product code
        public static void ProductQuantityUpdate(int code, int quantity)
        {
            for (int i = 0; i <= productsIndex; i++)
            {

                var item = products[i];
                if (item.ProductCode == code)
                {
                    Console.WriteLine($"old product details of productCode : {code}");
                    Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
                    item.Quantity = quantity;

                    Console.WriteLine($"New product details of productCode : {code}");
                    Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
                    
                }

            }
           
        }

        // product deletion with product code

        public static void ProductDeletion(int code)
        {
            for(int i = 0; i <= productsIndex; i++)
            {
                var item = products[i];
                if (item.ProductCode == code)
                {
                    ShiftArrayElements(i);
                    break;
                }
            }
        }



        // method to  slide all the objects to left afeter deletion
        public static bool ShiftArrayElements(int deletingIndex)
        {

            if (deletingIndex < 0 || deletingIndex > productsIndex)
                return false;

            // shift references to the left
            for (int i = deletingIndex; i < productsIndex; i++)
            {
                products[i] = products[i + 1];
            }

            // clear last slot
            products[productsIndex] = null;
            productsIndex--;

            return true;
        }

        // searching product by name

        public static void SearchProductByName(string name)
        {
            //for (int i = 0; i <= productsIndex; i++)
            //{
            //    var item = products[i];
            //    if (item.Name.ToLower() == name.ToLower())
            //    {
            //        Console.WriteLine($"Product Details with name [{name}] are : ");
            //        Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");

            //    }
            //}

            var items = products.Take(productsIndex+1)
                                .Where(n => n.Name == name);
            foreach(var item in items)
            {
                Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
            }
            
        }


        // searching products by price range
        public static void SearchProductByPriceRange(int priceRangeStart, int priceRangeEnd)
        {
            Console.WriteLine($"Product Details with this price range is : ");
            //for (int i = 0; i < productsIndex; i++)
            //{
            //    var item = products[i];
            //    if(item.Price >= priceRangeStart && item.Price <= priceRangeEnd)
            //    {

            //        Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
            //    }
            //}

            var items = products.Take(productsIndex + 1)
                .Where(n => n.Price > priceRangeStart && n.Price < priceRangeEnd);
            foreach (var item in items)
            {
                Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
            }
        }


        // products with low stocks
        public static void LowStockProducts(int stock)
        {
            Console.WriteLine($"Product Details with less stock is : ");
            for (int i = 0; i < productsIndex; i++)
            {
                var item = products[i];
                if (item.Quantity <=stock )
                {

                    Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity}");
                }
            }
        }



}
}
