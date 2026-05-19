Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Hello, World!");

// 1. Создать список `List<decimal>` и добавить туда операции:
// `1500`, `700`, `4000`, `900`, `12000`.
List<decimal> operations = new List<decimal>()
{
    1500m, 700m, 4000m, 900m, 12000m
};

// Вставить на **второе место** (индекс 1) забытую операцию `500`.
operations.Insert(1, 500m);

// 3. Проверить, есть ли в списке операция со значением `900`.
// Если есть — вывести в консоль её индекс.
if (operations.Contains(900m))
{
    Console.WriteLine($"Операция 900 найдена на индексе: {operations.IndexOf(900m)}");
}

// 4. Используя цикл `for` с конца к началу (или метод `RemoveAll`),
// удалить из списка все операции, которые **больше 2000** (крупные траты).
for (int i = operations.Count - 1; i >= 0; i--)
{
    if (operations[i] > 2000m)
    {
        operations.RemoveAt(i);
    }
}

// 5. Вывести итоговый список в консоль.
foreach (var operation in operations)
{
    Console.WriteLine(operation);
}
