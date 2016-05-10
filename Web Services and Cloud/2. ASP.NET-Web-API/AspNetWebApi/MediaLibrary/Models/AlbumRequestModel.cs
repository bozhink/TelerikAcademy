namespace MediaLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mappings;

    public class AlbumRequestModel : IMapFrom<Album>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Title { get; set; }

        public short Year { get; set; }

        public ProducerRequestModel Producer { get; set; }

        public ICollection<SongRequestModel> Songs { get; set; }

        public ICollection<ArtistRequestModel> Artists { get; set; }
    }
}