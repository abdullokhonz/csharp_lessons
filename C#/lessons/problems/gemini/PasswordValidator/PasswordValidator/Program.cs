namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(IsValidPassword("Password123!")); // True
            Console.WriteLine(IsValidPassword("Password")); // False
            Console.WriteLine(IsValidPassword("Password123")); // False
        }

        static bool IsValidPassword(string password)
        {
            // Проверка длины
            if (password.Length < 8) return false;

            bool hasDigit = false;
            bool hasSpecial = false;
            string specialChars = "!@#$%";

            foreach (char c in password)
            {
                if (char.IsDigit(c)) hasDigit = true;
                if (specialChars.Contains(c)) hasSpecial = true;
            }

            // Доступ разрешен только если ОБА флага стали true
            return hasDigit && hasSpecial;
        }
    }
}
