namespace LinqProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class AgeRange
    {
        private const uint MinimalAgeInRange = 18;
        private const uint MaximalAgeInRage = 24;

        public IEnumerable<AgeRangeStudentResponseModel> GetStudentsInRange(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.Where(s => (MaximalAgeInRage >= s.Age) && (s.Age >= MinimalAgeInRange))
                .Select(s => new AgeRangeStudentResponseModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                })
                .ToList();
        }
    }
}
