using CRUD_On_ProductsTable_ParameterizedQueries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_On_ProductsTable_ParameterizedQueries.Operations;

namespace CRUD_On_ProductsTable_ParameterizedQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product Price");
            Console.WriteLine("3. Display Specific Product");
            Console.WriteLine("4. Display All Products");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("----------------------------");

            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:

                        Console.WriteLine("enter name : ");
                        string name = Console.ReadLine();

                        Console.WriteLine("enter category : ");
                        string category = Console.ReadLine();

                        Console.WriteLine("enter price : ");
                        decimal price = Convert.ToDecimal(Console.ReadLine());

                        TableProducts tp = new TableProducts(name, category, price);

                        Console.WriteLine("Adding new product...");
                        ProductOperations.AddProduct(tp);
                        break;

                    case 2:
                        Console.WriteLine("enter the updating product name...");
                        string tname = Console.ReadLine();
                        Console.WriteLine("enter the new price of product...");
                        int tprice = Convert.ToInt32(Console.ReadLine());

                        ProductOperations.UpdatePrice(tname,tprice);
                        Console.WriteLine("Updating product price...");
                        
                        break;

                    case 3:
                        Console.Write("Enter specific product ID to display : ");
                        int tid = Convert.ToInt32(Console.ReadLine());
                        ProductOperations.DisplayProduct(tid);
                        break;

                    case 4:
                        Console.WriteLine("Displaying all products...");
                        ProductOperations.DisplayAllProducts();
                        break;

                    case 5:
                        Console.Write("Enter product ID to delete: ");
                        int delId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Are you sure? (yes/no): ");
                        string confirm = Console.ReadLine();

                        if (confirm.ToLower() == "yes")
                        {
                            ProductOperations.DeleteProduct(delId);
                            Console.WriteLine("Product deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Deletion cancelled.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }



            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           

        }

      
    }
}
