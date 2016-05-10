﻿namespace StudentSystem.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Data;
    using Data.Models;
    using Infrastructure;

    public class HomeworksController : ApiController
    {
        private IRepository<Homework, IStudentSystemDbContext> data;

        public HomeworksController(IStudentSystemDbContext db)
        {
            this.data = new EfGenericRepository<Homework, IStudentSystemDbContext>(db);
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

        public IHttpActionResult Put(int id, Homework entry)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                if (id != entry.Id)
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

        public IHttpActionResult Post(Homework entry)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.data.Add(entry);
            this.data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = entry.Id }, entry);
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