from interfaces.BasePaymentMethod import BasePaymentMethod


class CreditCard(BasePaymentMethod):

    def getpaymentmethodname(self):
        return "CreditCard"