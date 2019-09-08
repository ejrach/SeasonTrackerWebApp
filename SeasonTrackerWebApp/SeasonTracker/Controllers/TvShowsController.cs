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
        // GET: TvShows/Random
        public ActionResult Random()
        {
            var tvShow = new TvShow() { Name = "Game of Thrones" };
            return View(tvShow);
        }
    }
}