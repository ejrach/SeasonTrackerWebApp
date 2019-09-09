using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using SeasonTracker.Models;

namespace SeasonTracker.Controllers
{
    public class MembersController : Controller
    {
        //In order to query the database, we need to create a database context. 
        private ApplicationDbContext _context;

        //Create a constructor for the MembersController that creates the DbContext for this
        //controller.
        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        //The DbContext is a disposable object, se we need to properly dispose of the object.
        //So the proper way to do it is to override the dispose method of the base controller class.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Members
        // This is what renders the "Index" page for Members
        public ViewResult Index()
        {
            //When the Http request is received, a view is rendered with the Members of the application.
            //The members property is a dbset we defined in our DbContext.
            //A query to the database will immediately occur with the "ToList()" method.
            //The List of members is displayed on the Index page.
            //Index.cshtml provides the c# and the html markup in order to display information to the user.
            //We are using "Include" method here to load the Members along with their account types
            //together (because it comes from another table). This is called "Eager Loading". 
            //"m" is member, and it goes to m.AccountType.
            var members = _context.Members.Include(m => m.AccountType).ToList();

            return View(members);
        }

        //This is the action that is processed when the "Details" page is rendered.
        public ActionResult Details(int id)
        {
            //When the Index page is loaded, each user is displayed with an ActionLink that processes this "Details" action method.
            var member = _context.Members.Include(m => m.AccountType).SingleOrDefault(m => m.Id == id);

            if (member == null)
                return HttpNotFound();

            //A view is rendered for a specific user
            return View(member);
        }
    }
}