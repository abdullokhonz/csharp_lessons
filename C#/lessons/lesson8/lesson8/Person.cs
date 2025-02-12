namespace lesson8
{
    internal class Person
    {
        public string name;
        public uint age;

        public string PrintInfo()
        {
            string result = $"Name: {name}\nAge: {age}\n";
            return result;
        }

        public string HaveBirthday()
        {
            age++;
            return "Happy Birthday!\n";
        }
    }
}
