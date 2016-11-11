namespace SchoolSystem.Framework.Data.Repositories.Abstracts
{
    using System;
    using System.Collections.Generic;
    using SchoolSystem.Framework.Data.Contracts;
    using SchoolSystem.Framework.Data.Contracts.Repositories;

    public abstract class AbstractSchoolRepository<T> : ISchoolRepository<T>
    {
        private readonly ISchoolDbContext db;

        public AbstractSchoolRepository(ISchoolDbContext db)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }

            this.db = db;
        }

        protected abstract IDictionary<int, T> Collection { get; }

        protected ISchoolDbContext DbContext => this.db;

        public virtual int Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            int id = this.NextId();
            this.Collection.Add(id, entity);

            return id;
        }

        public virtual T GetById(int id)
        {
            return this.Collection[id];
        }

        public virtual bool Remove(int id)
        {
            return this.Collection.Remove(id);
        }

        protected abstract int NextId();
    }
}
