using MiniProject_BankTransaction_App.Models;
using MiniProject_BankTransaction_App.Services;
using System;
using System.Threading;

namespace MiniProject_BankTransaction_App
{
    internal class Program
    {
        private static AdminService _adService = new AdminService();
        private static CustomerService _cusService = new CustomerService();

        static bool mainloop = true;

        static void Main(string[] args)
        {
            Console.Title = "Mini Banking System";

            while (mainloop)
            {
                Console.Clear();
                BeginOperation();
            }
        }


        // BEGIN OPERATION
        static void BeginOperation()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("              MINI BANKING SYSTEM                   ");
            Console.WriteLine("====================================================\n");

            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. Customer Login");
            Console.WriteLine("3. Customer Registration");
            Console.WriteLine("4. Exit\n");

            int choice;

            while(!int.TryParse(Console.ReadLine(),out choice))
            {
                Console.WriteLine("Invalid Input. Please enter from above menu only.....");
            }

            //Console.Write("Enter your choice : ");
            //int choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (choice)
            {
                case 1:

                    Console.WriteLine("============== ADMIN LOGIN ==============\n");

                    Console.Write("Enter UserName : ");
                    string tuserName = Console.ReadLine();

                    Console.Write("Enter Password : ");
                    string tpassWord = Console.ReadLine();

                    if (_adService.AdminLogin(tuserName, tpassWord))
                    {
                        Console.WriteLine("\nLogin Successful...");
                        Thread.Sleep(1000);
                        Console.Clear();

                        AdminDashBoard();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Credentials...");
                        Thread.Sleep(1500);
                    }

                    break;


                case 2:

                    Console.WriteLine("============ CUSTOMER LOGIN ============\n");

                    Console.Write("Enter Account Number : ");
                    string tAccountNumber = Console.ReadLine();

                    Console.Write("Enter Password       : ");
                    tpassWord = Console.ReadLine();

                    bool customerLogin = false;

                    string cusName =
                        _cusService.CustomerLogin(
                            tAccountNumber,
                            tpassWord,
                            out customerLogin);

                    if (customerLogin)
                    {
                        Console.WriteLine("\nLogin Successful...");
                        Console.WriteLine($"Welcome {cusName} !!!");

                        Thread.Sleep(1500);
                        Console.Clear();

                        CustomerDashBoard(tAccountNumber, cusName);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Credentials...");
                        Thread.Sleep(1500);
                    }

                    break;


                case 3:

                    Console.WriteLine("========== CUSTOMER REGISTRATION =========\n");

                    Console.Write("Enter Name            : ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Gender          : ");
                    string gender = Console.ReadLine();

                    Console.Write("Enter Mobile Number   : ");
                    string mobile = Console.ReadLine();

                    Console.Write("Enter Email           : ");
                    string email = Console.ReadLine();

                    Console.Write("Enter Address         : ");
                    string address = Console.ReadLine();

                    Console.Write("Enter Aadhaar Number  : ");
                    string aadhaar = Console.ReadLine();

                    Console.Write("Enter Account Type    : ");
                    string accType = Console.ReadLine();

                    Console.Write("Enter Password        : ");
                    string password = Console.ReadLine();

                    _adService.AddCustomer(
                        name,
                        gender,
                        mobile,
                        email,
                        address,
                        aadhaar,
                        accType,
                        password);

                    Console.WriteLine("\nCustomer Registration Completed...");
                    Thread.Sleep(2000);

                    break;


                case 4:

                    Console.WriteLine("\nThank You For Using Banking System...");
                    Thread.Sleep(1500);

                    mainloop = false;
                    break;


                default:

                    Console.WriteLine("\nInvalid Choice...");
                    Thread.Sleep(1500);
                    break;
            }
        }


        // CUSTOMER DASHBOARD
        static void CustomerDashBoard(string tAccountNumber, string cusName)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("====================================================");
                Console.WriteLine($"      CUSTOMER DASHBOARD - {cusName}      ");
                Console.WriteLine("====================================================\n");

                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Mini Statement");
                Console.WriteLine("5. Fund Transfer");
                Console.WriteLine("6. Update Profile");
                Console.WriteLine("7. Change Password");
                Console.WriteLine("8. Close Account");
                Console.WriteLine("9. Logout\n");

                Console.Write("Enter your choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("============== DEPOSIT ==============\n");

                        Console.Write("Enter Amount : ");
                        long tamount = Convert.ToInt64(Console.ReadLine());

                        _cusService.DepositAmount(tAccountNumber, tamount);

                        break;


                    case 2:

                        Console.WriteLine("============== WITHDRAW ==============\n");

                        Console.Write("Enter Amount : ");
                        tamount = Convert.ToInt64(Console.ReadLine());

                        _cusService.WithDrawAmount(tAccountNumber, tamount);

                        break;


                    case 3:

                        Console.WriteLine("============== BALANCE ==============\n");

                        _cusService.GetBalance(tAccountNumber);

                        break;


                    case 4:

                        Console.WriteLine("=========== MINI STATEMENT ===========\n");

                        _cusService.ShowMiniStatement(tAccountNumber);

                        break;


                    case 5:

                        Console.WriteLine("=========== FUND TRANSFER ===========\n");
                        Console.Write("Enter Amount : ");
                        tamount = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter the Recievers Account Number :");
                        string receiversAccNo = Console.ReadLine();
                        _cusService.FundTransfer(tAccountNumber, receiversAccNo, tamount);



                        break;


                    case 6:

                        Console.WriteLine("=========== UPDATE PROFILE ===========\n");

                        Console.WriteLine($"Account Number : {tAccountNumber}\n");

                        Console.Write("Enter Mobile Number : ");
                        string mobileNumber = Console.ReadLine();

                        Console.Write("Enter Email         : ");
                        string email = Console.ReadLine();

                        Console.Write("Enter Address       : ");
                        string address = Console.ReadLine();

                        Console.Write("Enter Account Type  : ");
                        string accType = Console.ReadLine();

                        _adService.UpdateCustomer(
                            tAccountNumber,
                            mobileNumber,
                            email,
                            address,
                            accType);

                        break;


                    case 7:

                        Console.WriteLine("========== CHANGE PASSWORD ==========\n");

                        Console.Write("Enter New Password : ");
                        string tNewPassWord = Console.ReadLine();

                        _cusService.ChangePassword(
                            tAccountNumber,
                            tNewPassWord);

                        break;


                    case 8:

                        Console.WriteLine("========== CLOSE ACCOUNT ==========\n");
                        _adService.DeleteCustomer(tAccountNumber);

                        break;


                    case 9:

                        Console.WriteLine("Logging Out.....");
                        Thread.Sleep(1500);

                        Console.WriteLine("\nRedirecting to Main Login Menu...");
                        Thread.Sleep(1000);

                        for (int i = 3; i >= 1; i--)
                        {
                            Console.WriteLine(i);
                            Thread.Sleep(1000);
                        }

                        Console.Clear();
                        return;


                    default:

                        Console.WriteLine("Invalid Choice...");
                        Thread.Sleep(1500);
                        break;
                }

                Console.WriteLine("\nPress Any Key To Continue...");
                Console.ReadKey();
            }
        }


        // ADMIN DASHBOARD
        static void AdminDashBoard()
        {
            bool looping = true;

            while (looping)
            {
                Console.Clear();

                Console.WriteLine("====================================================");
                Console.WriteLine("                ADMIN DASHBOARD                     ");
                Console.WriteLine("====================================================\n");

                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. View All Customers");
                Console.WriteLine("5. Search Customer");
                Console.WriteLine("6. View Customers by Account Type");
                Console.WriteLine("7. View Transactions");
                Console.WriteLine("8. Freeze Account");
                Console.WriteLine("9. Logout\n");

                Console.Write("Enter your choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("=========== ADD CUSTOMER ===========\n");

                        Console.Write("Enter Name            : ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Gender          : ");
                        string gender = Console.ReadLine();

                        Console.Write("Enter Mobile Number   : ");
                        string mobile = Console.ReadLine();

                        Console.Write("Enter Email           : ");
                        string email = Console.ReadLine();

                        Console.Write("Enter Address         : ");
                        string address = Console.ReadLine();

                        Console.Write("Enter Aadhaar Number  : ");
                        string aadhaar = Console.ReadLine();

                        Console.Write("Enter Account Type    : ");
                        string accType = Console.ReadLine();

                        Console.Write("Enter Password        : ");
                        string password = Console.ReadLine();

                        _adService.AddCustomer(
                            name,
                            gender,
                            mobile,
                            email,
                            address,
                            aadhaar,
                            accType,
                            password);

                        break;


                    case 2:

                        Console.WriteLine("========== UPDATE CUSTOMER ==========\n");

                        Console.Write("Enter Account Number : ");
                        string accountNumber = Console.ReadLine();

                        Console.Write("Enter Mobile Number  : ");
                        string mobileNumber = Console.ReadLine();

                        Console.Write("Enter Email          : ");
                        email = Console.ReadLine();

                        Console.Write("Enter Address        : ");
                        address = Console.ReadLine();

                        Console.Write("Enter Account Type   : ");
                        accType = Console.ReadLine();

                        _adService.UpdateCustomer(
                            accountNumber,
                            mobileNumber,
                            email,
                            address,
                            accType);

                        break;


                    case 3:

                        Console.WriteLine("========== DELETE CUSTOMER ==========\n");

                        Console.Write("Enter Account Number : ");
                        accountNumber = Console.ReadLine();

                        _adService.DeleteCustomer(accountNumber);

                        break;


                    case 4:

                        Console.WriteLine("========== ALL CUSTOMERS ==========\n");

                        _adService.ViewAllCustomers();

                        break;


                    case 5:

                        Console.WriteLine("========== SEARCH CUSTOMER ==========\n");

                        Console.Write("Enter Account Number : ");
                        accountNumber = Console.ReadLine();

                        _adService.SearchCustomer(accountNumber);

                        break;


                    case 6:

                        Console.WriteLine("====== CUSTOMERS BY ACCOUNT TYPE ======\n");

                        Console.WriteLine("1. Savings");
                        Console.WriteLine("2. Current");
                        Console.WriteLine("3. Salary\n");

                        Console.Write("Choose Account Type : ");
                        int tAccType = Convert.ToInt32(Console.ReadLine());

                        switch (tAccType)
                        {
                            case 1:
                                _adService.GetCustomersByAccountType("Savings");
                                break;

                            case 2:
                                _adService.GetCustomersByAccountType("Current");
                                break;

                            case 3:
                                _adService.GetCustomersByAccountType("Salary");
                                break;
                        }

                        break;


                    case 7:

                        Console.WriteLine("========== VIEW TRANSACTIONS ==========\n");

                        Console.Write("Enter Account Number : ");
                        accountNumber = Console.ReadLine();

                        _adService.ViewTransactionsOnAccNo(accountNumber);

                        break;


                    case 8:

                        Console.WriteLine("========== FREEZE ACCOUNT ==========\n");

                        Console.Write("Enter Account Number : ");
                        accountNumber = Console.ReadLine();

                        _adService.FreezeAccount(accountNumber);

                        break;


                    case 9:

                        Console.WriteLine("Logging Out...");
                        Thread.Sleep(1500);

                        looping = false;
                        break;


                    default:

                        Console.WriteLine("Invalid Choice...");
                        Thread.Sleep(1500);
                        break;
                }

                if (looping)
                {
                    Console.WriteLine("\nPress Any Key To Continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}

