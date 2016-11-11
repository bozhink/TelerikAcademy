using SchoolSystem.Framework.Data.Contracts;
using SchoolSystem.Framework.Data.Contracts.Repositories;
using SchoolSystem.Framework.Data.Repositories.Abstracts;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Data.Repositories
{
    public class Students : AbstractSchoolRepository<IStudent>, IStudentRepository
    {
        private int currentId = 0;

        public Students(ISchoolDbContext db)
            : base(db)
        {
        }

        protected override IDictionary<int, IStudent> Collection => this.DbContext.Students;

        protected override int NextId() => this.currentId++;
    }
}
