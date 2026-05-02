using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_ProductManagement_CRUD
{
    internal class ProductServices
    {




       

            public void DisplayDetails()
            {
            foreach (var item in Program.products)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Price}\t{item.Category}");
            }


        }

            public void UpdateProduct(int id)
            {
                foreach (var item in Program.products)
                {
                    if (item.Id == id)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Category);
                        Console.WriteLine("Choose what you want to update\n" +
                                            "1.Name\n" +
                                            "2.Price\n" +
                                            "3.Category");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter Name: ");
                                string name = Console.ReadLine();
                                item.Name = name;
                                Console.WriteLine("Name updated");
                                Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Category);
                                break;

                            case 2:
                                Console.Write("Enter Price: ");
                                double price = Convert.ToDouble(Console.ReadLine());
                                item.Price = price;
                                Console.WriteLine("Price updated");
                                Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Category);
                                break;

                            case 4:
                                Console.Write("Enter Category: ");
                                string category = Console.ReadLine();
                                item.Category = category;
                                Console.WriteLine("Category updated");
                                Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Category);
                                break;

                            default:
                                Console.WriteLine("Enter valid Input");
                                break;


                        }
                        return;
                    }

                }
                Console.WriteLine("Invalid id");
            }

            public void DeleteProduct(int id)
            {
            foreach (var item in Program.products)
            {
                if (item.Id == id)
                {
                    Program.products.Remove(item);
                    return;
                }
            }



            Console.WriteLine("Invalid id");
            }

            public void SearchById(int id)
            {
                foreach (var item in Program.products)
                {
                    if (item.Id == id)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Category);
                        return;
                    }
                }
                Console.WriteLine("Invalid id");
            }

            public void ShowAllProducts()
            {
                foreach (var item in Program.products)
                {
                    Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Category);
                }
            }


            public void DisplayProductsByCategory(string category)
            {
                foreach (var item in Program.products)
                {
                    if (item.Category == category)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Category);
                        return;
                    }
                }
                Console.WriteLine("Invalid category");
            }

        }
    }



