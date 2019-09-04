//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


/*
 * 
 * 
 * IMPORTANT NOTE:
 *      Do not delete this file. It shows that, if I uncomment the code (regarding _readThread and _keepReading), 
 *      then this code puts the "ReadData" function on a thread (and the events still work). If I keep that code 
 *      commented out, I can still raise events and have that be raised to the form.
 * 
 * 
 */



//namespace SeasonTracker
//{
//    class _DONOTDELETE
//    {
//        private static readonly Lazy<SeasonTracker> lazy = new Lazy<SeasonTracker>(() => new SeasonTracker());
//        public static SeasonTracker Instance { get { return lazy.Value; } }

//        //private Thread _readThread;
//        //private volatile bool _keepReading;
//        private string _data;

//        //Create the Database
//        private Database db;


//        /// <summary>
//        /// Constructor for Season Tracker
//        /// </summary>
//        private SeasonTracker()
//        {
//            db = new Database();

//            //_readThread = null;
//            //_keepReading = false;
//        }

//        public event EventHandler<StatusRaisedEventArgs> StatusRaised;

//        public void Start()
//        {
//            StartReading();
//        }

//        private void StartReading()
//        {
//            //if (!_keepReading)
//            //{
//            //_keepReading = true;
//            //_readThread = new Thread(ReadData);
//            //_readThread.Start();
//            //}

//            //test
//            ReadData();
//        }

//        private void ReadData()
//        {
//            _data = db.ConnectionString;

//            StatusRaisedEventArgs args = new StatusRaisedEventArgs();
//            args.Status = _data;
//            OnStatusRaised(args);

//            //_keepReading = false;

//            //_readThread.Join();
//            //_readThread = null;
//        }


//        protected virtual void OnStatusRaised(StatusRaisedEventArgs e)
//        {
//            EventHandler<StatusRaisedEventArgs> handler = StatusRaised;
//            if (handler != null)
//            {
//                handler(this, e);
//            }
//        }
//    }
//    public class StatusRaisedEventArgs : EventArgs
//    {
//        public string Status { get; set; }
//    }
//}
