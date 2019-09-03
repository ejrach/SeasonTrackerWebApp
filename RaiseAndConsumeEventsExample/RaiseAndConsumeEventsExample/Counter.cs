using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseAndConsumeEventsExample
{
    class Counter
    {
        //Step 2:
        //Define the event handler in the class which will raise the event.
        //This will define the name of the event handler, which is "ThresholdReached"
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        private int threshold;
        private int total;

        //Step 4:
        //Defines the constructor
        //In this constructor, user is setting what the threshold will initially be set to
        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        //Step 5:
        //Define the adding function
        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                //If the threshold is reached, then raise the event and set the arguments
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;             // Set/Get in the class below
                args.TimeReached = DateTime.Now;        // Set/Get in the class below
                OnThresholdReached(args);
            }
        }

        //Step 3:
        //Define what happens with the event once the threshold reached
        protected virtual void OnThresholdReached (ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);       
            }
        }
    }
     

    //Step 1: 
    //Defines an event with data to be returned to the consumer, inheriting "EventArgs"
    //In this, define the data to be set or get
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
