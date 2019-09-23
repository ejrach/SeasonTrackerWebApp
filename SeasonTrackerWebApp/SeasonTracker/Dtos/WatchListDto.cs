using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeasonTracker.Dtos
{
    public class WatchListDto
    {
        public int Id { get; set; }
        ////There is no need to include all of the other properties in the domain model
        //public int MemberId { get; set; }

        //public int TvShowId { get; set; }

        //public List<int> TvShowIds { get; set; }
        public MemberDto Member { get; set; }

        public TvShowDto TvShow { get; set; }

        public string ViewingList { get; set; }

        /*
         * 
         * Model References
         * 
         */
        //Need the Member model defined here as property, since a Members' Id is defined
        //as part of the WatchList model. The Member Id is stored in the WatchList DbSet.
        //public virtual MemberDto MemberDto { get; set; }

        ////Need the TvShow model defined here as property, since a TvShows' Id is defined
        ////as part of the WatchList model. The TvShow Id is stored in the WatchList DbSet.
        //public virtual TvShowDto TvShowDto { get; set; }
    }
}