using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeasonTracker.Models;

namespace SeasonTracker.ViewModels
{
    /*
     * This View Model used in
     *      Viewing the editing the watch list 
     */
    public class WatchListFormViewModel
    {
        //For this View Model, we simply want access to the Viewing List within WatchList,
        //the member ID from Member, and the TV Show name and Season
        public WatchList WatchList { get; set; }

        //Let's reuse the Member model
        public Member Member { get; set; }
        
        //Let's reuse the TvShow model
        public TvShow TvShow { get; set; }
    }
}