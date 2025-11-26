using OCP.Interfaces;

namespace OCP.Classes
{
    public class VIPDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * .2;
    }
}
