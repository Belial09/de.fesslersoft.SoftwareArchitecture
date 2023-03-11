from ShoppingCart import ShoppingCart
from entities.Item import Item
from entities.PaymentMethods.CreditCard import CreditCard
from entities.PaymentMethods.Klarna import Klarna
from entities.PaymentMethods.PayPal import PayPal

if __name__ == '__main__':
    shopping_cart = ShoppingCart()
    shopping_cart.additem(Item("carrot"), PayPal())
    shopping_cart.additem(Item("apple"), Klarna())
    shopping_cart.additem(Item("tomato"), CreditCard())
    shopping_cart.checkout()