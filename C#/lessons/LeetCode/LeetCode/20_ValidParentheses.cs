public class Solution
{
    public bool IsValid(string s)
    {
        List<char> stack = new List<char>();
        Dictionary<char, char> mapping = new Dictionary<char, char>
            {
                { ')', '('},
                { '}', '{'},
                { ']', '['}
            };

        foreach (char item in s)
        {
            if (mapping.ContainsKey(item))
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char topElement = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);

                if (mapping[item] != topElement)
                {
                    return false;
                }
            }
            else
            {
                stack.Add(item);
            }
        }

        return stack.Count == 0;
    }
}
