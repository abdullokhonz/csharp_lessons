using AccessControlSystem.Entities;
using AccessControlSystem.Enums;

namespace AccessControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Настройка кодировки для кириллицы
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Иван", Role = Role.Developer },
                new Employee { Id = 2, Name = "Олег", Role = Role.Admin }
            };

            var rules = new List<AccessRule>
            {
                new AccessRule {
                    Role = Role.Developer,
                    ZoneId = 101,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0)
                }
            };

            var manager = new AccessManager(employees, rules);

            // Проверка: Разработчик в 10:00
            bool devOk = manager.CanAccess(1, 101, DateTime.Parse("2026-05-06 10:00"));
            // Проверка: Разработчик в 21:00
            bool devLate = manager.CanAccess(1, 101, DateTime.Parse("2026-05-06 21:00"));
            // Проверка: Админ ночью
            bool adminOk = manager.CanAccess(2, 101, DateTime.Parse("2026-05-06 03:00"));

            Console.WriteLine($"Разработчик (10:00): {devOk}");   // True
            Console.WriteLine($"Разработчик (21:00): {devLate}"); // False
            Console.WriteLine($"Админ (03:00): {adminOk}");       // True
        }
    }
}
