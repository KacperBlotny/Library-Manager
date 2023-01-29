//using System;

//namespace CSproject.classes
//{
//	public class App
//	{
//        public static void Main(string[] args)
//        {
//            Console.WriteLine("elo");

//            //Book book = new Book(2, "chuj", "aseasea", 12, Book.BookStatus.Dostepna);
//            //book.ShowData();
//            //Rental rental = new Rental(3, "511290646");

//            Console.WriteLine("Welcome to Library Manager!");

//            Console.WriteLine("0. Exit");
//            Console.WriteLine("1. Add a new book");
//            Console.WriteLine("2. Remove a existing book");
//            Console.WriteLine("3. Display a book using ID");
//            Console.WriteLine("4. Display books of given category");
//            Console.WriteLine("5. Change category");
//            Console.WriteLine("6. Borrow a book");
//            Console.WriteLine("7. Display book of given category");

//            while (true)
//            {
//                int choice = int.Parse(Console.ReadLine());
//                //Category.LoadBooksFromCsv();

//                switch (choice)
//                {
//                    case 1:
//                        //Add book
//                        Console.WriteLine("\nAdding a new book");
//                        Book.AddBook();
//                        break;
//                    case 2:
//                        //Remove book
//                        Console.WriteLine("\nRemoving a book");
//                        Book.RemoveBook();
//                        break;
//                    case 3:
//                        //Display book
//                        Console.WriteLine("\nType ID of the book you want to display");
//                        int bookId = int.Parse(Console.ReadLine());
//                        Book.DisplayBook(bookId);
//                        break;
//                    case 4:
//                        //Display category
//                        Console.WriteLine("\nType the category you want to display: ");
//                        string category = Console.ReadLine();
//                        Category.DisplayCategory(category);
//                        break;
//                    case 5:
//                        //Change category
//                        Console.WriteLine("\nType the ID of book you want to change category: ");
//                        int idToChange = int.Parse(Console.ReadLine());
//                        Console.WriteLine("\nType the category you want to insert: ");
//                        string categoryInsert = Console.ReadLine();
//                        Category.ChangeCategory(idToChange, categoryInsert);

//                        break;
//                    case 6:
//                        //Borrow book
//                        Rental.BorrowBook();
//                        break;

//                    case 7:
//                        //Display category
//                        Console.WriteLine("\nType the category you want to display: ");
//                        string categoryDisplay = Console.ReadLine();
//                        //Category.DisplayBooksByCategory(categoryDisplay);
//                        Category.DisplayCategory(categoryDisplay);
//                        break;
//                    case 0:
//                        Console.WriteLine("\nExiting...");
//                        return;
//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }
//            }

//        }
//    }
//}

