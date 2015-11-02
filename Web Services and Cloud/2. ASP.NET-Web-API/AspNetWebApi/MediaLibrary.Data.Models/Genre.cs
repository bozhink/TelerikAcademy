namespace MediaLibrary.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Genre
    {
        private ICollection<Song> songs;

        public Genre()
        {
            this.songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
            }
        }
    }
}
