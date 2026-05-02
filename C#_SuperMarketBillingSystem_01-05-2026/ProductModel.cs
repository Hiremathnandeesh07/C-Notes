using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SuperMarketBillingSystem_01_05_2026
{
    internal class ProductModel
    {
        public ProductModel(int productCode, string name, decimal price, int quantity)
        {
            ProductCode = productCode;
            Name = name;
            Price = price;
            Quantity = quantity;
        }


        public int ProductCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } // Available stock


    }
}


