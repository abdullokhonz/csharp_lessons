namespace lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int[] arr = { 1, 2, 3, 4 };
            Console.WriteLine(arr[arr.Length - 1]);

            foreach (var item in arr) Console.Write(item + " ");

            for (int i = 0; i < arr.Length; i++) Console.WriteLine(arr[i]);*/

            /*int[,] arr = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 6, 7, 8 },
            };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }*/

            /*int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, };
            int n = nums.Length;
            int k = n / 2;
            int tmp;
            for (int i = 0; i < k; i++)
            {
                tmp = nums[i];
                nums[i] = nums[n - i - 1];
                nums[n - i - 1] = tmp;
            }
            foreach (var item in nums)
            {
                Console.Write($"{item}\t");
            }*/

            // Ex - 1
            /*int[] nums = new int[5];
            Console.WriteLine("Enter 5 numbers:");
            for (int i = 0; i < nums.Length; i++)
                nums[i] = Convert.ToInt32(Console.ReadLine());
            foreach (int i in nums)
                Console.WriteLine(i);*/

            // Ex - 2
            /*int[] nums = { 1, 2, 3, 4, 5 };
            int min = nums[0], max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= min) min = nums[i];
                if (nums[i] >= max) max = nums[i];
            }
            Console.WriteLine($"Минимальное число: {min}\nМаксимальное число: {max}");*/

            // Ex - 3
            /*int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int sum = 0, countOfNums = nums.Length;
            foreach (int num in nums)
            {
                sum += num;
            }
            Console.WriteLine(sum);
            Console.WriteLine((double)sum / countOfNums);*/

            // Ex - 4
            /*int[] nums = new int[10];
            uint evenNums = 0, oddNums = 0;
            Console.WriteLine("Enter 10 numbers:");
            for (int i = 0; i < nums.Length; i++)
                nums[i] = Convert.ToInt32(Console.ReadLine());
            foreach (int num in nums)
            {
                if (num % 2 == 0) evenNums++;
                else oddNums++;
            }
            Console.WriteLine("Count of even numbers: " + evenNums);
            Console.WriteLine("Count of odd numbers: " + oddNums);*/

            /*int[] nums = { 1, 2, 3, 4, 5 };
            int[] nums2 = { 6, 7, 8, 9, 10 };
            int[] nums3 = new int[5];
            foreach (int i in nums3)
            {
                Console.WriteLine(i);
            }*/

            /*Random rand = new Random();
            for (int i = 0; i < nums3.Length; i++)
            {
                nums3[i] = rand.Next(1, 100);
            }
            foreach (int i in nums3)
            {
                Console.WriteLine(i);
            }*/
        }
    }
}
