namespace MediaLibrary.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        private ICollection<Artist> artists;
        private ICollection<Producer> producers;

        public Country()
        {
            this.artists = new HashSet<Artist>();
            this.producers = new HashSet<Producer>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

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

        public virtual ICollection<Producer> Producers
        {
            get
            {
                return this.producers;
            }

            set
            {
                this.producers = value;
            }
        }
    }
}
