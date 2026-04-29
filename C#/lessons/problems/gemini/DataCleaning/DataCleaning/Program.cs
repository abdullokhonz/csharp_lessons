namespace DataCleaning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string s = "  ivan,  AnNa, dmitry  ";
            string[] names = s.Split(',');

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].Trim().ToLower();
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
