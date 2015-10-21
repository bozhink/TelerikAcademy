namespace MySqlBooks
{
    using System;

    public class Book
    {
        public Book()
        {
        }

        public Book(string title, string author, DateTime publishDate, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.PublishDate = publishDate;
            this.Isbn = isbn;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Isbn { get; set; }
    }
}
