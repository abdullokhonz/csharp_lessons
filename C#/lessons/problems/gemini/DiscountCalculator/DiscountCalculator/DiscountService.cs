namespace DiscountCalculator
{
    public class DiscountService
    {
        public decimal CalculateFinalPrice(Product product, bool isBirthday)
        {
            decimal originalPrice = product.Price;
            decimal totalDiscountPercent = 0;

            // Скидка за сумму заказа
            if (originalPrice > 5000)
            {
                totalDiscountPercent += 0.05m; // 5%
            }

            // Скидка за день рождения
            if (isBirthday)
            {
                totalDiscountPercent += 0.10m; // 10%
            }

            // Вычисляем сумму скидки
            decimal discountAmount = originalPrice * totalDiscountPercent;

            // Ограничение для электроники (макс. 1000 руб)
            if (product.Category == Category.Electronics && discountAmount > 1000)
            {
                discountAmount = 1000;
            }

            return originalPrice - discountAmount;
        }
    }
}
