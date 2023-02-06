using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _01_strategy_pattern.interfaces;

namespace _01_strategy_pattern.entities
{
    internal sealed class ShoppingCart
    {
        private List<Tuple<IItem, IPaymentMethod>> _items;

        public ShoppingCart()
        {
            this._items = new List<Tuple<IItem, IPaymentMethod>>();
        }

        public void AddItem(IItem item, IPaymentMethod paymentMethod)
        {
            this._items.Add(new Tuple<IItem, IPaymentMethod>(item, paymentMethod));
            Console.WriteLine($"Added Item '{item.Name}' with PaymentMethod {paymentMethod.getPaymentMethodName()} into ShoppingCart.");
        }

        public void removeItem(IItem item)
        {
            
        }

        public void Checkout()
        {
            foreach (var item in _items)
            {
                Console.WriteLine($"Item {item.Item1.Name} will be payed using {item.Item2.getPaymentMethodName()}");
            }
        }   
    }
}
