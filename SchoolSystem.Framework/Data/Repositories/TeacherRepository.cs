using SchoolSystem.Framework.Data.Contracts;
using SchoolSystem.Framework.Data.Contracts.Repositories;
using SchoolSystem.Framework.Data.Repositories.Abstracts;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Data.Repositories
{
    public class TeacherRepository : AbstractSchoolRepository<ITeacher>, ITeacherRepository
    {
        public TeacherRepository(ISchoolDbContext db)
            : base(db)
        {
        }

        protected override IDictionary<int, ITeacher> Collection => this.DbContext.Teachers;
    }
}
