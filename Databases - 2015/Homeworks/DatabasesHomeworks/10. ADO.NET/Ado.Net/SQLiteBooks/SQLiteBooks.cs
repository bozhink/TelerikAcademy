namespace SQLiteBooks
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 10. Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).
    /// </summary>
    public class SQLiteBooks
    {
        public static void Main()
        {
            string connectionString = @"Data Source=.\Books.sqlite; Version=3";

            var operationsProvider = new BooksOperationsProvider(connectionString, Console.Out);

            {
                Console.WriteLine("List all books.");
                operationsProvider.List();
            }

            Console.WriteLine("\n\n");
            {
                Console.WriteLine("Add a new Book");
                var book = new Book()
                {
                    Title = "New book",
                    Author = "This Author",
                    PublishDate = DateTime.Now.ToLongDateString(),
                    Isbn = "0123456789123"
                };

                operationsProvider.Add(book);

                operationsProvider.List();
            }

            Console.WriteLine("\n\n");
            {
                Console.WriteLine("Search:");

                ICollection<Book> foundBooks = operationsProvider.Search("New");

                foreach (var book in foundBooks)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", book.Title, book.Author, book.PublishDate, book.Isbn);
                }
            }
        }
    }
}
