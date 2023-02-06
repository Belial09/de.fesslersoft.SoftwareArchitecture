using _01_strategy_pattern.interfaces;

namespace _01_strategy_pattern.entities.PaymentMethods
{
    internal sealed class PayPal:IPaymentMethod
    {
        public string getPaymentMethodName()
        {
            return "Paypal";
        }
    }
}
