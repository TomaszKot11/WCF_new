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
        [OperationBehavior]
        List<BookType> SearchLibrary(string LinqQuery);

        [OperationContract]
        BookType BorrowBook(string Signature);

        [OperationContract]
        BookType ReturnBook(string Signature);
    }

    [DataContract]
    public class BookType
    {
        [DataMember]
        string Title = "Not provided";

        //TODO: consider extracting this to separate class? 
        // perhaps we shouldnt return it when borrowing the book
        // use a map
        [DataMember]
        string Signature = "Not provided";

        [DataMember]
        List<AuthorType> authors;
    }

    [DataContract]
    public class AuthorType
    {
        [DataMember]
        string Name = "Not provided";

        [DataMember]
        string Surname = "Not provided";
    }

}
