namespace StudentSystem.ConsoleApp
{
    using Data;
    using Models;
    using Data.Migrations;
    using System;
    using System.Data.Entity;

    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

            using (var db = new StudentSystemDbContext())
            {
                db.Database.CreateIfNotExists();

                var homework = new Homework
                {
                    Content = "Entity Framework Code First",
                    TimeSent = DateTime.Now
                };

                var student = new Student
                {
                    Name = "Pesho",
                    Homeworks = new Homework[] { homework },
                    Number = Guid.NewGuid()
                };

                var course = new Course
                {
                    Name = "Databases",
                    Description = "MSSQL + MySql + EF",
                    Homeworks = student.Homeworks,
                    Materials = new Material[] {
                        new Material
                        {
                            Title = "Some material title"
                        }
                    }
                };

                student.Courses.Add(course);

                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }
}
