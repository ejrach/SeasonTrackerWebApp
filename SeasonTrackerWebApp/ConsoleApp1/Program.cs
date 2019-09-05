using System;
using SeasonTrackerWebApp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Set up the connection to the database.
            //Creates the connection string
            var database = new Database("SeasonTrackerDatabase",
                "SeasonTrackerTable",
                "DESKTOP-9C0DIO8",
                "sa",
                "tucson");

            //Try adding a record
            database.AddRecord("Eric", 34, 34, "");

            //Try deleting a record
            database.DeleteRecord(36);

            //Try updating a record
            database.UpdateRecord(40, "GOT", 34, 34, "");


        }
    }
}
