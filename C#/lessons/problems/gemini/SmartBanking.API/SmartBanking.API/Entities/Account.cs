namespace SmartBanking.API.Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public string AccountNumber { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public bool IsActive { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
