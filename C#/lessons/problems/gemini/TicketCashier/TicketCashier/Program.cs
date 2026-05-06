namespace TicketCashier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] coins = { 1, 2, 5, 10 };
            int amount = 13;
            Console.WriteLine(GetMinCoins(coins, amount));
        }

        static int GetMinCoins(int[] coins, int amount)
        {
            Array.Sort(coins);
            Array.Reverse(coins);

            int count = 0;

            foreach (int coin in coins)
            {
                if (amount >= coin)
                {
                    while (amount >= coin)
                    {
                        amount -= coin;
                        count++;
                    }

                    /*
                    if (amount == 0) break;

                    count += amount / coin;
                    amount %= coin;
                    */
                }
            }

            return count;
        }
    }
}
