namespace LinqProblems.Models
{
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Marks = new List<decimal>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public uint FN { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public ICollection<decimal> Marks { get; set; }

        public uint GroupNumber { get; set; }

        public uint Age { get; set; }
    }
}
