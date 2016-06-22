namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LinqProblems.Models;

    public static class StudentGroupsExtensions
    {
        private const int RequiredGroupId = 2;

        public static IEnumerable<Student> GetStudentsInGroup(this IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.Where(s => s.GroupNumber == RequiredGroupId)
                .OrderBy(s => s.FirstName)
                .ToList();
        }
    }
}
