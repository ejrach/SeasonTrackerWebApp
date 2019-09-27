using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeasonTracker.Models;

namespace SeasonTracker.ViewModels
{
    //In this view model, we are encapsulating all of the data required for 
    //displaying data within the Member WatchList Form View.
    //This ViewModel needs to exist in order to pass a view object within MembersController
    //
    // This view will display, the members' name, the TvShows they are watching and the 
    // corresponding watchlists
    public class WatchListViewModel
    {
        public int MemberId { get; set; }

        //public string MemberName { get; set; }
        //public int MemberId { get; set; }
        //public Member Member { get; set; }

        //Because the view that uses this model will display a list of the TvShows 
        //public List<TvShow> TvShows { get; set; }

        //Because the view that uses this model will display a list of the WatchLists 
        //public List<WatchList> WatchLists { get; set; }
    }
}