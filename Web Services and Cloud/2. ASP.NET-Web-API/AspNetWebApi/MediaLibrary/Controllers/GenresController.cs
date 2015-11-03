namespace MediaLibrary.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Commons.Data;
    using Data;
    using Data.Models;

    public class GenresController : ApiController
    {
        private IRepository<Genre, IMediaLibraryDbContext> genresData;

        public GenresController(IMediaLibraryDbContext db)
        {
            this.genresData = new EfGenericRepository<Genre, IMediaLibraryDbContext>(db);
        }

        // GET: api/Genres
        public IHttpActionResult GetGenres()
        {
            var result = this.genresData
                .All()
                .ToList();

            return this.Ok(result);
        }

        // GET: api/Genres/5
        public IHttpActionResult GetGenre(int id)
        {
            var genre = this.genresData.GetById(id);
            if (genre == null)
            {
                return this.NotFound();
            }

            return this.Ok(genre);
        }

        // PUT: api/Genres/5
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

            this.genresData.Update(genre);
            this.genresData.SaveChanges();

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Genres
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.genresData.Add(genre);
            this.genresData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        public IHttpActionResult DeleteGenre(int id)
        {
            var genre = this.genresData.GetById(id);
            if (genre == null)
            {
                return this.NotFound();
            }

            this.genresData.Delete(genre);
            this.genresData.SaveChanges();

            return this.Ok(genre);
        }
    }
}