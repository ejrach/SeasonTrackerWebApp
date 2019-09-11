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

        //Passing id as a parameter, represents the Member Id
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

            var viewModel = new MemberWatchListViewModel
            {
                Id = member.Id,
                MemberName = member.MemberName,
                TvShows = member.TvShows.ToList(),
                WatchLists = member.WatchLists.ToList()
            };

            return View(viewModel);
        }
    }
}