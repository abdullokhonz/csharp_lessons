/*

Поиск уникального числа — Find the Unique Number

Условие: Дан массив целых чисел, где каждое число повторяется дважды,
и только одно число встречается один раз. Нужно найти это число.

Пример: [4, 1, 2, 1, 2] → Результат: 4

Её можно решить через циклы,
а можно с помощью магии битовых операций (оператор ^ XOR) всего в одну строку.

*/

Console.WriteLine("Hello, World!");

Console.Write("Enter the length of array: ");
int len = Convert.ToInt32(Console.ReadLine());

int[] arr = new int[len];

int result = 0;

for (int i = 0; i < arr.Length; i++)
{
    Console.Write($"Enter the number {i + 1}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    arr[i] = num;
}

for (int i = 0; i < arr.Length; i++)
{
    bool isDuplicate = false;
    for (int j = 0; j < arr.Length; j++)
    {
        if (i != j && arr[i] == arr[j])
        {
            isDuplicate = true;
            break;
        }
    }

    if (!isDuplicate)
    {
        result = arr[i];
        break;
    }
}

Console.WriteLine($"Unique number is {result}.");

// v2
int result2 = 0;
foreach (int num in arr)
{
    result2 ^= num;
}
Console.WriteLine($"Unique number is {result}.");
