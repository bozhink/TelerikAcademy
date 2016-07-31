namespace School
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.students = new HashSet<Student>();
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

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (this.Students.Count + 1 >= Constants.MaximalNumberOfStudentsPerCourse)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Students), $"Number of students should be less than {Constants.MaximalNumberOfStudentsPerCourse}.");
            }

            this.Students.Add(student);
        }

        public bool RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var result = this.Students.Remove(student);
            return result;
        }
    }
}
