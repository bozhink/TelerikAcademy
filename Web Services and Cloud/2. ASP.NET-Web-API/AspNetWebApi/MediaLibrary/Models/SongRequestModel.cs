namespace MediaLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Commons.Data.Mappings;
    using Data.Models;

    public class SongRequestModel : IMapFrom<Song>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        public short Year { get; set; }

        public int GenreId { get; set; }

        public GenreRequestModel Genre { get; set; }

        public AlbumRequestModel Album { get; set; }

        public ICollection<ArtistRequestModel> Artists { get; set; }
    }
}