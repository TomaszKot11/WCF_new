using System;
using System.Collections.Generic;
using System.Linq;
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

                        break;
                    case "2":

                        break;
                    case "3":
                        
                        break;
                    case "4":

                        break;
                    case "5":

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
            }
        }

        static void FindByAuthor(ServiceReference1.Service1Client proxy)
        {

        }
        
       

        static void PrintMenu()
        {
            Console.WriteLine("------MENU------");
            Console.WriteLine("1 - Borrow the book");
            Console.WriteLine("2 - Return the book");
            Console.WriteLine("3 - Find the book by title");
            Console.WriteLine("4 - find the book by author");
            Console.WriteLine("5 - find the book by signature");
            Console.WriteLine("6 - print the menu");
            Console.WriteLine("7 - get the library information");
            Console.WriteLine("8 - exit the client");
            Console.WriteLine("----------------");
        }
    }
}
