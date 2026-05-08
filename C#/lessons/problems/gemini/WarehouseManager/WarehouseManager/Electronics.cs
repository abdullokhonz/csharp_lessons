namespace WarehouseManager
{
    public class Electronics : BaseProduct
    {
        private const decimal Tax = 0.15m;

        public Electronics(int id, string name) : base(id, name) { }

        public override decimal GetValue(decimal price) => price * (1 + Tax);
    }
}
