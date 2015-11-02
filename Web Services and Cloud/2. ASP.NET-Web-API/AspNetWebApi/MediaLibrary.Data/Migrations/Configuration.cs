namespace MediaLibrary.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<MediaLibraryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "MediaLibrary.Data.MediaLibraryDbContext";
        }

        protected override void Seed(MediaLibraryDbContext context)
        {
        }
    }
}
