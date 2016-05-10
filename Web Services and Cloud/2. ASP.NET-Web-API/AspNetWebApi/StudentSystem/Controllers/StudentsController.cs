namespace StudentSystem.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Data;
    using Data.Models;
    using Infrastructure;

    public class StudentsController : ApiController
    {
        private IRepository<Student, IStudentSystemDbContext> data;

        public StudentsController(IStudentSystemDbContext db)
        {
            this.data = new EfGenericRepository<Student, IStudentSystemDbContext>(db);
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

        public IHttpActionResult Put(int id, Student entry)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                if (id != entry.StudentIdentification)
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

        public IHttpActionResult Post(Student entry)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.data.Add(entry);
            this.data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = entry.StudentIdentification }, entry);
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