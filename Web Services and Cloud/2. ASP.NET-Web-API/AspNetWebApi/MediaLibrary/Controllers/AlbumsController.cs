namespace MediaLibrary.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Data;
    using Data.Models;

    public class AlbumsController : ApiController
    {
        private IMediaLibraryDbContext db;

        public AlbumsController(IMediaLibraryDbContext db)
        {
            this.db = db;
        }

        // GET: api/Albums
        public IQueryable<Album> GetAlbums()
        {
            return this.db.Albums;
        }

        // GET: api/Albums/5
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> GetAlbum(int id)
        {
            Album album = await Task.Run(() => this.db.Albums.Find(id));
            if (album == null)
            {
                return this.NotFound();
            }

            return this.Ok(album);
        }

        // PUT: api/Albums/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlbum(int id, Album album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != album.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(album).State = EntityState.Modified;

            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.AlbumExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Albums
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> PostAlbum(Album album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Albums.Add(album);
            await this.db.SaveChangesAsync();

            return this.CreatedAtRoute("DefaultApi", new { id = album.Id }, album);
        }

        // DELETE: api/Albums/5
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> DeleteAlbum(int id)
        {
            Album album = await Task.Run(() => this.db.Albums.Find(id));
            if (album == null)
            {
                return this.NotFound();
            }

            this.db.Albums.Remove(album);
            await this.db.SaveChangesAsync();

            return this.Ok(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return this.db.Albums.Count(e => e.Id == id) > 0;
        }
    }
}