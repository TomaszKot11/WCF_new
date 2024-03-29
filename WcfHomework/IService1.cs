﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfHomework.Exceptions;

namespace WcfHomework
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [FaultContract(typeof(LibrarySearchingException))]
        List<BookType> SearchLibrary(QueryType Query);

        [OperationContract]
        [FaultContract(typeof(WrongSignatureException))]
        BookType BorrowBook(int Signature);

        [OperationContract]
        [FaultContract(typeof(WrongSignatureException))]
        BookType ReturnBook(int Signature);

        [OperationContract]
        string GetLibraryInfo();
    }

    [DataContract]
    public class BookType
    {
        [DataMember]
        public string Title = "Not provided";

        [DataMember]
        public int Signature = -1;

        [DataMember]
        public List<AuthorType> authors;

        public BookType(string Title, int Signature, List<AuthorType> Authors)
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

        public QueryType(int type, string value)
        {
            Type = type;
            value = value;
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
            return "Name: " + Name + ", Surname: " + Surname;
        }
    }

}
