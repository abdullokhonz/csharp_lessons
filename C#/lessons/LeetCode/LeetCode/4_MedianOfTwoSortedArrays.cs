namespace LeetCode
{
    public class _4_MedianOfTwoSortedArrays
    {
        public Double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double result;

            int[] nums = new int[nums1.Length + nums2.Length];

            int i = 0, j = 0, k = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                    nums[k++] = nums1[i++];
                else
                    nums[k++] = nums2[j++];
            }

            while (i < nums1.Length)
                nums[k++] = nums1[i++];

            while (j < nums2.Length)
                nums[k++] = nums2[j++];

            int len = nums.Length;

            if (len % 2 == 0)
                result = (double)(nums[len / 2 - 1] + nums[len / 2]) / 2;
            else
                result = (double)nums[len / 2];

            return result;
        }
    }
}
