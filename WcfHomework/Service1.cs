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
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class Service1 : IService1
    {
        private Library library;

        public Service1()
        {
            this.library = new Library();

            library.InitializeMockData();

            Console.WriteLine(library);
        }

        public BookType BorrowBook(string Signature)
        {
            List<BookType> books = (List<BookType>)library.Books.Where(book => book.Signature == Signature);

            //TODO: throw/return custom exception 
            if (books.Count == 0 || books.Count > 1)
                throw new Exception();

            library.BorrowBook(books.First());

            return books.First();
        }

        public BookType ReturnBook(string Signature)
        {
            List<BookType> books = (List<BookType>)library.Borrowed.Where(book => book.Signature == Signature);

            //TODO: throw/return custom exception 
            if (books.Count == 0 || books.Count > 1)
                throw new Exception();

            library.ReturnBook(books.First());

            return books.First();
        }

        public List<BookType> SearchLibrary(string LinqQuery)
        {
            //Install-Package Microsoft.CodeAnalysis.CSharp.Scripting
            List<BookType> Books = library.Books.ToList();
            string query = "from element in Books where " + LinqQuery + " select element";
            IEnumerable result = ExecuteQuery(query, Books).Result;
            List<BookType> books = new List<BookType>();

            foreach (BookType book in result)
            {
                books.Add(book);
            }

            return books;
        }

        // new .NET features to dynamically construct linkq
        private async Task<IEnumerable> ExecuteQuery(string query, List<BookType> Books)
        {
            try
            {
                IEnumerable result = null;
                var scriptOptions = ScriptOptions.Default.WithReferences(typeof(System.Linq.Enumerable).Assembly).WithImports("System.Linq");
                result = await CSharpScript.EvaluateAsync<IEnumerable>(
                         query,
                         scriptOptions,
                         globals: Books);
                return result;
            }
            catch (CompilationErrorException ex)
            {
                return null;
            }
        }

        public string GetLibraryInfo()
        {
            return library.ToString();
        }

    }
}
