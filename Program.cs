using System;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using static CSproject.classes.Category;

namespace CSproject.classes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            catalog.LoadBooksFromFile();
            //Book book = new Book(2, "chuj", "aseasea", 12, Book.BookStatus.Dostepna);
            //book.ShowData();
            //Rental rental = new Rental(3, "511290646");

            Console.WriteLine("Welcome to Library Manager!");


            while (true)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. Remove a existing book");
                Console.WriteLine("3. Display a book using ID");
                Console.WriteLine("4. Display books of given category");
                Console.WriteLine("5. Change category");
                Console.WriteLine("6. Borrow a book");
                Console.WriteLine("7. Display book of given category");
                Console.WriteLine("===================================");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Add book
                        Console.WriteLine("===================================");
                        Console.WriteLine("Adding a new book");
                        Book.AddBook();
                        break;
                    case 2:
                        //Remove book
                        Console.WriteLine("===================================");
                        Console.WriteLine("Removing a book");
                        Book.RemoveBook();
                        break;
                    case 3:
                        //Display book
                        Console.WriteLine("===================================");
                        Console.WriteLine("Type ID of the book you want to display");
                        int bookId = int.Parse(Console.ReadLine());
                        Book.DisplayBook(bookId);
                        break;
                    case 4:
                        //Display category
                        Console.WriteLine("===================================");
                        Console.WriteLine("Type the category you want to display: ");
                        string category = Console.ReadLine();

                        catalog.DisplayBooksByCategory(category);
                         break;
                    case 5:
                        //Change category
                        Console.WriteLine("===================================");
                        Book.DisplayAllBooks();
                        Console.WriteLine("Type the ID of book you want to change category: ");
                        int idToChange = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nType the category you want to insert: ");
                        string categoryInsert = Console.ReadLine();

                        Category.ChangeCategory(idToChange, categoryInsert);
                        break;
                    case 6:
                        //Borrow book
                        Rental.BorrowBook();
                        break;

                    case 7:
                        //Display category
                        Console.WriteLine("===================================");
                        Console.WriteLine("Type the category you want to display: "); 
                        Console.WriteLine("Type the category you want to display: ");
                        string categoryDisplay = Console.ReadLine();

                        catalog.DisplayBooksByCategory(categoryDisplay);
                        //Category.DisplayCategory(categoryDisplay);
                        break;
                    case 0:
                        Console.WriteLine("\nExiting...");

                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");

                        break;
                }
            }
            Console.ReadLine();
        }
    }
}



