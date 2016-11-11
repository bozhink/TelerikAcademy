using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Data.Contracts
{
    public interface ISchoolDbContext
    {
        IDictionary<int, ITeacher> Teachers { get; }

        IDictionary<int, IStudent> Students { get; }
    }
}
