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

    public class CountriesController : ApiController
    {
        private IMediaLibraryDbContext db;

        public CountriesController()
            : this(new MediaLibraryDbContext())
        {
        }

        public CountriesController(IMediaLibraryDbContext db)
        {
            this.db = db;
        }

        // GET: api/Countries
        public IQueryable<Country> GetCountries()
        {
            return this.db.Countries;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCountry(int id)
        {
            var country = this.db.Countries.Find(id);
            if (country == null)
            {
                return this.NotFound();
            }

            return this.Ok(country);
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountry(int id, Country country)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != country.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(country).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CountryExists(id))
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

        // POST: api/Countries
        [ResponseType(typeof(Country))]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Countries.Add(country);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = this.db.Countries.Find(id);
            if (country == null)
            {
                return this.NotFound();
            }

            this.db.Countries.Remove(country);
            this.db.SaveChanges();

            return this.Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool CountryExists(int id)
        {
            return this.db.Countries.Count(e => e.Id == id) > 0;
        }
    }
}