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

    public class GenresController : ApiController
    {
        private IMediaLibraryDbContext db;

        public GenresController()
            : this(new MediaLibraryDbContext())
        {
        }

        public GenresController(IMediaLibraryDbContext db)
        {
            this.db = db;
        }

        // GET: api/Genres
        public IQueryable<Genre> GetGenres()
        {
            return this.db.Genres;
        }

        // GET: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            var genre = this.db.Genres.Find(id);
            if (genre == null)
            {
                return this.NotFound();
            }

            return this.Ok(genre);
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, Genre genre)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != genre.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(genre).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.GenreExists(id))
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

        // POST: api/Genres
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Genres.Add(genre);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            var genre = this.db.Genres.Find(id);
            if (genre == null)
            {
                return this.NotFound();
            }

            this.db.Genres.Remove(genre);
            this.db.SaveChanges();

            return this.Ok(genre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool GenreExists(int id)
        {
            return this.db.Genres.Count(e => e.Id == id) > 0;
        }
    }
}