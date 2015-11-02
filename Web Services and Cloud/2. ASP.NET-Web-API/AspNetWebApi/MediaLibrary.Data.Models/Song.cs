namespace MediaLibrary.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        private ICollection<Artist> artists;

        public Song()
        {
            this.artists = new HashSet<Artist>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        public short Year { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
            }
        }
    }
}
