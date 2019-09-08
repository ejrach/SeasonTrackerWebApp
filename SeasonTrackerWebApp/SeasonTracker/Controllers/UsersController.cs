using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeasonTracker.Models;

namespace SeasonTracker.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        // This is what renders the "Index" page for Users
        public ViewResult Index()
        {
            //When the Http request is received, a view is rendered with the Users of the application.
            //GetUsers is called and the a list is displayed on the Index page.
            //Index.cshtml provides the c# and the html markup in order to display information to the user.
            var users = GetUsers();
            return View(users);
        }

        //This is the action that is processed when the "Details" page is rendered.
        public ActionResult Details(int id)
        {
            //When the Index page is loaded, each user is displayed with an ActionLink that processes this "Details" action method.
            var user = GetUsers().SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();

            //A view is rendered for a specific user
            return View(user);
        }

        private IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User { Id = 1, UserName = "Eric Rach" },
                new User { Id = 2, UserName = "Nancy Rach" }
            };
        }
    }
}