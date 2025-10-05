namespace ad;

public class LargestPalindromicSubstring
{
    public void Run()
    {
        string s = Console.ReadLine();
        int q = int.Parse(Console.ReadLine());

        for (int i = 0; i < q; i++)
        {
            string[] parts = Console.ReadLine().Split();
            int L = int.Parse(parts[0]);
            int R = int.Parse(parts[1]);

            int result = MaxPalindromeLength(s, L - 1, R - 1);
            Console.WriteLine(result);
        }
    }

    static int MaxPalindromeLength(string s, int L, int R)
    {
        int maxLen = 1;

        for (int i = L; i <= R; i++)
        {
            for (int j = i; j <= R; j++)
            {
                if (IsPalindrome(s, i, j))
                {
                    int len = j - i + 1;
                    if (len > maxLen)
                        maxLen = len;
                }
            }
        }

        return maxLen;
    }

    static bool IsPalindrome(string s, int l, int r)
    {
        while (l < r)
        {
            if (s[l] != s[r]) return false;
            l++;
            r--;
        }
        return true;
    }
}
