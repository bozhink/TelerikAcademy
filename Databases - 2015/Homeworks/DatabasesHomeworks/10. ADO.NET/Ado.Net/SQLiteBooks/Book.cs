namespace SQLiteBooks
{
    using System;

    public class Book
    {
        public Book()
        {
        }

        public Book(string title, string author, string publishDate, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.PublishDate = publishDate;
            this.Isbn = isbn;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string PublishDate { get; set; }

        public string Isbn { get; set; }
    }
}
