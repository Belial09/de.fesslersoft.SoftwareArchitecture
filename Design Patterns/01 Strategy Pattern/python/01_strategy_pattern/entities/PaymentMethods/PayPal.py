from interfaces.BasePaymentMethod import BasePaymentMethod


class PayPal(BasePaymentMethod):

    def getpaymentmethodname(self):
        return "Paypal"