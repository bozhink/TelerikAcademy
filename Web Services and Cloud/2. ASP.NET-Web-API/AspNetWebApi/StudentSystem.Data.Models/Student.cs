namespace StudentSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.Trainers = new HashSet<Student>();
            this.AdditionalInformation = new StudentInfo();
        }

        [Key]
        public int StudentIdentification { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }

        public virtual Student Assistant { get; set; }

        [InverseProperty("Assistant")]
        public virtual ICollection<Student> Trainers { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public StudentInfo AdditionalInformation { get; set; }

        [NotMapped]
        public bool IsAssistant
        {
            get
            {
                return this.Trainers.Count > 0;
            }
        }
    }
}
