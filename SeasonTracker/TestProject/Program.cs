using System;

namespace SeasonTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Database object.
            //NOTE: the database "SeasonTrackerDatabase" needs to be created manually for now.
            //TODO: Figure out how to create the database programmatically.
            var database = new Database("SeasonTrackerDatabase",
                "SeasonTrackerTable",
                "DESKTOP-9C0DIO8",
                "sa",
                "tucson");

            database.

            //Create TvShow object
            var tvShow = new TvShow();
            
        }
    }
}
