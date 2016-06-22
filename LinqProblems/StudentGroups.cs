namespace LinqProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class StudentGroups
    {
        private const int RequiredGroupId = 2;

        public IEnumerable<Student> GetStudentsInGroup(IEnumerable<Student> students)
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
