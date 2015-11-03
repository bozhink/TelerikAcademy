namespace MediaLibrary.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Data;
    using Data.Models;

    public class ProducersController : ApiController
    {
        private IMediaLibraryDbContext db;

        public ProducersController()
            : this(new MediaLibraryDbContext())
        {
        }

        public ProducersController(IMediaLibraryDbContext db)
        {
            this.db = db;
        }

        // GET: api/Producers
        public IQueryable<Producer> GetProducers()
        {
            return this.db.Producers;
        }

        // GET: api/Producers/5
        [ResponseType(typeof(Producer))]
        public IHttpActionResult GetProducer(int id)
        {
            var producer = this.db.Producers.Find(id);
            if (producer == null)
            {
                return this.NotFound();
            }

            return this.Ok(producer);
        }

        // PUT: api/Producers/5
        [ResponseType(typeof(void))]
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

            this.db.Entry(producer).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ProducerExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Producers
        [ResponseType(typeof(Producer))]
        public IHttpActionResult PostProducer(Producer producer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Producers.Add(producer);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = producer.Id }, producer);
        }

        // DELETE: api/Producers/5
        [ResponseType(typeof(Producer))]
        public IHttpActionResult DeleteProducer(int id)
        {
            var producer = this.db.Producers.Find(id);
            if (producer == null)
            {
                return this.NotFound();
            }

            this.db.Producers.Remove(producer);
            this.db.SaveChanges();

            return this.Ok(producer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool ProducerExists(int id)
        {
            return this.db.Producers.Count(e => e.Id == id) > 0;
        }
    }
}