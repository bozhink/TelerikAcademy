namespace MediaLibrary.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Commons.Data;
    using Data;
    using Data.Models;

    public class ProducersController : ApiController
    {
        private IRepository<Producer, IMediaLibraryDbContext> producersData;

        public ProducersController(IMediaLibraryDbContext db)
        {
            this.producersData = new EfGenericRepository<Producer, IMediaLibraryDbContext>(db);
        }

        // GET: api/Producers
        public IHttpActionResult GetProducers()
        {
            var result = this.producersData
                .All()
                .ToList();

            return this.Ok(result);
        }

        // GET: api/Producers/5
        public IHttpActionResult GetProducer(int id)
        {
            var producer = this.producersData.GetById(id);
            if (producer == null)
            {
                return this.NotFound();
            }

            return this.Ok(producer);
        }

        // PUT: api/Producers/5
        public IHttpActionResult PutProducer(int id, Producer producer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != producer.Id)
            {
                return this.BadRequest();
            }

            this.producersData.Update(producer);
            this.producersData.SaveChanges();

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Producers
        public IHttpActionResult PostProducer(Producer producer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.producersData.Add(producer);
            this.producersData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = producer.Id }, producer);
        }

        // DELETE: api/Producers/5
        public IHttpActionResult DeleteProducer(int id)
        {
            var producer = this.producersData.GetById(id);
            if (producer == null)
            {
                return this.NotFound();
            }

            this.producersData.Delete(producer);
            this.producersData.SaveChanges();

            return this.Ok(producer);
        }
    }
}