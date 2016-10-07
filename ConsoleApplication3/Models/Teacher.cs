namespace SchoolSystem.Models
{
    using System;
    using Contracts;
    using Types;

    public class Teacher : Person, ITeacher
    {
        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; private set; }

        public void AddMark(IStudent student, float value)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var mark = new Mark(this.Subject, value);
            student.Marks.Add(mark);
        }
    }
}
