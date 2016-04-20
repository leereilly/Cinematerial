﻿namespace CinematerialDemo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Cinematerial;
    using DataAnnotationsExtensions;

    public class IndexViewModel : IValidatableObject
    {
        public IndexViewModel()
        {
            ImageWidth = 300;
        }

        [Required]
        [Display(Name = "API key")]
        public string ApiKey { get; set; }

        [Required]
        [Display(Name = "API secret")]
        public string ApiSecret { get; set; }

        [Min(1)]
        [Display(Name = "IMDb movie ID")]
        public int? ImdbMovieId { get; set; }

        [RegularExpression(@"https?://.*?imdb.com/title/tt(\d{7})/?.*", ErrorMessage = "Not a valid IMDb movie URL.")]
        [Display(Name = "IMDb movie URL")]
        public string ImdbMovieUrl { get; set; }

        [Range(30, 300)]
        [Display(Name = "Image width")]
        public int ImageWidth { get; set; }

        public CinematerialResult CinematerialResult { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ImdbMovieId == null && string.IsNullOrEmpty(ImdbMovieUrl))
            {
                yield return new ValidationResult("Either an IMDb movie ID or IMDb movie URL must be specified.");    
            }
        }
    }
}