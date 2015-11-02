namespace Commons.Data
{
    using System;
    using System.Linq;

    public interface IRepository<T, IContext> : IDisposable
        where T : class
        where IContext : IDbContext
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        T Attach(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
