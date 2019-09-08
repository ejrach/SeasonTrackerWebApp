using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeasonTracker.Models
{
    public class TvShow
    {
        //Look at the Vidly project to see how to not make specific properties nullable.
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int Season { get; set; }
        public int Episodes { get; set; }

    }
}