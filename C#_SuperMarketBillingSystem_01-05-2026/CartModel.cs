using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SuperMarketBillingSystem_01_05_2026
{
    internal class CartModel : ProductModel
    {

        public decimal Amount;

        // constructor for cartModel
        public CartModel(int productCode, string name, decimal price, int quantity) : base(productCode, name, price, quantity)
        {


        }

}
}
