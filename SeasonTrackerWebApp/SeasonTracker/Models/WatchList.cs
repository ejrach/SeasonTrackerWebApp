using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeasonTracker.Models
{
    public class WatchList
    {
        public int Id { get; set; }

        //public Member Member { get; set; }

        public int MemberId { get; set; }

        //public TvShow TvShow { get; set; }

        public int TvShowId { get; set; }

        public string ViewingList { get; set; }

        public virtual Member Member { get; set; }
    }
}