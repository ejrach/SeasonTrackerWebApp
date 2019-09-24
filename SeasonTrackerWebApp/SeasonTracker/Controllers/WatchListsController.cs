using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using SeasonTracker.Models;
using SeasonTracker.ViewModels;

/*
 * MVC Controller
 */
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
            return View();
        }

        //Passing id as a parameter, represents the Member Id.
        //In this action we are consolidating the watchlists into a view per individual member
        public ActionResult Member(int id)
        {
            //if (id == null)
            //    return HttpNotFound();

            //For the members' specific episode viewing list, include watchlists from the 
            //WatchLists table where the member Id is equal to the parameter passed to the action.
            //STEP 1) Important for understanding. This returns a list of tv shows, where the member id
            //          field is equal to what's passed to this method.
            //var tvShows = _context.WatchLists
            //    .Where(t => t.Member.Id == id)
            //    .ToList();

            //STEP 2) Important for understanding. By including the TvShow model, we then get the details
            //          of the shows that are included in the query.
            var tvShows = _context.WatchLists
                .Include(t => t.TvShow)
                .Include(t => t.Member)
                .Where(t => t.Member.Id == id)
                //.Single();
                .ToList();


            if (tvShows == null)
                return HttpNotFound();

            var viewModel = new WatchListViewModel
            {
                //TBD - LEFT off here
                Id = id
                //Member = member,
                //TvShows = .TvShows.ToList(),
                //WatchLists = member.WatchLists.ToList()
            };

            return View(viewModel);
        }

        //Passing id as a parameter, represents the Watchlist Id so the user can edit their Tv Show watchlist
        //[HttpPost]
        public ActionResult Edit(int id)
        {
            //First we need to get this specific watchlist with the watchlist id from the database.
            //If the watchlist with the given id exists it will be returned, otherwise null.
            var watchList = _context.WatchLists
                .Include(w => w.Member)
                .Include(w => w.TvShow)
                .SingleOrDefault(c => c.Id == id);




            if (watchList == null)
                return HttpNotFound();

            //Now we need to render the watch list edit form, which is based on the Model, and specify the 
            //view name.
            var viewModel = new WatchListFormViewModel
            {
                WatchList = watchList,
                TvShow = watchList.TvShow,
                Member = watchList.Member
            };
            return View(viewModel);
        }

        //Define the 'Save' action for the Watchlist. This is model binding. MVC framework binds
        //this model to the request data.
        //Here we are saving/persiting data to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(WatchList watchList)
        {
            //Using the Single method here because if the given watchlist is not found, 
            //we want to throw an exception. This action should only be called anyways because of posting
            //the watchlist edit form.
            var watchListInDb = _context.WatchLists
                .Include(w => w.Member)
                .Single(w => w.Id == watchList.Id);

            watchListInDb.ViewingList = watchList.ViewingList;

            //Persist the changes. This creates SQL statements at runtime, within a transaction.
            _context.SaveChanges();

            //Now redirect the members to the members page "Index"
            return RedirectToAction("Member/" + watchListInDb.Member.Id.ToString(), "WatchLists");
        }

        //Passing id as a parameter, represents the member Id so the user can add a new tv 
        //show to their Tv Show watchlist
        public ActionResult Add(int id)
        {
            //First we need to get the Tv Shows and member from the database.
            var tvShows = _context.TvShows.ToList();
            var member = _context.Members.SingleOrDefault(m => m.Id == id);

            if (tvShows == null || member == null)
                return HttpNotFound();

            //Now we need to render the watch list edit form, which is based on the Model, and specify the 
            //view name.
            var viewModel = new TvShowSelectionViewModel
            {
                TvShows = tvShows,
                Member = member
            };
            return View(viewModel);
        }

        //[Route("watchlists/add/{mId}/{tId}")]
        //public ActionResult AddNewWatchList(int mId, int tId)
        //{
        //    //Return the tv show record from the database associated with the Tv Show Id
        //    var tvShow = _context.TvShows.Single(t => t.Id == tId);

        //    //get the number of episodes from the record
        //    string viewingList = InitializeEpisodes(tvShow.NumberOfEpisodes);

        //    //Define a new watchlist record
        //    var watchListInDb = new WatchList
        //    {
        //        MemberId = mId,
        //        TvShowId = tId,
        //        ViewingList = viewingList
        //    };
           
        //    //Add a new watchlist record to the database
        //    _context.WatchLists.Add(watchListInDb);

        //    //Persist the changes. This creates SQL statements at runtime, within a transaction.
        //    _context.SaveChanges();

        //    //Now redirect the members to the members page "Index"
        //    return RedirectToAction("Member/" + mId, "WatchLists");
        //}

        private string InitializeEpisodes(byte numberOfEpisodes)
        {
            return new string('N',numberOfEpisodes);
        }
    }
}