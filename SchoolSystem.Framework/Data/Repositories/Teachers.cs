namespace SchoolSystem.Framework.Data.Repositories
{
    using System.Collections.Generic;
    using SchoolSystem.Framework.Data.Contracts;
    using SchoolSystem.Framework.Data.Contracts.Repositories;
    using SchoolSystem.Framework.Data.Repositories.Abstracts;
    using SchoolSystem.Framework.Models.Contracts;

    public class Teachers : AbstractSchoolRepository<ITeacher>, ITeacherRepository
    {
        private int currentId = 0;

        public Teachers(ISchoolDbContext db)
            : base(db)
        {
        }

        protected override IDictionary<int, ITeacher> Collection => this.DbContext.Teachers;

        protected override int NextId() => this.currentId++;
    }
}
