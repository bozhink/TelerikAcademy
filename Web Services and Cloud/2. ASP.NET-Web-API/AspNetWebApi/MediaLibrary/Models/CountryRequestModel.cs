namespace MediaLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Commons.Data.Mappings;
    using Data.Models;

    public class CountryRequestModel : IMapFrom<Country>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<ArtistRequestModel> Artists { get; set; }
    }
}