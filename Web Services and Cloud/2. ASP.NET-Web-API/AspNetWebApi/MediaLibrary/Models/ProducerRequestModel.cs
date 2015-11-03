namespace MediaLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Commons.Data.Mappings;
    using Data.Models;

    public class ProducerRequestModel : IMapFrom<Producer>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<AlbumRequestModel> Albums { get; set; }
    }
}