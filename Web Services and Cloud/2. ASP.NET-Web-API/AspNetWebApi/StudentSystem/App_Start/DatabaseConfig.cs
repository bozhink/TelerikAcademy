namespace StudentSystem
{
    using System.Data.Entity;
    using StudentSystem.Data;
    using Users.Data;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UsersDbContext, Users.Data.Migrations.Configuration>());
            UsersDbContext.Create().Database.Initialize(true);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, StudentSystem.Data.Migrations.Configuration>());
            StudentSystemDbContext.Create().Database.Initialize(true);
        }
    }
}