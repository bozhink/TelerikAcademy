namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LinqProblems.Models;

    public static class StudentsExtensions
    {
        private const int RequiredGroupId = 2;

        // Problem 10. Student groups extensions
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

        // Problem 19. Grouped by GroupName extensions
        public static void GroupByGroupNumberAndPrint(this IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            foreach (var group in students.GroupBy(s => s.GroupNumber))
            {
                Console.WriteLine("Group Number: {0}", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
