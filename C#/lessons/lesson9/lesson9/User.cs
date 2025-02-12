namespace lesson9
{
    public class User
    {
        static uint userCount;

        public string username;
        public uint id;

        public User(string un)
        {
            Console.WriteLine($"Создан новый объект");

            userCount++; id = userCount;
            username = un;

            Console.WriteLine($"Имя пользователя: {username}\nID пользователя: {id}");
        }
    }
}
