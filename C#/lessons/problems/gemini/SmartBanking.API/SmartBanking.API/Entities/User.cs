namespace SmartBanking.API.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal BonusBalance { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
