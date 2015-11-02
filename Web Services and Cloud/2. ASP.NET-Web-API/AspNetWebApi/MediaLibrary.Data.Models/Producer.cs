namespace MediaLibrary.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Producer
    {
        private ICollection<Album> albums;
        private ICollection<Country> countries;

        public Producer()
        {
            this.albums = new HashSet<Album>();
            this.countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }

        public virtual ICollection<Country> Countries
        {
            get
            {
                return this.countries;
            }

            set
            {
                this.countries = value;
            }
        }
    }
}
