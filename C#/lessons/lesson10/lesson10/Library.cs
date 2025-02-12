namespace lesson10
{
    public struct Library
    {
        public string Title, Author;
        public int Year;
        public bool isAvailable;

        public void BookInfo()
        {
            Console.WriteLine($"Название: {Title}, Автор: {Author}, Год издания: {Year}, В наличии: {YesOrNO(isAvailable)}");
        }

        public void BookAvailabilitySwitch()
        {
            isAvailable = !isAvailable;
        }

        private string YesOrNO(bool value) => isAvailable ? "Да" : "Нет";
    }
}
