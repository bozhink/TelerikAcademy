namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using RandomGenerator;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            const int NumberOfItems = 100;

            var random = RandomGenerator.Instance;

            var homeworks = new int[NumberOfItems]
                .Select(i => new Homework
                {
                    Content = random.GetRandomString(100),
                    TimeSent = DateTime.Now.AddDays(-random.GetRandomNumber(0, 12))
                })
                .ToList();

            var materials = new int[NumberOfItems]
                .Select(i => new Material
                {
                    Title = random.GetRandomString(30),
                    Content = random.GetRandomString(300)
                })
                .ToList();

            var students = new int[NumberOfItems]
                .Select(i =>
                {
                    int skip = random.GetRandomNumber(0, NumberOfItems - 2);
                    int take = random.GetRandomNumber(1, NumberOfItems - skip - 1);

                    return new Student
                    {
                        Name = random.GetRandomString(100),
                        Number = Guid.NewGuid(),
                        Homeworks = homeworks
                            .Skip(skip)
                            .Take(take)
                            .ToList()
                    };

                })
                .ToList();

            var courses = new int[NumberOfItems]
                .Select(i =>
                {
                    int skip = random.GetRandomNumber(0, NumberOfItems - 2);
                    int take = random.GetRandomNumber(1, NumberOfItems - skip - 1);

                    return new Course
                    {
                        Name = random.GetRandomString(50),
                        Description = random.GetRandomString(200),
                        Homeworks = homeworks
                            .Skip(skip)
                            .Take(take)
                            .ToList(),
                        Materials = materials
                            .Skip(skip)
                            .Take(take)
                            .ToList()
                    };

                })
                .ToList();

            courses.ForEach(c =>
            {
                int skip = random.GetRandomNumber(0, NumberOfItems - 2);
                int take = random.GetRandomNumber(1, NumberOfItems - skip - 1);

                c.Students = students
                    .Skip(skip)
                    .Take(take)
                    .ToList();
            });

            students.ForEach(s => context.Students.AddOrUpdate(s));
            courses.ForEach(c => context.Courses.AddOrUpdate(c));

            context.SaveChanges();
        }
    }
}
