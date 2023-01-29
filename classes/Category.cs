using System.Collections.Generic;
using System.Linq;
using System.IO;
using static CSproject.classes.Book;
using System.Diagnostics;
using System.Net.NetworkInformation;
using static System.Reflection.Metadata.BlobBuilder;

namespace CSproject.classes
{
	public class Category
    {
        public static void ChangeCategory(int id, string category)
        {
            string filePath = "/Users/kacperblotny/Projects/CSproject/CSproject/test.csv";
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                if (values[0].ToLower() == id.ToString())
                {
                    values[2] = category;
                    lines[i] = string.Join(",", values);
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Book category changed successfully!");
        }
    }
}
