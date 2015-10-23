namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int HomeworkId { get; set; }

        [MaxLength(100)]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
