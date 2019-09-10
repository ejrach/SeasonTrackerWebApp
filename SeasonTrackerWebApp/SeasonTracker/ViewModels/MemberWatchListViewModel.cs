using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeasonTracker.Models;

namespace SeasonTracker.ViewModels
{
    public class MemberWatchListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<WatchList> WatchLists { get; set; }
    }
}