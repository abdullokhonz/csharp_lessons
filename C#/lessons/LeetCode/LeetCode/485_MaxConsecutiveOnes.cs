namespace LeetCode
{
    public class _485_MaxConsecutiveOnes
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int currentCount = 0;

                while (i < nums.Length && nums[i] == 1)
                {
                    currentCount++;
                    i++;
                }

                if (currentCount > maxCount)
                    maxCount = currentCount;
            }

            return maxCount;
        }

        //public int FindMaxConsecutiveOnes(int[] nums)
        //{
        //    int max = 0;
        //    int count = 0;

        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (nums[i] == 1)
        //        {
        //            count++;
        //            max = Math.Max(max, count);
        //        }
        //        else
        //        {
        //            count = 0;
        //        }
        //    }

        //    return max;
        //}
    }
}
