namespace lesson8
{
    internal class Book
    {
        public string title;
        public string author;
        public uint pages;

        public string PrintBookInfo()
        {
            return $"\nTitle: {title}\nAuthor: {author}\nPages: {pages}\n";
        }

        public bool IsBigBook()
        {
            return pages >= 500 ? true : false;
        }
    }
}
