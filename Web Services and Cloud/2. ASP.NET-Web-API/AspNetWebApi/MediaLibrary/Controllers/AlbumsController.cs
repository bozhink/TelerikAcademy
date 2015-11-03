namespace MediaLibrary.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Commons.Data;
    using Data;
    using Data.Models;

    [EnableCors("*", "*", "*")]
    public class AlbumsController : ApiController
    {
        private IRepository<Album, IMediaLibraryDbContext> albumsData;

        public AlbumsController()
            : this(new MediaLibraryDbContext())
        {
        }

        public AlbumsController(IMediaLibraryDbContext db)
        {
            this.albumsData = new EfGenericRepository<Album, IMediaLibraryDbContext>(db);
        }

        // GET: api/Albums
        public IHttpActionResult GetAlbums()
        {
            var result = this.albumsData
                .All()
                .ToList();

            return this.Ok(result);
        }

        // GET: api/Albums/5
        public IHttpActionResult GetAlbum(int id)
        {
            var album = this.albumsData.GetById(id);
            if (album == null)
            {
                return this.NotFound();
            }

            return this.Ok(album);
        }

        // PUT: api/Albums/5
        public IHttpActionResult PutAlbum(int id, Album album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != album.Id)
            {
                return this.BadRequest();
            }

            this.albumsData.Update(album);
            this.albumsData.SaveChanges();

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Albums
        public IHttpActionResult PostAlbum(Album album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.albumsData.Add(album);
            this.albumsData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = album.Id }, album);
        }

        // DELETE: api/Albums/5
        public IHttpActionResult DeleteAlbum(int id)
        {
            var album = this.albumsData.GetById(id);
            if (album == null)
            {
                return this.NotFound();
            }

            this.albumsData.Delete(album);
            this.albumsData.SaveChanges();

            return this.Ok(album);
        }
    }
}