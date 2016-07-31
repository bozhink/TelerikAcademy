namespace School
{
    using System;
    using Common;

    public class Student
    {
        private int id;
        private string name;

        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (Constants.MaximalStudentIdValue < value || value < Constants.MinimalStudentIdValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Id), $"Id should be between {Constants.MinimalStudentIdValue} and {Constants.MaximalStudentIdValue}.");
                }

                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), "Name of student should not be empty.");
                }

                this.name = value;
            }
        }

        public void JoinToCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            course.RemoveStudent(this);
        }
    }
}
