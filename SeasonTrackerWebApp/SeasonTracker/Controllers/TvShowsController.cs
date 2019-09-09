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
        //In order to query the database, we need to create a database context. 
        private ApplicationDbContext _context;

        //Create a constructor for the TvShowsController that creates the DbContext for this
        //controller.
        public TvShowsController()
        {
            _context = new ApplicationDbContext();
        }

        //The DbContext is a disposable object, se we need to properly dispose of the object.
        //So the proper way to do it is to override the dispose method of the base controller class.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: TvShows
        // This is what renders the Index page for TvShows
        public ViewResult Index()
        {
            //load the TvShows from the DbContext
            var tvShows = _context.TvShows.ToList();

            return View(tvShows);
        }
    }
}