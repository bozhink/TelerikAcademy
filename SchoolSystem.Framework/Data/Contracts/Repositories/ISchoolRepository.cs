namespace SchoolSystem.Framework.Data.Contracts.Repositories
{
    public interface ISchoolRepository<T>
    {
        void Add(T entity);

        T GetById(int id);

        bool Remove(int id);
    }
}
