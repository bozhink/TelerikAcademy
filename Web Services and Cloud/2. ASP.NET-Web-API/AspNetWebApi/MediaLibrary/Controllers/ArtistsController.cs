namespace MediaLibrary.Controllers
{
    using System.Web.Http.Cors;
    using Data;
    using Data.Models;
    using Models;

    [EnableCors("*", "*", "*")]
    public class ArtistsController : AbstractRestController<Artist, ArtistRequestModel, IMediaLibraryDbContext>
    {
        public ArtistsController(IMediaLibraryDbContext db)
            : base(db)
        {
        }
    }
}