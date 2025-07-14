namespace LeetCode
{
    public class _2011_FinalValueOfVariableAfterPerformingOperations
    {
        public int FinalValueAfterOperations(string[] operations)
        {
            if (operations == null || operations.Length == 0)
                return 0;

            int x = 0;

            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i].Contains('+')) x++;
                else x--;
            }

            return x;
        }
    }
}
