using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeasonTracker.Dtos
{
    public class TvShowDto
    {
        //There is no need to include all of the other properties in the domain model
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