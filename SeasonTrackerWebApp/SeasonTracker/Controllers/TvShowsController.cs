using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeasonTracker.Models;
using SeasonTracker.ViewModels;

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

        //This is the action that is processed when the "Details" page is rendered.
        public ActionResult Details(int id)
        {
            //When the Index page is loaded, each user is displayed with an ActionLink that 
            //processes this "Details" action method.
            var tvShows = _context.TvShows.SingleOrDefault(t => t.Id == id);

            if (tvShows == null)
                return HttpNotFound();

            //A view is rendered for a specific user
            return View(tvShows);
        }

        public ViewResult New()
        {
            var viewModel = new TvShowFormViewModel();

            return View("TvShowForm", viewModel);
        }

        //This displays the TvShowForm for editing
        public ActionResult Edit(int id)
        {
            //First we need to get this TvShow with the TvShow id from the database.
            //If the tv show with the given id exists it will be returned, otherwise null.
            var tvShow = _context.TvShows.SingleOrDefault(t => t.Id == id);

            if (tvShow == null)
                return HttpNotFound();

            //New we need to render the tv show edit form, which is based on the View Model, and specify the 
            //view name.
            var viewModel = new TvShowFormViewModel
            {
                TvShow = tvShow,
            };
            return View("TvShowForm", viewModel);
        }

        //Define the 'Save' action for Member. This is model binding. MVC framework binds
        //this model to the request data.
        //Here we are saving/persiting data to the database.
        [HttpPost]
        public ActionResult Save(TvShow tvShow)
        {
            //if the tv show Id is 0, then we have a new tv show
            if (tvShow.Id == 0)
                //To save the data to the database, we need to create a context to it.
                _context.TvShows.Add(tvShow);
            else
            {
                //Using the Single method here because if the given tv show is not found, 
                //we want to throw an exception. This action should only be called anyways because of posting
                //the Tv Show form.
                var tvShowInDb = _context.TvShows.Single(t => t.Id == tvShow.Id);

                tvShowInDb.TvShowName = tvShow.TvShowName;
                tvShowInDb.SeasonNumber = tvShow.SeasonNumber;
                tvShowInDb.NumberOfEpisodes = tvShow.NumberOfEpisodes;
            }

            //Persist the changes. This creates SQL statements at runtime, within a transaction.
            _context.SaveChanges();

            //Now redirect the members to the TV Shows page "Index"
            return RedirectToAction("Index", "TvShows");
        }
    }
}