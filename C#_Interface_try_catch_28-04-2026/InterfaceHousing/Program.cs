using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHousing
{
    internal class Program
    {

        /*
         *  CUSTOMER WHO TOOK HOUSINGLOAN WANTED TO SWITCH TO ANY OTHER BANK
         *  DUE TO LESS INTRESET
         *  
         *  VREATE AN INTERFACE NAMED ibank WHICH CONATIN INTRESTRATE()
         *  METHOD AND IMPLIMENT IT IN THE CLASSESS Like hdfe,sbi AND icicI
         * 
         */
        static void Main(string[] args)
        {
            IBank myBank = new DSbi();
            myBank.IntrestRate();

           

            myBank = new DIcici();
            myBank.IntrestRate();
        }
    }
}
