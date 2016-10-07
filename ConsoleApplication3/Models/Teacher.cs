namespace SchoolSystem.Models
{
    using Contracts;
    using Types;

    public class Teacher : Person, ITeacher
    {
        private Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; private set; }

        public void AddMark(IStudent student, float value)
        {
            var mark = new Mark(this.Subject, value);
            student.Marks.Add(mark);
        }
    }
}
