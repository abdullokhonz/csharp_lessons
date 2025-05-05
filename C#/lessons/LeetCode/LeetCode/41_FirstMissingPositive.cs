namespace LeetCode
{
    public class _41_FirstMissingPositive
    {
        public int FirstMissingPositive(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                while (
                    nums[i] >= 1 &&
                    nums[i] <= nums.Length &&
                    nums[nums[i] - 1] != nums[i]
                )
                {
                    int correctIndex = nums[i] - 1;
                    int temp = nums[i];
                    nums[i] = nums[correctIndex];
                    nums[correctIndex] = temp;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return nums.Length + 1;
        }
    }
}
