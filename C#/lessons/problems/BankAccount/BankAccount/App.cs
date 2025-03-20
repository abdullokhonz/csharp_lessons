namespace BankAccount
{
    public static class App
    {
        public static User? user = null;

        public static void Welcome()
        {
            Beep();

            Console.WriteLine("Добро пожаловать в банк!");

            Beep();

            Console.Write("Введите имя и фамилию владельца счета: ");
            string? input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input) || input.Split().Length < 2)
            {
                Beep();

                Console.WriteLine("Ошибка! Введите имя и фамилию через пробел.");
                Console.Write("Введите имя и фамилию владельца счета: ");

                input = Console.ReadLine();
            }

            string[] fullName = input.Split();
            string firstName = fullName[0];
            string lastName = fullName[1];


            Beep();

            Console.Write("Введите номер счета: ");

            int accountNumber;
            while (!int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Beep();

                Console.Write("Ошибка! Введите номер счета заново: ");
            }

            Beep();

            Console.Write("Введите начальный баланс: ");

            decimal balance;
            while (!decimal.TryParse(Console.ReadLine(), out balance))
            {
                Beep();

                Console.Write("Ошибка! Введите начальный баланс заново: ");
            }

            user = new User(accountNumber, firstName, lastName, balance);

            Menu();
        }

        public static void Run() => Welcome();

        public static void Menu()
        {
            Beep();

            Console.WriteLine(
                "\nМеню:\n" +
                "1. Посмотреть информацию о счете\n" +
                "2. Пополнить баланс\n" +
                "3. Снять деньги\n" +
                "4. Выйти"
            );

            Console.Write("Выберите действие: ");

            ushort actionNumber;
            while (!ushort.TryParse(Console.ReadLine(), out actionNumber) || actionNumber < 1 || actionNumber > 4)
            {
                Beep();

                Console.WriteLine("Ошибка! Введите число от 1 до 4.");
            }

            Beep();

            if (actionNumber == 4) Exit();
            else if (actionNumber == 1) user?.ShowAccountInfo();
            else if (actionNumber == 2) user?.TopUpBalance();
            else if (actionNumber == 3) user?.WithdrawMoney();

            Menu();
        }

        public static void Exit()
        {
            Console.WriteLine("\nСпасибо за использование нашей системы! Хорошего дня!");

            Environment.Exit(0);
        }

        public static void Beep()
        {
            Console.Beep();
            Thread.Sleep(500);
        }
    }
}
