from interfaces.BasePaymentMethod import BasePaymentMethod


class Klarna(BasePaymentMethod):

    def getpaymentmethodname(self):
        return "Klarna"