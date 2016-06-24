namespace SchoolClasses.Models
{
    /// <summary>
    /// Disciplines have a name, number of lectures and number of exercises
    /// Students, classes, teachers and disciplines could have optional comments (free text block)
    /// </summary>
    public class Discipline : Commentable
    {
        public string Name { get; set; }

        public uint NumberOfLectures { get; set; }

        public uint NumberOfExercises { get; set; }
    }
}
