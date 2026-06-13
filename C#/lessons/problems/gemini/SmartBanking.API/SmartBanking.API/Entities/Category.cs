namespace SmartBanking.API.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
