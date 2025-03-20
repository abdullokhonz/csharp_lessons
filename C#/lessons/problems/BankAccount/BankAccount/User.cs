namespace BankAccount
{
    public class User
    {
        public int AccountNumber { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal Balance { get; set; }

        public User(
            int accountNumber,
            string firstName,
            string lastName,
            decimal balance
        )
        {
            this.AccountNumber = accountNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Balance = balance;
        }

        public void ShowAccountInfo()
        {
            Console.WriteLine(
                $"Информация о счете:\n" +
                $"Владелец: {this.FirstName} {this.LastName}\n" +
                $"Номер счета: {this.AccountNumber}\n" +
                $"Баланс: {this.Balance}\n"
            );

            App.Menu();
        }

        public void TopUpBalance()
        {
            Console.Write("Введите сумму пополнения: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            this.Balance += amount;

            App.Beep();

            Console.WriteLine("Баланс успешно пополнен!");

            App.Menu();
        }

        public void WithdrawMoney()
        {
            Console.Write("Введите сумму для снятия: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount > this.Balance)
            {
                App.Beep();

                Console.WriteLine("Ошибка! Недостаточно средств на счету.");
            }
            else
            {
                this.Balance -= amount;

                App.Beep();

                Console.WriteLine($"Операция успешна! С вашего счёта списано {amount}.");
                Console.WriteLine($"Текущий баланс: {this.Balance}");
            }


            App.Menu();
        }
    }
}
