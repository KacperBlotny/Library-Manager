using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static CSproject.classes.Category;

namespace CSproject.classes
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        public BookStatus status { get; set; }

        public enum BookStatus
        {
            Dostepna,
            Wypozyczona
        }


        public Book(int id, string title, string category, decimal price, BookStatus status)
        {
            this.id = id;
            this.title = title;
            this.category = category;
            this.price = price;
            this.status = status;

        }

        public static void AddToFile(Book book)
        {
            string filepath = "/Users/kacperblotny/Projects/CSproject/CSproject/test.csv";
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(book.id + "," + book.title + "," + book.category + "," + book.price + "," + book.status);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed! ", ex);
            }
        }

        public static void AddBook()
        {
            string filePath = "/Users/kacperblotny/Projects/CSproject/CSproject/test.csv";
            var lines = File.ReadAllLines(filePath);
            Console.WriteLine("Enter the ID of the book:");
            int id = int.Parse(Console.ReadLine());

            if (lines.Any(line => line.Split(',')[0] == id.ToString()))
            {
                Console.WriteLine("This ID already exists in the file. Please enter a new ID.");
                Book.AddBook();
            }
            else
            {
                Console.WriteLine("Enter the title of the book:");
                string title = Console.ReadLine();

                Console.WriteLine("Enter the category of the book (1-9):");
                string category = Console.ReadLine();

                Console.WriteLine("Enter the price of the book:");
                decimal price = decimal.Parse(Console.ReadLine());

                BookStatus status = BookStatus.Dostepna;

                var newBook = new Book(id, title, category, price, status);
                AddToFile(newBook);
                Console.WriteLine("===================================");
                Console.WriteLine("Book added successfully!");
            }
        }

        public static void RemoveBook()
        {
            DisplayAllBooks();
            Console.WriteLine("\nEnter the ID of the book you want to remove:");
            int id = int.Parse(Console.ReadLine());
            string filePath = "/Users/kacperblotny/Projects/CSproject/CSproject/test.csv";
            var lines = File.ReadAllLines(filePath);
            var newLines = lines.Where(line =>
            {
                var values = line.Split(',');
                return values[0] != id.ToString();
            });
            File.WriteAllLines(filePath, newLines);
            Console.WriteLine("Book removed successfully!");
        }

        public static void DisplayBook(int id)
        {
            string filePath = "/Users/kacperblotny/Projects/CSproject/CSproject/test.csv";
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values[0] == id.ToString())
                {
                    //Console.WriteLine(line);
                    Console.WriteLine(values[0] + " " + values[1] + " " + values[2] + " " + values[3] + " " + values[4]);
                    break;
                }
            }
        }
        public static void DisplayAllBooks()
        {
            string filePath = "/Users/kacperblotny/Projects/CSproject/CSproject/test.csv";
            var lines = File.ReadAllLines(filePath);
            Console.WriteLine("===================================");
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values[4].ToLower() != "wypozyczona")
                {
                    Console.WriteLine(line);
                }

            }
            Console.WriteLine("===================================");
        }
    }
}
