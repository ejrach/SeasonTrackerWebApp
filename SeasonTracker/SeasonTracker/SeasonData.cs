using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonTracker
{
    public class SeasonData
    {
        private static readonly Lazy<SeasonData> lazy = new Lazy<SeasonData>(() => new SeasonData());
        public static SeasonData Instance { get { return lazy.Value; } }

        public int ID { get; set; }
        public string ShowName { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeCount { get; set; }
        public string WatchList { get; set; }
        public bool SeasonCompleteState { get; set; }
        public int EpisodesWatched { get; set; }
        //public int SelectedRow { get; set; }

        //public struct WatchListState
        //{
        //    public int TotalEpisodes;
        //    public int EpisodesWatched;
        //    public bool Complete;
        //};

        //WatchListState SeasonWatchState;

        //Class member variables
        private string _seasondataStatus;

        /// <summary>
        /// Constructor for Season Tracker
        /// </summary>
        private SeasonData()
        {
            
        }

        //return COMPLETED, 3/10 Viewed, 

        public event EventHandler<SeasonDataStatusRaisedEventArgs> StatusRaised;

        public void GetStatus()
        {
            ReadStatus();
        }

        private void ReadStatus()
        {
            _seasondataStatus = "From SeasonData Class";

            SeasonDataStatusRaisedEventArgs args = new SeasonDataStatusRaisedEventArgs();
            args.Status = _seasondataStatus;
            OnSeasonDataStatusRaised(args);
        }

        /// <summary>
        /// Initializes the entire watchlist to all "N", (all episodes Not Viewed)
        /// </summary>
        /// <param name="episodeCount">The total number of episodes in the season</param>
        /// <returns></returns>
        public void WatchList_Init(int episodeCount)
        {
            WatchList = "";

            //Initialize for the number of episodes to "N" (i.e. No watched episodes)
            for (int i = 0; i < episodeCount; i++)
            {
                WatchList += "N";
            }
            //return WatchList;
        }

        ///// <summary>
        ///// Sets the "WatchListState" of the season.
        ///// </summary>
        //public void Watchlist_SetSeasonViewState()
        //{
        //    int episodesWatched = 0;
        //    SeasonCompleteState = false;

        //    StringBuilder sb = new StringBuilder(WatchList);

        //    //Find the count of which ones have been watched
        //    foreach (char c in WatchList)
        //    {
        //        if (c == 'Y')
        //            episodesWatched++;
        //    }

        //    if (episodesWatched == EpisodeCount)
        //        SeasonCompleteState = true;
        //}

        /// <summary>
        /// Updates the current complete watchlist from the database for the season of interest, by updating viewstate of the episode passed in.
        /// For example, episode number 3 of a 10 episode season is to be updated from Not Viewed (N) to Viewed (Y)
        /// </summary>
        /// <param name="episodeNum">The episode number to update</param>
        /// <param name="viewState">The viewstate of the episode. Y = Viewed, N = Not Viewed</param>
        /// <returns></returns>
        public void Watchlist_SetSingleEpisodeViewState(int episodeNum, char viewState)
        {
            //TODO: Need to add error handling. Need to make sure episodeNum is not 0
            
            StringBuilder sb = new StringBuilder(WatchList);

            //Update the view state at the character location (zero indexed)
            sb[episodeNum - 1] = viewState;
            WatchList = sb.ToString();
        }

        /// <summary>
        /// Returns view state as Y or N of a single episode number 
        /// </summary>
        /// <param name="episodeNum"></param>
        /// <returns></returns>
        public char Watchlist_GetSingleEpisodeViewState(int episodeNum)
        {
            //TODO: Need to check here that WatchList is not null, otherwise an error will be thrown.
            char viewState;

            StringBuilder sb = new StringBuilder(WatchList);

            //Update the view state at the character location (zero indexed)
            viewState = sb[episodeNum - 1];
          
            return viewState;
        }

        //public void SetSelectedRow(int selectedRow)
        //{
        //    SelectedRow = selectedRow;
        //}

        protected virtual void OnSeasonDataStatusRaised(SeasonDataStatusRaisedEventArgs e)
        {
            EventHandler<SeasonDataStatusRaisedEventArgs> handler = StatusRaised;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }


    public class SeasonDataStatusRaisedEventArgs : EventArgs
    {
        public string Status { get; set; }
    }
}
