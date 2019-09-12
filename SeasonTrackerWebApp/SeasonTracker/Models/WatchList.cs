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

        public int MemberId { get; set; }

        public int TvShowId { get; set; }

        [Display(Name = "Episode Viewing List")]
        public string ViewingList { get; set; }

        /*
         * 
         * Model References
         * 
         */

        //Need the Member model defined here as property, since a Members' Id is defined
        //as part of the WatchList model. The Member Id is stored in the WatchList DbSet.
        public virtual Member Member { get; set; }

        //Need the TvShow model defined here as property, since a TvShows' Id is defined
        //as part of the WatchList model. The TvShow Id is stored in the WatchList DbSet.
        public virtual TvShow TvShow { get; set; }
    }
}