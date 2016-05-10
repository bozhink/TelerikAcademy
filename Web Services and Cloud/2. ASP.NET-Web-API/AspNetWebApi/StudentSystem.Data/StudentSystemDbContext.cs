namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Models;

    public class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        public StudentSystemDbContext()
            : base("StudentDbConnection")
        {
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public static StudentSystemDbContext Create()
        {
            return new StudentSystemDbContext();
        }
    }
}
