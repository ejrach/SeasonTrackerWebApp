using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SeasonTracker.Models;

namespace SeasonTracker.ViewModels
{
    //In this view model, we are encapsulating all of the data required for 
    //displaying data within the Tv Show Form View.
    //This ViewModel needs to exist in order to pass a view object within MembersController
    public class TvShowFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Series Name")]
        public string TvShowName { get; set; }

        [Required]
        [Display(Name = "Season Number")]
        [Range(1, 30)]
        public byte? SeasonNumber { get; set; }

        [Required]
        [Display(Name = "Number of Episodes in Season")]
        [Range(1, 30)]
        public byte? NumberOfEpisodes { get; set; }

        //A derived property. Used for Viewbag title
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Tv Show" : "New Tv Show";
            }
        }

        //When there is a new TvShow
        public TvShowFormViewModel()
        {
            Id = 0;
        }

        //When there is an edit of a TvShow
        public TvShowFormViewModel(TvShow tvShow)
        {
            Id = tvShow.Id;
            TvShowName = tvShow.TvShowName;
            SeasonNumber = tvShow.SeasonNumber;
            NumberOfEpisodes = tvShow.NumberOfEpisodes;
        }
    }
}