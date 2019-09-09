using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeasonTracker.Controllers
{
    public class WatchListsController : Controller
    {
        // GET: WatchLists
        public ActionResult Index()
        {
            return View();
        }
    }
}