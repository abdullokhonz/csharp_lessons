Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Hello, World!");

string[] history = { "USD", "EUR", "USD", "RUB", "USD", "EUR" };

// 1. Создай пустой словарь.
Dictionary<string, int> dict = new Dictionary<string, int>();

// 2. Пробегись циклом `foreach` по массиву строк `history`.
foreach (string curr in history)
{
    // 3. Внутри цикла проверяй: если валюты еще нет в словаре — добавь её со значением `1`.
    // Если уже есть — увеличь её счетчик на `+1`.
    if (dict.ContainsKey(curr))
    {
        dict[curr]++;
    }
    else
    {
        dict[curr] = 1;
    }
}

// 4. Выведи результат на экран в формате: `USD встретилась 3 раз(а)`.
foreach (var kvp in dict)
{
    Console.WriteLine($"{kvp.Key} встретилась {kvp.Value} раз(а)");
}
