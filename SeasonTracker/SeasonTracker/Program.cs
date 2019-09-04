using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeasonTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);




            //TEMP: can be removed. This is just testing the interfaces

            //Set up the connection to the database
            var database = new Database("SeasonTrackerDatabase",
                "SeasonTrackerTable",
                "DESKTOP-9C0DIO8",
                "sa",
                "tucson");

            //Try adding a record
            database.AddRecord("Eric", 34, 34, "");

            //Try deleting a record
            database.DeleteRecord(32);

            //Try updating a record
            database.UpdateRecord(27, "GOT", 34, 34, "HI");
            
            //database.
            //TEMP: can be removed.




            Application.Run(new Home());
        }
    }
}
