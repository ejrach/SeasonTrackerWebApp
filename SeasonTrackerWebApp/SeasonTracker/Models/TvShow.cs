using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeasonTracker.Models
{
    public class TvShow
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Series Name")]
        public string TvShowName { get; set; }

        [Required]
        [Display(Name = "Season Number")]
        [Range(1, 30)]
        public byte SeasonNumber { get; set; }

        [Required]
        [Display(Name = "Number of Episodes in Season")]
        [Range(1, 30)]
        public byte NumberOfEpisodes { get; set; }
    }
}