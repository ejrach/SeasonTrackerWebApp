using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using SeasonTracker.Models;
using SeasonTracker.ViewModels;

namespace SeasonTracker.Controllers
{
    public class WatchListsController : Controller
    {
        //In order to query the database, we need to create a database context. 
        private ApplicationDbContext _context;

        //Create a constructor for the WatchListsController that creates the DbContext for this
        //controller.
        public WatchListsController()
        {
            _context = new ApplicationDbContext();
        }

        //The DbContext is a disposable object, se we need to properly dispose of the object.
        //So the proper way to do it is to override the dispose method of the base controller class.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: WatchLists
        // This is what renders the "Index" page for WatchLists
        public ViewResult Index()
        {
            //load the TvShows from the DbContext
            //var watchLists = _context.WatchLists.Include(w => w.Member.MemberName).ToList();
            var watchLists = _context.WatchLists.ToList();

            return View(watchLists);
        }


    }
}