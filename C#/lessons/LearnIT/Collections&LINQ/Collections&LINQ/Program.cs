using Collections_LINQ;

List<string> names = new List<string> { "Alice", "Bob", "Charlie" };

names.Add("David");

foreach (string name in names)
    Console.WriteLine(name);

Console.WriteLine();

var filtered = names.Where(name => name.StartsWith("A")).ToList();

foreach (string name in filtered)
    Console.WriteLine(name);

/*
Часто используемые LINQ-методы:
•  Where() — фильтрация.
•  Select() — проекция (изменение формы данных).
•  OrderBy(), OrderByDescending() — сортировка.
•  First(), FirstOrDefault() — получить первый элемент.
•  Any(), All() — логические проверки.
•  GroupBy() — группировка.
•  Join() — соединение коллекций.
*/

Console.WriteLine();

List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

var evenNumbers = numbers
    .Where(n => n % 2 == 0)
    .Select(n => n * n)
    .ToList(); // Результат: [4, 16, 36]

foreach (int number in evenNumbers)
    Console.WriteLine(number);

Console.WriteLine();

List<Employee> employees = new List<Employee>
{
    new Employee { Name = "Alice", Age = 28, Department = "IT" },
    new Employee { Name = "Bob", Age = 35, Department = "HR" },
    new Employee { Name = "Charlie", Age = 40, Department = "IT" },
    new Employee { Name = "Diana", Age = 25, Department = "Finance" },
    new Employee { Name = "Ethan", Age = 32, Department = "Marketing" }
};

var itEmployees = employees
    .Where(e => e.Department == "IT")
    .ToList();

var olderThan30 = employees
    .Where(e => e.Age > 30)
    .ToList();

var namesSortedByAge = employees
    .OrderBy(e => e.Age)
    .Select(e => e.Name)
    .ToList();

bool hasHR = employees.Any(e => e.Department == "HR");

double averageAge = employees.Average(e => e.Age);

foreach (var emp in itEmployees)
{
    Console.WriteLine($"{emp.Name} из отдела {emp.Department}");
}
