namespace SchoolSystem.Framework.Data.Contracts.Repositories
{
    public interface ISchoolRepository<T>
    {
        int Add(T entity);

        T GetById(int id);

        bool Remove(int id);
    }
}
