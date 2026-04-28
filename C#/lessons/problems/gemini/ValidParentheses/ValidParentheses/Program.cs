namespace ValidParentheses
{
    internal class Program
    {
        public static void Main()
        {
            Console.Write("Enter brackets: ");
            string input = Console.ReadLine() ?? "";

            bool isValid = IsValid(input);
            Console.WriteLine($"Result: {isValid}");
        }

        public static bool IsValid(string s)
        {
            // 1. Если длина нечетная — сразу false
            if (s.Length % 2 != 0) return false;

            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                // 2. Если скобка открывающая — кладем в стек
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    // 3. Если встретили закрывающую, а стек пуст — значит пары нет
                    if (stack.Count == 0) return false;

                    // 4. Достаем верхнюю скобку из стека
                    char lastOpen = stack.Pop();

                    // 5. Проверяем, подходит ли она к текущей закрывающей
                    if (c == ')' && lastOpen != '(') return false;
                    if (c == ']' && lastOpen != '[') return false;
                    if (c == '}' && lastOpen != '{') return false;
                }
            }

            // 6. В конце стек должен быть пуст (все открытые скобки закрылись)
            return stack.Count == 0;
        }
    }
}
