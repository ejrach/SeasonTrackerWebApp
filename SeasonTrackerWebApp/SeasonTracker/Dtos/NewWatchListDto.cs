using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeasonTracker.Dtos
{
    public class NewWatchListDto
    {
        /*
         * 
         * These are the inputs to our WatchList API controller when submitting a list of Tv
         * Shows for the member
         * 
         */
        public int MemberId { get; set; }

        public List<int> TvShowIds { get; set; }


    }
}