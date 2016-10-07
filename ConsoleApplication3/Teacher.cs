namespace SchoolSystem
{
    using Contracts;
    using Types;

    public class Teacher : ITeacher
    {
        private Teacher(string firstName, string lastName, Subject subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Subject Subject { get; private set; }

        public void AddMark(IStudent student, float value)
        {
            var mark = new Mark(this.Subject, value);
            student.Marks.Add(mark);
        }
    }
}
