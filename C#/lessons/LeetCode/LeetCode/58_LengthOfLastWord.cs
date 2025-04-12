namespace LeetCode
{
    public class _58_LengthOfLastWord
    {
        public int LengthOfLastWord(string s)
        {
            string[] arr = s.Trim().Split(' ');

            int result = arr[arr.Length - 1].Count();

            return result;
        }
    }
}
