namespace MediaLibrary.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Commons.Data;
    using Data;
    using Data.Models;

    [EnableCors("*", "*", "*")]
    public class CountriesController : ApiController
    {
        private IRepository<Country, IMediaLibraryDbContext> countriesData;

        public CountriesController(IMediaLibraryDbContext db)
        {
            this.countriesData = new EfGenericRepository<Country, IMediaLibraryDbContext>(db);
        }

        // GET: api/Countries
        public IHttpActionResult GetCountries()
        {
            var result = this.countriesData
                .All()
                ////.ProjectTo<CountryRequestModel>()
                .ToList();

            return this.Ok(result);
        }

        // GET: api/Countries/5
        public IHttpActionResult GetCountry(int id)
        {
            var country = this.countriesData.GetById(id);
            if (country == null)
            {
                return this.NotFound();
            }

            return this.Ok(country);
        }

        // PUT: api/Countries/5
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

            this.countriesData.Update(country);
            this.countriesData.SaveChanges();

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Countries
        public IHttpActionResult PostCountry(Country country)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.countriesData.Add(country);
            this.countriesData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = this.countriesData.GetById(id);
            if (country == null)
            {
                return this.NotFound();
            }

            this.countriesData.Delete(country);
            this.countriesData.SaveChanges();

            return this.Ok(country);
        }
    }
}