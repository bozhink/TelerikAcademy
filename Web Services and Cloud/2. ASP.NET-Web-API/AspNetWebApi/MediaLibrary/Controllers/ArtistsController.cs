namespace MediaLibrary.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Data;
    using Data.Models;

    public class ArtistsController : ApiController
    {
        private IMediaLibraryDbContext db;

        public ArtistsController()
            : this(new MediaLibraryDbContext())
        {
        }

        public ArtistsController(IMediaLibraryDbContext db)
        {
            this.db = db;
        }

        // GET: api/Artists
        public IQueryable<Artist> GetArtists()
        {
            return this.db.Artists;
        }

        // GET: api/Artists/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult GetArtist(int id)
        {
            var artist = this.db.Artists.Find(id);
            if (artist == null)
            {
                return this.NotFound();
            }

            return this.Ok(artist);
        }

        // PUT: api/Artists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != artist.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(artist).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ArtistExists(id))
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

        // POST: api/Artists
        [ResponseType(typeof(Artist))]
        public IHttpActionResult PostArtist(Artist artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Artists.Add(artist);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // DELETE: api/Artists/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            var artist = this.db.Artists.Find(id);
            if (artist == null)
            {
                return this.NotFound();
            }

            this.db.Artists.Remove(artist);
            this.db.SaveChanges();

            return this.Ok(artist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return this.db.Artists.Count(e => e.Id == id) > 0;
        }
    }
}