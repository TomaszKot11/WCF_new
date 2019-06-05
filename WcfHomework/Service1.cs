using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfHomework
{
    // we need single context mode in order to avoid library object list recreation
    // the service object is a singleton 
    // concurrency mode guarantees that there is not race conditions :)
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private Library library;

        public Service1()
        {
            this.library = new Library();

            library.InitializeMockData();

            Console.WriteLine(library);
        }

        public BookType BorrowBook(int Signature)
        {
            List<BookType> books = library.Books.Where(book => book.Signature == Signature).ToList();

            //TODO: throw/return custom exception 
            if (books.Count != 1)
                throw new Exception();

            library.BorrowBook(books.First());

            return books.First();
        }

        public BookType ReturnBook(int Signature)
        {
            List<BookType> books = library.Borrowed.Where(book => book.Signature == Signature).ToList();

            if (books.Count != 1)
                throw new Exception();

            library.ReturnBook(books.First());

            return books.First();
        }

        public List<BookType> SearchLibrary(QueryType queryType)
        {
            //Install-Package Microsoft.CodeAnalysis.CSharp.Scripting
            List<BookType> Books = library.Books.ToList();
            string queryValue = queryType.Value;

            switch(queryType.Type)
            {
                case 1:
                    // by title
                    return Books.FindAll(book => book.Title.Contains(queryValue));
                case 2:
                    //by author
                    return Books.FindAll(book => book.IsAuthor(queryValue));
                case 3:
                    // by signature
                    List<BookType> foundBook = Books.FindAll(book => book.Signature == Int32.Parse(queryValue));
                    //if (foundBook == null || foundBook.Count() != 1) // signature have to be unique
                      //  throw new Exception(); //TODO: throw custom exception

                    return foundBook;
                default:
                    // TODO: throw exception
                    return new List<BookType>();
            }
        }

        public string GetLibraryInfo()
        {
            return library.ToString();
        }

    }
}
