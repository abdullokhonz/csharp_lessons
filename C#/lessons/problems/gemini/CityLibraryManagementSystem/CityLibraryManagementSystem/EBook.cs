using System;
using System.Collections.Generic;
using System.Text;

namespace CityLibraryManagementSystem
{
    public class EBook : Book
    {
        public double FileSize { get; set; } // in MB

        public override void GetInfo()
        {
            Console.WriteLine($"E-Book ID: {Id}, Title: {Title}, Author: {Author}, File Size: {FileSize} MB");
        }
    }
}
