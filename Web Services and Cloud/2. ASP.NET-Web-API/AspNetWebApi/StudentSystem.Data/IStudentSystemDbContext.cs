namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Infrastructure;
    using Models;

    public interface IStudentSystemDbContext : IDbContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Student> Students { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<Test> Tests { get; set; }
    }
}
