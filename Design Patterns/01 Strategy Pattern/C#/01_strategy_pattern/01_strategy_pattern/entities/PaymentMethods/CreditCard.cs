using _01_strategy_pattern.interfaces;

namespace _01_strategy_pattern.entities.PaymentMethods
{
    internal sealed class CreditCard : IPaymentMethod
    {
        public string getPaymentMethodName()
        {
            return "CreditCard";
        }
    }
}
