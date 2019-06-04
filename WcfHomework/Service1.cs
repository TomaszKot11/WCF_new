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
        private Library Library;

        public Service1()
        {
            this.Library = new Library();

            Library.InitializeMockData();
        }

        public BookType BorrowBook(string Signature)
        {
            List<BookType> books = (List<BookType>)Library.Books.Where(book => book.Signature == Signature);

            //TODO: throw/return custom exception 
            if (books.Count == 0 || books.Count > 1)
                throw new Exception();

            return books.First();
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
