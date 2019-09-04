using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonTracker
{
    //The TvShow object is what is going to going to get passed to the Database class
    //TvShow is a Record - inheritance of properties and methods of Record
    public class TvShow : Record
    {
        //TvShow inherits properties and methods of Record, and adds the following...
        public bool TvShowComplete { get; set; }    //defines if the TvShow is completed or not



    }
}
