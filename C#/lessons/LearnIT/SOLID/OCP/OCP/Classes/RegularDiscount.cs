using OCP.Interfaces;

namespace OCP.Classes
{
    public class RegularDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * .1;
    }
}
