namespace MediaLibrary.Data
{
    using System.Data.Entity;
    using Commons.Data;
    using Models;

    public interface IMediaLibraryDbContext : IDbContext
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Genre> Genres { get; set; }

        IDbSet<Producer> Producers { get; set; }

        IDbSet<Song> Songs { get; set; }
    }
}