namespace SchoolClasses.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Each teacher teaches, a set of disciplines
    /// Teachers have a name
    /// Both teachers and students are people
    /// Students, classes, teachers and disciplines could have optional comments (free text block)
    /// </summary>
    public class Teacher : Person
    {
        public Teacher()
        {
            this.Disciplines = new HashSet<Discipline>();
        }

        public ICollection<Discipline> Disciplines { get; set; }
    }
}
