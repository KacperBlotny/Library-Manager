using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;
using static CSproject.classes.Book;

namespace CSproject.classes
{

    public class Rental
    {
        public int bookId { get; set; }
        public string userId { get; set; }
        public string billType { get; set; }
        public string nip = "";
        public string nazwisko = "";

        public Rental()
        { 
            Console.WriteLine("\nType the ID of book you want to borrow");
            bookId = int.Parse(Console.ReadLine());

            Console.WriteLine("\nType your user ID (phone number)");
            userId = Console.ReadLine();

            string filePath = "/Users/kacperblotny/Projects/CSproject/CSproject/bill.csv";
            var lines = File.ReadAllLines(filePath);
            int id = bookId;

            if (lines.Any(line => line.Split(',')[0] == id.ToString()))
            {
                Console.WriteLine("This book is already borrowed");
                Rental.BorrowBook();
            }
            else
            {
                Rental.ChangeStatus(bookId, 0);
            }

        }

        public static void BorrowBook()
        {
            Book.DisplayAllBooks();
            Console.WriteLine("\nChoose receipt or invoice.");
            string billType = Console.ReadLine();
            if (billType.ToLower() == "receipt")
            {
                var rentalReceipt = new Receipt();
            }
            if (billType.ToLower() == "invoice")
            {
                var rental = new Invoice();
            }
        }


        public static void ChangeStatus(int id, int change)
        {
            string av = "Dostepna";
            string uav = "Wypozyczona";
            string status;

            if(change == 0)
            {
                status = uav;
            } else
            {
                status = av;
            }

            string filePath = "/Users/kacperblotny/Projects/CSproject/CSproject/test.csv";
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                if (values[0].ToLower() == id.ToString())
                {
                    values[4] = status;
                    lines[i] = string.Join(",", values);
                }
            }
            File.WriteAllLines(filePath, lines);
        }
    }


    class Receipt : Rental
    {
        public Receipt()
        {
            Console.WriteLine("Prosze podać naziwsko: ");
            nazwisko = Console.ReadLine();
            Console.WriteLine("Book rented successfully!\n");

            string filepath = "/Users/kacperblotny/Projects/CSproject/CSproject/bill.csv";
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(bookId + "," + userId + "," + "receipt" + ",nazwisko:" + nazwisko);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed! ", ex);
            }
        }
    }

    class Invoice : Rental
    {
        public Invoice()
        {
            Console.WriteLine("Prosze podać NIP: ");
            nip = Console.ReadLine();
            Console.WriteLine("Book rented successfully!\n");

            string filepath = "/Users/kacperblotny/Projects/CSproject/CSproject/bill.csv";
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(bookId + "," + userId + "," + "invoice" + ",nip:" + nip);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed! ", ex);
            }
        }
    }
}
