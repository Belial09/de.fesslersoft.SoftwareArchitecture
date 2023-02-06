using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_strategy_pattern.entities;
using _01_strategy_pattern.entities.PaymentMethods;

namespace _01_strategy_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();
            //Items get the PaymentMethod as IPaymentMethod so that the Checkout() method is independent of their real implementation.
            cart.AddItem(new Item("carrot"), new PayPal());
            cart.AddItem(new Item("apple"), new Klarna());
            cart.AddItem(new Item("tomato"), new CreditCard());
            cart.Checkout();
            Console.Read();
        }
    }
}
