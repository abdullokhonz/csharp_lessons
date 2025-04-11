namespace LeetCode
{
    public class _2843_CountSymmetricIntegers
    {
        public int CountSymmetricIntegers(int low, int high)
        {
            int count = 0;

            for (int i = low; i <= high; i++)
            {
                string number = i.ToString();
                if (number.Length % 2 == 1) continue; // Пропускаем нечетные числа

                int len = number.Length / 2;
                string left = number.Substring(0, len);  // Первая половина
                string right = number.Substring(len);    // Вторая половина

                int leftSum = left.Sum(c => c - '0');    // Сумма цифр левой половины
                int rightSum = right.Sum(c => c - '0');  // Сумма цифр правой половины

                if (leftSum == rightSum)
                    count++;
            }

            return count;
        }
    }
}
