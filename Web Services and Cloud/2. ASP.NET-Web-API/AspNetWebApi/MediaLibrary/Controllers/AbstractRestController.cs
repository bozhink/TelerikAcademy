namespace MediaLibrary.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Infrastructure;

    [EnableCors("*", "*", "*")]
    public abstract class AbstractRestController<TDatabaseModel, TRequestModel, TContext> : ApiController
        where TDatabaseModel : class, IDataModel
        where TRequestModel : class
        where TContext : IDbContext
    {
        private IRepository<TDatabaseModel, TContext> data;

        public AbstractRestController(TContext db)
        {
            this.data = new EfGenericRepository<TDatabaseModel, TContext>(db);
        }

        public IHttpActionResult Get()
        {
            var result = this.data
                .All()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var entry = this.data.GetById(id);
            if (entry == null)
            {
                return this.NotFound();
            }

            return this.Ok(entry);
        }

        public IHttpActionResult Put(int id, TDatabaseModel entry)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                if (id != (entry as IDataModel).Id)
                {
                    return this.BadRequest();
                }
            }
            catch
            {
                return this.BadRequest();
            }

            this.data.Update(entry);
            this.data.SaveChanges();

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Post(TDatabaseModel entry)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.data.Add(entry);
            this.data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = (entry as IDataModel).Id }, entry);
        }

        public IHttpActionResult Delete(int id)
        {
            var entry = this.data.GetById(id);
            if (entry == null)
            {
                return this.NotFound();
            }

            this.data.Delete(entry);
            this.data.SaveChanges();

            return this.Ok(entry);
        }
    }
}