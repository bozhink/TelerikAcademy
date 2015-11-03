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

    public class SongsController : ApiController
    {
        private IMediaLibraryDbContext db;

        public SongsController()
            : this(new MediaLibraryDbContext())
        {
        }

        public SongsController(IMediaLibraryDbContext db)
        {
            this.db = db;
        }

        // GET: api/Songs
        public IQueryable<Song> GetSongs()
        {
            return this.db.Songs;
        }

        // GET: api/Songs/5
        [ResponseType(typeof(Song))]
        public IHttpActionResult GetSong(int id)
        {
            var song = this.db.Songs.Find(id);
            if (song == null)
            {
                return this.NotFound();
            }

            return this.Ok(song);
        }

        // PUT: api/Songs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSong(int id, Song song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != song.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(song).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.SongExists(id))
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

        // POST: api/Songs
        [ResponseType(typeof(Song))]
        public IHttpActionResult PostSong(Song song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Songs.Add(song);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [ResponseType(typeof(Song))]
        public IHttpActionResult DeleteSong(int id)
        {
            var song = this.db.Songs.Find(id);
            if (song == null)
            {
                return this.NotFound();
            }

            this.db.Songs.Remove(song);
            this.db.SaveChanges();

            return this.Ok(song);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool SongExists(int id)
        {
            return this.db.Songs.Count(e => e.Id == id) > 0;
        }
    }
}