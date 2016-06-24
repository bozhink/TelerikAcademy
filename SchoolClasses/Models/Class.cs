namespace SchoolClasses.Models
{
    using System.Collections.Generic;
    using Attribures;

    /// <summary>
    /// Each class has a set of teachers
    /// Students, classes, teachers and disciplines could have optional comments (free text block)
    /// </summary>
    public class Class : Commentable
    {
        public Class()
        {
            this.Teachers = new HashSet<Teacher>();
            this.Students = new HashSet<Student>();
        }

        [Unique]
        public string Id { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
