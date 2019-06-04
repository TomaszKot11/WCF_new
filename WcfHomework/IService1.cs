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
        // TODO: dodaj tutaj operacje usługi
    }

    [DataContract]
    public class BookType
    {
        [DataMember]
        string Title = "Not provided";

        //TODO: consider extracting this to separate class? 
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
