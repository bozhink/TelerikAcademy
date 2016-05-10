namespace MediaLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ArtistRequestModel : IMapFrom<Artist>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public CountryRequestModel Country { get; set; }

        public ICollection<SongRequestModel> Songs { get; set; }

        public ICollection<AlbumRequestModel> Albums { get; set; }
    }
}