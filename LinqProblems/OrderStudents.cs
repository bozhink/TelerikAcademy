namespace LinqProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class OrderStudents
    {
        public IEnumerable<Student> OrderStudentsByFirstThenByLastName(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.OrderBy(s => s.FirstName)
                .ThenByDescending(s => s.LastName);
        }
    }
}
