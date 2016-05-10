namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Material
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Content { get; set; }
    }
}
