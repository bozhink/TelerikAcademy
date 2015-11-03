﻿namespace MediaLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Commons.Data.Mappings;
    using Data.Models;

    public class GenreRequestModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<SongRequestModel> Songs { get; set; }
    }
}