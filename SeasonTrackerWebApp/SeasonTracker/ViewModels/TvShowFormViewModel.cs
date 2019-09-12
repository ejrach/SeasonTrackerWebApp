using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeasonTracker.Models;

namespace SeasonTracker.ViewModels
{
    //In this view model, we are encapsulating all of the data required for 
    //displaying data within the Tv Show Form View.
    //This ViewModel needs to exist in order to pass a view object within MembersController
    public class TvShowFormViewModel
    {
        //Let's reuse the TvShow model
        public TvShow TvShow { get; set; }

        //A derived property. Used for Viewbag title
        public string Title
        {
            get
            {
                if (TvShow != null && TvShow.Id != 0)
                    return "Edit Tv Show";
                return "New Tv Show";
            }
        }
    }
}