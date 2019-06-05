using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldRun = true;
            PrintMenu();
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

            while (shouldRun)
            {
                Console.WriteLine("Give the option: ");
                string option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        try
                        {
                            int signatureToBorrow = AskForSignature("borrow");

                            SendBorrowRequest(proxy, signatureToBorrow);
                        } catch (FormatException e)
                        {
                            Console.WriteLine("Wrong input - book not borrowed");
                        }
                        break;
                    case "2":
                        try
                        {
                            int signatureToReturn = AskForSignature("return");

                            SendReturnBookRequest(proxy, signatureToReturn);
                        } catch(FormatException e)
                        {
                            Console.WriteLine("Wrong input - book not borrowed");
                        }
                        break;
                    case "3":
                        ServiceReference1.QueryType queryType = QueryTypeFactory((int)SearchingTypeEnum.ByTitle, "title");
                        try
                        {
                            SearchInLibrary(proxy, queryType);
                        } catch(FaultException<ServiceReference1.LibrarySearchingException> e ) {
                            Console.WriteLine(e.Detail.CustomMessage + "\nOperation type:" + e.Detail.OperationType);
                        }
                        break;
                    case "4":
                        ServiceReference1.QueryType queryTypeAuthor = QueryTypeFactory((int)SearchingTypeEnum.ByAuthor, "name/surname");
                        try
                        {
                            SearchInLibrary(proxy, queryTypeAuthor);
                        }
                        catch (FaultException<ServiceReference1.LibrarySearchingException> e)
                        {
                            Console.WriteLine(e.Detail.CustomMessage + "\nOperation type:" + e.Detail.OperationType);
                        }
                        break;
                    case "5":
                        ServiceReference1.QueryType queryTypeSignature = QueryTypeFactory((int)SearchingTypeEnum.BySignature, "signature");
                       try { 
                          SearchInLibrary(proxy, queryTypeSignature);
                       } catch (FaultException<ServiceReference1.LibrarySearchingException> e)
                       {
                            Console.WriteLine(e.Detail.CustomMessage + "\nOperation type:" + e.Detail.OperationType);
                        }
                break;
                    case "6":
                        PrintMenu();
                        break;
                    case "7":
                        string libraryInfoString = proxy.GetLibraryInfo();
                        Console.WriteLine(libraryInfoString);
                        break;
                    case "8":
                        shouldRun = false;
                        break;
                    
                }

                if(!option.Equals("8") && !option.Equals("6"))
                    PrintMenu();
            }
        }

        // helper method asking for book signature
        static int AskForSignature(string action)
        {
            Console.WriteLine("Give the signature of book you waant to " + action +" :");

            return Convert.ToInt32(Console.ReadLine());
        }

        // send the return book request to the service
        static void SendReturnBookRequest(ServiceReference1.Service1Client proxy, int Signature)
        {
            ServiceReference1.BookType ReturnedBook = proxy.ReturnBook(Signature);

            PrintBookTypeInfoToConsole(ReturnedBook, "returned");
        }

        // send the borrow request to the service
        static void SendBorrowRequest(ServiceReference1.Service1Client proxy, int Signature)
        {
            ServiceReference1.BookType BorrowedBook = proxy.BorrowBook(Signature);

            PrintBookTypeInfoToConsole(BorrowedBook, "borrowed");
        }

        // prints the boorowed/returned book information to the console 
        static void PrintBookTypeInfoToConsole(ServiceReference1.BookType Book, string action)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("You " + action + ":");
            Console.WriteLine("Singature: " + Book.Signature + ", title: " + Book.Title);
            Console.WriteLine("--------------------------------");
        }


        // helper method to get query value from the user
        static ServiceReference1.QueryType QueryTypeFactory(int queryTypeNumber, string queryTypeName)
        {
            ServiceReference1.QueryType queryType = new ServiceReference1.QueryType();
            queryType.Type = queryTypeNumber;

            Console.WriteLine("Please enter the " + queryTypeName + ":");
            queryType.Value = Console.ReadLine();

            return queryType;
        }

        // query to service 
        static void SearchInLibrary(ServiceReference1.Service1Client proxy, ServiceReference1.QueryType queryType)
        {
            ServiceReference1.BookType[] receiveBooks = proxy.SearchLibrary(queryType);

            PrintBookList(receiveBooks);
        }

        // prints the reveived books set
        static void PrintBookList(ServiceReference1.BookType[] receiveBooks)
        {
            if(receiveBooks.Count() == 0)
            {
                Console.WriteLine("No books matching given criteria received");
                return;
            }
            Console.WriteLine("Received books:");
            foreach (ServiceReference1.BookType book in receiveBooks)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine(book.Signature + ": " + book.Title);
                Console.WriteLine("Authors:");

                foreach (ServiceReference1.AuthorType author in book.authors)
                    Console.WriteLine("Name: " + author.Name + ", surname: " + author.Surname);

                Console.WriteLine("--------------------------------");
            }
        }
   
        static void PrintMenu()
        {
            Console.WriteLine("------MENU------");
            Console.WriteLine("1 - Borrow the book");
            Console.WriteLine("2 - Return the book");
            Console.WriteLine("3 - Find the book by title");
            Console.WriteLine("4 - Find the book by author");
            Console.WriteLine("5 - Find the book by signature");
            Console.WriteLine("6 - Print the menu");
            Console.WriteLine("7 - Get the library information");
            Console.WriteLine("8 - Exit the client");
            Console.WriteLine("----------------");
        }
    }
}
