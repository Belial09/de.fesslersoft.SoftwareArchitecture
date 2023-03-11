from typing import List, Tuple
from interfaces import BasePaymentMethod, BaseItem


class ShoppingCart:
    items: List[Tuple[BaseItem, BasePaymentMethod]]

    def __init__(self):
        self.items = []

    def additem(self, item: BaseItem, paymentmethod: BasePaymentMethod):
        self.items.append((item, paymentmethod))
        print(f'Added Item "{item.name}" with PaymentMethod "{paymentmethod.getpaymentmethodname()}" into ShoppingCart.')

    def removeitem(self, itemtuple: Tuple[BaseItem, BasePaymentMethod]):
        if itemtuple in self.items:
            self.items.remove(itemtuple)
            print(f'Removed Item "{itemtuple[0].name}" from ShoppingCart.')
        else:
            print(f'Item "UNKNOWN" not found in ShoppingCart.')

    def checkout(self):
        for item, payment_method in self.items:
            print(f'Item {item.name} will be paid using {payment_method.getpaymentmethodname()}')