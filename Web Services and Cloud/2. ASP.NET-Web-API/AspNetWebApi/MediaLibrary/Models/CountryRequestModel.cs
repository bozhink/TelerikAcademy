namespace MediaLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CountryRequestModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ArtistRequestModel> Artists { get; set; }

        public virtual ICollection<ProducerRequestModel> Producers { get; set; }
    }
}