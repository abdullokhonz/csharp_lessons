namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 1, 2 };
            int k1 = new _26_RemoveDuplicatesFromSortedArray().RemoveDuplicates(nums1);
            Console.WriteLine($"{k1}, nums = [{string.Join(", ", nums1[..k1])}, {string.Join(", ", Enumerable.Repeat("_", nums1.Length - k1))}]");

            // Ожидаемый вывод:
            // 2, nums = [1, 2, _]

            int[] nums2 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int k2 = new _26_RemoveDuplicatesFromSortedArray().RemoveDuplicates(nums2);
            Console.WriteLine($"{k2}, nums = [{string.Join(", ", nums2[..k2])}, {string.Join(", ", Enumerable.Repeat("_", nums2.Length - k2))}]");

            // Ожидаемый вывод:
            // 5, nums = [0, 1, 2, 3, 4, _, _, _, _, _]
        }
    }
}
