namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Models;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Material> Materials { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(s => s.Name).IsUnicode(true);

            modelBuilder.Entity<Course>().Property(c => c.Name).IsUnicode(true);
            modelBuilder.Entity<Course>().Property(c => c.Description).IsUnicode(true);

            modelBuilder.Entity<Material>().Property(m => m.Content).IsUnicode(true);
            modelBuilder.Entity<Material>().Property(m => m.Title).IsUnicode(true);

            modelBuilder.Entity<Homework>().Property(h => h.Content).IsUnicode(true);
        }
    }
}
