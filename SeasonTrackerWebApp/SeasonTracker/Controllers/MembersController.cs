using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeasonTracker.Models;

namespace SeasonTracker.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        // This is what renders the "Index" page for Users
        public ViewResult Index()
        {
            //When the Http request is received, a view is rendered with the Users of the application.
            //GetUsers is called and the a list is displayed on the Index page.
            //Index.cshtml provides the c# and the html markup in order to display information to the user.
            var members = GetMembers();
            return View(members);
        }

        //This is the action that is processed when the "Details" page is rendered.
        public ActionResult Details(int id)
        {
            //When the Index page is loaded, each user is displayed with an ActionLink that processes this "Details" action method.
            var member = GetMembers().SingleOrDefault(c => c.Id == id);

            if (member == null)
                return HttpNotFound();

            //A view is rendered for a specific user
            return View(member);
        }

        private IEnumerable<Member> GetMembers()
        {
            return new List<Member>
            {
                new Member { Id = 1, MemberName = "Eric Rach" },
                new Member { Id = 2, MemberName = "Nancy Rach" }
            };
        }
    }
}