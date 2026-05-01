using System;
using System.Collections.Generic;
using System.Text;

namespace CityLibraryManagementSystem
{
    public interface ILendable
    {
        void Lend(string readerName);
    }
}
