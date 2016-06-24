namespace StudentsAndWorkers.Models
{
    public class Student : Human
    {
        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, decimal grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public decimal Grade { get; set; }

        public override string ToString()
        {
            return base.ToString() + " Grade: " + this.Grade;
        }
    }
}
