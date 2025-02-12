namespace lesson11
{
    public class Person
    {
        ushort age;
        public string Name { get; set; }
        public ushort Age
        {
            set
            {
                if (value > 0 && value < 120) age = value;
                else Console.WriteLine("Возраст должен быть в дмапазоне от 1 до 120");
            }
            get {  return age; }
        }

        public Person(string name, ushort age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
