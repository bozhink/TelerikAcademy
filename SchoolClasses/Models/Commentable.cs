namespace SchoolClasses.Models
{
    using Attribures;

    public abstract class Commentable
    {
        [Optional]
        public string Comments { get; set; }
    }
}
