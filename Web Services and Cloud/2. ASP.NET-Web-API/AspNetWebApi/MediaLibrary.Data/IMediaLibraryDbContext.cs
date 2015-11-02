namespace MediaLibrary.Data
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Models;
    using System.Data.Entity.Infrastructure;

    public interface IMediaLibraryDbContext : IDisposable
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Genre> Genres { get; set; }

        IDbSet<Producer> Producers { get; set; }

        IDbSet<Song> Songs { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        // TODO
        DbEntityEntry Entry(object entity);

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}