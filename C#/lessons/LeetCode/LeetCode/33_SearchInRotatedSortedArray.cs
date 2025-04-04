namespace LeetCode
{
    public class _33_SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                // Проверка, в какой половине порядок нормальный
                if (nums[left] <= nums[mid]) // Левая половина отсортирована
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1; // Ищем в левой части
                    else
                        left = mid + 1;  // Ищем в правой части
                }
                else // Правая половина отсортирована
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;  // Ищем в правой части
                    else
                        right = mid - 1; // Ищем в левой части
                }
            }

            return -1; // Не нашли
        }
    }
}
