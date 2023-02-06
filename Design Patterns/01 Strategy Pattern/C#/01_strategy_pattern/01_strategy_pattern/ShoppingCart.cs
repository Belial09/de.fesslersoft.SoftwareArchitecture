using System;
using System.Collections.Generic;
using System.Linq;
using _01_strategy_pattern.interfaces;

namespace _01_strategy_pattern
{
    internal sealed class ShoppingCart
    {
        internal List<Tuple<IItem, IPaymentMethod>> _items;

        public ShoppingCart()
        {
            this._items = new List<Tuple<IItem, IPaymentMethod>>();
        }

        public void AddItem(IItem item, IPaymentMethod paymentMethod)
        {
            this._items.Add(new Tuple<IItem, IPaymentMethod>(item, paymentMethod));
            Console.WriteLine($"Added Item '{item.Name}' with PaymentMethod {paymentMethod.getPaymentMethodName()} into ShoppingCart.");
        }

        public Tuple<IItem, IPaymentMethod> getItem(Guid itemIdentifier)
        {
            return _items.FirstOrDefault(i => i.Item1.Identifier == itemIdentifier);
        }

        public void removeItem(Tuple<IItem, IPaymentMethod> itemTuple)
        {
            if (itemTuple != null)
            {
                _items.Remove(itemTuple);
                Console.WriteLine($"Removed Item '{itemTuple.Item1.Name}' from ShoppingCart.");
            }
            else
            {
                Console.WriteLine($"Item 'UNKNOWN not found in ShoppingCart.");
            }
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
