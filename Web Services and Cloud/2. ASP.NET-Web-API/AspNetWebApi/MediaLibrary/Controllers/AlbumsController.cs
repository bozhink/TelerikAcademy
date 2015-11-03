namespace MediaLibrary.Controllers
{
    using System.Web.Http.Cors;
    using Data;
    using Data.Models;
    using Models;

    [EnableCors("*", "*", "*")]
    public class AlbumsController : AbstractRestController<Album, AlbumRequestModel, IMediaLibraryDbContext>
    {
        public AlbumsController(IMediaLibraryDbContext db)
            : base(db)
        {
        }
    }
}