namespace CityLibraryManagementSystem
{
    public class Library
    {
        // Для O(1) поиска используем Dictionary
        public Dictionary<int, Book> BooksMap { get; set; } = new Dictionary<int, Book>();
        public List<Book> Books { get; set; } = new List<Book>();

        public static int ToTalBooksCreated { get; internal set; } = 0;

        public Book FindBook(int id)
        {
            foreach (var book in Books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null!;
        }

        // Поиск за O(1)
        public Book FindBookFast(int id)
        {
            return BooksMap.TryGetValue(id, out var book) ? book : null!;
        }

        // Работа с файлами
        public void SavePaperBooksToFile(string path)
        {
            // Используем LINQ для фильтрации (пройдем это позже, но посмотри как красиво)
            var paperTitles = Books.OfType<PaperBook>().Select(b => b.Title);
            File.WriteAllLines(path, paperTitles);
            Console.WriteLine("Названия бумажных книг сохранены!");
        }
    }
}
