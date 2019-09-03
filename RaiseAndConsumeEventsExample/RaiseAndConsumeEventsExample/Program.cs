using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseAndConsumeEventsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 7:
            //Here we are subscribing to the public event defined in the counter class
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReached;       //IMPORTANT: Subscribing to the "ThresholdReached" public event, and what to do with the data in the main program 

            Console.WriteLine("press 'a' key to increase total");
            while(Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }

        }

        //Step 6:
        //Define a function "counter threshold reached" which is subscribed to the event and does something with the data
        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            //Environment.Exit(0);
        }

    }
}
