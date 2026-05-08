namespace WarehouseManager
{
    public class Food : BaseProduct
    {
        public int ExpirationDays { get; set; }

        public Food(int id, string name, int expirationDays) : base(id, name)
        {
            ExpirationDays = expirationDays;
        }

        public override decimal GetValue(decimal price)
        {
            // Полиморфизм в действии: своя логика расчета
            return ExpirationDays < 3 ? price * 0.5m : price;
        }
    }
}
