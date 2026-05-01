using System;
using System.Collections.Generic;
using System.Text;

namespace CityLibraryManagementSystem
{
    public class PaperBook : Book, ILendable
    {
        public double Weight { get; set; }

        public override void GetInfo()
        {
            Console.WriteLine($"Paper Book ID: {Id}, Title: {Title}, Author: {Author}, Weight: {Weight} kg");
        }

        public void Lend(string readerName)
        {
            Console.WriteLine($"Paper Book '{Title}' lent to {readerName}.");
        }
    }
}
