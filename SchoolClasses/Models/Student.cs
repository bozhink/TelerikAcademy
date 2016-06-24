namespace SchoolClasses.Models
{
    using Attribures;

    /// <summary>
    /// Students have a name and unique class number
    /// Both teachers and students are people
    /// Students, classes, teachers and disciplines could have optional comments (free text block)
    /// </summary>
    public class Student : Person
    {
        [Unique]
        public ulong ClassNumber { get; set; }
    }
}
