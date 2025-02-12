namespace lesson12
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public void PrintName()
        {
            Console.WriteLine($"My name is {FirstName}");
        }
    }
}
