namespace SchoolSystem.Framework.Data.Repositories
{
    using System.Collections.Generic;
    using SchoolSystem.Framework.Data.Contracts;
    using SchoolSystem.Framework.Data.Contracts.Repositories;
    using SchoolSystem.Framework.Data.Repositories.Abstracts;
    using SchoolSystem.Framework.Models.Contracts;

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
