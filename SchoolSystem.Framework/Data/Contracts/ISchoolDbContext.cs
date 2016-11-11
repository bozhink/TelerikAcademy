namespace SchoolSystem.Framework.Data.Contracts
{
    using System.Collections.Generic;
    using SchoolSystem.Framework.Models.Contracts;

    public interface ISchoolDbContext
    {
        IDictionary<int, ITeacher> Teachers { get; }

        IDictionary<int, IStudent> Students { get; }
    }
}
