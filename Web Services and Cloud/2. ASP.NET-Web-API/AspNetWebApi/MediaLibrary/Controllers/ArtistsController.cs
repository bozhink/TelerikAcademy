namespace MediaLibrary.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Commons.Data;
    using Data;
    using Data.Models;

    public class ArtistsController : ApiController
    {
        private IRepository<Artist, IMediaLibraryDbContext> artistsData;

        public ArtistsController(IMediaLibraryDbContext db)
        {
            this.artistsData = new EfGenericRepository<Artist, IMediaLibraryDbContext>(db);
        }

        // GET: api/Artists
        public IHttpActionResult GetArtists()
        {
            var result = this.artistsData
                .All()
                .ToList();

            return this.Ok(result);
        }

        // GET: api/Artists/5
        public IHttpActionResult GetArtist(int id)
        {
            var artist = this.artistsData.GetById(id);
            if (artist == null)
            {
                return this.NotFound();
            }

            return this.Ok(artist);
        }

        // PUT: api/Artists/5
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

            this.artistsData.Update(artist);
            this.artistsData.SaveChanges();

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Artists
        public IHttpActionResult PostArtist(Artist artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.artistsData.Add(artist);
            this.artistsData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // DELETE: api/Artists/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            var artist = this.artistsData.GetById(id);
            if (artist == null)
            {
                return this.NotFound();
            }

            this.artistsData.Delete(artist);
            this.artistsData.SaveChanges();

            return this.Ok(artist);
        }
    }
}