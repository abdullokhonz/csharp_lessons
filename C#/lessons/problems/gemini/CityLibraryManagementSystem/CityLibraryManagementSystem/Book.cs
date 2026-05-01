using System;
using System.Collections.Generic;
using System.Text;

namespace CityLibraryManagementSystem
{
    public abstract class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public Book()
        {
            Library.ToTalBooksCreated++; // Увеличиваем общий счетчик
        }

        public abstract void GetInfo();
    }
}
