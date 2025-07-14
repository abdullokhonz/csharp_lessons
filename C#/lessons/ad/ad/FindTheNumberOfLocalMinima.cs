namespace ad
{
    public class FindTheNumberOfLocalMinima
    {
        public void CountOfLocalMinima()
        {
            int n = 3;
            int[,] arr = new int[n, n];
            Random rand = new Random();

            // Заполняем массив случайными числами и сразу выводим
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rand.Next(1, 10);
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            int count = 0;

            // Проверяем каждый элемент
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int current = arr[i, j];
                    bool isMin = true;

                    // Сверху
                    if (i > 0 && arr[i - 1, j] <= current)
                        isMin = false;

                    // Снизу
                    if (i < n - 1 && arr[i + 1, j] <= current)
                        isMin = false;

                    // Слева
                    if (j > 0 && arr[i, j - 1] <= current)
                        isMin = false;

                    // Справа
                    if (j < n - 1 && arr[i, j + 1] <= current)
                        isMin = false;

                    if (isMin)
                        count++;
                }
            }

            Console.WriteLine($"\nКоличество локальных минимумов: {count}");
        }
    }
}
