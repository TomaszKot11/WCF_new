using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfHomework
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class Service1 : IService1
    {
        public BookType BorrowBook(string Signature)
        {
            throw new NotImplementedException();
        }

        public BookType ReturnBook(string Signature)
        {
            throw new NotImplementedException();
        }

        public List<BookType> SearchLibrary(string LinqQuery)
        {
            throw new NotImplementedException();
        }
    }
}
