using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfHomework
{
    class Library
    {
        private IList<BookType> Books;
        private IList<AuthorType> Authors;

        public void InitializeMockData()
        {
            // initialize authors
            Authors = new List<AuthorType>();

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
        }

        private BookType BookTypeFactory(String Title, string Signature, List<AuthorType> BookAuthors)
        {
            throw new NotImplementedException();
        }

        private AuthorType AuthorTypeFactory(String Name, String Surname)
        {
            return new AuthorType(Name, Surname);
        }

    }
}
