//using MiniProject_BankTransaction_App.Models;
//using MiniProject_BankTransaction_App.Services;
//using System;
//using System.Collections.Generic;
//using System.IO.MemoryMappedFiles;
//using System.Linq;
//using System.Net;
//using System.Security.AccessControl;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace MiniProject_BankTransaction_App
//{
//    internal class Program
//    {
//      private static AdminService _adService = new AdminService();

//        private static CustomerService _cusService = new CustomerService();
//        static bool mainloop = true;

//        static void Main(string[] args)
//        {


//            while (mainloop)
//            {
//                BeginOperation();
//            }


//        }

//        // BEGIN OPERATION
//        static void BeginOperation()
//        {
//            Console.WriteLine("----Banking system ------");
//            Console.WriteLine("Enter your Role ---");
//            Console.WriteLine("1.Admin Login\n" +
//                "2. Customer Login\n" +
//                "3. Customer Registrtion\n" +
//                "4. Exit");
//            int choice = Convert.ToInt32(Console.ReadLine());
//            switch (choice)
//            {
//                case 1:
//                    Console.WriteLine("enter the userName :");
//                    string tuserName = Console.ReadLine();
//                    Console.WriteLine("enter the password");
//                    string tpassWord = Console.ReadLine();
//                    if (_adService.AdminLogin(tuserName, tpassWord))
//                    {
//                        AdminDashBoard();
//                    }
//                    break;
//                case 2:
//                    Console.WriteLine("enter the AccountNumber :");
//                    string tAccountNumber = Console.ReadLine();
//                    Console.WriteLine("enter the password");
//                    tpassWord = Console.ReadLine();
//                    bool customerLogin = false;
//                    string cusName = _cusService.CustomerLogin(tAccountNumber, tpassWord, out customerLogin);
//                    if (customerLogin)
//                    {
//                        Console.WriteLine("Login successfull...");
//                        Console.WriteLine($"Welcome {cusName} to out Bank with Account Number {tAccountNumber}");
//                        CustomerDashBoard(tAccountNumber, cusName);
//                    }
//                    else
//                    {
//                        Console.WriteLine("invalid credentials");
//                    }
//                    break;
//                case 3:

//                    Console.WriteLine("Add Customer Selected");
//                    Console.Write("Enter Name: ");
//                    string name = Console.ReadLine();

//                    Console.Write("Enter Gender: ");
//                    string gender = Console.ReadLine();

//                    Console.Write("Enter Mobile Number: ");
//                    string mobile = Console.ReadLine();

//                    Console.Write("Enter Email: ");
//                    string email = Console.ReadLine();

//                    Console.Write("Enter Address: ");
//                    string address = Console.ReadLine();

//                    Console.Write("Enter Aadhaar Number: ");
//                    string aadhaar = Console.ReadLine();

//                    Console.Write("Enter Account Type: ");
//                    string accType = Console.ReadLine();

//                    Console.Write("Enter Password: ");
//                    string password = Console.ReadLine();

//                    _adService.AddCustomer(name, gender, mobile, email, address, aadhaar, accType, password);

//                    break;
//                case 4:
//                    mainloop = !mainloop;
//                    break;






//            }
//        }

//        // CUSTOMER DASHBOARD
//        static void CustomerDashBoard(string tAccountNumber,string cusName)
//        {
//            string presentCustomerAccNo = tAccountNumber;
//            string PresentCustomerName = cusName;
//            while (true)
//            {
//                Console.WriteLine("\n========== CUSTOMER MENU ==========\n");

//                Console.WriteLine("1. Deposit");
//                Console.WriteLine("2. Withdraw");
//                Console.WriteLine("3. Show Balance");
//                Console.WriteLine("4. Mini Statement");
//                Console.WriteLine("5. Fund Transfer");
//                Console.WriteLine("6. Update Profile");
//                Console.WriteLine("7. Change Password");
//                Console.WriteLine("8. Close Account");
//                Console.WriteLine("9. Logout");

//                Console.Write("\nEnter your choice: ");

//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:

//                        Console.WriteLine("Deposit Selected....");
//                        Console.WriteLine("Enter the amount to be deposited : ");
//                        long tamount = Convert.ToInt64(Console.ReadLine());
//                        _cusService.DepositAmount(tAccountNumber, tamount);
//                        break;

//                    case 2:
//                        Console.WriteLine("Withdraw Selected");
//                        Console.WriteLine("Enter the amount to be Withdrawed : ");
//                        tamount = Convert.ToInt64(Console.ReadLine());
//                        _cusService.WithDrawAmount(tAccountNumber, tamount);
//                        break;

//                    case 3:
//                        Console.WriteLine("Show Balance Selected");
//                        _cusService.GetBalance(tAccountNumber);
//                        break;

//                    case 4:
//                        Console.WriteLine("Mini Statement Selected");
//                        _cusService.ShowMiniStatement(tAccountNumber);
//                        break;

//                    case 5:
//                        Console.WriteLine("Fund Transfer Selected");
//                        break;

//                    case 6:
//                        Console.WriteLine("Update Profile Selected");
//                        Console.WriteLine("Update Customer Selected");
//                        Console.Write($" your AccountNumber is :{tAccountNumber} ");


//                        Console.Write("Enter Mobile Number: ");
//                        string mobileNumber = Console.ReadLine();


//                        Console.Write("Enter Email: ");
//                        string email = Console.ReadLine();

//                        Console.Write("Enter Address: ");
//                        string address = Console.ReadLine();

//                        Console.Write("Enter AccountType: ");
//                        string accType = Console.ReadLine();

//                        Console.Write("Enter Account status:");
//                        string accStatus = Console.ReadLine();

//                        _adService.UpdateCustomer(tAccountNumber, mobileNumber, email, address, accType);
//                        break;


//                    case 7:
//                        Console.WriteLine("Change Password Selected");
//                        Console.WriteLine("Enter the new password :");
//                        string tNewPassWord = Console.ReadLine();
//                        _cusService.ChangePassword(tAccountNumber,tNewPassWord);

//                        break;

//                    case 8:
//                        Console.WriteLine("Close Account Selected");
//                        break;

//                    case 9:
//                        Console.WriteLine("Logging Out.....");
//                        Thread.Sleep(1500);

//                        Console.WriteLine("\nRedirecting to Main Login Menu...");
//                        Thread.Sleep(1000);

//                        for (int i = 3; i >= 1; i--)
//                        {
//                            Console.WriteLine(i);
//                            Thread.Sleep(1000);
//                        }

//                        Console.Clear();

//                        return;

//                    default:
//                        Console.WriteLine("Invalid Choice");
//                        break;
//                }
//            }
//        }

































//        //ADMIN DASHBOARD
//        static void AdminDashBoard()
//        {
//            bool looping = true;
//            while (looping)
//            {


//                Console.WriteLine("---Admin DashBoard---");
//                Console.WriteLine("1. Add Customer");
//                Console.WriteLine("2. Update Customer");
//                Console.WriteLine("3. Delete Customer");
//                Console.WriteLine("4. View All Customers");
//                Console.WriteLine("5. Search Customer");
//                Console.WriteLine("6. View Customers by Account Type");
//                Console.WriteLine("7. View Transactions");
//                Console.WriteLine("8. Freeze Account");
//                Console.WriteLine("9. Logout");

//                Console.Write("\nEnter your choice: ");

//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Console.WriteLine("Add Customer Selected");
//                        Console.Write("Enter Name: ");
//                        string name = Console.ReadLine();

//                        Console.Write("Enter Gender: ");
//                        string gender = Console.ReadLine();

//                        Console.Write("Enter Mobile Number: ");
//                        string mobile = Console.ReadLine();

//                        Console.Write("Enter Email: ");
//                        string email = Console.ReadLine();

//                        Console.Write("Enter Address: ");
//                        string address = Console.ReadLine();

//                        Console.Write("Enter Aadhaar Number: ");
//                        string aadhaar = Console.ReadLine();

//                        Console.Write("Enter Account Type: ");
//                        string accType = Console.ReadLine();

//                        Console.Write("Enter Password: ");
//                        string password = Console.ReadLine();

//                        _adService.AddCustomer(name, gender, mobile, email, address, aadhaar, accType, password);

//                        break;

//                    case 2:
//                        Console.WriteLine("Update Customer Selected");
//                        Console.Write("Enter AccountNumber: ");
//                        string accountNumber = Console.ReadLine();

//                        Console.Write("Enter Mobile Number: ");
//                        string mobileNumber = Console.ReadLine();


//                        Console.Write("Enter Email: ");
//                         email = Console.ReadLine();

//                        Console.Write("Enter Address: ");
//                         address = Console.ReadLine();

//                        Console.Write("Enter AccountType: ");
//                         accType = Console.ReadLine();

//                        Console.Write("Enter Account status:");
//                           string accStatus = Console.ReadLine();

//                        _adService.UpdateCustomer(accountNumber, mobileNumber, email, address, accType);
//                        break;

//                    case 3:
//                        Console.WriteLine("Delete Customer Selected");
//                        Console.Write("Enter AccountNumber: ");
//                         accountNumber = Console.ReadLine();
//                        _adService.DeleteCustomer(accountNumber);
//                        Console.WriteLine("Delete Customer Selected");
//                        break;

//                    case 4:
//                        Console.WriteLine("View All Customers Selected");
//                        _adService.ViewAllCustomers();
//                        break;

//                    case 5:
//                        Console.WriteLine("Search Customer Selected");
//                        Console.Write("Enter AccountNumber: ");
//                        accountNumber = Console.ReadLine();
//                        _adService.SearchCustomer(accountNumber);
//                        break;

//                    case 6:
//                        Console.WriteLine("View Customers by Account Type Selected ---");
//                        Console.WriteLine("Choose account type to display :\n" +

//                            "1. Savings \n" +
//                            "2. Current \n" +
//                            "3. Salary");

//                        int tAccType = Convert.ToInt32( Console.ReadLine());

//                        switch (tAccType)
//                        {
//                            case 1:
//                                _adService.GetCustomersByAccountType("Savings");
//                                break;
//                            case 2:
//                                _adService.GetCustomersByAccountType("Current");
//                                break;
//                            case 3:
//                                _adService.GetCustomersByAccountType("Salary");
//                                break;
//                        }


//                        break;

//                    case 7:
//                        Console.WriteLine("View Transactions Selected");
//                        Console.Write("Enter AccountNumber: ");
//                        accountNumber = Console.ReadLine();
//                        _adService.ViewTransactionsOnAccNo(accountNumber);
//                        break;

//                    case 8:
//                        Console.WriteLine("Freeze Account Selected");
//                        Console.Write("Enter AccountNumber: ");
//                        accountNumber = Console.ReadLine();
//                        _adService.FreezeAccount(accountNumber);
//                        break;

//                    case 9:
//                        Console.WriteLine("Logout Successful");
//                        looping = !looping;
//                        break;

//                    default:
//                        Console.WriteLine("Invalid Choice");
//                        break;
//                }
//            }
//        } 
//    }
//}
