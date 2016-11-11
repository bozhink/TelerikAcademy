using SchoolSystem.Framework.Data.Contracts;
using SchoolSystem.Framework.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Framework.Data.Repositories.Abstracts
{
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

        protected ISchoolDbContext DbContext => db;

        protected abstract IDictionary<int, T> Collection { get; }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // TODO: Generate unique id
            int id = this.Collection.Keys.Max() + 1;
            this.Collection.Add(id, entity);
        }

        public virtual T GetById(int id)
        {
            return this.Collection[id];
        }

        public virtual bool Remove(int id)
        {
            return this.Collection.Remove(id);
        }
    }
}
