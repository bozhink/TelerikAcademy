namespace SQLiteBooks
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Data.SQLite;

    public class BooksOperationsProvider : IOperationsProvider<Book>
    {
        private string connectionString;
        private TextWriter logger;

        public BooksOperationsProvider(string connectionString)
            : this(connectionString, Console.Out)
        {
        }

        public BooksOperationsProvider(string connectionString, TextWriter logger)
        {
            this.connectionString = connectionString;
            this.logger = logger;
        }

        public void Add(Book book)
        {
            var connection = new SQLiteConnection(this.connectionString);
            connection.Open();

            using (connection)
            {
                var command = new SQLiteCommand("INSERT INTO books(Title, Author, PublishDate, ISBN) VALUES (@title, @author, @publishDate, @isbn)", connection);

                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@publishDate", book.PublishDate);
                command.Parameters.AddWithValue("@isbn", book.Isbn);

                command.ExecuteNonQuery();
            }
        }

        public void List()
        {
            var connection = new SQLiteConnection(this.connectionString);
            connection.Open();

            using (connection)
            {
                var command = new SQLiteCommand("SELECT Title, Author, PublishDate, ISBN FROM books", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var currentBook = this.DataReaderToBook(reader);

                        this.logger?.WriteLine(
                            "Title: {0}\n\tAuthor: {1}\n\tPublish date: {2}\n\tISBN: {3}\n",
                            currentBook.Title,
                            currentBook.Author,
                            currentBook.PublishDate,
                            currentBook.Isbn);
                    }
                }
            }
        }

        public ICollection<Book> Search(string serachString)
        {
            ICollection<Book> result = new HashSet<Book>();

            var connection = new SQLiteConnection(this.connectionString);
            connection.Open();

            using (connection)
            {
                string pattern = Regex.Replace(serachString, @"(?=[%""&_\\])", @"\");

                var command = new SQLiteCommand("SELECT Title, Author, PublishDate, ISBN FROM books WHERE Title LIKE ('%' || @pattern || '%')", connection);
                command.Parameters.AddWithValue("@pattern", pattern);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var book = this.DataReaderToBook(reader);

                        result.Add(book);
                    }
                }
            }

            return result;
        }

        private Book DataReaderToBook(SQLiteDataReader reader)
        {
            var title = reader.GetString(0);
            var author = reader.GetString(1);
            var date = reader.GetFieldValue<object>(2);
            var isbn = reader.GetFieldValue<object>(3);

            return new Book()
            {
                Title = title,
                Author = author,
                PublishDate = date as string,
                Isbn = isbn as string
            };
        }
    }
}
