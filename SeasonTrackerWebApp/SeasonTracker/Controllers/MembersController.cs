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

        //Display the member form with a list of the account types
        public ActionResult New()
        {
            //First get the list of the account types
            var accountTypes = _context.AccountTypes.ToList();

            //Use a View Model that encapsulates all of the data required for this view
            var viewModel = new MemberFormViewModel
            {
                //Set the list of accountTypes to the view models' AccountTypes property
                AccountTypes = accountTypes
            };

            return View("MemberForm", viewModel);
        }

        //Define the 'Save' action for Member. This is model binding. MVC framework binds
        //this model to the request data.
        //Here we are saving/persiting data to the database.
        [HttpPost]
        public ActionResult Save(Member member)
        {
            //if the member Id is 0, then we have a new member
            if (member.Id == 0)
                //To save the data to the database, we need to create a context to it.
                _context.Members.Add(member);
            else
            {
                //Using the Single method here because if the given member is not found, 
                //we want to throw an exception. This action should only be called anyways because of posting
                //the member form.
                var memberInDb = _context.Members.Single(m => m.Id == member.Id);

                memberInDb.MemberName = member.MemberName;
                memberInDb.AccountTypeId = member.AccountTypeId;
                memberInDb.IsSubscribedToNewsLetter = member.IsSubscribedToNewsLetter;
            }

            //Persist the changes. This creates SQL statements at runtime, within a transaction.
            _context.SaveChanges();

            //Now redirect the members to the members page "Index"
            return RedirectToAction("Index", "Members");
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

        public ActionResult ViewingDetails(int? id)
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
                Name = member.MemberName,
                WatchLists = member.WatchLists.ToList()
            };

            return View(viewModel);
        }

        //This displays the MemberForm for editing
        public ActionResult Edit(int id)
        {
            //First we need to get this member with the member id from the database.
            //If the member with the given id exists it will be returned, otherwise null.
            var member = _context.Members.SingleOrDefault(c => c.Id == id);

            if (member == null)
                return HttpNotFound();

            //New we need to render the members edit form, which is based on the View Model, and specify the 
            //view name.
            var viewModel = new MemberFormViewModel
            {
                Member = member,
                AccountTypes = _context.AccountTypes.ToList()
            };
            return View("MemberForm", viewModel);
        }
    }
}