using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SuperMarketBillingSystem_01_05_2026
{

    // method to validating services
    internal class AuthService
    {
        private static int passcodeAdmin = 9090;
        public static bool IsAdminValid(int code)
        {
            if(code == passcodeAdmin)
            {
                return true;
            }
            return false;
        }
    }
}
