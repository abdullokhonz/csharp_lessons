namespace LeetCode
{
    public class _14_LongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            string prefix = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                string currentPrefix = string.Empty;

                for (int j = 0; j < prefix.Length && j < strs[i].Length; j++)
                {
                    if (strs[i][j] == prefix[j])
                        currentPrefix += prefix[j];
                    else
                        break;
                }

                prefix = currentPrefix;

                if (prefix == "")
                    break;
            }

            return prefix;
        }
    }
}
