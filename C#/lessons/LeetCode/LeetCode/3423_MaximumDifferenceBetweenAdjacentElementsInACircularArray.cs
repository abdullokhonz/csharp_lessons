namespace LeetCode
{
    public class _3423_MaximumDifferenceBetweenAdjacentElementsInACircularArray
    {
        public int MaxAdjacentDistance(int[] nums)
        {
            if (nums == null)
                return 0;

            int maxAdjDis = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int curAdjDis = Math.Abs(nums[i] - nums[(i + 1) % nums.Length]);
                if (curAdjDis > maxAdjDis) maxAdjDis = curAdjDis;
            }

            return maxAdjDis;
        }
    }
}
