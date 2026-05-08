namespace WarehouseManager
{
    public abstract class BaseProduct : IItem
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public abstract decimal GetValue(decimal price);

        protected BaseProduct(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
