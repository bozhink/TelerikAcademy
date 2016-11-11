namespace SchoolSystem.Framework.Data
{
    using System.Collections.Generic;
    using SchoolSystem.Framework.Data.Contracts;
    using SchoolSystem.Framework.Models.Contracts;

    public class SchoolDatabase : ISchoolDbContext
    {
        public SchoolDatabase()
        {
            this.Students = new Dictionary<int, IStudent>();
            this.Teachers = new Dictionary<int, ITeacher>();
        }

        public IDictionary<int, IStudent> Students { get; private set; }

        public IDictionary<int, ITeacher> Teachers { get; private set; }
    }
}
