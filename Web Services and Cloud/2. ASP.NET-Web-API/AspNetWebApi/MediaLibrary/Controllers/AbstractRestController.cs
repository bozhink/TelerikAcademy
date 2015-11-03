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

        // GET: api/Albums
        public IHttpActionResult GetAlbums()
        {
            var result = this.data
                .All()
                .ToList();

            return this.Ok(result);
        }

        // GET: api/Albums/5
        public IHttpActionResult GetAlbum(int id)
        {
            var album = this.data.GetById(id);
            if (album == null)
            {
                return this.NotFound();
            }

            return this.Ok(album);
        }

        // PUT: api/Albums/5
        public IHttpActionResult PutAlbum(int id, TDatabaseModel entry)
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

        // POST: api/Albums
        public IHttpActionResult PostAlbum(TDatabaseModel entry)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.data.Add(entry);
            this.data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = (entry as IDataModel).Id }, entry);
        }

        // DELETE: api/Albums/5
        public IHttpActionResult DeleteAlbum(int id)
        {
            var album = this.data.GetById(id);
            if (album == null)
            {
                return this.NotFound();
            }

            this.data.Delete(album);
            this.data.SaveChanges();

            return this.Ok(album);
        }
    }
}