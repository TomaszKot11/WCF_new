using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfHomework
{
    class Library
    {
        public IList<BookType> Books { get; private set; }
        public IList<BookType> Borrowed { get; private set; }
        private IList<AuthorType> Authors;

        public void InitializeMockData()
        {
            // initialize authors
            Authors = new List<AuthorType>();

            // list of borrowed books
            Borrowed = new List<BookType>();

            Authors.Add(AuthorTypeFactory("Andrzej", "Sapkowski"));
            Authors.Add(AuthorTypeFactory("Tomasz", "Kot"));
            Authors.Add(AuthorTypeFactory("Jan", "Kowalski"));
            Authors.Add(AuthorTypeFactory("Henryk", "Sienkiewicz"));
            Authors.Add(AuthorTypeFactory("Andrzej", "Włodarczyk"));
            Authors.Add(AuthorTypeFactory("John", "Doe"));
            Authors.Add(AuthorTypeFactory("Emilly", "XYZ"));
            Authors.Add(AuthorTypeFactory("John", "Doe"));

            Books = new List<BookType>();
            int numberAuthors = Authors.Count;
            Random random = new Random();

            Books.Add(BookTypeFactory("Something", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Symfonia C++", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Programming in iOS", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Programming in Kotlin", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Android dla praktyków", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Windows PowerShell", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Windows New Terminal", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Linux dla praktyków", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Unix", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("iOS best practices", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Systemy wbudowane", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Ruby programowanie", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("C# dla programistów Ruby", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Harry Potter: Zagubiony Zakon", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Władcy Pierściania: Powrót C#", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
            Books.Add(BookTypeFactory("Unix Part Two", Guid.NewGuid().ToString(), Authors.ToList().GetRange(0, random.Next(0, numberAuthors + 1))));
        }

        public void BorrowBook(BookType Book)
        {
            BookType bookToBorrow = Books.ToList().Find(book => book.Signature == Book.Signature);
            Borrowed.Add(bookToBorrow);
            Books.Remove(bookToBorrow);
        }

        public void ReturnBook(BookType Book)
        {
            BookType bookToBorrow = Borrowed.ToList().Find(book => book.Signature == Book.Signature);
            Borrowed.Remove(bookToBorrow);
            Books.Add(bookToBorrow);
        }
        
        public override string ToString()
        {
            //TODO: use some Stringbuilder
            string libraryString = "";
            foreach (BookType bookType in Books)
                libraryString += bookType + "\n";

            return libraryString;
        }


        // factory methods

        private BookType BookTypeFactory(String Title, string Signature, List<AuthorType> BookAuthors)
        {
            return new BookType(Title, Signature, BookAuthors);
        }

        private AuthorType AuthorTypeFactory(String Name, String Surname)
        {
            return new AuthorType(Name, Surname);
        }

    }
}
