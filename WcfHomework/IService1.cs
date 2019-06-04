using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfHomework
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<BookType> SearchLibrary(QueryType Query);

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

        public bool IsAuthor(string name)
        {
            if (authors.FindAll(author => author.Name.Contains(name) || author.Surname.Contains(name)).Count() > 0)
                return true;

            return false;
        }

        public override string ToString()
        {

            string AuthorString = "";

            foreach (AuthorType author in authors)
                AuthorString += author + "\n";

            return "Title: " + Title + ", signature: " + Signature + "\n" + AuthorString;
        }
    }

    [DataContract]
    public class QueryType
    {
        [DataMember]
        public int Type;

        [DataMember]
        public string Value;
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
