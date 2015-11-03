namespace MediaLibrary.Controllers
{
    using System.Web.Http.Cors;
    using Data;
    using Data.Models;
    using Models;

    [EnableCors("*", "*", "*")]
    public class ProducersController : AbstractRestController<Producer, ProducerRequestModel, IMediaLibraryDbContext>
    {
        public ProducersController(IMediaLibraryDbContext db)
            : base(db)
        {
        }
    }
}