namespace lesson11
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public uint PublicationYear { get; }

        public Book(string title, string author, uint pYear)
        {
            this.Title = title;
            this.Author = author;
            this.PublicationYear = pYear;
        }
    }
}
