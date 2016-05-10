namespace MediaLibrary.Controllers
{
    using System.Web.Http.Cors;
    using Data;
    using Data.Models;
    using Models;

    [EnableCors("*", "*", "*")]
    public class CountriesController : AbstractRestController<Country, CountryRequestModel, IMediaLibraryDbContext>
    {
        public CountriesController(IMediaLibraryDbContext db)
            : base(db)
        {
        }
    }
}