using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfHomework
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IService1
    {
        // https://docs.microsoft.com/pl-pl/dotnet/csharp/linq/write-linq-queries
        [OperationContract]
        List<BookType> SearchLibrary(string LinqQuery);

        [OperationContract]
        BookType BorrowBook(string Signature);

        [OperationContract]
        BookType ReturnBook(string Signature);

        [OperationContract]
        string GetLibraryInfo();
    }

    [DataContract]
    public class BookType
    {
        [DataMember]
        public string Title = "Not provided";

        //TODO: consider extracting this to separate class? 
        // perhaps we shouldnt return it when borrowing the book
        // use a map
        [DataMember]
        public string Signature = "Not provided";

        [DataMember]
        public List<AuthorType> authors;

        public BookType(string Title, string Signature, List<AuthorType> Authors)
        {
            this.Title = Title;
            this.Signature = Signature;
            this.authors = Authors;
        }

        public override string ToString()
        {

            string AuthorString = "";

            foreach(AuthorType author in authors)
                AuthorString += author + "\n";

            return "Title: " + Title + ", signature: " + Signature + "\n" + AuthorString;
        }
    }

    [DataContract]
    public class AuthorType
    {
        [DataMember]
        public string Name = "Not provided";

        [DataMember]
        public string Surname = "Not provided";

        public AuthorType(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", urname: " + Surname;
        }
    }

}
