namespace StudentSystem.Data
{
    using Infrastructure;
    using Models;
    using Repositories;

    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }

        StudentsRepository Students { get; }
    }
}
