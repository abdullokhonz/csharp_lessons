namespace WarehouseManager
{
    public interface IItem
    {
        int Id { get; }

        string Name { get; }

        decimal GetValue(decimal price);
    }
}
