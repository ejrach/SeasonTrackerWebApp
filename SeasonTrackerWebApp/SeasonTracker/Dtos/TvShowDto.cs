using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeasonTracker.Dtos
{
    public class TvShowDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string TvShowName { get; set; }

        [Required]
        [Range(1, 30)]
        public byte SeasonNumber { get; set; }

        [Required]
        [Range(1, 30)]
        public byte NumberOfEpisodes { get; set; }
    }
}