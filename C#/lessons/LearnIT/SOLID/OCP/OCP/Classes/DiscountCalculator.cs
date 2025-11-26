using OCP.Interfaces;

namespace OCP.Classes
{
    public class DiscountCalculator
    {
        private readonly IDiscountStrategy _strategy;

        public DiscountCalculator(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }

        public double Calculate(double amount)
        {
            return _strategy.CalculateDiscount(amount);
        }
    }
}
