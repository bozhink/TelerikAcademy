namespace SQLiteBooks
{
    using System.Collections.Generic;

    public interface IOperationsProvider<T>
    {
        void List();

        void Add(T item);

        ICollection<T> Search(string serachString);
    }
}
