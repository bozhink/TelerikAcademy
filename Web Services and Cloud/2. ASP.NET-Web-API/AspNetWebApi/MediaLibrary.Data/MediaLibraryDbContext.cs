namespace MediaLibrary.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class MediaLibraryDbContext : DbContext, IMediaLibraryDbContext
    {
        public MediaLibraryDbContext()
            : base("MediaDbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediaLibraryDbContext, Configuration>());
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Producer> Producers { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
