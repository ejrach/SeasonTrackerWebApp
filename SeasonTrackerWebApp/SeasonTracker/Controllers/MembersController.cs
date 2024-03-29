﻿using System;
using System.Collections.Generic;
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

        /*
         * Method: In use
         */
        //Display the member form with a list of the account types
        public ActionResult New()
        {
            //First get the list of the account types
            var accountTypes = _context.AccountTypes.ToList();

            //Use a View Model that encapsulates all of the data required for this view
            var viewModel = new MemberFormViewModel
            {
                //On a new member, create a member object so the Id gets initialized in the form.
                Member = new Member(),
                //Set the list of accountTypes to the view models' AccountTypes property
                AccountTypes = accountTypes
            };

            return View("MemberForm", viewModel);
        }

        /*
         * Method: In use
         */
        //Define the 'Save' action for Member. This is model binding. MVC framework binds
        //this model to the request data.
        //Here we are saving/persiting data to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Member member)
        {
            //Use modelstate property to get access to validatation data.
            //Since we are requiring the Name property of Member model,
            //we want to return the MemberForm if the field is empty. So need 
            //to define the viewModel and return the form.
            if (!ModelState.IsValid)
            {
                var viewModel = new MemberFormViewModel
                {
                    Member = member,
                    AccountTypes = _context.AccountTypes.ToList()

                };

                return View("MemberForm", viewModel);
            }

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

        /*
         * Method: In use
         */
        // GET: Members
        // This is what renders the "Index" page to display all Members. The Index page calls 
        // /api/members
        public ViewResult Index()
        {
            return View();
        }

        /*
         * Method: In use
         */
        //This is the action that is processed when the "Details" page is rendered.
        public ActionResult Details(int id)
        {
            //When the Index page is loaded, each user is displayed with an ActionLink that processes this "Details" action method.
            var member = _context.Members
                .Include(m => m.AccountType)
                .SingleOrDefault(m => m.Id == id);

            if (member == null)
                return HttpNotFound();

            //A view is rendered for a specific user
            return View(member);
        }

        /*
         * Method: In use
         */
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