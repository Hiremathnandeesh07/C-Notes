using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SuperMarketBillingSystem_01_05_2026
{
    internal class CartServices
    {
        private static CartModel[] cartProducts = new CartModel[100];

        public static int cartProductsIndex = -1;


        // checkking availability of the particualr product with quantity
        public static bool CheckProductAvailability(int CartProductCode, int CartProductQuantity)
        {
            for (int i = 0; i < ProductServices.productsIndex; i++)
            {
                var item = ProductServices.products[i];
                if (item.ProductCode == CartProductCode && item.Quantity>=CartProductQuantity)
                {
                    return true;
                }
            }
            return false;
        }

        public static void AddToCart(int CartProductCode, int CartProductQuantity)
        {

            // fetching product name and price of the product with code
            for (int i = 0; i < ProductServices.productsIndex; i++)
            {
                string tempProductName;
                decimal tempProductPrice;
                var item = ProductServices.products[i];
                if (item.ProductCode == CartProductCode )
                {
                    tempProductName = item.Name;
                    tempProductPrice = item.Price;
                    CartModel cartItems = new CartModel(CartProductCode, tempProductName, tempProductPrice, CartProductQuantity);
                    cartProducts[++cartProductsIndex] = cartItems;
                }

            }

        }


        // deleting from cart
        public static void CartItemDeletion(int code)
        {
            for (int i = 0; i <= cartProductsIndex; i++)
            {
                var item = cartProducts[i];
                if (item.ProductCode == code)
                {
                    ShiftArrayElementsInCart(i);
                    break;
                }
            }
        }



        // method to  slide all the objects to left afeter deletion
        public static bool ShiftArrayElementsInCart(int deletingIndex)
        {

            if (deletingIndex < 0 || deletingIndex > cartProductsIndex)
                return false;

            // shift references to the left
            for (int i = deletingIndex; i < cartProductsIndex; i++)
            {
                cartProducts[i] = cartProducts[i + 1];
            }

            // clear last slot
            cartProducts[cartProductsIndex] = null;
            cartProductsIndex--;

            return true;
        }


        // displaying cart items 
        public static void ShowCartItems()
        {
            foreach(var item in cartProducts)
            {
                Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity} \t {item.Price*item.Quantity}");
            }
        }



        // generating the bill 
        public static void GenerateBill()
        {
            Console.WriteLine("following is the bill generated of your cart --------- >");
            Console.WriteLine("========= BILL =========");
            decimal totalBillAmount = 0;
            foreach (var item in cartProducts)
            {
                totalBillAmount += item.Price * item.Quantity;
                Console.WriteLine($"{item.ProductCode}\t {item.Name}\t {item.Price}\t {item.Quantity} \t {item.Price * item.Quantity}");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Total Bill Amount is : {totalBillAmount}");

        }
    }
}
