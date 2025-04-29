namespace LeetCode
{
    public class _2962_Count_Subarrays_Where_Max_Element_Appears_At_Least_K_Times
    {
        public long CountSubarrays(int[] nums, int k)
        {
            int maxNum = nums.Max(); // ищем максимум
            long result = 0;
            int left = 0, count = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                // увеличиваем счётчик, если встретили максимум
                if (nums[right] == maxNum) count++;

                // пока в окне хотя бы k максимумов — считаем
                while (count >= k)
                {
                    // все подмассивы от left до конца, которые начинаются в left и заканчиваются где-то справа
                    result += nums.Length - right;

                    // сдвигаем левый указатель
                    if (nums[left] == maxNum) count--;
                    left++;
                }
            }

            return result;
        }

        public long CountSubarrays2(int[] nums, int k)
        {
            long result = 0;

            int maxNum = nums[0];
            for (int i = 1; i < nums.Length; i++) maxNum = nums[i] > maxNum ? nums[i] : maxNum;

            for (int i = 0; i < nums.Length; i++)
            {
                int count = 0;

                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] == maxNum) count++;

                    if (count >= k) result++;
                }
            }

            return result;
        }

        public long CountSubarrays3(int[] nums, int k)
        {
            int maxNum = nums.Max(); // Находим максимум
            Console.WriteLine($"Максимум в массиве: {maxNum} ❤️");

            long result = 0;
            int left = 0, count = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == maxNum)
                {
                    count++;
                    Console.WriteLine($"➡️ nums[{right}] == maxNum, увеличиваем count: {count}");
                }

                while (count >= k)
                {
                    long added = nums.Length - right;
                    result += added;

                    Console.WriteLine($"✅ count = {count} >= {k} => добавляем {added} к result (итого {result})");
                    Console.WriteLine($"  Окно: [{left}..{right}] → подмассив: {string.Join(", ", nums[left..(right + 1)])}");

                    if (nums[left] == maxNum)
                    {
                        count--;
                        Console.WriteLine($"⬅️ nums[{left}] == maxNum → уменьшаем count: {count}");
                    }

                    left++;
                }
            }

            Console.WriteLine($"🎉 Общий результат: {result}");
            return result;
        }
    }
}
