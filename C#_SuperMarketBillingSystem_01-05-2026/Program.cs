using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C__SuperMarketBillingSystem_01_05_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loginExit = false;
            string currentUser="";

            // starting the program by getting userType
            while (!loginExit)
            {
                Console.WriteLine($"Choose user role from below --- \n" +
                    $"1. Admin\n" +
                    $"2. User\n" +
                    $"3. Exit");


                // getting usertype input
                int userChoice = Convert.ToInt32(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        int adminPassCode = Convert.ToInt32(Console.ReadLine());
                        if (AuthService.IsAdminValid(adminPassCode))
                        {
                            currentUser = "admin";
                            Console.WriteLine("Admin login Successfull....");
                            Console.WriteLine("Here is the Menu --- > ");
                            loginExit = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Entered Wrong Password. Try Again...");
                            break;
                        }

                    case 2:
                        currentUser = "customer";
                        Console.WriteLine("User login Successfull....");
                        Console.WriteLine();
                        Console.WriteLine("\n\nHere is the Menu --- > ");
                        
                        break;
                    case 3:
                        Console.WriteLine("Exiting System......");
                        Task.Delay(2000);
                        loginExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input... Retry....");
                        loginExit = true;
                        break;
                }

                // breaking out of while Loop
                if (loginExit)
                {
                    break;
                }


            }
                // displaying and handling user menu
                if (currentUser == "admin")
                {
                    label1:
                Console.WriteLine("<------------------------->");
                    Console.WriteLine($"1. Add Product \r\n" +
                     $"2. View Products \r\n" +
                     $"3. Update Product \r\n" +
                     $"4. Delete Product \r\n" +
                     $"5. Search Product by Name \r\n" +
                     $"6. Search by Price Range \r\n" +
                     $"7. Low Stock Products \r\n" +
                     $"8. Back");
                Console.WriteLine("<------------------------->");

                int adminMenuInputChoice = Convert.ToInt32(Console.ReadLine());
                    switch (adminMenuInputChoice)
                    {

                           // adding the products
                        case 1:
                            Console.WriteLine("Enter the Product Name : ");
                            string ProductName = Console.ReadLine();
                            Console.WriteLine($"Enter the Price of [[ {ProductName} ]] : ");
                            decimal ProductPrice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Enter the Quantity of [[ {ProductName} ]] with price [[ {ProductPrice} ]] : ");
                            int ProductQuantity = Convert.ToInt32(Console.ReadLine());

                            if (ProductServices.AddProduct(ProductName, ProductPrice, ProductQuantity))
                            {
                                Console.WriteLine("\nproduct addedd suceesfully...\n");
                                goto label1;
                            }
                            else
                            {
                                Console.WriteLine("product space is full....");
                                goto label1;
                            }
                        


                        // viewing the products
                        case 2:
                        if (!ProductServices.ViewProducts())
                        {
                            Console.WriteLine("sorry the product list is empty\n\n\n");
                            
                        }
                        goto label1;
                        


                        case 3:
                            Console.WriteLine("you are updating Price and Quantity with productCode ----");
                            Console.WriteLine("Select the product code from below product list--");
                            ProductServices.ViewProducts();

                            Console.WriteLine("Noe enter the productCode : ");
                            int tempProductCode = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"Select which you want to update \n" +
                                $"1. updatePrice\n" +
                                $"2. UpdateQuantity");
                            decimal tempProductUpdateChoice = Convert.ToInt32(Console.ReadLine());
                            switch (tempProductUpdateChoice)
                            {
                                case 1:
                                    decimal newProductPrice = Convert.ToInt32(Console.ReadLine());
                                    if (!ProductServices.ProductPriceUpdate(tempProductCode, newProductPrice))
                                    {
                                        Console.WriteLine("product code not exist.....");
                                    }
                                    break;


                                case 2:
                                    int newProductQuantity = Convert.ToInt32(Console.ReadLine());
                                    ProductServices.ProductQuantityUpdate(tempProductCode, newProductQuantity);
                                    break;
                            }
                        goto label1;


                    case 4:
                        Console.WriteLine("Now enter the productCode to delete : ");
                        int tempProductCodeToDelete = Convert.ToInt32(Console.ReadLine());
                        ProductServices.ProductDeletion(tempProductCodeToDelete);

                        Console.WriteLine("deleted the item.....");
                        Console.WriteLine("New product List after deletiob : ");
                        ProductServices.ViewProducts();
                        goto label1;



                    case 5:
                        string productName = Console.ReadLine();
                        ProductServices.SearchProductByName(productName);
                        goto label1;

                    case 6:
                        Console.WriteLine("enter the price range start : ");
                        int priceRangeStart = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the price range end : ");
                        int priceRangeEnd = Convert.ToInt32(Console.ReadLine());
                        ProductServices.SearchProductByPriceRange(priceRangeStart,priceRangeEnd);
                        goto label1;


                    case 7:
                        Console.WriteLine("enter the quantity for the low stock products : ");
                        int tempStockQuantity = Convert.ToInt32(Console.ReadLine());

                        ProductServices.LowStockProducts(tempStockQuantity);

                        goto label1;

                    case 8:
                        break; ;
                    }
                }


                if(currentUser == "customer")
            {
            label2:
                Console.WriteLine("<--------CUSTOMER RELATED MENU------->");
                Console.WriteLine($"1. Add Customer \r\n" +
                 $"2. View Customer \r\n" +
                 $"3. Update Customer \r\n" +
                 $"4. Delete Customer \r\n" +
                 $"<-------CART RELATED MENU------------->" +
                 $"5. Add items to cart\n" +
                 $"6. Remove from cart\n" +
                 $"7. view Cart\n" +
                 $"8. Generate Bill\n" +
                 $"9. exit");
                Console.WriteLine("<------------------------->");

                int cusomterMenuInputChoice = Convert.ToInt32(Console.ReadLine());

                switch (cusomterMenuInputChoice)
                {
                    case 2:
                        CustomerServices.ViewCustomer();
                        goto label2;
                    case 1:
                        Console.WriteLine("enter customer name");
                        string tempCustomerName = Console.ReadLine();
                        CustomerServices.AddCustomer(tempCustomerName);
                        goto label2;

                    case 3:

                        Console.WriteLine("enter customer id to update his name...");
                        int tempCustomerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the new name...");
                        string tempCustomerNameToUpdate = Console.ReadLine();
                        CustomerServices.UpdateCustomer(tempCustomerId,tempCustomerNameToUpdate);
                        goto label2;

                    case 4:
                        Console.WriteLine("enter customer id to delete....");
                        tempCustomerId = Convert.ToInt32(Console.ReadLine());
                        CustomerServices.DeleteCustomer(tempCustomerId);

                        goto label2;

                    case 5:
                        Console.WriteLine("Following are the prodcuts -----\n");
                        ProductServices.ViewProducts();
                        Console.WriteLine("enter product code of Product to add to cart ----");
                        int tempCartProductCode = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the quantity to the product");
                        int tempCartProductQuantity = Convert.ToInt32(Console.ReadLine());
                        if (!CartServices.CheckProductAvailability(tempCartProductCode, tempCartProductQuantity))
                        {
                            Console.WriteLine("You entered more than the avilable quantity...");
                            
                        }
                        else
                        {
                            CartServices.AddToCart(tempCartProductCode, tempCartProductQuantity);
                        }
                        goto label2;

                    case 6:
                        Console.WriteLine("Present Cart items ---------");
                        CartServices.ShowCartItems();
                        Console.WriteLine("enter the product code to delete from cart ...");
                        int tempProductCodeFromCart = Convert.ToInt32(Console.ReadLine());
                        CartServices.CartItemDeletion(tempProductCodeFromCart);

                        goto label2;
                    case 7:
                        CartServices.ShowCartItems();
                        goto label2;
                    case 8:
                        CartServices.GenerateBill();
                        goto label2;

                    case 9:
                        break;



                }
            }






            }
        }
    }

