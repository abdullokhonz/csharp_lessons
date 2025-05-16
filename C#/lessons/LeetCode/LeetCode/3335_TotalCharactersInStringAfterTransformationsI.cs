namespace LeetCode
{
    public class _3335_TotalCharactersInStringAfterTransformationsI
    {
        public int LengthAfterTransformations(string s, int t)
        {
            const int MOD = 1000000007;
            int[] count = new int[26];

            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            for (int step = 0; step < t; step++)
            {
                int[] newCount = new int[26];

                for (int i = 0; i < 25; i++)
                {
                    newCount[i + 1] = count[i];
                }

                newCount[0] = (newCount[0] + count[25]) % MOD;
                newCount[1] = (newCount[1] + count[25]) % MOD;
                count = newCount;
            }

            int total = 0;

            foreach (int val in count)
            {
                total = (total + val) % MOD;
            }

            return total;
        }
    }
}
