namespace MediaLibrary.Controllers
{
    using System.Web.Http.Cors;
    using Data;
    using Data.Models;
    using Models;

    [EnableCors("*", "*", "*")]
    public class GenresController : AbstractRestController<Genre, GenreRequestModel, IMediaLibraryDbContext>
    {
        public GenresController(IMediaLibraryDbContext db)
            : base(db)
        {
        }
    }
}