/*
Тепличные условия
Задача: «Инверсия слов в строке».
Напиши метод, который принимает предложение и возвращает его же, но каждое слово в нем развернуто задом наперед, при этом порядок самих слов остается прежним.

Пример: C# is awesome → #C si emosewa

Ограничение: Попробуй решить это без использования Reverse() из LINQ.
*/

Console.WriteLine("Hello, World!");

Console.Write("Enter a sentence: ");
string input = Console.ReadLine() ?? string.Empty;

for (int i = input.Length - 1; i >= 0; i--)
{
    Console.Write(input[i]);
}
