namespace LinqProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Models;

    public class StudentsExtractor
    {
        // Problem 11. Extract students by email
        public IEnumerable<Student> ExtractStudentsByEmail(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.Where(s => Regex.IsMatch(s.Email, @"@abv.bg\Z"))
                .ToList();
        }

        // Problem 12. Extract students by phone
        public IEnumerable<Student> ExtractStudentsByPhone(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.Where(s => Regex.IsMatch(s.Tel.Trim(), @"\A(?:\+?359|0)2"))
                .ToList();
        }

        // Problem 13. Extract students by marks
        public IEnumerable<object> ExtractStudentsByMarks(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.Where(s => s.Marks.Contains(6))
                .Select(s => new
                {
                    FullName = $"{s.FirstName} {s.LastName}",
                    Marks = s.Marks
                })
                .ToList();
        }

        // Problem 14. Extract students with two marks
        public IEnumerable<object> ExtractStudentsWithTwoMarks(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.Where(s => s.Marks.Count == 2)
                .Select(s => new
                {
                    FullName = $"{s.FirstName} {s.LastName}",
                    Marks = s.Marks
                })
                .ToList();
        }

        // Problem 15. Extract marks
        public IEnumerable<decimal> ExtractMarks(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            return students.Where(s => Regex.IsMatch(s.FN, @"(?<!\d)\d{4,4}06"))
                .SelectMany(s => s.Marks)
                .ToList();
        }

        // Problem 16.* Groups
        public IEnumerable<object> ExtractStudentsFromMathematicsDepartment(
            IEnumerable<Student> students,
            IEnumerable<Models.Group> groups)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(groups));
            }

            if (groups == null)
            {
                throw new ArgumentNullException(nameof(groups));
            }

            var result = students.Join(
                groups,
                s => s.GroupNumber,
                g => g.GroupNumber,
                (s, g) => new
                {
                    s.Age,
                    s.Email,
                    s.FirstName,
                    s.FN,
                    s.LastName,
                    s.Marks,
                    s.Tel,
                    g.DepartmentName
                })
                .Where(r => r.DepartmentName == "Mathematics")
                .ToList();

            return result;
        }
    }
}
