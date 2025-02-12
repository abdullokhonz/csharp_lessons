namespace lesson11
{
    public class BankAccount
    {
        public uint AccountNumber { get; set; }
        public int Balance { get; set; }
        public string OwnerName { get; set; }

        public BankAccount(uint accountNumber, int balance, string ownerName)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
            this.OwnerName = ownerName;
        }

        public void Deposit(int amount)
        {
            this.Balance += amount;
        }
    }
}
