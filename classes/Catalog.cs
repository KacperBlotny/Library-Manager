using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static CSproject.classes.Book;

namespace CSproject.classes
{
    class Catalog
    {
        public List<Book> FictionBooks { get; set; }
        public List<Book> ScienceBooks { get; set; }
        public List<Book> FantasyBooks { get; set; }
        public List<Book> RomanceBooks { get; set; }
        public List<Book> NonFictionBooks { get; set; }
        public List<Book> OtherBooks { get; set; }

        public Catalog()
        {
            FictionBooks = new List<Book>();
            ScienceBooks = new List<Book>();
            FantasyBooks = new List<Book>();
            RomanceBooks = new List<Book>();
            NonFictionBooks = new List<Book>();
            OtherBooks = new List<Book>();
        }

        public void LoadBooksFromFile()
        {
            Console.WriteLine("elo");
            string filePath = "/Users/kacperblotny/Projects/CSproject/CSproject/test.csv";

            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var id = Convert.ToInt32(values[0]);
                var title = values[1];
                var category = values[2];
                var price = Convert.ToDecimal(values[3]);
                var status = (BookStatus)Enum.Parse(typeof(BookStatus), values[4]);

                var book = new Book(id, title, category.ToLower(), price, status);

                switch (category)
                {
                    case "fiction":
                        FictionBooks.Add(book);
                        break;
                    case "science":
                        ScienceBooks.Add(book);
                        break;
                    case "fantasy":
                        FantasyBooks.Add(book);
                        break;
                    case "romance":
                        RomanceBooks.Add(book);
                        break;
                    case "non-Fiction":
                        NonFictionBooks.Add(book);
                        break;
                    default:
                        OtherBooks.Add(book);
                        break;
                }
            }
        }

        public void DisplayBooksByCategory(string category)
        {
            switch (category)
            {
                case "fiction":
                    foreach (var book in FictionBooks)
                    {
                        Console.WriteLine(book.id + " " + book.title + " " + book.category + " " + book.price + " " + book.status);
                    }
                    break;
                case "science":
                    foreach (var book in ScienceBooks)
                    {
                        Console.WriteLine(book.id + " " + book.title + " " + book.category + " " + book.price + " " + book.status);
                    }
                    break;
                case "fantasy":
                    foreach (var book in FantasyBooks)
                    {
                        Console.WriteLine(book.id + " " + book.title + " " + book.category + " " + book.price + " " + book.status);
                    }
                    break;
                case "romance":
                    foreach (var book in RomanceBooks)
                    {
                        Console.WriteLine(book.id + " " + book.title + " " + book.category + " " + book.price + " " + book.status);
                    }
                    break;
                case "non-Fiction":
                    foreach (var book in NonFictionBooks)
                    {
                        Console.WriteLine(book.id + " " + book.title + " " + book.category + " " + book.price + " " + book.status);
                    }
                    break;
                case "other":
                    foreach (var book in OtherBooks)
                    {
                        Console.WriteLine(book.id + " " + book.title + " " + book.category + " " + book.price + " " + book.status);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid category");
                    break;
            }
        }
    }
}