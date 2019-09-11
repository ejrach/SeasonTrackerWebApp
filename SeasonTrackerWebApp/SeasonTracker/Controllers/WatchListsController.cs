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

        //Create a constructor for the MembersController that creates the DbContext for this
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
        public ViewResult Index()
        {
            var watchLists = _context.WatchLists.ToList();

            return View(watchLists);
        }

        //Passing id as a parameter, represents the Member Id.
        //In this action we are consolidating the watchlists into a view per user
        public ActionResult Member(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Member member = _context.Members
                .Include(m => m.WatchLists)
                .Where(m => m.Id == id)
                .SingleOrDefault();

            if (member == null)
                return HttpNotFound();

            var viewModel = new WatchListViewModel
            {
                Id = member.Id,
                MemberName = member.MemberName,
                TvShows = member.TvShows.ToList(),
                WatchLists = member.WatchLists.ToList()
            };

            return View(viewModel);
        }

        //Passing id as a parameter, represents the Watchlist Id so the user can edit their Tv Show watchlist
        public ActionResult Edit(int id)
        {
            //First we need to get this watchlist with the watchlist id from the database.
            //If the watchlist with the given id exists it will be returned, otherwise null.
            var watchList = _context.WatchLists.SingleOrDefault(c => c.Id == id);

            if (watchList == null)
                return HttpNotFound();

            //Now we need to render the watch list edit form, which is based on the Model, and specify the 
            //view name.
            var viewModel = new WatchListFormViewModel
            {
                WatchList = watchList,
                TvShow = watchList.TvShow,
                Member = watchList.Member
                //ViewingList = watchList.ViewingList
            };
            return View(viewModel);
        }

        //Define the 'Save' action for the Watchlist. This is model binding. MVC framework binds
        //this model to the request data.
        //Here we are saving/persiting data to the database.
        [HttpPost]
        public ActionResult Save(WatchList watchList)
        {
            
            //Using the Single method here because if the given watchlist is not found, 
            //we want to throw an exception. This action should only be called anyways because of posting
            //the watchlist edit form.
            var watchListInDb = _context.WatchLists.Single(w => w.Id == watchList.Id);

            watchListInDb.ViewingList = watchList.ViewingList;           

            //Persist the changes. This creates SQL statements at runtime, within a transaction.
            _context.SaveChanges();

            //Now redirect the members to the members page "Index"
            return RedirectToAction("Member/" + watchListInDb.MemberId.ToString(), "WatchLists");
        }

    }
}