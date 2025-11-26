using OCP.Interfaces;

namespace OCP.Classes
{
    public class StudentDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * .5;
    }
}
