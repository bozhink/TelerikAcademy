namespace SchoolSystem.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Types;

    public class Student : IStudent
    {
        public Student(string firstName, string lastName, Grade grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public string FirstName { get; private set; }

        public Grade Grade { get; private set; }

        public ICollection<IMark> Marks { get; private set; }

        public string LastName { get; private set; }

        public string ListMarks()
        {
            var marks = this.Marks
                .Select(m => $"{m.Subject} => {m.Value}")
                .ToList();

            return string.Join("\n", marks);
        }
    }
}
