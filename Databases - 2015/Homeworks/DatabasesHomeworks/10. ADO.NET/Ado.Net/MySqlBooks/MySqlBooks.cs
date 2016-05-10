namespace MySqlBooks
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// 09. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool.
    ///     Create a MySQL database to store Books(title, author, publish date and ISBN).
    ///     Write methods for listing all books, finding a book by name and adding a book.
    /// </summary>
    public class MySqlBooks
    {
        public static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString;

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
                    PublishDate = DateTime.Now,
                    Isbn = "0123456789123"
                };

                operationsProvider.Add(book);

                operationsProvider.List();
            }

            Console.WriteLine("\n\n");
            {
                Console.WriteLine("Search:");

                ICollection<Book> foundBooks = operationsProvider.Search("new");

                foreach (var book in foundBooks)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", book.Title, book.Author, book.PublishDate, book.Isbn);
                }
            }
        }
    }
}
