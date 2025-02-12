namespace lesson10
{
    public struct Person
    {
        public int Age { get; set; }

        public void Display()
        {
            Console.WriteLine($"Возраст: {Age}");
        }
    }
}
