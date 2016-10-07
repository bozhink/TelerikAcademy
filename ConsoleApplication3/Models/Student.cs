namespace SchoolSystem.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Core;
    using Types;

    public class Student : Person, IStudent
    {
        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new Collection<IMark>();
        }

        public Grade Grade { get; private set; }

        public ICollection<IMark> Marks { get; private set; }

        public string ListMarks()
        {
            var marks = this.Marks
                .Select(m => $"{m.Subject} => {m.Value}")
                .ToList();

            return string.Join("\n", marks);
        }
    }
}
