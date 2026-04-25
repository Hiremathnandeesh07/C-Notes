using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentManagementSystemProj.Services
{
    internal class AuthService
    {

        //private string username ;
        //private string password;
       

        private int failedAttempts = 0;
        private const int maxAttemps = 3;

        // Method to validate user considering attemps
        public bool ValidateUser(string username,string password)
        {
            // admin validate
            if(username=="admin" && password == "1234")
            {
                Console.WriteLine("Login Successful! Welcome admin");

                return true;
            }
            //user validate
            else if(username=="user" && password == "pass")
            {
                Console.WriteLine("Login Successful! Welcome User");
                return true;
            }
            else
            {
                failedAttempts++;
                Console.WriteLine($"Attemps : {failedAttempts} / 3");
                if (failedAttempts >= maxAttemps)
                {
                    Console.WriteLine("Your account is blocked.");
                }
                return false;
            }

        }
        
        public bool IsAccountBlocked()
        {
            return failedAttempts > maxAttemps;
        }

    }
}
