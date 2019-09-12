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
        public string TvShowName { get; set; }
        [Required]
        public byte SeasonNumber { get; set; }
        [Required]
        public byte NumberOfEpisodes { get; set; }
    }
}