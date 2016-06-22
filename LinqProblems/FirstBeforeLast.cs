namespace LinqProblems
{
    using System;
    using System.Linq;
    using Models;

    public class FirstBeforeLast
    {
        public Student[] GetStudentsWithFirstBeforeLastName(Student[] students)
        {
            if (students == null || students.Length < 1)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.Where(s => string.Compare(s.FirstName, s.LastName, true) < 0)
                .ToArray();
        }
    }
}
