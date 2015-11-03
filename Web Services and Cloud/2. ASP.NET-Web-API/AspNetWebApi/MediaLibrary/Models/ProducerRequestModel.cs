namespace MediaLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProducerRequestModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<AlbumRequestModel> Albums { get; set; }

        public virtual ICollection<CountryRequestModel> Countries { get; set; }
    }
}