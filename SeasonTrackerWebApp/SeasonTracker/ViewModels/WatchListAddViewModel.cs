using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeasonTracker.Models;

namespace SeasonTracker.ViewModels
{
    public class WatchListAddViewModel
    {
        public Member Member { get; set; }

        public WatchList WatchList { get; set; }

        public TvShow TvShow { get; set; }

        //Because the view that uses this model will display a list of the TvShows in a dropdown
        //public List<TvShow> TvShows { get; set; }
        //List of account types
        public List<TvShow> TvShows { get; set; }
    }
}