using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonTracker
{
    
    public class Record
    {
        //Define the properties by typing "prop" then tab, and fill in the types and names.
        //These properties are publicly acessible.
        //Every Record has a...
        public int ID { get; set; }
        public string Name { get; set; }
        public int EpisodeCount { get; set; }
        public int SeasonNumber { get; set; }

        //These properties are private. They don't need to be accessible to the public.
        //Encapsulation of this data since the implementation and behavior should be hidden.
        private string _watchlist;

        public Record()
        {

        }


    }
}
