using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using SeasonTracker.Models;
using SeasonTracker.Dtos;
using AutoMapper;

namespace SeasonTracker.Controllers.Api
{
    public class NewWatchListsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewWatchListsController()
        {
            _context = new ApplicationDbContext();
        }

        // POST /api/newwatchlists
        //This action takes a NewWatchListDto as an input to our application.
        //In this API, we expect to add a list of TvShows a member is looking to track.
        //To comply with RESTFUL conventions, adding the HttpPost
        [HttpPost]
        public IHttpActionResult CreateNewWatchLists(NewWatchListDto newWatchList)
        {
            //First get the member from the context.
            var member = _context.Members
                .Single(m => m.Id == newWatchList.MemberId);

            //Then get the list of Tv Shows from the database that the member wants to track.
            //This loads multiple Tv Shows.
            //This translates to a sql statement like this:
            //      SELECT * 
            //      FROM TvShows
            //      Where Id IN(1, 2, 3, ...)
            var tvShows = _context.TvShows
                .Where(t => newWatchList.TvShowIds.Contains(t.Id)).ToList();

            //Iterate over the tv shows the member wants to add
            foreach(var tvShow in tvShows)
            {
                //Create a new watchlist record
                var watchList = new WatchList
                {
                    Member = member,
                    TvShow = tvShow,
                    ViewingList = "TBD",         //This is where I can initialize the Viewing List  
                };

                //Add it to the database
                _context.WatchLists.Add(watchList);
            }

            //Save changes
            _context.SaveChanges();

            return Ok();
        }
    }
}
