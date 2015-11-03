namespace MediaLibrary.Controllers
{
    using System.Web.Http.Cors;
    using Data;
    using Data.Models;
    using Models;

    [EnableCors("*", "*", "*")]
    public class SongsController : AbstractRestController<Song, SongRequestModel, IMediaLibraryDbContext>
    {
        public SongsController(IMediaLibraryDbContext db)
            : base(db)
        {
        }
    }
}