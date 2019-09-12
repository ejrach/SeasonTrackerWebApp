using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeasonTracker.Models;

namespace SeasonTracker.ViewModels
{
    public class TvShowSelectionViewModel
    {
        public Member Member { get; set; }

        public List<TvShow> TvShows { get; set; }
    }
}