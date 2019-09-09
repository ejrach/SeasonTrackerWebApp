using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeasonTracker.Models;

namespace SeasonTracker.Controllers
{
    public class TvShowsController : Controller
    {
        // GET: TvShows
        // This is what renders the Index page for TvShows
        public ViewResult Index()
        {
            var tvShows = GetTvShows();

            return View(tvShows);
        }

        private IEnumerable<TvShow> GetTvShows()
        {
            return new List<TvShow>
            {
                new TvShow { Id = 1, TvShowName = "Game of Thrones" },
                new TvShow { Id = 2, TvShowName = "Big Bang Theory" }
            };
        }

    }
}