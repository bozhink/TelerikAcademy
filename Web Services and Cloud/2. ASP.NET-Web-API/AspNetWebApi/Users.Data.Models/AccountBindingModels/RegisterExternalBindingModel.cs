﻿namespace Users.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
