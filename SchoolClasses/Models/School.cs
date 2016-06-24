namespace SchoolClasses.Models
{
    using System.Collections.Generic;
    
    /// <summary>
    /// In the school there are classes of students
    /// </summary>
    public class School
    {
        public School()
        {
            this.Classes = new HashSet<Class>();
        }

        public ICollection<Class> Classes { get; set; }
    }
}
