namespace StudentSystem.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Data;
    using Data.Models;
    using Infrastructure;

    public class CoursesController : ApiController
    {
        private IRepository<Course, IStudentSystemDbContext> data;

        public CoursesController(IStudentSystemDbContext db)
        {
            this.data = new EfGenericRepository<Course, IStudentSystemDbContext>(db);
        }

        public IHttpActionResult Get()
        {
            var result = this.data
                .All()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(string id)
        {
            var guid = new Guid(id);
            var entry = this.data.GetById(guid);
            if (entry == null)
            {
                return this.NotFound();
            }

            return this.Ok(entry);
        }

        public IHttpActionResult Put(string id, Course entry)
        {
            var guid = new Guid(id);
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                if (guid != entry.Id)
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

        public IHttpActionResult Post(Course entry)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.data.Add(entry);
            this.data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = entry.Id }, entry);
        }

        public IHttpActionResult Delete(string id)
        {
            var guid = new Guid(id);
            var entry = this.data.GetById(guid);
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