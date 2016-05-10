namespace MediaLibrary
{
    using System.Data.Entity;
    using MediaLibrary.Data;
    using Users.Data;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UsersDbContext, Users.Data.Migrations.Configuration>());
            UsersDbContext.Create().Database.Initialize(true);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediaLibraryDbContext, MediaLibrary.Data.Migrations.Configuration>());
            MediaLibraryDbContext.Create().Database.Initialize(true);
        }
    }
}