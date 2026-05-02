using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_ProductManagement_CRUD
{
    internal class Program
    {
      
            //Adding products
            public static List<Product> products = new List<Product>()
        {
              new Product(101,"Mobile",12000,"Electronics"),
              new Product(102,"Bottle", 120, "Plastic"),
              new Product(103, "Book", 90, "Stationery"),
              new Product(104, "Shirt", 1000, "Clothing"),
              new Product(105, "KS", 180, "Style")
        };
            static void Main(string[] args)
            {


                //Create object of Product Services
                ProductServices pService = new ProductServices();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("Enter the choide to perform operation\n" +
                                      "1.Display Details\n" +
                                      "2.Update Product\n" +
                                      "3.Delete a Product\n" +
                                      "4.Search for specific product\n" +
                                      "5.Show All Products\n" +
                                      "6.Display Products by Category.\n" +
                                      "7.Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            pService.DisplayDetails();
                            break;


                        case 2:
                            Console.Write("Enter id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            pService.UpdateProduct(id);
                            break;

                        case 3:
                            Console.Write("Enter id: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            pService.DeleteProduct(deleteId);
                            break;
                        case 4:
                            Console.Write("Enter id: ");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            pService.SearchById(searchId);
                            break;

                        case 5:
                            pService.ShowAllProducts();
                            break;

                        case 6:
                            Console.Write("Enter Category: ");
                            string category = Console.ReadLine();
                            pService.DisplayProductsByCategory(category);
                            break;

                        case 7:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid Input");
                            break;

                    }
                }






            }
        }
    }
















