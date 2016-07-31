namespace School
{
    using System.Collections.Generic;

    public class School
    {
        private ICollection<Student> students;
        private ICollection<Course> courses;

        public School()
        {
            this.students = new HashSet<Student>();
            this.courses = new HashSet<Course>();
        }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }
    }
}
