namespace MediaLibrary.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Commons.Data;
    using Data;
    using Data.Models;

    public class SongsController : ApiController
    {
        private IRepository<Song, IMediaLibraryDbContext> songsData;

        public SongsController(IMediaLibraryDbContext db)
        {
            this.songsData = new EfGenericRepository<Song, IMediaLibraryDbContext>(db);
        }

        // GET: api/Songs
        public IHttpActionResult GetSongs()
        {
            var result = this.songsData
                .All()
                .ToList();

            return this.Ok(result);
        }

        // GET: api/Songs/5
        public IHttpActionResult GetSong(int id)
        {
            var song = this.songsData.GetById(id);
            if (song == null)
            {
                return this.NotFound();
            }

            return this.Ok(song);
        }

        // PUT: api/Songs/5
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

            this.songsData.Update(song);
            this.songsData.SaveChanges();

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Songs
        public IHttpActionResult PostSong(Song song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.songsData.Add(song);
            this.songsData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        public IHttpActionResult DeleteSong(int id)
        {
            var song = this.songsData.GetById(id);
            if (song == null)
            {
                return this.NotFound();
            }

            this.songsData.Delete(song);
            this.songsData.SaveChanges();

            return this.Ok(song);
        }
    }
}